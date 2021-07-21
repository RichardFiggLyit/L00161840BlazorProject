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
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public EmployeesController(ApplicationDbContext context)
        {
            this.context = context;

        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> Get([FromQuery] PaginationDTO paginationDTO)
        {
            var queryable = context.Employees.AsQueryable();
            await HttpContext.InsertPaginationParametersInResponse(queryable, paginationDTO.RecordsPerPage);
            return await queryable.Paginate(paginationDTO).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            var employee = await context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee == null) { return NotFound(); }
            return employee;
        }

        [HttpGet("search/{searchText}")]
        public async Task<ActionResult<List<Employee>>> FilterByName(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText)) { return new List<Employee>(); }
            return await context.Employees.Where(x => x.Surname.Contains(searchText))
                .Take(50)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Employee employee)
        {

            context.Add(employee);
            await context.SaveChangesAsync();
            return employee.Id;
        }

        [HttpPut]
        public async Task<ActionResult> Put(Employee employee)
        {
            var EmployeeDB = await context.Employees.FirstOrDefaultAsync(x => x.Id == employee.Id);

            if (EmployeeDB == null) { return NotFound(); }

            context.Attach(employee).State = EntityState.Modified;

            await context.SaveChangesAsync();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Employee = await context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (Employee == null)
            {
                return NotFound();
            }

            context.Remove(Employee);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
