using L00161840BlazorProject.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Client.Repository
{
    interface IPayItemRepository
    {
        Task CreatePayItem(PayItem payItem);
        Task DeletePayItem(int Id);
        Task<PayItem> GetPayItemById(int id);
        Task<List<PayItem>> GetPayItems();
        Task UpdatePayItem(PayItem payItem);
    }
}
