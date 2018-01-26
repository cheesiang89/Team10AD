using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team10AD_Web.Clerk
{
    public partial class PurchaseOrderPage : System.Web.UI.Page
    {
        BusinessLogic b = new BusinessLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dgvPORecord.DataSource = b.ShowPurchaseOrders();
                dgvPORecord.DataBind();
                dgvPORecord.AllowPaging = true;
            }
        }

        protected void dgvPORecord_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvPORecord.PageIndex = e.NewPageIndex;
            dgvPORecord.DataSource = b.ShowPurchaseOrders();
            dgvPORecord.DataBind();
        }

        protected void dgvPORecord_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Details")
            {
                GridViewRow gvRow = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                int POID = Int32.Parse(gvRow.Cells[0].Text);
                Session["POID"] = POID;
                Response.Redirect("ShowPurchaseOrderDetails.aspx");
            }
        }
    }
}