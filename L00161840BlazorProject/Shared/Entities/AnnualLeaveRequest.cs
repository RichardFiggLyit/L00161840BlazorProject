using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Shared.Entities
{
    public class AnnualLeaveRequest
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DaysTaken { get; set; }
        public AnnualLeaveRequestStatus Status { get; set; } = AnnualLeaveRequestStatus.Pending;
        public string RequestedBy { get; set; }
        public DateTime RequestedTime { get; set; }
        public string StatusSetBy { get; set; }
        public DateTime? StatusSetTime { get; set; }
        
        public string StatusDescription
        {
            get
            {
                return Status.ToString();
            }
        }

    }
    public enum AnnualLeaveRequestStatus
    {
        Pending, Declined, Approved
    }

}
