using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web;
using Team10AD_Web.Model;

namespace Team10AD_Web.Clerk
{
    public partial class RequisitionDetailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Team10ADModel context = new Team10ADModel();
                string requisitionid = (string)Session["requisitiondetail"];
                int reqid = Convert.ToInt32(requisitionid);
                Requisition req = RayBizLogic.GetRequisitionById(requisitionid);

                var qry = from r in context.RequisitionDetails where r.RequisitionID == reqid select new { r.ItemCode ,r.Catalogue.Description, r.QuantityRequested, r.QuantityRetrieved };
                dgvRequisitionDetail.DataSource = qry.ToList();
                dgvRequisitionDetail.DataBind();
                dgvRequisitionDetail.AllowPaging = true;

                Model.Employee emp = context.Employees.Where(x => x.EmployeeID == req.RequestorID).First();
                Model.Department dept = context.Departments.Where(x => x.DepartmentCode == emp.DepartmentCode).First();
                ReqIDTextBox.Text = req.RequisitionID.ToString();
                StatusTextBox.Text = req.Status;
                DeptNameTextBox.Text = dept.DepartmentName;
                DeptCodeTextBox.Text = dept.DepartmentCode;
                NameTextBox.Text = emp.Name;
                EmployeePhoneTextBox.Text = emp.Phone.ToString();
                EmailTextBox.Text = emp.Email;
            }
        }
    }
}