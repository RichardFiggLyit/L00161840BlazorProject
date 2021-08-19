using L00161840BlazorProject.Client.Helpers;
using L00161840BlazorProject.Shared.DTOs;
using L00161840BlazorProject.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Client.Repository
{
    public class AnnualLeaveRequestRepository: IAnnualLeaveRequestRepository
    {
        private readonly IHttpService httpService;
        private string url = "api/annualLeaveRequest";

        public AnnualLeaveRequestRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<List<AnnualLeaveRequest>> GetAnnualLeaveRequestByEmployeedId(int id)
        {
            return await httpService.GetHelper<List<AnnualLeaveRequest>>($"{url}/byEmployee/{id}");
        }

        public async Task<List<AnnualLeaveRequest>> GetAll()
        {
            return await httpService.GetHelper<List<AnnualLeaveRequest>>($"{url}/all");
        }

        public async Task UpdateAnnualLeaveRequest(AnnualLeaveRequest annualLeaveRequest)
        {
            var response = await httpService.Put(url, annualLeaveRequest);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
                public async Task<int> CreateAnnualLeaveRequest(AnnualLeaveRequest annualLeaveRequest)
        {
            var response = await httpService.Post<AnnualLeaveRequest, int>(url, annualLeaveRequest);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }
        public async Task DeleteAnnualLeaveRequest(int id)
        {
            var response = await httpService.Delete($"{url}/{id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task<AnnualLeaveRequest> GetAnnualLeaveRequestById(int id)
        {
            return await httpService.GetHelper<AnnualLeaveRequest>($"{url}/{id}");
        }
    }
}
