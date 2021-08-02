using L00161840BlazorProject.Client.Helpers;
using L00161840BlazorProject.Shared.DTOs;
using L00161840BlazorProject.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Client.Repository
{
    public class PayDataRepository : IPayDataRepository
    {
        private readonly IHttpService httpService;
        private string url = "api/payDatum";

        public PayDataRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }


        public async Task<List<PayData>> GetPayDatum()
        {
            return await httpService.GetHelper<List<PayData>>(url);
        }

        public async Task<PayData> GetPayDataById(int id)
        {
            return await httpService.GetHelper<PayData>($"{url}/{id}");
        }

        public async Task<int> CreatePayData(PayData payData)
        {
            var response = await httpService.Post<PayData,int>(url, payData);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }

        public async Task UpdatePayData(PayData payData)
        {
            var response = await httpService.Put(url, payData);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task DeletePayData(int Id)
        {
            var response = await httpService.Delete($"{url}/{Id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}

