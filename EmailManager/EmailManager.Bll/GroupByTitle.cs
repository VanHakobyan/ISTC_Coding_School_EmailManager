using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailManager.Common;
using EmailManager.DB;

namespace EmailManager.Bll
{
    class GroupByTitle
    {
        private EmailSender _emailSender;

        public GroupByTitle()
        {
            _emailSender = new EmailSender();
        }

        public void SendSeveralEmails()
        {
            var sortedContacts = DataBase.IstcContacts.OrderByDescending(o => o.CompanyName);

            foreach (var item in sortedContacts)
            {
                _emailSender.SendEmail(item);
            }
        }
    }
}
