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
                Subject = " Confirmation Mail for Registration",
                PlainTextContent = "Hello " + FirstName + "!",
                HtmlContent = "<strong> Hello "+ FirstName + "!</strong ><br /><br /> We're glad to have you onboard with RxOutlet! Please click the following link to activate your account<br /><a href =" + "http://rxoutlet.azurewebsites.net/VerificationPage.html?ActivationCode=" + ActivationCode + ">Click here to activate your account.</a><br /><br />Thanks"
                //http://localhost:64404/Account/VerificationCode
            };
            myMessage.AddTo(new EmailAddress(email, "RxOutlet Confirmation Mail"));
            var apiKey = ConfigurationManager.AppSettings["Sendgrid_key"];
            var client = new SendGridClient(apiKey);
            var response = client.SendEmailAsync(myMessage);
            return response;
        }
        public Task SendOneEmail(string email, string FirstName, int PrescriptionID)
        {
            var myMessage = new SendGridMessage()
            {
                From = new EmailAddress("savvyitsol@gmail.com", "RxOutlet"),
                Subject = "Thank You Mail",
                PlainTextContent = "Hello " + FirstName + "!",
                HtmlContent = "<strong> Hello " + FirstName + "!</strong ><br /><br /> Thanks for sharing the information with us.</a> Your Transaction Prescription ID is TransactionID_" + PrescriptionID
            };
            myMessage.AddTo(new EmailAddress(email, "RxOutlet Confirmation Mail"));
            var apiKey = ConfigurationManager.AppSettings["Sendgrid_key"];
            var client = new SendGridClient(apiKey);
            var response = client.SendEmailAsync(myMessage);
            return response;
        }
    }
}