using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web.App_Code.Model;

namespace Team10AD_Web.EmployeePage
{
    public partial class DisbursementList : System.Web.UI.Page
    {
        BusinessLogic b = new BusinessLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            int employeeid = (int)Session["employeeid"];
            Team10AD_Web.App_Code.Model.Employee emp = b.GetEmployee(employeeid);
            string employeeDepCode = emp.DepartmentCode;
            if (!IsPostBack)
            {
                dgvDisbursementRecord.DataSource = b.DisbursementRecordsByDepartment(employeeDepCode);
                dgvDisbursementRecord.DataBind();
                dgvDisbursementRecord.AllowPaging = true;
            }
        }

        protected void dgvDisbursementRecord_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "details")
            {
                GridViewRow gvRow = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                int disbursementID = Int32.Parse(gvRow.Cells[0].Text);
                Disbursement disbursement = b.GetDisbursement(disbursementID);
                Session["Disbursement"] = disbursement;
                int employeeid = (int)Session["employeeid"];
                Team10AD_Web.App_Code.Model.Employee emp = b.GetEmployee(employeeid);
                Session["Employee"] = emp;
                Response.Redirect("DisbursementDetailsPage.aspx");
            }
        }

        protected void dgvDisbursementRecord_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            int employeeid = (int)Session["employeeid"];
            Team10AD_Web.App_Code.Model.Employee emp = b.GetEmployee(employeeid);
            string employeeDepCode = emp.DepartmentCode;
            dgvDisbursementRecord.PageIndex = e.NewPageIndex;
            dgvDisbursementRecord.DataSource = b.DisbursementRecordsByDepartment(employeeDepCode);
            dgvDisbursementRecord.DataBind();
        }
    }
}