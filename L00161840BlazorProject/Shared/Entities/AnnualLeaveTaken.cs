using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Shared.Entities
{
    public class AnnualLeaveTaken
    {
        public int Id { get; set; }
        public int AnnualLeaveRequestId { get; set; }
        public AnnualLeaveRequest AnnualLeaveRequest { get; set; }
        public int AnnualLeaveEntitlementId { get; set; }
        public AnnualLeaveEntitlement AnnualLeaveEntitlement { get; set; }
        public int DaysTaken { get; set; }
    }
}
