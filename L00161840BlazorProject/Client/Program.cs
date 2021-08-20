using L00161840BlazorProject.Client.Auth;
using L00161840BlazorProject.Client.Helpers;
using L00161840BlazorProject.Client.Repository;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Radzen;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //System.Diagnostics.Debugger.Launch();
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            ConfigureServices(builder.Services);
            await builder.Build().RunAsync();
        }

        private static void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<IHttpService, HttpService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IAccountsRepository, AccountsRepository>();
            services.AddScoped<IUsersRepository, UserRepository>();
            services.AddScoped<IInviteRepository, InviteRepository>();
            services.AddScoped<IPayGroupRepository, PayGroupRepository>();
            services.AddScoped<IPayPeriodRepository, PayPeriodRepository>();
            services.AddScoped<IPayItemRepository, PayItemRepository>();
            services.AddScoped<IPayDataRepository, PayDataRepository>();
            services.AddScoped<IPayslipItemRepository, PayslipItemRepository>();

            services.AddScoped<IAnnualLeaveTakenRepository, AnnualLeaveTakenRepository>();
            services.AddScoped<IAnnualLeaveEntitlementRepository, AnnualLeaveEntitlementRepository>();
            services.AddScoped<IAnnualLeaveRequestRepository, AnnualLeaveRequestRepository>();


            services.AddScoped<DialogService>();
            services.AddScoped<NotificationService>();
            services.AddScoped<TooltipService>();
            services.AddScoped<ContextMenuService>();

            
            services.AddAuthorizationCore();

            services.AddScoped<JWTAuthenticationStateProvider>();
            services.AddScoped<AuthenticationStateProvider, JWTAuthenticationStateProvider>(
                provider => provider.GetRequiredService<JWTAuthenticationStateProvider>()
                );

            services.AddScoped<ILoginService, JWTAuthenticationStateProvider>(
                provider => provider.GetRequiredService<JWTAuthenticationStateProvider>()
                );


            services.AddAuthorizationCore();

            services.AddScoped<JWTAuthenticationStateProvider>();
            services.AddScoped<AuthenticationStateProvider, JWTAuthenticationStateProvider>(
                provider=> provider.GetRequiredService<JWTAuthenticationStateProvider>());
            services.AddScoped<ILoginService, JWTAuthenticationStateProvider>(
                provider => provider.GetRequiredService<JWTAuthenticationStateProvider>());
            services.AddScoped<TokenRenewer>();

        }
    }
}
