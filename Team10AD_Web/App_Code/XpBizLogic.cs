using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team10AD_Web.App_Code.Model;

namespace Team10AD_Web.App_Code
{
    public static class XpBizLogic
    {
        public static List<Department> DepartmentList()
        {
            using (Team10ADModel context = new Team10ADModel())
            {
                return context.Departments.ToList<Department>();
                //var qry = from x in context.Departments select new Department { x.DepartmentCode, x.DepartmentName, x.Employee.Name };
                //return qry.ToList<Department>();
            }
        }

        public static Department GetDepartmentByCode(string code)
        {
            using (Team10ADModel context = new Team10ADModel())
            {
                Department department = context.Departments.Where(x => x.DepartmentCode == code).First();
                return department;
            }
        }
        public static Catalogue GetLowStockByStatus(string status)
        {
            using (Team10ADModel context = new Team10ADModel())
            {
                Catalogue catalogue = context.Catalogues.Where(x => x.ShortfallStatus == status).First();
                return catalogue;

            }
        }
    }
}