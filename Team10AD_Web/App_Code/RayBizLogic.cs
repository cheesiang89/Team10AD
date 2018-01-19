using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team10AD_Web.App_Code.Model;

namespace Team10AD_Web.App_Code
{
    public static class RayBizLogic
    {
        public static List<Catalogue> SearchCatalogue(string search)
        {
            using (Team10ADModel context = new Team10ADModel())
            {
                return context.Catalogues.Where(x => x.Description.Contains(search) || x.Category.Contains(search)).ToList();
            }
        }

        public static List<Catalogue> CatalogueList()
        {
            using (Team10ADModel context = new Team10ADModel())
            {
                return context.Catalogues.ToList();
            }
        }

        public static string DepartmentId(string email)
        {
            using (Team10ADModel context = new Team10ADModel())
            {
                Model.Employee emp = context.Employees.Where(x => x.Email == email).First();
                return emp.DepartmentCode;
            }
        }

        public static int EmployeeId(string email)
        {
            using (Team10ADModel context = new Team10ADModel())
            {
                Model.Employee emp = context.Employees.Where(x => x.Email == email).First();
                return emp.EmployeeID;
            }
        }

        public static Model.Employee EmployeeObjById(int id)
        {
            using (Team10ADModel context = new Team10ADModel())
            {
                Model.Employee emp = context.Employees.Where(x => x.EmployeeID == id).First();
                return emp;
            }
        }

        public static List<Requisition> RequisitionList()
        {
            using (Team10ADModel context = new Team10ADModel())
            {
                return context.Requisitions.ToList();
            }
        }

        public static Requisition GetRequisitionById(string id)
        {
            int reqid = Convert.ToInt32(id);
            using (Team10ADModel context = new Team10ADModel())
            {
                Requisition req = context.Requisitions.Where(x => x.RequisitionID == reqid).First();
                return req;
            }
        }

        public static void CancelRequisition(int reqid)
        {
            using (Team10ADModel context = new Team10ADModel())
            {
                App_Code.Model.Requisition req = context.Requisitions.Where(x => x.RequisitionID == reqid).First();
                req.Status = "Cancelled";
                context.SaveChanges();
            }
        }
    }
}