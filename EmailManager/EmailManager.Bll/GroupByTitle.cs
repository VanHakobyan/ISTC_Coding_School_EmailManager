using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailManager.Common;

namespace EmailManager.Bll
{
    class GroupByTitle
    {
        public static void SortByCompany(List<PeopleModel> models)
        {
            var companys = models.Select(s => s.Company).OrderByDescending(o=>o).ToList();

                        



        }
    }
}
