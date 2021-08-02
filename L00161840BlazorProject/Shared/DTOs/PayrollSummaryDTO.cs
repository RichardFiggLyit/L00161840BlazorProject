using L00161840BlazorProject.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Shared.DTOs
{
    public class PayrollSummaryDTO
    {
        public int PayPeriodId { get; set; }
        public int PayGroupId { get; set; }
        public string PayGroupName { get; set; }
        public Period PayPeriod { get; set; }
        public int TaxYear { get; set; }
        public int TaxPeriod { get; set; }
        public DateTime PayDate { get; set; }
        public List<PayItem> Payments { get; set; } = new List<PayItem>();
        public List<PayItem> Deductions { get; set; } = new List<PayItem>();

        public List<Row> Rows { get; set; } = new List<Row>();

        public class Row
        {
            public int PayDataId { get; set; }
            public string PayrollReference { get; set; }
            public string EmployeeName { get; set; }
            public string PPSN { get; set; }
            public double BasicHours { get; set; }
            public double BasicRate { get; set; }
            public double Gross { get; set; }
            public double Net { get; set; }
            public double PAYE { get; set; }
            public double EEPRSI { get; set; }
            public double ERPRSI { get; set; }
            public double USC { get; set; }
            public double LPT { get; set; }
            public List<PayslipItemDTO> PayslipItems { get; set; } = new List<PayslipItemDTO>();
            

        }
        
    }
}
