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
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; } = null;
        public string InviteReference { get; set; }
        public bool IsAccepted { get; set; }
    }
}
