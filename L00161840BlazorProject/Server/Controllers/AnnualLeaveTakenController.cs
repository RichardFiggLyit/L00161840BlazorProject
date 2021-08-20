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
    public class AnnualLeaveTakenController: ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AnnualLeaveTakenController(ApplicationDbContext context)
        {
            this.context = context;

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AnnualLeaveTaken>> Get(int id)
        {
            var annualLeaveTaken = await context.AnnualLeaveTaken.FirstOrDefaultAsync(x => x.Id == id);
            if (annualLeaveTaken == null) { return NotFound(); }
            return annualLeaveTaken;
        }
        [HttpGet("byRequest/{requestId}")]
        public async Task<ActionResult<List<AnnualLeaveTaken>>> GetByRequest(int requestId)
        {
            var annualLeaveTaken = await context.AnnualLeaveTaken.Where(x => x.AnnualLeaveRequestId == requestId).ToListAsync();
            if (annualLeaveTaken == null) { return NotFound(); }
            return annualLeaveTaken;
        }


        [HttpPost]
        public async Task<ActionResult<int>> Post(AnnualLeaveTaken annualLeaveTaken)
        {

            context.Add(annualLeaveTaken);
            await context.SaveChangesAsync();
            return annualLeaveTaken.Id;
        }

        [HttpPut]
        public async Task<ActionResult> Put(AnnualLeaveTaken annualLeaveTaken)
        {
            var annualLeaveTakenDB = await context.AnnualLeaveTaken.AsNoTracking().FirstOrDefaultAsync(x => x.Id == annualLeaveTaken.Id);

            if (annualLeaveTakenDB == null) { return NotFound(); }

            context.Attach(annualLeaveTaken).State = EntityState.Modified;

            await context.SaveChangesAsync();
            return NoContent();

        }
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            var AnnualLeaveTaken = await context.AnnualLeaveTaken.FirstOrDefaultAsync(x => x.Id == id);
            if (AnnualLeaveTaken == null)
            {
                return NotFound();
            }
            context.RemoveRange(AnnualLeaveTaken);
            await context.SaveChangesAsync();
            return NoContent();
        }


    }
}
