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
    public class PayslipItemsController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PayslipItemsController(ApplicationDbContext context)
        {
            this.context = context;

        }

        [HttpGet]
        public async Task<ActionResult<List<PayslipItem>>> Get()
        {
            return await context.PayslipItems.ToListAsync();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PayslipItem>> Get(int id)
        {
            var payslipItem = await context.PayslipItems.FirstOrDefaultAsync(x => x.Id == id);
            if (payslipItem == null) { return NotFound(); }
            return payslipItem;
        }


        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult<int>> Post(PayslipItem payslipItem)
        {

            context.Add(payslipItem);
            await context.SaveChangesAsync();
            return payslipItem.Id;
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult> Put(PayslipItem payslipItem)
        {
            var PayslipItemDB = await context.PayslipItems.AsNoTracking().FirstOrDefaultAsync(x => x.Id == payslipItem.Id);

            if (PayslipItemDB == null) { return NotFound(); }

            context.Attach(payslipItem).State = EntityState.Modified;

            await context.SaveChangesAsync();
            return NoContent();

        }
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            var PayslipItem = await context.PayslipItems.FirstOrDefaultAsync(x => x.Id == id);
            if (PayslipItem == null)
            {
                return NotFound();
            }

            context.Remove(PayslipItem);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
