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
using System.Security.Claims;

namespace L00161840BlazorProject.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public EmployeesController(ApplicationDbContext context)
        {
            this.context = context;

        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult<List<EmployeeOverviewDTO>>> Get([FromQuery] PaginationDTO paginationDTO)
        {
            var queryable = context.Employees.Include(x => x.Invite).OrderBy(y => y.Surname).ThenBy(z => z.Forename).AsQueryable();
            await HttpContext.InsertPaginationParametersInResponse(queryable, paginationDTO.RecordsPerPage);
            return await queryable.Paginate(paginationDTO).Select(x => new EmployeeOverviewDTO()
            {
                Forename = x.Forename,
                Surname = x.Surname,
                Email = x.Email,
                PayrollReference = x.PayrollReference,
                Id = x.Id,
                PPSN = x.PPSN,
                Invite = x.Invite,
            }).ToListAsync();
        }

        [HttpGet("{id}")]
        
        public async Task<ActionResult<Employee>> Get(int id)
        {
            bool isAdmin = User.IsAdmin();
            int employeeId = User.EmployeeId();

            if (!isAdmin && employeeId != id)
            {
                return NoContent();
            }
            var employee = await context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee == null) { return NotFound(); }
            return employee;
        }


        [HttpGet("search/{searchText}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult<List<Employee>>> FilterByName(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText)) { return new List<Employee>(); }
            return await context.Employees.Where(x => x.Surname.Contains(searchText))
                .Take(50)
                .ToListAsync();
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult<int>> Post(Employee employee)
        {

            context.Add(employee);
            await context.SaveChangesAsync();
            return employee.Id;
        }

    

        [HttpGet("payslip/{id}")]
        public async Task<ActionResult<PayslipDTO>> GetPayslip(int id)
        {
            var payData = await context.PayDatum.Include(x=>x.Employee).Include(x=>x.PayPeriod).ThenInclude(x=>x.PayGroup).Include(x=>x.PayslipItems).ThenInclude(x=>x.PayItem).FirstOrDefaultAsync(x => x.Id == id);
            if (payData == null)
                return NoContent();
            bool isAdmin = User.IsAdmin();
            int employeeId = User.EmployeeId();

            if (!isAdmin && employeeId != payData.EmployeeId)
            {
                return NoContent();
            }
            var company = await context.Companies.FirstOrDefaultAsync();

            PayslipDTO payslip = new PayslipDTO()
            {
                Address1 = company.Address1,
                Address2 = company.Address2,
                Address3 = company.Address3,
                Address4 = company.Address4,
                Address5 = company.Address5,
                AdminEmail = company.AdminEmail,
                Phone = company.Phone,
                CompanyName = company.Name,
                TaxReference = company.TaxReference,
                EmployeeName = payData.Employee.Forename + " " + payData.Employee.Surname,
                ERPRSI = payData.ERPRSI,
                Gross = payData.Gross,
                PayGroupName = payData.PayPeriod.PayGroup.Name,
                Net = payData.Net,
                PayDate = payData.PayPeriod.PayDate,
                PayPeriod = payData.PayPeriod.PayGroup.Period,
                PPSN = payData.Employee.PPSN,
                PayrollReference = payData.Employee.PayrollReference,
                TaxPeriod = payData.PayPeriod.TaxPeriod,
                TaxYear = payData.PayPeriod.TaxYear,
                EmployeeId = payData.EmployeeId,
                PayPeriodId = payData.PayPeriodId
                
            };
            payslip.Deduction.Add(new PayslipDTO.Item() { Amount = payData.PAYE, Description = "PAYE" });
            payslip.Deduction.Add(new PayslipDTO.Item() { Amount = payData.EEPRSI, Description = "EE PRSI" });
            payslip.Deduction.Add(new PayslipDTO.Item() { Amount = payData.USC, Description = "USC" });
            if (payData.LPT != 0)
                payslip.Deduction.Add(new PayslipDTO.Item() { Amount = payData.LPT, Description = "LPT" });
            foreach (var deduction in payData.PayslipItems.Where(x=>x.PayItem.PayItemType == PayItemType.Deduction && x.Amount != 0.0))
                payslip.Deduction.Add(new PayslipDTO.Item() { Amount = deduction.Amount, Description = deduction.PayItem.Name });
            if ((payData.BasicHours * payData.BasicRate) != 0.0)
                payslip.Addition.Add(new PayslipDTO.Item() { Amount = payData.BasicHours * payData.BasicRate, Description = string.Format("{0} @ €{1}", payData.BasicHours.ToString("0.00"), payData.BasicRate.ToString("0.00")) });
            foreach (var payment in payData.PayslipItems.Where(x => x.PayItem.PayItemType == PayItemType.Payment && x.Amount != 0.0))
                payslip.Addition.Add(new PayslipDTO.Item() { Amount = payment.Amount, Description = payment.PayItem.Name });
            return payslip;
        }
        [HttpGet("payslip/overview/{id}")]
        public async Task<ActionResult<List<PayslipOverviewDTO>>> GetPayslipOverview(int id)
        {
            bool isAdmin = User.IsAdmin();
            int employeeId = User.EmployeeId();

            if (!isAdmin && employeeId !=  id)
            {
                return NoContent();
            }
            var overview = await context.PayDatum.Where(x=>x.EmployeeId== id).Select(x => new PayslipOverviewDTO
            {
                PayDate = x.PayPeriod.PayDate,
                PayDataId = x.Id,
                PayGroupName = x.PayPeriod.PayGroup.Name,
                PayPeriod = x.PayPeriod.PayGroup.Period,
                TaxPeriod = x.PayPeriod.TaxPeriod,
                TaxYear = x.PayPeriod.TaxYear,
                TotalGross = x.Gross,
                TotalNet = x.Net
            }).OrderByDescending(x => x.PayDate).ToListAsync();

            return overview;
        }


        [HttpPost("createupdate")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult<Employee>> PostOrUpdate(Employee employee)
        {
            var EmployeeDBPPSN = await context.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.PPSN == employee.PPSN);
            var EmployeeDBPayrollReference = await context.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.PayrollReference == employee.PayrollReference);
            if (EmployeeDBPayrollReference == null &&  EmployeeDBPPSN == null)
            {
                context.Add(employee);
            }
            else
            {
                if (EmployeeDBPPSN!= null)
                {
                    employee.Id = EmployeeDBPPSN.Id;
                }
                else
                {
                    employee.Id = EmployeeDBPayrollReference.Id;
                }
                context.Attach(employee).State = EntityState.Modified;
            }
            await context.SaveChangesAsync();
            return employee;
        }

        [HttpPut]
        public async Task<ActionResult> Put(Employee employee)
        {
            bool isAdmin = User.IsAdmin();
            int employeeId = User.EmployeeId();

            if (!isAdmin && employeeId != employee.Id)
            {
                return NoContent();
            }
            var EmployeeDB = await context.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.Id == employee.Id);

            if (EmployeeDB == null) { return NotFound(); }

            context.Attach(employee).State = EntityState.Modified;

            await context.SaveChangesAsync();
            return NoContent();

        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
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
