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
    public partial class GeneratePO : System.Web.UI.Page
    {


        List<Catalogue> listSource;
        protected void Page_Load(object sender, EventArgs e)
        {
           listSource = (List<Catalogue>)Session["Shortfall"];
            lblTag.Visible = false;
                lblDescription.Visible = false;
            btnAddItem.Visible = false;
            
            if (!IsPostBack)
            {
                //Storelist in shortfall
               
                dataRefresh();
            }
        
        }

        protected void dataRefresh()
        {
            repeaterItems.DataSource = listSource;
            repeaterItems.DataBind();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //Show Label with Item Description
            string itemQuery = txtItemCode.Text.ToUpper();
           string description = PurvaBizLogic.GetDescriptionFromItemCode(itemQuery);
            lblDescription.Text = description;
            if (!String.IsNullOrEmpty(description))
            {
                lblTag.Text = "Description: ";
                lblDescription.Text = description;
                lblTag.Visible = true;
                lblDescription.Visible = true;
                btnAddItem.Visible = true;
           
            }
            else
            {
                lblTag.Text = "No such item";
                lblTag.Visible = true;
                
            }
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            listSource.Add(PurvaBizLogic.GetItemByCode(txtItemCode.Text));
            Session["Shortfall"] = listSource;
            dataRefresh();
        }
      

        protected void repeaterItems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                listSource.RemoveAt(Convert.ToInt32(e.CommandArgument));
                Session["Shortfall"] = listSource;
                dataRefresh();
            }

        }
    }
}