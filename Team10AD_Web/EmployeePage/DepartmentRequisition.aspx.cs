using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web.App_Code;

namespace Team10AD_Web.EmployeePage
{
    public partial class DepartmentRequisition : System.Web.UI.Page
    {
        // ONLY approver can see this page. I'll assume this has been filter at menu side prior to entering this page.
        string approverName;
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
               for(int i=0; i < dgvDepReq.Rows.Count; i++)
                {//need to set the employeename dynamically
                    dgvDepReq.Rows[i].Cells[3].Text = "123";
                }

                GridView1.DataSource = BusinessLogic_Sam.getEmployeeNamefromRequestorID(departmentCode);
                GridView1.DataBind();


            }
        }

    }
}