using SendGrid;
using SendGrid.Helpers.Mail;
using System.Collections.Generic;
using System.Configuration;

using System.Threading.Tasks;

namespace RxOutlet.Business
{
    public class SendEmail
    {

        // public Task SendOneEmail(string email, string firstName, string PrescriptionTitle)




        public Task SendOneEmail(string ActivationCode, string email, string FirstName)
        {
            var myMessage = new SendGridMessage()
            {
                From = new EmailAddress("savvyitsol@gmail.com", "RxOutlet"),
                Subject = " Confirmation Mail for Registration",
                PlainTextContent = "Hello " + FirstName + "!",
                HtmlContent = "<strong> Hello " + FirstName + "!</strong ><br /><br /> We're glad to have you onboard with RxOutlet! Please click the following link to activate your account<br /><a href =" + "http://rxoutlet.azurewebsites.net/Account/VerificationCode?ActivationCode=" + ActivationCode + ">Click here to activate your account.</a><br /><br />Thanks"
                //http://localhost:64404/Account/VerificationCode
            };
            myMessage.AddTo(new EmailAddress(email, "RxOutlet Confirmation Mail"));
            var apiKey = ConfigurationManager.AppSettings["Sendgrid_key"];
            var client = new SendGridClient(apiKey);
            var response = client.SendEmailAsync(myMessage);
            return response;
        }


        public Task SendOneEmail(List<string> MailDetails)
        {
            var myMessage = new SendGridMessage()
            {
                From = new EmailAddress("savvyitsol@gmail.com", "RxOutlet"),
                Subject = MailDetails[5],
                PlainTextContent = "Hello " + MailDetails[1] + "!",
                HtmlContent = MailDetails[4]  };
            myMessage.AddTo(new EmailAddress(MailDetails[0], MailDetails[3]));
            var apiKey = ConfigurationManager.AppSettings["Sendgrid_key"];
            var client = new SendGridClient(apiKey);
            var response = client.SendEmailAsync(myMessage);
            return response;
        }
    }
}