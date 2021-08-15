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
    public class AnnualLeaveRequestController: ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AnnualLeaveRequestController(ApplicationDbContext context)
        {
            this.context = context;

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AnnualLeaveRequest>> Get(int id)
        {
            var annualLeaveRequest = await context.AnnualLeaveRequests.FirstOrDefaultAsync(x => x.Id == id);
            if (annualLeaveRequest == null) { return NotFound(); }
            return annualLeaveRequest;
        }
        [HttpGet("byEmployee/{employeeId}")]
        public async Task<ActionResult<List<AnnualLeaveRequest>>> GetByEmployee(int employeeId)
        {
            var annualLeaveRequest = await context.AnnualLeaveRequests.Where(x => x.Id == employeeId).ToListAsync();
            if (annualLeaveRequest == null) { return NotFound(); }
            return annualLeaveRequest;
        }


        [HttpPost]
        public async Task<ActionResult<int>> Post(AnnualLeaveRequest annualLeaveRequest)
        {

            context.Add(annualLeaveRequest);
            await context.SaveChangesAsync();
            return annualLeaveRequest.Id;
        }

        [HttpPut]
        public async Task<ActionResult> Put(AnnualLeaveRequest annualLeaveRequest)
        {
            var annualLeaveRequestDB = await context.AnnualLeaveRequests.AsNoTracking().FirstOrDefaultAsync(x => x.Id == annualLeaveRequest.Id);

            if (annualLeaveRequestDB == null) { return NotFound(); }

            context.Attach(annualLeaveRequest).State = EntityState.Modified;

            await context.SaveChangesAsync();
            return NoContent();

        }


    }
}
