using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Shared.Entities
{
    public class PayData
    {
        public int Id { get; set; }
        public int PayPeriodId {get;set; }
        public PayPeriod PayPeriod { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public double Gross { get; set; }
        public double Net { get; set; }
        public double PAYE { get; set; }
        public double EEPRSI { get; set; }
        public double ERPRSI { get; set; }
        public double USC { get; set; }
        public double LPT { get; set; }


    }
}
