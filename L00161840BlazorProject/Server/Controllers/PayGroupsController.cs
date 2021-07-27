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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace L00161840BlazorProject.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PayGroupsController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PayGroupsController(ApplicationDbContext context)
        {
            this.context = context;

        }

        [HttpGet]
        public async Task<ActionResult<List<PayGroup>>> Get()
        {
            return await context.PayGroups.ToListAsync();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PayGroup>> Get(int id)
        {
            var payGroup = await context.PayGroups.FirstOrDefaultAsync(x => x.Id == id);
            if (payGroup == null) { return NotFound(); }
            return payGroup;
        }


        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles ="Admin")]
        public async Task<ActionResult<int>> Post(PayGroup payGroup)
        {

            context.Add(payGroup);
            await context.SaveChangesAsync();
            return payGroup.Id;
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult> Put(PayGroup payGroup)
        {
            var PayGroupDB = await context.PayGroups.AsNoTracking().FirstOrDefaultAsync(x => x.Id == payGroup.Id);

            if (PayGroupDB == null) { return NotFound(); }

            context.Attach(payGroup).State = EntityState.Modified;

            await context.SaveChangesAsync();
            return NoContent();

        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            var PayGroup = await context.PayGroups.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (PayGroup == null)
            {
                return NotFound();
            }

            context.Remove(PayGroup);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
