﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web;
using Team10AD_Web.App_Code.Model;
using System.Data;
using System.Text.RegularExpressions;
using System.Text;

namespace Team10AD_Web.EmployeePage
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



        protected void saveToCart(string itemCode)

        {
            Page.Validate();
            if (Page.IsValid)
            {

                List<string> cart = (List<string>)Session["requisitionCart"];
                cart.Add(itemCode);
                // popup.HidePopupWindow();
            }


        }

        protected void btnTest_Click(object sender, EventArgs e)
        {
            List<string> cart = (List<string>)Session["requisitionCart"];
            StringBuilder sb = new StringBuilder();
            foreach (string s in cart)
            {
                sb.Append(s);
            }
            lblTest.Text = sb.ToString();
        }
        protected void dgvCatalogue_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "Add")
            //{

            //    //Pass in Item Code to Pop up window
            //    // Convert the row index stored in the CommandArgument property to an Integer.
            //    int index = Convert.ToInt32(e.CommandArgument);
            //    //Reference the GridView Row.
            //    GridViewRow row = dgvCatalogue.Rows[index];
            //    string itemCode = row.Cells[0].Text.ToString();
            //     lblTest.Text = itemCode;
            //}

        }

    }
}