using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailManager.Common;
using Newtonsoft.Json;


namespace EmailManager.DB
{
    public static class DataBase
    {
        public static List<ContactModel> AllContacts = new List<ContactModel>();
        public static List<ContactModel> GetContacts()
        {
            var json = File.ReadAllText($"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName}\\statics\\contacts.json");
            var contacts = JsonConvert.DeserializeObject<List<Profile>>(json);
            var contactModels = FactoryModel(contacts);
            AllContacts.AddRange(contactModels);
            return contactModels;
        }


        private static List<ContactModel> FactoryModel(List<Profile> contacts)
        {
            List<ContactModel> contactModels = new List<ContactModel>();
            foreach (var contact in contacts)
            {
                contactModels.Add(new ContactModel { Email = contact.eMail, FullName = contact.Nickname });
            }

            return contactModels;
        }

        public static string GetTemplate(string name = "Template")
        {
            return File.ReadAllText($"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName}\\statics\\{name}.html");
        }

        public static List<string> GetCompanies()
        {
            return new List<string>();
        }

        public static List<ContactModel> GetISTCContacts()
        {
            var json = File.ReadAllText($"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName}\\statics\\Employee.json");
            var contacts = JsonConvert.DeserializeObject<List<ContactModel>>(json);
            AllContacts.AddRange(contacts);
            return contacts;
        }

        public static void Init()
        {
            GetISTCContacts();
            GetContacts();
        }

    }
}
