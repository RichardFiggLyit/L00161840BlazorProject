using L00161840BlazorProject.Client.Helpers;
using L00161840BlazorProject.Shared.DTOs;
using L00161840BlazorProject.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Client.Repository
{
        public class PayGroupRepository : IPayGroupRepository
    {
            private readonly IHttpService httpService;
            private string url = "api/payGroups";

            public PayGroupRepository(IHttpService httpService)
            {
                this.httpService = httpService;
            }

            
            public async Task<List<PayGroup>> GetPayGroups()
            {
                return await httpService.GetHelper<List<PayGroup>>(url);
            }

            public async Task<PayGroup> GetPayGroupById(int id)
            {
                return await httpService.GetHelper<PayGroup>($"{url}/{id}");
            }

            public async Task CreatePayGroup(PayGroup payGroup)
            {
                var response = await httpService.Post(url, payGroup);
                if (!response.Success)
                {
                    throw new ApplicationException(await response.GetBody());
                }
            }

            public async Task UpdatePayGroup(PayGroup payGroup)
            {
                var response = await httpService.Put(url, payGroup);
                if (!response.Success)
                {
                    throw new ApplicationException(await response.GetBody());
                }
            }

            public async Task DeletePayGroup(int Id)
            {
                var response = await httpService.Delete($"{url}/{Id}");
                if (!response.Success)
                {
                    throw new ApplicationException(await response.GetBody());
                }
            }
        }
    }

