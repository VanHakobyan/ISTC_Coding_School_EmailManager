using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailManager.Common
{
  public  class PeopleModel
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string Company { get; set; }
        public string Title { get; set; }

        public PeopleModel()
        {

        }

        public PeopleModel(string email, string phone, string country, string company,string title)
        {
            Email = email;
            Phone = phone;
            Country = country;
            Company = company;
            Title = title;
        }
        
    }
}
