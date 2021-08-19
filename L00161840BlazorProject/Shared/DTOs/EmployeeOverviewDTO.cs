using L00161840BlazorProject.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Shared.DTOs
{
    public class EmployeeOverviewDTO
    {
        public int Id { get; set; }
        public string PayrollReference { get; set; }
        public string PPSN { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public Invite Invite { get; set; }
        public InviteStatus InviteStatus
        {
            get
            {
                var status = InviteStatus.Not_Invited;
                if (string.IsNullOrWhiteSpace(Email))
                    status = InviteStatus.No_Email;
                if (Invite != null)
                {
                    if (Invite.IsAccepted)
                        status = InviteStatus.Accepted;
                    else
                        status = InviteStatus.Invited;
                }
                return status;

            }
        }


    }
    public enum InviteStatus
    {
        No_Email, Not_Invited, Invited, Accepted
    }


 

}
