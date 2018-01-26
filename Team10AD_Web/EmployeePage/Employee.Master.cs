using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team10AD_Web.EmployeePage
{
    public partial class Employee : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            reqStatus.Attributes["href"] = "~/EmployeePage/RequisitionStatus";
            deptReq.Attributes["href"] = "~/EmployeePage/DepartmentRequisition";
            if (((int)Session["employeeid"])==((int)Session["ApproverID"]))
            {
                deptReq.Visible = true;
            }
            else
            {
                reqStatus.Visible = true;
               
            }
            
        }
    }
}