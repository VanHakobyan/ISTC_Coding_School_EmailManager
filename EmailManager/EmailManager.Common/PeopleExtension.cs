﻿using System;
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
            //Asta masta
            // Edvin :P
            //Astan shash a msov tchash a
            ContactModel myContact = new ContactModel
            {
                FullName = $"{people.FirstName} {people.LastName}",
                Email = people.Email,
                Country = people.Country,
                CompanyName = people.Company
            };
            return myContact;
        }
    }
}
