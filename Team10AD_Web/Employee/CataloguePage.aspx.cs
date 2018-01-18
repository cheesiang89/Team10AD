using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web;
using Team10AD_Web.App_Code.Model;
using System.Data;
using System.Text.RegularExpressions;

namespace Team10AD_Web.Employee
{
    public partial class CataloguePage : System.Web.UI.Page
    {
        private Team10ADModel m = new Team10ADModel();
      
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                dgvCatalogue.DataSource = m.Catalogues.ToList();
                dgvCatalogue.DataBind();
                dgvCatalogue.AllowPaging = true;
            }

        }
        protected void dgvCatalogue_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvCatalogue.PageIndex = e.NewPageIndex;
            dgvCatalogue.DataSource = m.Catalogues.ToList();
            dgvCatalogue.DataBind();
        }

        protected void dgvCatalogue_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                
                //Pass in Item Code to Pop up window
                // Convert the row index stored in the CommandArgument property to an Integer.
                int index = Convert.ToInt32(e.CommandArgument);
                //Reference the GridView Row.
                GridViewRow row = dgvCatalogue.Rows[index];
                string itemCode = row.Cells[0].Text.ToString();
                // lblTest.Text = itemCode;
                //populatePopup(itemCode);
                //popup.ShowPopupWindow();
            }

         }

        protected void dgvCatalogue_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //LinkButton btnDetails = new LinkButton();
                //btnDetails = (e.Row.FindControl("btnDetails") as LinkButton);
                //btnDetails.Attributes.Add("onClick", "jQuery('#dialog').dialog('open'); return false;");

            }
        }
        protected void btnDetails_Click(object sender, EventArgs e)
        {
            //Pass in Item Code to Pop up window
               //LinkButton btnDetails = sender as LinkButton;
            //GridViewRow gRow = (GridViewRow)btnDetails.NamingContainer;
            //this.ModalPopupExtender1.Show();

            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('Test.aspx');", true);
        }
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            lblTest.Text = "Test";
            Page.Validate();
            if (Page.IsValid)
            {
                //popup.HidePopupWindow();
            }
            
        }
        protected void populatePopup(string itemCode)
        {
            //lblCategory.Text = m.Catalogues.Where(x => x.ItemCode == itemCode).Select(x => x.Category).First().ToString();
            //lblDescription.Text = m.Catalogues.Where(x => x.ItemCode == itemCode).Select(x => x.Description).First().ToString();
            //lblUOM.Text = m.Catalogues.Where(x => x.ItemCode == itemCode).Select(x => x.UnitOfMeasure).First().ToString();
        }
        protected void saveToCart(string itemCode)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                //Do some cool stuff
            }

        }
        //protected bool checkNumOnly(string controlToCheck)
        //{
        //    TextBox text = (TextBox)
        //    Regex regex = new Regex(@"^\d$");
        //    if (regex.IsMatch(contr))
        //    {
        //        //true
        //    }

        //    txtQuantity
        //}
    }
}