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

namespace L00161840BlazorProject.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {

        private readonly ApplicationDbContext context;

        public CompaniesController(ApplicationDbContext context)
        {
            this.context = context;

        }



        [HttpGet]
        public async Task<ActionResult<Company>> Get()
        {
            var company = await context.Companies.FirstOrDefaultAsync();
            if (company == null) { return NotFound(); }
            return company;
        }




        [HttpPut]
        public async Task<ActionResult> Put(Company company)
        {
            context.Attach(company).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();

        }

    }
}
