using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web.Model;
using Team10AD_Web;
using System.Collections;

namespace Team10AD_Web.Clerk
{
    public partial class RequestsRecords : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Team10ADModel context = new Team10ADModel();
                var qry = from r in context.Requisitions where (r.Status == "Approved" || r.Status == "Partial") select new { r.RequisitionID, r.ApprovalDate, r.Employee.Department.DepartmentName, r.Status };
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
                Session["requisitiondetail"] = selectedRow.Cells[1].Text;
                Response.Redirect("RequisitionDetailPage.aspx");
            }
        }

        protected void ReqHistButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("RequisitionHistory.aspx");
        }

        protected void dgvReqList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //header select all function
            if (e.Row.RowType == DataControlRowType.Header)
            {
                ((CheckBox)e.Row.FindControl("allchk")).Attributes.Add("onclick",
                    "javascript:SelectAll('" +
                    ((CheckBox)e.Row.FindControl("allchk")).ClientID + "')");
            }
        }

        protected void GenRetListButton_Click(object sender, EventArgs e)
        {
            //For collecting all requisitiondetails into 1 list
            List<RequisitionDetail> rd = new List<RequisitionDetail>();

            //For collecting all the requisition into 1 list
            ArrayList reqIdList = new ArrayList();
            List<Requisition> reqlist = new List<Requisition>();

            //For checking that at least 1 record was selected for retrieval list generation
            int checkselection = 0;

            foreach (GridViewRow row in dgvReqList.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("selectchk");
                if (chk != null && chk.Checked)
                {
                    int reqid = Convert.ToInt32(row.Cells[1].Text);
                    reqIdList.Add(reqid);
                    reqlist = RayBizLogic.CombineReq(reqIdList);

                    List<RequisitionDetail>  templist = RayBizLogic.CombineReqDetail(reqid);
                    foreach (RequisitionDetail r in templist)
                    {
                        rd.Add(r);
                    }
                    checkselection++;
                }
            }

            int clerkid = (int) Session["clerkid"];
            if (checkselection > 0)
            {
                RayBizLogic.GenerateRetrievalList(rd, reqlist, clerkid);
            }

            //Set selected requisition status to "Processing"
            RayBizLogic.ReqStatusProcessing(reqIdList);

            Response.Redirect("RetrievalList.aspx");
        }

        protected void dgvReqList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Team10ADModel context = new Team10ADModel();
            var qry = from r in context.Requisitions where (r.Status == "Approved" || r.Status == "Partial") select new { r.RequisitionID, r.ApprovalDate, r.Employee.Department.DepartmentName, r.Status };
            dgvReqList.DataSource = qry.ToList();
            dgvReqList.DataBind();
        }
    }
}