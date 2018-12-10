using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailManager.Common
{
    static class PeopleExtension
    {
        public static ContactModel GetContact(this PeopleModel people)
        {
            ContactModel myContact = new ContactModel();
            myContact.FullName = $"{people.FirstName} {people.LastName}";
            myContact.Email = people.Email;
            myContact.Country = people.Country;
            myContact.CompanyName = people.Company;

            return myContact;
        }
    }
}
