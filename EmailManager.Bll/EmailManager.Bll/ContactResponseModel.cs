using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EmailManager.Bll
{
    public class ContactResponseModel
    {
        [JsonProperty("Full Name")]
        public string FullName { get; set; }
        [JsonProperty("Company Name")]
        public string CompanyName { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
    }
}
