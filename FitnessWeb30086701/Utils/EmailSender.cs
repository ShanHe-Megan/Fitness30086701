using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FitnessWeb30086701.Utils
{
    public class EmailSender
    {
        // Please use your API KEY here.
        private const String API_KEY = "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";

        public void Send(String toEmail, String subject, String contents)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("meganhe307@gmail.com", "FIT5032 Example Email User");
            var to = new EmailAddress(toEmail, "meganhe307@gmail.com");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
        }

    }
}