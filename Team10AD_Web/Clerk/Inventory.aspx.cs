using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web;
using Team10AD_Web.App_Code.Model;
using Team10AD_Web.App_Code;

namespace Team10AD_Web.Clerk
{
    public partial class Inventory : System.Web.UI.Page
    {
        private Team10ADModel m = new Team10ADModel();
        protected void Page_Load(object sender, EventArgs e)
        {

            dgvCatalogue.DataSource = RayBizLogic.CatalogueList();

            dgvCatalogue.DataBind();
            dgvCatalogue.AllowPaging = true;
        }

        protected void dgvCatalogue_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvCatalogue.PageIndex = e.NewPageIndex;

            if (SearchBox.Text == "")
            {
                dgvCatalogue.DataSource = RayBizLogic.CatalogueList();
            }
            else
            {
                dgvCatalogue.DataSource = RayBizLogic.SearchCatalogue(SearchBox.Text);
            }


            dgvCatalogue.DataBind();
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            dgvCatalogue.DataSource = RayBizLogic.SearchCatalogue(SearchBox.Text);
            dgvCatalogue.DataBind();
            dgvCatalogue.AllowPaging = true;
        }

    }
}