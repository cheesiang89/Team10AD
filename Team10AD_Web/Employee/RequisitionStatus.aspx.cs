using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web.App_Code.Model;
using Team10AD_Web.App_Code;

namespace Team10AD_Web.Employee
{
    public partial class RequisitionStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string deptcode = RayBizLogic.DepartmentId("ling@LogicUniversity");
            Team10ADModel context = new Team10ADModel();
            var qry = from r in context.Requisitions where r.Employee.DepartmentCode == deptcode select new { r.Employee.Name, r.RequisitionDate, r.Status};
            dgvReqStatus.DataSource = qry.ToList();
            dgvReqStatus.DataBind();
            dgvReqStatus.AllowPaging = true;
        }

        protected void dgvReqStatus_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //To be coded.
            if (e.CommandName == "Details")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = dgvReqStatus.Rows[index];
                Session["departmentdetail"] = selectedRow.Cells[0].Text;
                Response.Redirect("DepartmentDetail.aspx");
            }
            if (e.CommandName == "Cancel")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = dgvReqStatus.Rows[index];
                Session["departmentdetail"] = selectedRow.Cells[0].Text;
                Response.Redirect("DepartmentDetail.aspx");
            }
        }
    }
}