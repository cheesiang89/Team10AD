using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web.App_Code.Model;

namespace Team10AD_Web.Clerk
{
    public partial class SupplierDetailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Supplier supplier = (Supplier)Session["Supplier"];
            dvSupplierDetail.DataSource = new List<Supplier> { supplier };
            dvSupplierDetail.DataBind();
          


        }
    }
}