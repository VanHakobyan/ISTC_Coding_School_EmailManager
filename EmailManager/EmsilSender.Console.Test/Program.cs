using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailManager.Bll;
using EmailManager.Common;
using EmailManager.DB;
using Newtonsoft.Json;

namespace EmsilSender.Console.Test
{
    class Program
    {
        static void Main(string[] args)
        {



            EmailSender send = new EmailSender();
            send.SendEmailByCompany("ISTC");

            var emailSender = new EmailSender();
            emailSender.SendEmail(new ContactModel { Email = "van19962013@mail.ru", CompanyName = "BetConstruct", Country = "Armenia", FullName = "Aram Zhamkochyan" });

        }
    }
}
