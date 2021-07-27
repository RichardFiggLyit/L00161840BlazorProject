using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Shared.Entities
{
    public class PayPeriod
    {
        public int Id { get; set; }
        public int PayGroupId { get; set; }
        public PayGroup PayGroup { get; set; }
        public int TaxYear { get; set; }
        public int TaxPeriod { get; set; }
        public DateTime PayDate { get; set; }
        public List<PayData> PayDatas { get; set; } = new List<PayData>();

    }
}
