using L00161840BlazorProject.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Shared.DTOs
{
    public class PayslipDTO
    {
        public int PayPeriodId { get; set; }
        public int EmployeeId { get; set; }
        public string PayGroupName { get; set; }
        public Period PayPeriod { get; set; }
        public int TaxYear { get; set; }
        public int TaxPeriod { get; set; }
        public DateTime PayDate { get; set; }
        public string PayrollReference { get; set; }
        public string EmployeeName { get; set; }
        public string PPSN { get; set; }
        public double Gross { get; set; }
        public double Net { get; set; }
        public double ERPRSI { get; set; }
        public string CompanyName { get; set; }
        public string TaxReference { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Address5 { get; set; }
        public string AdminEmail { get; set; }
        public string Phone { get; set; }
        public List<Item> Addition { get; set; } = new List<Item>();
        public List<Item> Deduction { get; set; } = new List<Item>();

        public class Item
        {
            public string Description { get; set; }
            public double Amount { get; set; }
        }
    }
}
