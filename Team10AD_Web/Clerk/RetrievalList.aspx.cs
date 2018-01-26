using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web.Model;
using Team10AD_Web;

namespace Team10AD_Web.Clerk
{
    public partial class RetrievalList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dgvRetList.DataSource = RayBizLogic.RetrievalListForGV();
                dgvRetList.DataBind();
                dgvRetList.AllowPaging = true;
            }
        }

        protected void dgvRetList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Details")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = dgvRetList.Rows[index];
                Session["retrievaldetail"] = selectedRow.Cells[0].Text;

                int id = Convert.ToInt32(selectedRow.Cells[0].Text);
                Retrieval ret =  RayBizLogic.GetRetrievalById(id);

                if (ret.Status == "Retrieved")
                {
                    Response.Redirect("CompletedRetrievalDetailPage.aspx");
                }
                else
                {
                    Response.Redirect("RetrievalDetailPage.aspx");
                }
            }
        }

        protected void dgvRetList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvRetList.PageIndex = e.NewPageIndex;
            dgvRetList.DataSource = RayBizLogic.RetrievalListForGV();
            dgvRetList.DataBind();
        }
    }
}