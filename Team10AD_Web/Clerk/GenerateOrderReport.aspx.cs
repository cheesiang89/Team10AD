using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team10AD_Web.Clerk
{
    public partial class GenerateOrderReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dgvCategory.DataSource = ViewState["categoryTable"];
                dgvCategory.DataBind();
            }

        }

        protected void btnCategoryAdd_Click(object sender, EventArgs e)
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
                    dgvCategory.DataSource = dt;
                    dgvCategory.DataBind();
                }
            }
            else
            {
                dr = dt.NewRow();
                dr["Category"] = dropCategory.SelectedValue;
                dr["Details"] = "hello";
                dt.Rows.Add(dr);
                dgvCategory.DataSource = dt;
                dgvCategory.DataBind();
            }
            ViewState["categoryTable"] = dt;
        }
    }
}