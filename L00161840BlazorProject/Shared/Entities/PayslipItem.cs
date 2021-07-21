using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Shared.Entities
{
    public class PayslipItem
    {
        public int Id { get; set; }
        public int PayDataId { get; set; }
        public PayData PayData { get; set; }
        public int PayItemId { get; set; }
        public PayItem PayItem { get; set; }
        public double Amount { get; set; }
    }
}
