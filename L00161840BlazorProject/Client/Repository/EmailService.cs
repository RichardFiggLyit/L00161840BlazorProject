using L00161840BlazorProject.Client.Helpers;
using L00161840BlazorProject.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Client.Repository
{
    public class EmailService : IEmailService
    {
        private readonly IHttpService httpService;
        private string url = "api/email";


        public EmailService(IHttpService httpService)
        {
            this.httpService = httpService;
        }
        public async Task SendEmail(string from, string to, string subject, string body)
        {
            MailRequest mailRequest = new MailRequest(from, to, subject, body);

                var response = await httpService.Put(url, mailRequest);
                if (!response.Success)
                {
                    throw new ApplicationException(await response.GetBody());
                }
            

        }
    }
}
