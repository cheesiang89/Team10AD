using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web.App_Code;
using Team10AD_Web.App_Code.Model;

namespace Team10AD_Web.EmployeePage
{
    public partial class RequisitionDetailsPage : System.Web.UI.Page
    {
        int reqid;
        string remarks;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Team10ADModel context = new Team10ADModel();
                string requisitionid = (string)Session["requisitiondetail"];
                reqid = Convert.ToInt32(requisitionid);
                Requisition req = RayBizLogic.GetRequisitionById(requisitionid);
                //int currentEmpId = (int)Session["employeeid"];
                int currentEmpId = 104;
                int approverID = (int)Session["ApproverID"];

                if (currentEmpId == req.RequestorID && req.Status == "Pending")
                {
                    CancelButton.Visible = true;
                }
                else if(currentEmpId == approverID && req.Status =="Pending")
                {
                    btnApprove.Visible = true;
                    btnReject.Visible = true;
                    lblRemarks.Visible = true;
                    txtBoxRemarks.Visible = true;
                }
                //if currentEmId = approverId, approve and reject buttons will show

                var qry = from r in context.RequisitionDetails where r.RequisitionID == reqid select new { r.Catalogue.ItemCode,r.Catalogue.Description, r.QuantityRequested, r.Catalogue.UnitOfMeasure };
                dgvRequisitionDetail.DataSource = qry.ToList();
                dgvRequisitionDetail.DataBind();
                dgvRequisitionDetail.AllowPaging = true;

                App_Code.Model.Employee emp = context.Employees.Where(x => x.EmployeeID == req.RequestorID).First();
                NameTextBox.Text = emp.Name;
                StatusTextBox.Text = req.Status;
                txtBoxRemarks.Text = req.Remarks;
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Team10ADModel context = new Team10ADModel();
            string requisitionid = (string)Session["requisitiondetail"];
            int reqid = Convert.ToInt32(requisitionid);
            RayBizLogic.CancelRequisition(reqid);
            Response.Redirect("RequisitionDetailsPage.aspx");
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            string requisitionid = (string)Session["requisitiondetail"];
            string itemCode; int itemReqQty;
            //List<Catalogue> reqListItems = new List<Catalogue>();
            Dictionary<string, int> reqListItems = new Dictionary<string, int>();
            for(int i = 0; i < dgvRequisitionDetail.Rows.Count; i++)
            {
                itemCode = dgvRequisitionDetail.Rows[i].Cells[3].Text;
                itemReqQty = Convert.ToInt32(dgvRequisitionDetail.Rows[i].Cells[1].Text);
                reqListItems.Add(itemCode, itemReqQty);
            }

            try
            {
                reqid = Convert.ToInt32(requisitionid);
                int approverID = (int)Session["ApproverID"];
                remarks = txtBoxRemarks.Text;
                BusinessLogic_Sam.approveRequisition(reqid,remarks,approverID.ToString());
                BusinessLogic_Sam.updateItemStockLevel(reqListItems);
                Response.Redirect("DepartmentRequisition.aspx");
            }
            catch (Exception exp)
            {
                Response.Write(exp.ToString());
            }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            string requisitionid = (string)Session["requisitiondetail"];
            try
            {
                reqid = Convert.ToInt32(requisitionid);
                remarks = txtBoxRemarks.Text;
                BusinessLogic_Sam.rejectRequisition(reqid, remarks);
                Response.Redirect("DepartmentRequisition.aspx");
            }
            catch (Exception exp)
            {
                Response.Write(exp.ToString());
            }
        }

    }
}