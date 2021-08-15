using L00161840BlazorProject.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Client.Repository
{
    public interface IAnnualLeaveTakenRepository
    {
        Task<int> CreateAnnualLeaveTaken(AnnualLeaveTaken annualLeaveTaken);
        Task DeleteAnnualLeaveTaken(int id);
        Task<AnnualLeaveTaken> GetAnnualLeaveTakenById(int id);
        Task<List<AnnualLeaveTaken>> GetAnnualLeaveTakenByRequestId(int id);
        Task UpdateAnnualLeaveTaken(AnnualLeaveTaken annualLeaveTaken);
    }
}
