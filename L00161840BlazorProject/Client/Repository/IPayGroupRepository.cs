using L00161840BlazorProject.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Client.Repository
{
    public interface IPayGroupRepository
    {
        Task CreatePayGroup(PayGroup payGroup);
        Task DeletePayGroup(int Id);
        Task<PayGroup> GetPayGroupById(int id);
        Task<List<PayGroup>> GetPayGroups();
        Task UpdatePayGroup(PayGroup payGroup);
    }
}
