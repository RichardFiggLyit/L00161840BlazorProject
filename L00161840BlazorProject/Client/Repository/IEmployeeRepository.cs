using L00161840BlazorProject.Shared.DTOs;
using L00161840BlazorProject.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Client.Repository
{
    interface IEmployeeRepository
    {
        Task CreateEmployee(Employee Employee);
        Task DeleteEmployee(int Id);
        Task<Employee> GetEmployeeById(int id);
        Task<PaginatedResponse<List<Employee>>> GetEmployees(PaginationDTO paginationDTO);
        Task<List<Employee>> GetEmployeesBySurname(string name);
        Task UpdateEmployee(Employee Employee);
    }
}
