using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using EmailManager.Common;
using EmailManager.DB;
using Newtonsoft.Json;

namespace EmailManager.Bll
{
    public class EmailSender
    {
        private static readonly string ImageUrl = ConfigurationManager.AppSettings["ImageUrl"];
        
        private string GetMessageText(ContactModel contact)
        {
            try
            {
                return
                      DataBase.GetTemplate().Replace("{FullName}", contact.FullName)
                     .Replace("{Company}", contact.CompanyName)
                     .Replace("{ImageUrl}", ImageUrl)
                     .Replace("{DateTimeNow}", DateTime.UtcNow.ToString(CultureInfo.InvariantCulture));
            }
            catch
            {
                return "";
            }
        }

        public void SendEmail(ContactModel contact)
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


        public void SendEmailByCompany(string CompanyName)
        {
            var allContacts = DataBase.AllContacts;

            var allContactsGroup = allContacts.Where(a => a.CompanyName == CompanyName).Select(a => a);

            foreach (var item in allContactsGroup)
            {
                SendEmail(item);
            }
        }

        public void MultyEmailSender( List<ContactModel> contactModels)
        {
            foreach (var contact in contactModels)
            {
                SendEmail(contact);
            }
        }
        
    }
}
