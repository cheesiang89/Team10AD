using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web;
using Team10AD_Web.App_Code.Model;

namespace Team10AD_Web.Clerk
{
    public partial class Inventory : System.Web.UI.Page
    {
        private Team10ADModel m = new Team10ADModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            dgvCatalogue.DataSource = m.Catalogues.Select(
                x => new {
                    ItemCode = x.ItemCode,
                Category=x.Category,
                Description=x.Description}).ToList();
            dgvCatalogue.DataBind();
            dgvCatalogue.AllowPaging = true;

        }

        protected void dgvCatalogue_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvCatalogue.PageIndex = e.NewPageIndex;
            dgvCatalogue.DataSource = m.Catalogues.Select(
                    x => new {
                        ItemCode = x.ItemCode,
                        Category = x.Category,
                        Description = x.Description
                    }).ToList();
            dgvCatalogue.DataBind();
        }
    }
}