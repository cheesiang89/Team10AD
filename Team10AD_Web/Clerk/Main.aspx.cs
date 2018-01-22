using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web.App_Code;
using Team10AD_Web.App_Code.Model;

namespace Team10AD_Web.Clerk
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string status = "True";
                Team10ADModel context = new Team10ADModel();
                var qry = from r in context.Catalogues where r.ShortfallStatus == status select new { r.ItemCode, r.Description,r.ReorderLevel,r.PendingRequestQuantity,r.BalanceQuantity};
                dgvAlertLowSto.DataSource = qry.ToList();
                dgvAlertLowSto.DataBind();

                var query = from r in context.Requisitions where (r.Status == "Approved" || r.Status == "Partial") select new { r.RequisitionID, r.ApprovalDate, r.Employee.Department.DepartmentName, r.Status };
                dgvReqPendCol.DataSource = query.ToList();
                dgvReqPendCol.DataBind();
            }           
        }

        protected string SuggestedOrderQty(int ReorderLevel,int PendingRequestQuantity, int BalanceQuantity)
        {
            int suggestedQty = ReorderLevel + PendingRequestQuantity - BalanceQuantity;
            return suggestedQty.ToString();
        }

        protected void btnCreatePO_Click(object sender, EventArgs e)
        {
            Response.Redirect("PurchaseOrderPage.aspx");
        }

        protected void btnGoReqRec_Click(object sender, EventArgs e)
        {
            Response.Redirect("RequisitionRecord.aspx");
        }
    }
}