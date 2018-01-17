using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web.App_Code.Model;

namespace Team10AD_Web.Employee
{
    public partial class SelectCollection : System.Web.UI.Page
    {
        BusinessLogic b = new BusinessLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Employee emp = (Employee)Session["Employee"];
                //int employeeID = b.GetEmployee();
                int pointID = b.ShowCollectionPoint(61);
                rdoBtnSelectCollection.Items.FindByValue(pointID.ToString()).Selected = true;           
            }
        }

        protected void rdoBtnSelectCollection_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Employee emp = (Employee)Session["Employee"];
            //int employeeID = b.GetEmployee();
            string pointID = rdoBtnSelectCollection.SelectedValue;
           // string representativeID = b.GetEmployee();
            try
            {
                b.SelectCollection(pointID);
                
            }
            catch (Exception exp)
            {
                Response.Write(exp.ToString());
            }
        }
    }
}