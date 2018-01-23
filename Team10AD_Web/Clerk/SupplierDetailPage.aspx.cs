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
            //lblSupCode.Text = "Supplier Code";
            //string supplierCode = txtBoxSupCode.Text;

            //lblSupName.Text = "Supplier Name";
            //string supplierName = txtBoxSupName.Text;

            //lblConName.Text = "Contact Name";
            //string contactName = txtBoxConName.Text;
            //lblPhone.Text = "Phone No.";
            //int phoneNumber = Convert.ToInt32(txtBoxConName.Text);


            //lblFax.Text = "Fax No.";
            //int faxNumber = Convert.ToInt32(txtBoxFax.Text);

            //lblAddress.Text = "Address";
            //string address = txtBoxAddress.Text;


        }
    }
}