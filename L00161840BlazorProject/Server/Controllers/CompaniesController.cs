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

        [HttpGet("payrolloverview")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult<List<PayrollOverviewDTO>>> GetPayrollOverview()
        {
            var overview = await context.PayPeriods.Select(x => new PayrollOverviewDTO
            {
                PayDate = x.PayDate,
                PayGroupId = x.PayGroupId,
                PayGroupName = x.PayGroup.Name,
                PayPeriod = x.PayGroup.Period,
                PayPeriodId = x.Id,
                TaxPeriod = x.TaxPeriod,
                TaxYear = x.TaxYear,
                TotalGross = x.PayDatas.Sum(x=>x.Gross),
                TotalNet = x.PayDatas.Sum(x=>x.Net)
            }).OrderByDescending(x=>x.PayDate).ToListAsync();

            return overview;
                
        }

         [HttpGet("payrollsummary/{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult<PayrollSummaryDTO>> GetPayrollSummary(int id)
        {
            
            //var payItems = await context.PayItems.ToListAsync();
            var payPeriod = await context.PayPeriods.FirstOrDefaultAsync(x => x.Id == id);
            if (payPeriod == null) return NotFound();
            var payGroup = await context.PayGroups.FirstOrDefaultAsync(x => x.Id == payPeriod.PayGroupId);
            var payDatum =  await context.PayDatum.Where(x => x.PayPeriodId == id).Include(x=>x.Employee).Include(x=>x.PayslipItems).ThenInclude(x=>x.PayItem).ToListAsync();
            var payItems = payDatum.Select(x => x.PayslipItems.Where(y => y.Amount != 0.0)).SelectMany(x=>x).Select(x=>x.PayItem).Distinct().ToList();
            
            PayrollSummaryDTO payrollSummaryDTO = new PayrollSummaryDTO()
            {
                PayDate = payPeriod.PayDate,
                PayGroupId = payPeriod.PayGroupId,
                PayGroupName = payPeriod.PayGroup.Name,
                PayPeriod = payPeriod.PayGroup.Period,
                PayPeriodId = payPeriod.Id,
                TaxPeriod = payPeriod.TaxPeriod,
                TaxYear = payPeriod.TaxYear,
                Payments = payItems.Where(x => x.PayItemType == PayItemType.Payment).ToList(),
                Deductions = payItems.Where(x => x.PayItemType == PayItemType.Deduction).ToList(),
                Rows = new List<PayrollSummaryDTO.Row>()
            };

            
            foreach (var record in payDatum)
            {

                PayrollSummaryDTO.Row row = new PayrollSummaryDTO.Row()
                { 
                    PayDataId = record.Id,
                    BasicHours = record.BasicHours,
                    BasicRate = record.BasicRate,
                    EEPRSI = record.EEPRSI,
                    EmployeeName = record.Employee.Forename + " " + record.Employee.Surname,
                    ERPRSI = record.ERPRSI,
                    Gross = record.Gross,
                    LPT = record.LPT,
                    Net = record.Net,
                    PAYE = record.PAYE,
                    PayrollReference = record.Employee.PayrollReference,
                    PPSN = record.Employee.PPSN,
                    USC = record.USC,
                    PayslipItems = record.PayslipItems.Select(x=> new PayslipItemDTO {Amount = x.Amount, Id = x.Id, PayDataId = x.PayDataId, PayItemId = x.PayItemId }).ToList()
                };

                payrollSummaryDTO.Rows.Add(row);
            }
            return payrollSummaryDTO;

        }


        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult> Put(Company company)
        {
            context.Attach(company).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();

        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<ActionResult<int>> Post(Company company)
        {
            context.Add(company);
            await context.SaveChangesAsync();
            return company.Id;
        }

    }
}
