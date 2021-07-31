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
    public class PayItemsController: ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PayItemsController(ApplicationDbContext context)
        {
            this.context = context;

        }

        [HttpGet]
        public async Task<ActionResult<List<PayItem>>> Get()
        {
            return await context.PayItems.ToListAsync();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PayItem>> Get(int id)
        {
            var payItem = await context.PayItems.FirstOrDefaultAsync(x => x.Id == id);
            if (payItem == null) { return NotFound(); }
            return payItem;
        }


        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult<int>> Post(PayItem payItem)
        {

            context.Add(payItem);
            await context.SaveChangesAsync();
            return payItem.Id;
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult> Put(PayItem payItem)
        {
            var PayItemDB = await context.PayItems.AsNoTracking().FirstOrDefaultAsync(x => x.Id == payItem.Id);

            if (PayItemDB == null) { return NotFound(); }

            context.Attach(payItem).State = EntityState.Modified;

            await context.SaveChangesAsync();
            return NoContent();

        }
    }
}
