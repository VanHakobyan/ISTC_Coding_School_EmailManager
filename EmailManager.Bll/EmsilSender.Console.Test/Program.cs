using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailManager.Bll;

namespace EmsilSender.Console.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            EmailSender emailSender=new EmailSender();
            emailSender.SendEmail(new ContactResponseModel{Email = "vanhakobyan1996@gmail.com",CompanyName ="ISTC",Country = "Armenia",FullName = "Vanik Hakobyan"});
        }
    }
}
