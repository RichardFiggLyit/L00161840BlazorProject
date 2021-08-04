
using L00161840BlazorProject.Server.Helpers;
using L00161840BlazorProject.Shared.DTOs;
using L00161840BlazorProject.Shared.DTOs.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly string EMPLOYEE_CLAIM = "Employee";

        public UsersController(ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> Get([FromQuery] PaginationDTO paginationDTO)
        {
            
            var queryable = context.Users.AsQueryable();
            await HttpContext.InsertPaginationParametersInResponse(queryable, paginationDTO.RecordsPerPage);
            return await queryable.Paginate(paginationDTO)
                .Select(x => new UserDTO { Email = x.Email, UserId = x.Id, Name = x.UserName }).ToListAsync();
        }

        [HttpGet("roles")]
        public async Task<ActionResult<List<RoleDTO>>> Get()
        {
            return await context.Roles
                .Select(x => new RoleDTO { RoleName = x.Name }).ToListAsync();
        }
        [HttpGet("claim/{userId}")]
        public async Task<ActionResult<IdentityUserClaim<string>>> GetEmployeeClaim(string userId)
        {
           return await context.UserClaims.Where(x=>x.UserId==userId && x.ClaimType == EMPLOYEE_CLAIM).FirstOrDefaultAsync();
        }

        [HttpGet("getEmployees")]
        public async Task<ActionResult<List<UserEmployeeDTO>>> GetEmployees()
        {
            return await context.Employees.Select(x => new UserEmployeeDTO { EmployeeId = x.Id, Forename = x.Forename, Surname = x.Surname, PayrollReference = x.PayrollReference, PPSN = x.PPSN }).ToListAsync();
        }

        [HttpPost("setAdmin")]
        public async Task<ActionResult> SetAdmin(SetAdminDTO setAdminDTO)
        {
            var user = await userManager.FindByIdAsync(setAdminDTO.UserId);
            var role = await context.UserClaims.Where(x => x.UserId == setAdminDTO.UserId && x.ClaimType == ClaimTypes.Role && x.ClaimValue == "Admin").FirstOrDefaultAsync();
            if (role != null)
            {
                if (!setAdminDTO.IsAdmin)
                    await userManager.RemoveClaimAsync(user, new Claim(ClaimTypes.Role, "Admin"));
            }
            else
            {
                if (setAdminDTO.IsAdmin)
                    await userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Admin"));
            }
            return NoContent();
        }
        [HttpGet("getAdmin/{userId}")]
        public async Task<ActionResult<bool>> GetAdmin(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            var role = await context.UserClaims.Where(x => x.UserId == userId && x.ClaimType == ClaimTypes.Role && x.ClaimValue == "Admin").FirstOrDefaultAsync();
            return role != null;
        }

        [HttpGet("getEmployeeId/{userId}")]
        public async Task<ActionResult<int>> GetEmployeeId(string userId)
        {
            int employeeId = 0;
            var user = await userManager.FindByIdAsync(userId);
            var role = await context.UserClaims.Where(x => x.UserId == userId && x.ClaimType == EMPLOYEE_CLAIM).FirstOrDefaultAsync();
            if (role!= null)
            {
                int.TryParse(role.ClaimValue, out employeeId);
                
            }
            return employeeId;
        }
        [HttpPost("setEmployee")]
        public async Task<ActionResult> SetEmployee(SetEmployeeDTO setEmployeeDTO)
        {
            var user = await userManager.FindByIdAsync(setEmployeeDTO.UserId);
            var role = await context.UserClaims.Where(x => x.UserId == setEmployeeDTO.UserId && x.ClaimType == EMPLOYEE_CLAIM).FirstOrDefaultAsync();
            if (role != null)
            {
                if (role.ClaimValue != setEmployeeDTO.EmployeeId)
                {

                    await userManager.RemoveClaimAsync(user, new Claim(EMPLOYEE_CLAIM, role.ClaimValue));
                    if (setEmployeeDTO.EmployeeId != "0")
                        await userManager.AddClaimAsync(user, new Claim(EMPLOYEE_CLAIM, setEmployeeDTO.EmployeeId));
                }
            }
            else
            {
                if (setEmployeeDTO.EmployeeId != "0")
                    await userManager.AddClaimAsync(user, new Claim(EMPLOYEE_CLAIM, setEmployeeDTO.EmployeeId));
            }
            return NoContent();
        }

        [HttpGet("getUserName/{userId}")]
        public async Task<ActionResult<UserNameDTO>> GetUserName(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            UserNameDTO userNameDTO = new UserNameDTO() { UserId = userId, UserName = user.UserName };
            return userNameDTO;
        }
        [HttpPost("setUserName")]
        public async Task<ActionResult> SetUserName(UserNameDTO userNameDTO)
        {
            var user = await userManager.FindByIdAsync(userNameDTO.UserId);
            if (user != null)
            {
                await userManager.SetUserNameAsync(user, userNameDTO.UserName);
            }
            return NoContent();
        }




    }
}
