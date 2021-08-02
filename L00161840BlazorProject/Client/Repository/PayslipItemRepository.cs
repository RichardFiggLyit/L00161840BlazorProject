using L00161840BlazorProject.Client.Helpers;
using L00161840BlazorProject.Shared.DTOs;
using L00161840BlazorProject.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Client.Repository
{
    public class PayslipItemRepository : IPayslipItemRepository
    {
        private readonly IHttpService httpService;
        private string url = "api/payslipItems";

        public PayslipItemRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }


        public async Task<List<PayslipItem>> GetPayslipItems()
        {
            return await httpService.GetHelper<List<PayslipItem>>(url);
        }

        public async Task<PayslipItem> GetPayslipItemById(int id)
        {
            return await httpService.GetHelper<PayslipItem>($"{url}/{id}");
        }

        public async Task CreatePayslipItem(PayslipItem payslipItem)
        {
            var response = await httpService.Post(url, payslipItem);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task UpdatePayslipItem(PayslipItem payslipItem)
        {
            var response = await httpService.Put(url, payslipItem);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task DeletePayslipItem(int Id)
        {
            var response = await httpService.Delete($"{url}/{Id}");
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}

