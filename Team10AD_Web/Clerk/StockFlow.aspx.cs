using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web.App_Code.Model;

namespace Team10AD_Web.Clerk
{
    public partial class StockCheck : System.Web.UI.Page
    {
        BusinessLogic b = new BusinessLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Catalogue catalogue = (Catalogue)Session["Catalogue"];
                lblItemCode2.Text = catalogue.ItemCode;
                lblItemDesc2.Text = catalogue.Description;
                lblLoc2.Text = catalogue.Location;
                lblqty2.Text = catalogue.BalanceQuantity.ToString();
                lblUOM2.Text = catalogue.UnitOfMeasure;
                dgvHstTrans.DataSource = b.ShowStockFlow(catalogue.ItemCode);
                dgvHstTrans.DataBind();
                dgvHstTrans.AllowPaging = true;
            }
        }

        protected void dgvHstTrans_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Catalogue catalogue = (Catalogue)Session["Catalogue"];
            dgvHstTrans.PageIndex = e.NewPageIndex;
            dgvHstTrans.DataSource = b.ShowStockFlow(catalogue.ItemCode);
            dgvHstTrans.DataBind();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inventory.aspx");
        }
    }
}