using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Shared.DTOs.User
{
    public class UserEmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string PayrollReference { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string PPSN { get; set; }

        public override string ToString()
        {
            return PayrollReference + " | " + Forename + " " + Surname + " | " + PPSN;
        }
    }
}
