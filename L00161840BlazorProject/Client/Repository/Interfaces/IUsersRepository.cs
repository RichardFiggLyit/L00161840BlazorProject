using L00161840BlazorProject.Shared.DTOs.User;
using L00161840BlazorProject.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Client.Repository
{
    public interface IUsersRepository
    {
        Task AssignRole(EditRoleDTO editRole);
        Task<bool> GetAdmin(string userId);
        Task<int> GetEmployeeId(string userId);
        Task<List<UserEmployeeDTO>> GetEmployees();
        Task<List<RoleDTO>> GetRoles();
        Task<UserNameDTO> GetUserName(string userId);
        Task<PaginatedResponse<List<UserDTO>>> GetUsers(PaginationDTO paginationDTO);
        Task RemoveRole(EditRoleDTO editRole);
        Task SetAdmin(SetAdminDTO setAdminDTO);
        Task SetEmployee(SetEmployeeDTO setEmployeeDTO);
        Task SetUserName(UserNameDTO setEmployeeDTO);
    }
}
