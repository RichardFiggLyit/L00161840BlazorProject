using L00161840BlazorProject.Client.Helpers;
using L00161840BlazorProject.Shared.DTOs;
using L00161840BlazorProject.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Client.Repository
{
    public class InviteRepository : IInviteRepository
    {
        private readonly IHttpService httpService;
        private string url = "api/invites";


        public InviteRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }


 

        public async Task<Invite> GetInviteFromReference(string inviteReference)
        {
            return await httpService.GetHelper<Invite>($"{url}/{inviteReference}");
        }

        public async Task<Invite> CreateInvite(Invite invite)
        {
            var response = await httpService.Post<Invite,Invite>(url, invite);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
            return response.Response;
        }

        public async Task UpdateInvite(Invite invite)
        {
            var response = await httpService.Put(url, invite);
            if (!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }


    }
}
