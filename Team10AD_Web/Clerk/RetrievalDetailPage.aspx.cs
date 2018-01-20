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
    public partial class RetrievalDetailPage : System.Web.UI.Page
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

                if (ret.Status == "Retrieved")
                {
                    GenDisbursementButton.Visible = false;
                }

                var qry = from r in context.RetrievalDetails where r.RetrievalID == retrievalid select new { r.ItemCode, r.Catalogue.Description, r.Catalogue.BalanceQuantity, r.RequestedQuantity };
                dgvRetrievalDetail.DataSource = qry.ToList();
                dgvRetrievalDetail.DataBind();

                RetIDTextBox.Text = ret.RetrievalID.ToString();
                StatusTextBox.Text = ret.Status;
            }
        }

        protected string QtyToRetrieve(int balqty, int reqqty)
        {
            int retrieveqty;
            if ((balqty - reqqty) >= 0)
            {
                retrieveqty = reqqty;
            }
            else if (balqty == 0)
            {
                retrieveqty = 0;
            }
            else
            {
                retrieveqty = balqty;
            }

            return retrieveqty.ToString();
        }
    }


}