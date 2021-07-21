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
        public async Task<List<Company>> Get()
        {
            var queryable = context.Companies.AsQueryable();
            return await queryable.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> Get(int id)
        {
            var company = await context.Companies.FirstOrDefaultAsync(x => x.Id == id);
            if (company == null) { return NotFound(); }
            return company;
        }


        [HttpPost]
        public async Task<ActionResult<int>> Post(Company company)
        {

            context.Add(company);
            await context.SaveChangesAsync();
            return company.Id;
        }

        [HttpPut]
        public async Task<ActionResult> Put(Company company)
        {
            var CompanyDB = await context.Companies.FirstOrDefaultAsync(x => x.Id == company.Id);

            if (CompanyDB == null) { return NotFound(); }

            context.Attach(company).State = EntityState.Modified;

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
