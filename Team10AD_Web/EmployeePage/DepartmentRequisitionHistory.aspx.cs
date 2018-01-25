using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web.App_Code;

namespace Team10AD_Web.EmployeePage
{
    public partial class DepartmentRequisitionHistory : System.Web.UI.Page
    {
        string departmentCode;
        int employeeID;
        int approverID;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["departmentid"] = "ARTS";
            //this employee is the approver
            Session["employeeid"] = 104;
            Session["ApproverID"] = 104;
            departmentCode = (string)Session["departmentid"];
            employeeID = (int)Session["employeeid"];
            approverID = (int)Session["ApproverID"];

            if (!IsPostBack)
            {
                btnReqHst.ForeColor = System.Drawing.Color.Green;
                dgvDepReqHst.DataSource = BusinessLogic_Sam.getDepartmentRequisitionList(departmentCode);
                dgvDepReqHst.DataBind();
            }
        }

        protected void btnPendingReq_Click(object sender, EventArgs e)
        {
            Response.Redirect("DepartmentRequisition.aspx");
        }

        protected void dgvDepReqHst_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Details")
            {
                GridViewRow selectedRow = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                int selectedIndex = selectedRow.RowIndex;
                Session["requisitiondetail"] = dgvDepReqHst.Rows[selectedIndex].Cells[5].Text;
                Response.Redirect("RequisitionDetailsPage.aspx");
            }
        }
    }
}