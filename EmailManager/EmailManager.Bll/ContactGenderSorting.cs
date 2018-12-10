using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailManager.Common;
using EmailManager.DB;

namespace EmailManager.Bll
{
    public class ContactGenderSorting
    {
        public void Sort()
        {
            EmailSender emailSender = new EmailSender();
            var contacts = DataBase.IstcContacts.OrderBy(x => x.CompanyName).OrderBy(x => x.FullName).ToList();
            emailSender.MultyEmailSender(contacts);
        }

    }

}
