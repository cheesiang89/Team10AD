using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web.Model;
using Team10AD_Web;

namespace Team10AD_Web.EmployeePage
{
    public partial class RequisitionStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string deptcode = (string)Session["departmentcode"];
                Team10ADModel context = new Team10ADModel();
                var qry = from r in context.Requisitions where r.Employee.DepartmentCode == deptcode select new { r.Employee.Name, r.RequisitionDate, r.Status, r.RequisitionID, r.Employee.EmployeeID };
                dgvReqStatus.DataSource = qry.ToList();
                dgvReqStatus.DataBind();
                dgvReqStatus.AllowPaging = true;
            }
        }

        protected void dgvReqStatus_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //To be coded.
            if (e.CommandName == "Details")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = dgvReqStatus.Rows[index];
                Session["requisitiondetail"] = selectedRow.Cells[0].Text;
                Response.Redirect("RequisitionDetailsPage.aspx");
            }

            if (e.CommandName == "CancelRequisition")
            {
                GridViewRow selectedRow = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                int reqid = Convert.ToInt32(selectedRow.Cells[0].Text);
                RayBizLogic.CancelRequisition(reqid);
                Response.Redirect("RequisitionStatus.aspx");
            }
        }

        protected Boolean IsRequestorAndPending(int empid, int reqid)
        {
            Team10ADModel context = new Team10ADModel();
            Model.Requisition req = context.Requisitions.Where(x => x.RequisitionID == reqid).First();
            int currentEmpId = (int)Session["employeeid"];

            Boolean reqAndPend;
            if (currentEmpId == empid && req.Status == "Pending")
            {
                reqAndPend = true;
            }
            else
            {
                reqAndPend = false;
            }
            return reqAndPend;
        }
    }
}