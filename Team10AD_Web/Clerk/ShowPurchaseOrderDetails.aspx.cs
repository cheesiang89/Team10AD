using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web.Model;

namespace Team10AD_Web.Clerk
{
    public partial class ShowPurchaseOrderDetails : System.Web.UI.Page
    {
        BusinessLogic b = new BusinessLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int POID = (int)Session["POID"];
                PurchaseOrder po = b.GetPurchaseOrder(POID);
                lblpoid.Text = POID.ToString();
                lblDate2.Text = (Convert.ToDateTime(po.CreationDate)).ToString();
                lblSupplier2.Text = po.Supplier.SupplierName;   
                dgvPODetails.DataSource = b.ShowPurchaseOrderDetail(po.PurchaseOrderDetails.);
                dgvPODetails.DataBind();
                dgvPODetails.AllowPaging = true;
            }
        }

        protected void dgvPODetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvPODetails.PageIndex = e.NewPageIndex;
            dgvPODetails.DataSource = b.ShowPurchaseOrders();
            dgvPODetails.DataBind();
        }
    }
}