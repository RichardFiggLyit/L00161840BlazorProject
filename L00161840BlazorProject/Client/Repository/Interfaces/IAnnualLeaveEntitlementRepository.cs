using L00161840BlazorProject.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Client.Repository
{
    public interface IAnnualLeaveEntitlementRepository
    {
        Task<AnnualLeaveEntitlement> CreateAnnualLeaveEntitlement(AnnualLeaveEntitlement annualLeaveEntitlement);
        Task DeleteAnnualLeaveEntitlement(int id);
        Task<AnnualLeaveEntitlement> GetAnnualLeaveEntitlementByEmployeedId(int employeeId, int taxYear);
        Task<AnnualLeaveEntitlement> GetAnnualLeaveEntitlementById(int id);
        Task UpdateAnnualLeaveEntitlement(AnnualLeaveEntitlement annualLeaveEntitlement);
    }
}
