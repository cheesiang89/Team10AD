using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team10AD_Web.App_Code.Model;

namespace Team10AD_Web.App_Code
{
    public static class BusinessLogic
    {
        public static List<Catalogue> SearchCatalogue(string search)
        {
            using (Team10ADModel context = new Team10ADModel())
            {
                return context.Catalogues.Where(x => x.Description == search).ToList<Catalogue>();
            }
        }
    }
}