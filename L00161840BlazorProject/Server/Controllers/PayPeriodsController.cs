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
    public class PayPeriodsController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PayPeriodsController(ApplicationDbContext context)
        {
            this.context = context;

        }

        [HttpGet]
        public async Task<ActionResult<List<PayPeriod>>> Get()
        {
            return await context.PayPeriods.ToListAsync();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PayPeriod>> Get(int id)
        {
            var payPeriod = await context.PayPeriods.FirstOrDefaultAsync(x => x.Id == id);
            if (payPeriod == null) { return NotFound(); }
            return payPeriod;
        }
        [HttpGet("{payGroupId}/{taxYear}/{taxPeriod}")]
        public async Task<ActionResult<PayPeriod>> Get(int payGroupId, int taxYear, int taxPeriod)
        {
            var payPeriod = await context.PayPeriods.FirstOrDefaultAsync(x => x.PayGroupId == payGroupId && x.TaxPeriod == taxPeriod && x.TaxYear == taxYear);
            if (payPeriod == null) { return new PayPeriod(); }
            return payPeriod;
        }


        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult<int>> Post(PayPeriod payPeriod)
        {

            context.Add(payPeriod);
            await context.SaveChangesAsync();
            return payPeriod.Id;
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult> Put(PayPeriod payPeriod)
        {
            var PayPeriodDB = await context.PayPeriods.AsNoTracking().FirstOrDefaultAsync(x => x.Id == payPeriod.Id);

            if (PayPeriodDB == null) { return NotFound(); }

            context.Attach(payPeriod).State = EntityState.Modified;

            await context.SaveChangesAsync();
            return NoContent();

        }
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            var PayPeriod = await context.PayPeriods.FirstOrDefaultAsync(x => x.Id == id);
            if (PayPeriod == null)
            {
                return NotFound();
            }
            var payDatum = await context.PayDatum.Where(x => x.PayPeriodId == id).ToListAsync();
            foreach (var data in payDatum)
            {
                var payslipItems = await context.PayslipItems.Where(x => x.PayDataId == data.Id).ToListAsync();
                context.RemoveRange(payslipItems);
            }
            context.RemoveRange(payDatum);
            context.Remove(PayPeriod);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
