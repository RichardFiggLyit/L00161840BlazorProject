using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L00161840BlazorProject.Shared.Entities
{
    public class MailRequest
    {
        public string FromEmail { get; set; }
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public MailRequest(string fromEmail, string toEmail, string subject, string body)
        {
            FromEmail = fromEmail;
            ToEmail = toEmail;
            Subject = subject;
            Body = body;
        }
    }
}
