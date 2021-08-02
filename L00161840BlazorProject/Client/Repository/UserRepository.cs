using L00161840BlazorProject.Client.Helpers;
using L00161840BlazorProject.Shared.DTOs;
using L00161840BlazorProject.Shared.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Client.Repository
{
    public class UserRepository: IUsersRepository
    {
        private readonly IHttpService httpService;
        private readonly string url = "api/users";

        public UserRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<PaginatedResponse<List<UserDTO>>> GetUsers(PaginationDTO paginationDTO)
        {
            return await httpService.GetHelper<List<UserDTO>>(url, paginationDTO);
        }

        public async Task<List<RoleDTO>> GetRoles()
        {
            return await httpService.GetHelper<List<RoleDTO>>($"{url}/roles");
        }
        public async Task SetAdmin(SetAdminDTO setAdminDTO)
        {
            var response = await httpService.Post($"{url}/setAdmin", setAdminDTO);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
        public async Task<bool> GetAdmin(string userId)
        {
            return await httpService.GetHelper<bool>($"{url}/getAdmin/{userId}");
        }

        public async Task<int> GetEmployeeId(string userId)
        {
            return await httpService.GetHelper<int>($"{url}/getEmployeeId/{userId}");
        }
        public async Task SetEmployee(SetEmployeeDTO setEmployeeDTO)
        {
            var response = await httpService.Post($"{url}/setEmployee", setEmployeeDTO);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
        public async Task<UserNameDTO> GetUserName(string userId)
        {
            return await httpService.GetHelper<UserNameDTO>($"{url}/getUserName/{userId}");
        }
        public async Task SetUserName(UserNameDTO setEmployeeDTO)
        {
            setEmployeeDTO.UserName = setEmployeeDTO.UserName.Replace(" ", "_");
            var response = await httpService.Post($"{url}/setUserName", setEmployeeDTO);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
        public async Task<List<UserEmployeeDTO>> GetEmployees()
        {
            return await httpService.GetHelper<List<UserEmployeeDTO>>($"{url}/getEmployees");
        }

        public async Task AssignRole(EditRoleDTO editRole)
        {
            var response = await httpService.Post($"{url}/assignRole", editRole);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task RemoveRole(EditRoleDTO editRole)
        {
            var response = await httpService.Post($"{url}/removeRole", editRole);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

       

    }
}
