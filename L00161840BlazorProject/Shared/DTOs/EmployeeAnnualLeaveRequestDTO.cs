using L00161840BlazorProject.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Shared.DTOs
{
    public class EmployeeAnnualLeaveRequestDTO
    {
        public int EmployeeId { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string PPSN { get; set; }
        public string EmployeeReference { get; set; }
        public List<LeaveYear> LeaveYears {get;set;} = new List<LeaveYear>();
        public List<Request> Requests { get; set; } = new List<Request>();
        public class LeaveYear

        { 
            public int Id { get; set; }
            public int TaxYear { get; set; }
            public int Entitlment { get; set; } = 20;
            public int Taken { get; set; } = 0;
            public int Remaining { get { return Entitlment - Taken; } }
           

            
        }
        public class Request
        {
            public int Id { get; set; }
            public int EntitlmentId { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public int DaysTaken { get; set; }
            public AnnualLeaveRequestStatus Status { get; set; } = AnnualLeaveRequestStatus.Pending;
            public string RequestedBy { get; set; }
            public DateTime RequestedTime { get; set; }
            public string StatusSetBy { get; set; }
            public DateTime StatusSetTime { get; set; }
        }

    }
}
