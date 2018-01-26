using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web.Model;

namespace Team10AD_Web.Clerk
{
    public partial class DisbursementRecord : System.Web.UI.Page
    {
        BusinessLogic b = new BusinessLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dgvDisbursementRecord.DataSource = b.DisbursementRecords();
                dgvDisbursementRecord.DataBind();
                dgvDisbursementRecord.AllowPaging = true;
            }
        }

        protected void dgvDisbursementRecord_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "details")
            {
                GridViewRow gvRow = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                int disbursementID = Int32.Parse(gvRow.Cells[0].Text);
                Disbursement disbursement = b.GetDisbursement(disbursementID);
                Session["Disbursement"] = disbursement;
                int employeeid = (int)Session["employeeid"];
                Employee emp = b.GetEmployee(employeeid);
                Session["Employee"] = emp;
                Response.Redirect("DisbursementDetailsPage.aspx");
            }
        }

        protected void dgvDisbursementRecord_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvDisbursementRecord.PageIndex = e.NewPageIndex;
            dgvDisbursementRecord.DataSource = b.DisbursementRecords();
            dgvDisbursementRecord.DataBind();
        }
    }
}