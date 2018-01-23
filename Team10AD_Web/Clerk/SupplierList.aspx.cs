using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web.App_Code.Model;

namespace Team10AD_Web.Clerk
{
    public partial class SupplierList1 : System.Web.UI.Page
    {

    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dgvSupList.DataSource = PurvaBizLogic.ShowSuppliers();
                dgvSupList.DataBind();
            }
        }

        protected void dgvSupList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {

                ////Pass in Item Code to Pop up window
                //// Convert the row index stored in the CommandArgument property to an Integer.
                //int index = Convert.ToInt32(e.CommandArgument.ToString());
                ////Reference the GridView Row.
                //GridViewRow row = dgvSupList.Rows[index];
                //string supplierName = row.Cells[0].Text.ToString();

                GridViewRow gvRow = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                //Get JobId value and save to session or other page object
                string supplierCode = gvRow.Cells[0].Text;
                Supplier supplier = PurvaBizLogic.GetSupplier(supplierCode);
                Session["Supplier"] = supplier;
                Response.Redirect("SupplierDetailPage.aspx");
            }
        }
        }
    }
    
