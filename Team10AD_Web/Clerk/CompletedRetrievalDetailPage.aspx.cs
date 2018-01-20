using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web.App_Code.Model;
using Team10AD_Web.App_Code;

namespace Team10AD_Web.Clerk
{
    public partial class CompletedRetrievalDetailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Team10ADModel context = new Team10ADModel();
                string id = (string)Session["retrievaldetail"];
                int retrievalid = Convert.ToInt32(id);
                Retrieval ret = RayBizLogic.GetRetrievalById(retrievalid);
                int currentClerkId = (int)Session["clerkid"];

                var qry = from r in context.RetrievalDetails where r.RetrievalID == retrievalid select new { r.ItemCode, r.Catalogue.Description, r.RequestedQuantity, r.RetrievedQuantity };
                dgvRetrievalDetail.DataSource = qry.ToList();
                dgvRetrievalDetail.DataBind();

                RetIDTextBox.Text = ret.RetrievalID.ToString();
                StatusTextBox.Text = ret.Status;
            }
        }
    }
}