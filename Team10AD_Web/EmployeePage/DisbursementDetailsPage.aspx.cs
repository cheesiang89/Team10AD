using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web.App_Code.Model; 

namespace Team10AD_Web.EmployeePage
{
    public partial class DisbursementDetailsPage : System.Web.UI.Page
    {
        BusinessLogic b = new BusinessLogic();
        protected void Page_Load(object sender, EventArgs e)
        {       
            string collected = "Collected";
            string uncollected = "Uncollected";
            if (!IsPostBack)
            {
                Disbursement disbursement = (Disbursement)Session["Disbursement"];
                lblDisList2.Text = disbursement.DisbursementID.ToString();
                lblDepName2.Text = disbursement.Department.DepartmentName;
                lblSts2.Text = disbursement.Status;
                if (lblSts2.Text == collected)
                {
                    lblSts2.CssClass = "text-primary";
                }
                else if (lblSts2.Text == uncollected)
                {
                    lblSts2.CssClass = "text-danger";
                }
                lblColDate2.Text = (Convert.ToDateTime(disbursement.CollectionDate)).ToString("dd-MMM-yyyy");
                Team10AD_Web.App_Code.Model.Employee emp = (Team10AD_Web.App_Code.Model.Employee)Session["Employee"];
                lblEmpName2.Text = (emp.Name).ToString();
                lblEmpEmailAdd2.Text = emp.Email;
                lblDeptRepName2.Text = b.GetEmployeeName(disbursement.Department.RepresentativeID);
                Image1.ImageUrl = "~/Images/" + disbursement.DisbursementID + ".png";
                dgvDisList.DataSource = b.ShowDisbursementDetails(disbursement.DisbursementID);
                dgvDisList.DataBind();

            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("DisbursementList.aspx");
        }
    }
}