using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web.App_Code.Model;

namespace Team10AD_Web.Employee
{
    public partial class DepartmentDetail : System.Web.UI.Page
    {
        BusinessLogic b = new BusinessLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Employee emp = (Employee)Session["Employee"];
                txtBoxRepName.Text = b.GetEmployeeName(61);
                txtBoxCollectionPt.Text = b.ShowCollectionPointName(61);
            }
        }
    }
}