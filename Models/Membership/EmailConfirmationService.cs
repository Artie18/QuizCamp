using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace QuizCamp.Models.Membership
{
    public class EmailConfirmationService
    {
        public static void SendConfirmationMarkerToEmail(string confirmationMarker, string email)
        {
            //string confirmationGuid = user.ProviderUserKey.ToString();
            string verifyUrl = string.Format("{0}account/verify?ID={1}", GetPublicUrl(), confirmationMarker);
            string from = "artyomvirusnyak@gmail.com"; //ConfigurationManager.AppSettings["MvcConfirmationEmailFromAccount"];

            var message = new MailMessage(from, email)
            {
                Subject = "Please confirm your email",
                Body = verifyUrl,
                Sender = new MailAddress(from),
            };
            var client = new SmtpClient("smtp.gmail.com");
            client.Credentials = new NetworkCredential(from, "franklinthedetectivedog");
            client.EnableSsl = true;
            client.Send(message);

        }

        public static string GetPublicUrl()
        {
            var request = HttpContext.Current.Request;

            var uriBuilder = new UriBuilder
            {
                Host = request.Url.Host,
                Path = "/",
                Port = 80,
                Scheme = "http",
            };

            if (request.IsLocal)
            {
                uriBuilder.Port = request.Url.Port;
            }

            return new Uri(uriBuilder.Uri.ToString()).AbsoluteUri;
        }

        public static User GetCurrentUser(DataContext context)
        {
            return context.Users.FirstOrDefault(user => user.Username == WebSecurity.User.Identity.Name);
        }
    }
}