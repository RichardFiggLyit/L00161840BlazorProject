using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using L00161840BlazorProject.Server;
using L00161840BlazorProject.Shared.Entities;
using L00161840BlazorProject.Shared.DTOs;
using L00161840BlazorProject.Server.Helpers;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace L00161840BlazorProject.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public class InvitesController : ControllerBase
    {

        private readonly ApplicationDbContext context;

        public InvitesController(ApplicationDbContext context)
        {
            this.context = context;

        }


        [AllowAnonymous]
        [HttpGet("{inviteReference}")]
        public async Task<ActionResult<Invite>> Get(string inviteReference)
        {
            var invite = await context.Invites.FirstOrDefaultAsync(x => x.InviteReference == inviteReference && !x.IsAccepted);
            if (invite == null) { return NotFound(); }
            return invite;
        }


        [HttpPost]
        public async Task<ActionResult<Invite>> Post(Invite invite)
        {
            invite.InviteReference = CreateInviteReference();
            context.Add(invite);
            await context.SaveChangesAsync();
            return invite;
        }

        internal static readonly char[] chars =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
        public string CreateInviteReference()
        {
            int size = 64;
            byte[] data = new byte[4 * size];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            for (int i = 0; i < size; i++)
            {
                var rnd = BitConverter.ToUInt32(data, i * 4);
                var idx = rnd % chars.Length;

                result.Append(chars[idx]);
            }

            return result.ToString();
        }
        [HttpPut]
        public async Task<ActionResult> Put(Invite invite)
        {
            var CompanyDB = await context.Invites.AsNoTracking().FirstOrDefaultAsync(x => x.Id == invite.Id);

            if (CompanyDB == null) { return NotFound(); }

            context.Attach(invite).State = EntityState.Modified;

            await context.SaveChangesAsync();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Company = await context.Companies.FirstOrDefaultAsync(x => x.Id == id);
            if (Company == null)
            {
                return NotFound();
            }

            context.Remove(Company);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
