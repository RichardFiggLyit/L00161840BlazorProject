using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Shared.DTOs.User
{
    public class UserInfo
    {

        public string UserName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
        public bool IsAdmin { get; set; } = false;
        public int? EmployeeId { get; set; } = null;
    }
}
