using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web.App_Code.Model;

namespace Team10AD_Web.EmployeePage
{
    public partial class SelectCollection : System.Web.UI.Page
    {
        BusinessLogic b = new BusinessLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            int employeeid = (int)Session["employeeid"];
            if (!IsPostBack)
            {
                int pointID = b.ShowCollectionPointID(employeeid);
                rdoBtnSelectCollection.Items.FindByValue(pointID.ToString()).Selected = true;
            }
        }

        protected void rdoBtnSelectCollection_SelectedIndexChanged(object sender, EventArgs e)
        {
            int employeeid = (int)Session["employeeid"];
            string pointID = rdoBtnSelectCollection.SelectedValue;
           // string representativeID = b.GetEmployee();
            try
            {
                b.SelectCollection(pointID, employeeid);
                lblSelection.Visible = true;
                lblSelection.Text = b.ShowCollectionPointName(employeeid) + " is successfully selected!";

            }
            catch (Exception exp)
            {
                Response.Write(exp.ToString());
            }
        }
    }
}