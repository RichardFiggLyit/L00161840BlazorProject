using L00161840BlazorProject.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Client.Repository
{
    interface IPayPeriodRepository
    {
        Task<int> CreatePayPeriod(PayPeriod payPeriod);
        Task DeletePayPeriod(int Id);
        Task<PayPeriod> GetPayPeriod(int payGroupId, int taxYear, int taxPeriod);
        Task<PayPeriod> GetPayPeriodById(int id);
        Task<List<PayPeriod>> GetPayPeriods();
        Task UpdatePayPeriod(PayPeriod payPeriod);
    }
}
