using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailManager.Common;

namespace EmailManager.Bll
{
    public class ContactGenderSorting
    {
        public void Sort()
        {
            var SortedList = DB.DataBase.IstcContacts.OrderBy(s => s.Country).GroupBy(x => x.CompanyName).ToList();
            foreach (var item in SortedList)
            {
                
            }
        }

    }

}
