using L00161840BlazorProject.Shared.DTOs;
using L00161840BlazorProject.Shared.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Client.Repository
{
    public interface IEmployeeRepository
    {
        Task CreateEmployee(Employee employee);
        Task<Employee> CreateOrUpdateEmployee(Employee employee);
        Task DeleteEmployee(int Id);
        Task<Employee> GetEmployeeById(int id);
        Task<List<EmployeeOverviewDTO>> GetEmployees();
        Task<List<Employee>> GetEmployeesBySurname(string name);
        Task<PayslipDTO> GetPayslip(int id);
        Task<List<PayslipOverviewDTO>> GetPayslipOverview(int id);
        Task UpdateEmployee(Employee employee);
    }
}