using L00161840BlazorProject.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Client.Repository
{
    public interface IInviteRepository
    {

        Task<Invite> CreateInvite(Invite invite);
        Task<Invite> GetInviteFromReference(string inviteReference);
    }
}
