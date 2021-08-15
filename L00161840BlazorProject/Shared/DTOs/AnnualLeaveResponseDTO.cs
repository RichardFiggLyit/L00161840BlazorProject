using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L00161840BlazorProject.Shared.Entities;

namespace L00161840BlazorProject.Shared.DTOs
{
    public class AnnualLeaveResponseDTO
    {
        public AnnualLeaveRequest AnnualLeaveRequest { get; set; } = null;
        public string ErrorDetail { get; set; } = null;

    }

}
