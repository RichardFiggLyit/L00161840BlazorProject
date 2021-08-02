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
    public class PayDatumController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PayDatumController(ApplicationDbContext context)
        {
            this.context = context;

        }

        [HttpGet]
        public async Task<ActionResult<List<PayData>>> Get()
        {
            return await context.PayDatum.ToListAsync();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PayData>> Get(int id)
        {
            var payDatum = await context.PayDatum.FirstOrDefaultAsync(x => x.Id == id);
            if (payDatum == null) { return NotFound(); }
            return payDatum;
        }


        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult<int>> Post(PayData payData)
        {

            context.Add(payData);
            await context.SaveChangesAsync();
            return payData.Id;
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult> Put(PayData payData)
        {
            var PayDatumDB = await context.PayDatum.AsNoTracking().FirstOrDefaultAsync(x => x.Id == payData.Id);

            if (PayDatumDB == null) { return NotFound(); }

            context.Attach(payData).State = EntityState.Modified;

            await context.SaveChangesAsync();
            return NoContent();

        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            var PayData = await context.PayDatum.FirstOrDefaultAsync(x => x.Id == id);
            if (PayData == null)
            {
                return NotFound();
            }

            context.Remove(PayData);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
