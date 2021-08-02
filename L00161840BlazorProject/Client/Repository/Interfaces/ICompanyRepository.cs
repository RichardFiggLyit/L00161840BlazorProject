using L00161840BlazorProject.Shared.DTOs;
using L00161840BlazorProject.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Client.Repository
{
    interface ICompanyRepository
    {

        Task<Company> GetCompany();
        Task<List<PayrollOverviewDTO>> GetPayrollOverivew();
        Task<PayrollSummaryDTO> GetPayrollSummary(int id);
        Task UpdateCompany(Company company);
    }
}
