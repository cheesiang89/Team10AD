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
    public partial class DepartmentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Team10ADModel context = new Team10ADModel();
            var qry = from x in context.Departments select new { x.DepartmentCode, x.DepartmentName, x.Employee.Name };
            dgvDeptList.DataSource = qry.ToList();
            dgvDeptList.DataBind();
            dgvDeptList.AllowPaging = true;
        }

        protected void dgvDeptList_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = dgvDeptList.Rows[index];
                //TestLabel.Text = selectedRow.Cells[0].Text;
                Session["departmentdetail"] = selectedRow.Cells[0].Text;
                Response.Redirect("DepartmentDetail.aspx");
            }
        }
    }
}