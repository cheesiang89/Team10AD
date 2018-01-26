using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web;

namespace Team10AD_Web.EmployeePage
{
    public partial class DepartmentRequisition : System.Web.UI.Page
    {
        // ONLY approver can see this page. I'll assume this has been filter at menu side prior to entering this page.
        string departmentCode;
        //int hodID;
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
            //on page load, the Pending Requisition button is selected(green) and the dgv load requisitions with status pending

            if (!IsPostBack)
            {
                btnPendingReq.ForeColor = System.Drawing.Color.Green;
                dgvDepReq.DataSource = BusinessLogic_Sam.getDepartmentPendingRequisition(departmentCode);
                dgvDepReq.DataBind();
              
             
            }
        }

        protected void btnReqHst_Click(object sender, EventArgs e)
        {
            Response.Redirect("DepartmentRequisitionHistory.aspx");
        }

        protected void dgvDepReq_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Details")
            {
 
                GridViewRow selectedRow = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                int selectedIndex = selectedRow.RowIndex;
                Session["requisitiondetail"] = dgvDepReq.Rows[selectedIndex].Cells[4].Text;
                Response.Redirect("RequisitionDetailsPage.aspx");

            }
        }


    }
}