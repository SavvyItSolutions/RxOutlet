using SendGrid;
using SendGrid.Helpers.Mail;
using System.Configuration;

using System.Threading.Tasks;

namespace RxOutlet
{
    public class SendEmail
    {

       // public Task SendOneEmail(string email, string firstName, string PrescriptionTitle)
        

        public Task SendOneEmail(string email)
        {
            var myMessage = new SendGridMessage()
            {
                From = new EmailAddress("savvyitsol@gmail.com", "RxOutlet"),
                Subject = " Confirmation Mail for Uploading Prescription",
                PlainTextContent = "Hello " ,
                HtmlContent = "</strong><br /><br />Confirmation Mail</a><br /><br />Thanks"
            };

            myMessage.AddTo(new EmailAddress(email, "RxOutlet Confirmation Mail"));
            var apiKey = ConfigurationManager.AppSettings["Sendgrid_key"];
            var client = new SendGridClient(apiKey);
            var response = client.SendEmailAsync(myMessage);
            return response;
        }
        public Task SendOneEmail(string ActivationCode,string email,string FirstName)
        {
            var myMessage = new SendGridMessage()
            {
                From = new EmailAddress("savvyitsol@gmail.com", "RxOutlet"),
                Subject = " Confirmation Mail for Uploading Prescription",
                PlainTextContent = "Hello " + FirstName + "!",
                HtmlContent = " < strong > Hello "+ FirstName + "!</ strong >< br />< br /> We're glad to have you onboard with WineOutlet! Please click the following link to activate your account<br /><a href =" + "http://localhost:64404/VerificationPage.html?ActivationCode=" + ActivationCode + ">Click here to activate your account.</a><br /><br />Thanks"
            };
            myMessage.AddTo(new EmailAddress(email, "RxOutlet Confirmation Mail"));
            var apiKey = ConfigurationManager.AppSettings["Sendgrid_key"];
            var client = new SendGridClient(apiKey);
            var response = client.SendEmailAsync(myMessage);
            return response;
        }
    }
}