using L00161840BlazorProject.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Client.Repository
{
    interface IPayslipItemRepository
    {
        Task CreatePayslipItem(PayslipItem payslipItem);
        Task DeletePayslipItem(int Id);
        Task<PayslipItem> GetPayslipItemById(int id);
        Task<List<PayslipItem>> GetPayslipItems();
        Task UpdatePayslipItem(PayslipItem payslipItem);
    }
}
