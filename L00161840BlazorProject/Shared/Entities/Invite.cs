using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Shared.Entities
{
    public class Invite
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; } = null;
        public bool IsAdmin { get; set; } = false;
        public string InviteReference { get; set; }
        public string Email { get; set; }
        public bool IsAccepted { get; set; }
    }
}
