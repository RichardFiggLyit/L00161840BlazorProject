using L00161840BlazorProject.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Shared.DTOs
{
    public class PayslipOverviewDTO
    {
        public int PayDataId { get; set; }
        public string PayGroupName { get; set; }
        public Period PayPeriod { get; set; }
        public int TaxYear { get; set; }
        public int TaxPeriod { get; set; }
        public DateTime PayDate { get; set; }
        public double TotalGross { get; set; }
        public double TotalNet { get; set; }

    }
}
