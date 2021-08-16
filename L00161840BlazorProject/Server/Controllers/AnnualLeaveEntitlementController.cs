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
using L00161840BlazorProject.Shared.Helpers;

namespace L00161840BlazorProject.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AnnualLeaveEntitlementController: ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AnnualLeaveEntitlementController(ApplicationDbContext context)
        {
            this.context = context;

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AnnualLeaveEntitlement>> Get(int id)
        {
            var annualLeaveEntitlement = await context.AnnualLeaveEntitlements.FirstOrDefaultAsync(x => x.Id == id);
            if (annualLeaveEntitlement == null) { return NotFound(); }
            return annualLeaveEntitlement;
        }
        [HttpGet("byEmployee/{employeeId}/{taxYear}")]
        public async Task<ActionResult<AnnualLeaveEntitlement>> GetbyEmployee(int employeeId, int taxYear)
        {
            var annualLeaveEntitlement = await context.AnnualLeaveEntitlements.FirstOrDefaultAsync(x => x.EmployeeId == employeeId && x.TaxYear == taxYear);
            if (annualLeaveEntitlement == null) { return NotFound(); }
            return annualLeaveEntitlement;
        }


        [HttpPost]
        public async Task<ActionResult<AnnualLeaveEntitlement>> Post(AnnualLeaveEntitlement annualLeaveEntitlement)
        {

            context.Add(annualLeaveEntitlement);
            await context.SaveChangesAsync();
            return annualLeaveEntitlement;
        }

        [HttpPut]
        public async Task<ActionResult> Put(AnnualLeaveEntitlement annualLeaveEntitlement)
        {
            var annualLeaveEntitlementDB = await context.AnnualLeaveEntitlements.AsNoTracking().FirstOrDefaultAsync(x => x.Id == annualLeaveEntitlement.Id);

            if (annualLeaveEntitlementDB == null) { return NotFound(); }

            context.Attach(annualLeaveEntitlement).State = EntityState.Modified;

            await context.SaveChangesAsync();
            return NoContent();

        }


    }
}
