using L00161840BlazorProject.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Client.Repository
{
    public interface IAnnualLeaveRequestRepository
    {
        Task<int> CreateAnnualLeaveRequest(AnnualLeaveRequest annualLeaveRequest);
        Task DeleteAnnualLeaveRequest(int id);
        Task<List<AnnualLeaveRequest>> GetAnnualLeaveRequestByEmployeedId(int id);
        Task<AnnualLeaveRequest> GetAnnualLeaveRequestById(int id);
        Task UpdateAnnualLeaveRequest(AnnualLeaveRequest annualLeaveRequest);
    }
}
