using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Shared.DTOs
{
    public class RequestYear
    {
        public int EntitlementId { get; set; }
        public int TaxYear { get; set; }
        public int Entitlement { get; set; }
        public int Requested { get; set; }
        public int Available { get; set; }
        public int Remaining
        {
            get
            {
                return Available - Requested;
            }
        }
    }
}
