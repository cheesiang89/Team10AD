using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web.Model;

namespace Team10AD_Web.EmployeePage
{
    public partial class DepartmentDetail : System.Web.UI.Page
    {
        BusinessLogic b = new BusinessLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int employeeid = (int)Session["employeeid"];
                txtBoxRepName.Text = b.GetEmployeeName(employeeid);
                txtBoxCollectionPt.Text = b.ShowCollectionPointName(employeeid);
            }
        }
    }
}