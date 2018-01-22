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
    public partial class AdjustmentVoucherList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dgvAdjVoucher.DataSource = RayBizLogic.AdjustmentVoucherList();
                dgvAdjVoucher.DataBind();
                dgvAdjVoucher.AllowPaging = true;
            }
        }

        protected void dgvAdjVoucher_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Details")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = dgvAdjVoucher.Rows[index];
                Session["AdjustVoucherId"] = selectedRow.Cells[0].Text;
                Response.Redirect("AdjustmentVoucherDetail.aspx");
            }
        }

        protected void dgvAdjVoucher_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvAdjVoucher.PageIndex = e.NewPageIndex;
            dgvAdjVoucher.DataSource = RayBizLogic.AdjustmentVoucherList();
            dgvAdjVoucher.DataBind();
        }

    }
}