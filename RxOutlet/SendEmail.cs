﻿using SendGrid;
using System.Configuration;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace RxOutlet
{
    public class SendEmail
    {
        public Task SendOneEmail(string email, string firstName, string PrescriptionTitle)
        {
            var myMessage = new SendGridMessage()
            {
                From = new EmailAddress("savvyitsol@gmail.com", "RxOutlet"),
                Subject = " Confirmation Mail for Uploading Prescription",
                PlainTextContent = "Hello " + firstName + "!",
                HtmlContent = "<strong>Hello " + firstName + "!</strong><br /><br />Confirmation Mail</a><br /><br />Thanks"
            };
          
            myMessage.AddTo(new EmailAddress(email, "RxOutlet Confirmation Mail"));
            var apiKey = ConfigurationManager.AppSettings["Sendgrid_key"];
            var client = new SendGridClient(apiKey);
            var response = client.SendEmailAsync(myMessage);
            return response;
        }
    }
}