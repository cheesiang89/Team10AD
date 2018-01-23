using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Team10AD_Web.Clerk
{
    public partial class GenerateRequestReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dgvDept.DataSource = ViewState["deptTable"];
                dgvDept.DataBind();
                dgvCatagory.DataSource = ViewState["categoryTable"];
                dgvCatagory.DataBind();
            }
        }

        protected void btnAddDept_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Department");
            dt.Columns.Add("Details");
            DataRow dr = null;
            if(ViewState["deptTable"]!= null)
            {
                dt = (DataTable)ViewState["deptTable"];
                if (dt.Rows.Count > 0)
                {
                    dr = dt.NewRow();
                    dr["Department"] = dropDept.SelectedValue;
                    dr["Details"] = "hi";
                    dt.Rows.Add(dr);
                    dgvDept.DataSource = dt;
                    dgvDept.DataBind();
                }
                
            }
            else{
                dr = dt.NewRow();
                dr["Department"] = dropDept.SelectedValue;
                dr["Details"] = "hi";
                dt.Rows.Add(dr);
                dgvDept.DataSource = dt;
                dgvDept.DataBind();
            }

            ViewState["deptTable"] = dt;
        }

        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Category");
            dt.Columns.Add("Details");
            DataRow dr = null;
            if (ViewState["categoryTable"] != null)
            {
                dt = (DataTable)ViewState["categoryTable"];
                if (dt.Rows.Count > 0)
                {
                    dr = dt.NewRow();
                    dr["Category"] = dropCategory.SelectedValue;
                    dr["Details"] = "hello";
                    dt.Rows.Add(dr);
                    dgvCatagory.DataSource = dt;
                    dgvCatagory.DataBind();
                }
            }
            else
            {
                dr = dt.NewRow();
                dr["Category"] = dropCategory.SelectedValue;
                dr["Details"] = "hello";
                dt.Rows.Add(dr);
                dgvCatagory.DataSource = dt;
                dgvCatagory.DataBind();
            }
            ViewState["categoryTable"] = dt;
        }

        protected void dgvDept_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}