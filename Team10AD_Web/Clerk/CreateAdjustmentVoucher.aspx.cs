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
    public partial class CreateAdjustmentVoucher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int needAdjustment = (int)Session["AdjustVoucherId"];
                //int needAdjustment = 1000002;
                dgvCreateAdj.DataSource = RayBizLogic.AdjustmentVoucherDetailForGV(needAdjustment);
                dgvCreateAdj.DataBind();
                dgvCreateAdj.AllowPaging = true;
            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            Team10ADModel context = new Team10ADModel();

            int needAdjustment = (int)Session["AdjustVoucherId"];
            //int needAdjustment = 1000002;

            List<StockAdjustmentVoucherDetail> userinput = context.StockAdjustmentVoucherDetails.Where(x => x.VoucherID == needAdjustment).ToList(); ;
            foreach (StockAdjustmentVoucherDetail v in userinput)
            {
                foreach (GridViewRow row in dgvCreateAdj.Rows)
                {
                    if ((row.Cells[0].Text).Equals(v.ItemCode))
                    {
                        TextBox reasonbox = (TextBox)row.FindControl("ReasonTextBox");
                        v.Reason = reasonbox.Text;
                        context.SaveChanges();
                    }
                }
            }

            Response.Redirect("AdjustmentVoucherList.aspx");
        }
    }
}