using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web.App_Code;
using Team10AD_Web.Clerk;

namespace Team10AD_Web.Clerk
{
    public partial class GeneratePurchaseOrder : System.Web.UI.Page
    {
        PurchaseOrderBizLogic pobl = new PurchaseOrderBizLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dgvShortfall.DataSource = pobl.ShowShortfallItems();
                   
                dgvShortfall.DataBind();
            }

        }
    }
}