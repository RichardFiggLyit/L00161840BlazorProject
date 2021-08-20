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
        private string url = "api/employees";

        public EmployeeRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<List<EmployeeOverviewDTO>> GetEmployees()
        {
            return await httpService.GetHelper<List<EmployeeOverviewDTO>>(url);
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
        public async Task<List<PayslipOverviewDTO>> GetPayslipOverview(int id)
        {
            return await httpService.GetHelper<List<PayslipOverviewDTO>>($"{url}/payslip/overview/{id}");
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

        public async Task<Employee> CreateOrUpdateEmployee(Employee employee)
        {
            var response = await httpService.Post<Employee, Employee>($"{url}/createupdate", employee);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }

        public async Task<PayslipDTO> GetPayslip(int id)
        {
            return  await httpService.GetHelper<PayslipDTO>($"{url}/payslip/{id}");

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
