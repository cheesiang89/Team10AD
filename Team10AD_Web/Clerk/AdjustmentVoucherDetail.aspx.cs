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
    public partial class AdjustmentVoucherDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Team10ADModel context = new Team10ADModel();
                string id = (string)Session["AdjustVoucherId"];
                int adjId = Convert.ToInt32(id);

                int storestaffid = (int) Session["clerkid"];
                StoreStaff staff = RayBizLogic.GetStoreStaffById(storestaffid);

                dgvVoucherDetail.DataSource = RayBizLogic.AdjustmentVoucherDetailList(adjId);
                dgvVoucherDetail.DataBind();

                StockAdjustmentVoucher voucher = context.StockAdjustmentVouchers.Where(v => v.VoucherID == adjId).First();
                VouchderIdBox.Text = voucher.VoucherID.ToString();
                DateTextBox.Text = voucher.DateIssue.ToString();
                GenByTextBox.Text = voucher.StoreStaff.Name;

                if (staff.Title == "Supervisor" && voucher.Status == "Pending" && RayBizLogic.AdjustmentVoucherCost(adjId) <= 250)
                {
                    AcknowledgeButton.Visible = true;
                }
                else if (staff.Title == "Manager" && voucher.Status == "Pending" && RayBizLogic.AdjustmentVoucherCost(adjId) > 250)
                {
                    AcknowledgeButton.Visible = true;
                }
            }
        }

        protected void AcknowledgeButton_Click(object sender, EventArgs e)
        {
            Team10ADModel context = new Team10ADModel();
            int voucherid = Convert.ToInt32(VouchderIdBox.Text);
            StockAdjustmentVoucher voucher = context.StockAdjustmentVouchers.Where(v => v.VoucherID == voucherid).First();
            voucher.ApproverID = (int)Session["clerkid"];
            voucher.DateApproved = DateTime.Now;
            voucher.Status = "Approved";
            context.SaveChanges();

            Response.Redirect("AdjustmentVoucherList.aspx");
        }
    }
}