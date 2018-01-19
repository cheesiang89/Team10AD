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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Team10ADModel context = new Team10ADModel();
                string requisitionid = (string)Session["requisitiondetail"];
                int reqid = Convert.ToInt32(requisitionid);
                Requisition req = RayBizLogic.GetRequisitionById(requisitionid);

                var qry = from r in context.RequisitionDetails where r.RequisitionID == reqid select new { r.Catalogue.Description, r.QuantityRequested, r.Catalogue.UnitOfMeasure };
                dgvRequisitionDetail.DataSource = qry.ToList();
                dgvRequisitionDetail.DataBind();
                dgvRequisitionDetail.AllowPaging = true;

                App_Code.Model.Employee emp = context.Employees.Where(x => x.EmployeeID == req.RequestorID).First();
                NameTextBox.Text = emp.Name;
                StatusTextBox.Text = req.Status;
            }
        }
    }
}