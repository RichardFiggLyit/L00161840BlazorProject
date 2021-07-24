using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Client.Auth
{
    public class DummyAuthenticationStateProvider : AuthenticationStateProvider
    {
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            //await Task.Delay(3000);
            var anonymous = new ClaimsIdentity(new List<Claim>() {
                new Claim(ClaimTypes.Name,"Richard"),
                new Claim(ClaimTypes.Role,"Employee"),
                new Claim("Company","55")
            },"Test");
                 
            
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));
        }
    }
}
