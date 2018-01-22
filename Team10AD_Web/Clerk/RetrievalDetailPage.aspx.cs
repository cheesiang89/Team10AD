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

                //Safety catch. Incase user click back and click generate again
                if (ret.Status == "Retrieved")
                {
                    GenDisbursementList.Visible = false;
                }

                var qry = from r in context.RetrievalDetails where r.RetrievalID == retrievalid select new { r.ItemCode, r.Catalogue.Description, r.Catalogue.BalanceQuantity, r.RequestedQuantity };
                dgvRetrievalDetail.DataSource = qry.ToList();
                dgvRetrievalDetail.DataBind();

                RetIDTextBox.Text = ret.RetrievalID.ToString();
                StatusTextBox.Text = ret.Status;

                //Saving the suggested retrieval details before user make any changes
                List<RetrievalDetail> suggested = RayBizLogic.GetRetrievalList(retrievalid);
                foreach (RetrievalDetail r in suggested)
                {
                    foreach (GridViewRow row in dgvRetrievalDetail.Rows)
                    {
                        TextBox retrieveqtybox = (TextBox)row.FindControl("RetrieveQty");
                        if (r.ItemCode == row.Cells[0].Text)
                        {
                            r.RetrievedQuantity = Convert.ToInt32(retrieveqtybox.Text);
                        }
                    }
                }
                Session["SuggestedRetrievalDetail"] = suggested;
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

        protected void GenDisbursementList_Click(object sender, EventArgs e)
        {
            Team10ADModel context = new Team10ADModel();
            List<RetrievalDetail> suggested = (List < RetrievalDetail >) Session["SuggestedRetrievalDetail"];

            int clerkid = (int) Session["clerkid"];
            string id = (string)Session["retrievaldetail"];
            int retrievalid = Convert.ToInt32(id);
            List<RetrievalDetail> userinput = RayBizLogic.GetRetrievalList(retrievalid);
            foreach (RetrievalDetail r in userinput)
            {
                foreach (GridViewRow row in dgvRetrievalDetail.Rows)
                {
                    TextBox retrieveqtybox = (TextBox)row.FindControl("RetrieveQty");
                    if (r.ItemCode == row.Cells[0].Text)
                    {
                        r.RetrievedQuantity = Convert.ToInt32(retrieveqtybox.Text);
                    }
                }
            }

            //Check for adjustment voucher needs
            int needAdjustment = RayBizLogic.GenerateAdjustmentVoucherDetails(suggested, userinput, clerkid);

            //Update retrieval and catalogue
            //Generate disbursement lists
            //Update requisition qty
            //Update requisition status
            RayBizLogic.UpdateRetrievalDetailsEager(retrievalid, userinput, clerkid);

            if (needAdjustment > 0)
            {
                Session["AdjustVoucherId"] = needAdjustment;
                Response.Redirect("CreateAdjustmentVoucher.aspx");
            }
            else
            {
                Response.Redirect("DisbursementList.aspx");
            }
        }
    }
}