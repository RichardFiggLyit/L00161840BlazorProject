using L00161840BlazorProject.Client.Helpers;
using L00161840BlazorProject.Shared.DTOs;
using L00161840BlazorProject.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Client.Repository
{
    public class PayPeriodRepository : IPayPeriodRepository
    {
        private readonly IHttpService httpService;
        private string url = "api/payPeriods";

        public PayPeriodRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }


        public async Task<List<PayPeriod>> GetPayPeriods()
        {
            return await httpService.GetHelper<List<PayPeriod>>(url);
        }

        public async Task<PayPeriod> GetPayPeriodById(int id)
        {
            return await httpService.GetHelper<PayPeriod>($"{url}/{id}");
        }

        public async Task<PayPeriod> GetPayPeriod(int payGroupId, int taxYear, int taxPeriod)
        {
            return await httpService.GetHelper<PayPeriod>($"{url}/{payGroupId}/{taxYear}/{taxPeriod}");
        }

        public async Task<int> CreatePayPeriod(PayPeriod payPeriod)
        {
            var response = await httpService.Post<PayPeriod, int>(url, payPeriod);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }

        public async Task UpdatePayPeriod(PayPeriod payPeriod)
        {
            var response = await httpService.Put(url, payPeriod);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task DeletePayPeriod(int Id)
        {
            var response = await httpService.Delete($"{url}/{Id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}

