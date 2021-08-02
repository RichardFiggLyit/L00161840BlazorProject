using L00161840BlazorProject.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Client.Repository
{
    interface IPayDataRepository
    {
        Task<int> CreatePayData(PayData payData);
        Task DeletePayData(int Id);
        Task<PayData> GetPayDataById(int id);
        Task<List<PayData>> GetPayDatum();
        Task UpdatePayData(PayData payData);
    }
}
