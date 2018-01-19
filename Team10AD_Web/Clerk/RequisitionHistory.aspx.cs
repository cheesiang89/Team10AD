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
    public partial class RequisitionHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Team10ADModel context = new Team10ADModel();
                var qry = from r in context.Requisitions where (r.Status == "Approved" || r.Status == "Ready To Collect" || r.Status == "Completed" || r.Status == "Partial") select new { r.RequisitionID, r.ApprovalDate, r.Employee.Department.DepartmentName, r.Status};
                dgvReqList.DataSource = qry.ToList();
                dgvReqList.DataBind();
                dgvReqList.AllowPaging = true;
            }
        }

        protected void dgvReqList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Details")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = dgvReqList.Rows[index];
                Session["requisitiondetail"] = selectedRow.Cells[0].Text;
                Response.Redirect("RequisitionDetailPage.aspx");
            }
        }
    }
}