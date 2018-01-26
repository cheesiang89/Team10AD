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
            if (((int)Session["employeeid"])==((int)Session["ApproverID"]))
            {
                reqStatus.Visible = false;
            }
            else
            {
                reqStatus.Visible = true;
                deptReq.Visible = false;
            }
            
        }
    }
}