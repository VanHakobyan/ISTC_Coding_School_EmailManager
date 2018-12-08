using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EmailManager.Bll
{
    public class ContactResponseModel
    {
        public string FullName { get; set; }
        public string CompanyName { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
    }
}
