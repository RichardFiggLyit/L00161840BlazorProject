using L00161840BlazorProject.Client.Helpers;
using L00161840BlazorProject.Shared.DTOs;
using L00161840BlazorProject.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Client.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IHttpService httpService;
        private string url = "api/employee";

        public EmployeeRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<PaginatedResponse<List<Employee>>> GetEmployees(PaginationDTO paginationDTO)
        {
            return await httpService.GetHelper<List<Employee>>(url, paginationDTO);
        }

        public async Task<List<Employee>> GetEmployeesBySurname(string name)
        {
            var response = await httpService.Get<List<Employee>>($"{url}/search/{name}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await httpService.GetHelper<Employee>($"{url}/{id}");
        }

        public async Task CreateEmployee(Employee employee)
        {
            var response = await httpService.Post(url, employee);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task UpdateEmployee(Employee employee)
        {
            var response = await httpService.Put(url, employee);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task DeleteEmployee(int Id)
        {
            var response = await httpService.Delete($"{url}/{Id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}
