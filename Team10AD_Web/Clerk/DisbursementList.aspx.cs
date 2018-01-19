using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web.App_Code.Model;

namespace Team10AD_Web.Clerk
{
    public partial class DisbursementRecord : System.Web.UI.Page
    {
        BusinessLogic b = new BusinessLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Team10ADModel tm = new Team10ADModel();
                //var qry = from d in tm.Disbursements select new { d.DisbursementID, d.CollectionDate, d.Department.DepartmentName, d.CollectionPoint.PointName, d.Department.Employee.Name, d.Status };
                dgvDisbursementRecord.DataSource = b.DisbursementRecords();
                dgvDisbursementRecord.DataBind();
            }
        }

        protected void dgvDisbursementRecord_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "details")
            {
                GridViewRow gvRow = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                int disbursementID = Int32.Parse(gvRow.Cells[0].Text);
                //string collectionDate = gvRow.Cells[1].Text;
                //string status = gvRow.Cells[5].Text;
                Disbursement disbursement = b.GetDisbursement(disbursementID);
                Session["Disbursement"] = disbursement;
                Response.Redirect("DisbursementDetailsPage.aspx");
            }
        }
    }
}