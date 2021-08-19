using L00161840BlazorProject.Client.Helpers;
using L00161840BlazorProject.Shared.DTOs;
using L00161840BlazorProject.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Client.Repository
{
    public class AnnualLeaveEntitlementRepository: IAnnualLeaveEntitlementRepository
    {
        private readonly IHttpService httpService;
        private string url = "api/annualLeaveEntitlement";

        public AnnualLeaveEntitlementRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<AnnualLeaveEntitlement> GetAnnualLeaveEntitlementById(int id)
        {
            return await httpService.GetHelper<AnnualLeaveEntitlement>($"{url}/{id}");
        }
        public async Task<AnnualLeaveEntitlement> GetAnnualLeaveEntitlementByEmployeedId(int employeeId, int taxYear)
        {
            return await httpService.GetHelper<AnnualLeaveEntitlement>($"{url}/byEmployee/{employeeId}/{taxYear}");
        }

        public async Task<AnnualLeaveEntitlement> CreateAnnualLeaveEntitlement(AnnualLeaveEntitlement annualLeaveEntitlement)
        {
            var response = await httpService.Post<AnnualLeaveEntitlement, AnnualLeaveEntitlement>(url, annualLeaveEntitlement);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }

        public async Task UpdateAnnualLeaveEntitlement(AnnualLeaveEntitlement annualLeaveEntitlement)
        {
            var response = await httpService.Put(url, annualLeaveEntitlement);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
        public async Task DeleteAnnualLeaveEntitlement(int id)
        {
            var response = await httpService.Delete($"{url}/{id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

    }
}
