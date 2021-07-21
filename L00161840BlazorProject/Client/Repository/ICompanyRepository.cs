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
        Task CreateCompany(Company company);
        Task DeleteCompany(int Id);
        
        Task<List<Company>> GetCompany();
        Task<Company> GetCompanyById(int id);
        Task<List<Company>> GetCompanyByName(string name);
        Task UpdateCompany(Company company);
    }
}
