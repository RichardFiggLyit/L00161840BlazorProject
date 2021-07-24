using L00161840BlazorProject.Server.Helpers;
using L00161840BlazorProject.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly EmailConfiguration emailConfiguration;
        public EmailController(IOptions<EmailConfiguration> options)
        {
            emailConfiguration = options.Value;
        }
        [HttpPut]
        public void Put(MailRequest mail)
        {

            var client = new SmtpClient(emailConfiguration.Host, emailConfiguration.Port)
            {
                Credentials = new NetworkCredential(emailConfiguration.Username, emailConfiguration.Password),
                EnableSsl = true
            };
            client.Send(mail.FromEmail, mail.ToEmail, mail.Subject, mail.Body);


        }
    }
}
