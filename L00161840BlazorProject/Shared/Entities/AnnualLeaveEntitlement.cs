using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Shared.Entities
{
    public class AnnualLeaveEntitlement
    {
        public AnnualLeaveEntitlement(int employeeId, int taxYear)
        {
            EmployeeId = employeeId;
            TaxYear = taxYear;
        }

        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int TaxYear { get; set; }
        public int Entitlment { get; set; } = 20;
        public int Taken { get; set; } = 0;
        public int Remaining { get { return Entitlment - Taken; } }
        public List<AnnualLeaveRequest> AnnualLeaveRequests { get; set; } = new List<AnnualLeaveRequest>();
    }
}
