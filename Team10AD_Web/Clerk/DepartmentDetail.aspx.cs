using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web.Model;
using Team10AD_Web;

namespace Team10AD_Web.Clerk
{
    public partial class DepartmentDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string deptcode = (string) Session["departmentdetail"];
            Department dept = XpBizLogic.GetDepartmentByCode(deptcode);
            txtBoxDeptCode.Text = dept.DepartmentCode;
            txtBoxDeptName.Text = dept.DepartmentName;
            using (Team10ADModel context = new Team10ADModel())
            {
                Employee contactperson = context.Employees.Where(x => x.EmployeeID == dept.ContactPersonID).First();
                txtBoxContName.Text = contactperson.Name;
                txtBoxTelNum.Text = contactperson.Phone.ToString();
                Employee rep = context.Employees.Where(x => x.EmployeeID == dept.RepresentativeID).First();
                txtBoxRepName.Text = rep.Name;
                CollectionPoint point = context.CollectionPoints.Where(x => x.PointID == dept.PointID).First();
                txtBoxColPoint.Text = point.PointName;
            }
             
        }
    }
}