using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Shared.DTOs
{
    public class PayslipItemDTO
    {
        public int Id { get; set; }
        public int PayDataId { get; set; }
        public int PayItemId { get; set; }
        public double Amount { get; set; }
    }
}
