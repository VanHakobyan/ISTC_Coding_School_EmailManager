using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Mail;
using Newtonsoft.Json;

namespace EmailManager.Bll
{
    public class EmailSender
    {
        private List<ContactResponseModel> contactResponseModels;

        public EmailSender()
        {
            var json = File.ReadAllText($"{Directory.GetCurrentDirectory()}/contacts.json");
            var contacts = JsonConvert.DeserializeObject<List<Profile>>(json);
            FactoryModel(contacts);
        }

        private void FactoryModel(List<Profile> contacts)
        {
            contactResponseModels = new List<ContactResponseModel>();
            foreach (var contact in contacts)
            {
                contactResponseModels.Add(new ContactResponseModel { Email = contact.eMail, FullName = contact.Nickname });
            }
        }

        private string GetMessageText(ContactResponseModel contact)
        {
            try
            {
                var templateText = File.ReadAllText("E:\\Template.html");
                return
                    templateText.Replace("{FullName}", contact.FullName)
                     .Replace("{Company}", contact.CompanyName)
                     .Replace("{ImageUrl}", $"")
                     .Replace("{DateTimeNow}", DateTime.UtcNow.ToString(CultureInfo.InvariantCulture));
            }
            catch
            {
                return "";
            }
        }

        public void SendEmail(ContactResponseModel contact)
        {

            using (var msg = new MailMessage())
            {

                msg.To.Add(contact.Email);
                msg.From = new MailAddress("ISTCCsharp@gmail.com");

                msg.Subject = "ISTC Project";
                msg.IsBodyHtml = true;
                msg.Body = GetMessageText(contact);

                var client = new SmtpClient
                {
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                };

                try
                {
                    client.Send(msg);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }

        }

        public void SendEmailList(int count)
        {
            for (int i = 0; i < count; i++)
                SendEmail(contactResponseModels[i]);
        }

    }
}
