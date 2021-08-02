using L00161840BlazorProject.Client.Helpers;
using L00161840BlazorProject.Shared.DTOs;
using L00161840BlazorProject.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Client.Repository
{
    public class CompanyRepository: ICompanyRepository
    {
        private readonly IHttpService httpService;
        private string url = "api/companies";


        public CompanyRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }



        public async Task<Company> GetCompany()
        {
            return await httpService.GetHelper<Company>($"{url}");
        }



        public async Task UpdateCompany(Company company)
        {
            var response = await httpService.Put(url, company);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
        
        public async Task<List<PayrollOverviewDTO>> GetPayrollOverivew()
        {
            return await httpService.GetHelper<List<PayrollOverviewDTO>>($"{url}/payrolloverview");
        }
        public async Task<PayrollSummaryDTO> GetPayrollSummary(int id)
        {
            return await httpService.GetHelper<PayrollSummaryDTO>($"{url}/payrollsummary/{id}");
        }


    }
}
