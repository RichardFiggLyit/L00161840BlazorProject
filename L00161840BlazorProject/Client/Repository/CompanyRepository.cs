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

        public async Task<List<Company>> GetCompany()
        {
            return await httpService.GetHelper<List<Company>>(url);
        }

        public async Task<List<Company>> GetCompanyByName(string name)
        {
            var response = await httpService.Get<List<Company>>($"{url}/search/{name}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }

        public async Task<Company> GetCompanyById(int id)
        {
            return await httpService.GetHelper<Company>($"{url}/{id}");
        }

        public async Task CreateCompany(Company company)
        {
            var response = await httpService.Post(url, company);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task UpdateCompany(Company company)
        {
            var response = await httpService.Put(url, company);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task DeleteCompany(int Id)
        {
            var response = await httpService.Delete($"{url}/{Id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}
