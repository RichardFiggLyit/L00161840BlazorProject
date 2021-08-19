using L00161840BlazorProject.Client.Helpers;
using L00161840BlazorProject.Shared.DTOs;
using L00161840BlazorProject.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Client.Repository
{
    public class AnnualLeaveTakenRepository: IAnnualLeaveTakenRepository
    {
        private readonly IHttpService httpService;
        private string url = "api/annualLeaveTaken";

        public AnnualLeaveTakenRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<AnnualLeaveTaken> GetAnnualLeaveTakenById(int id)
        {
            return await httpService.GetHelper<AnnualLeaveTaken>($"{url}/{id}");
        }
        public async Task<List<AnnualLeaveTaken>> GetAnnualLeaveTakenByRequestId(int id)
        {
            return await httpService.GetHelper<List<AnnualLeaveTaken>>($"{url}/byRequest/{id}");
        }

        public async Task<int> CreateAnnualLeaveTaken(AnnualLeaveTaken annualLeaveTaken)
        {
            var response = await httpService.Post<AnnualLeaveTaken, int>(url, annualLeaveTaken);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }

        public async Task UpdateAnnualLeaveTaken(AnnualLeaveTaken annualLeaveTaken)
        {
            var response = await httpService.Put(url, annualLeaveTaken);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
        public async Task DeleteAnnualLeaveTaken(int id)
        {
            var response = await httpService.Delete($"{url}/{id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

    }
}
