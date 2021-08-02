using L00161840BlazorProject.Client.Helpers;
using L00161840BlazorProject.Shared.DTOs;
using L00161840BlazorProject.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Client.Repository
{
    public class PayItemRepository : IPayItemRepository
    {
        private readonly IHttpService httpService;
        private string url = "api/payItems";

        public PayItemRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }


        public async Task<List<PayItem>> GetPayItems()
        {
            return await httpService.GetHelper<List<PayItem>>(url);
        }

        public async Task<PayItem> GetPayItemById(int id)
        {
            return await httpService.GetHelper<PayItem>($"{url}/{id}");
        }

        public async Task CreatePayItem(PayItem payItem)
        {
            var response = await httpService.Post(url, payItem);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task UpdatePayItem(PayItem payItem)
        {
            var response = await httpService.Put(url, payItem);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task DeletePayItem(int Id)
        {
            var response = await httpService.Delete($"{url}/{Id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}

