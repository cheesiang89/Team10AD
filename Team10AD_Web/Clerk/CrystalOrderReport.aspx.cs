using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team10AD_Web.Clerk
{
    public partial class CrystalOrderReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dgvCategory.DataSource = ViewState["categoryTable"];
                dgvCategory.DataBind();

                dgvDate.DataSource = ViewState["dateTable"];
                dgvDate.DataBind();
            }

        }

        protected void btnCategoryAdd_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Category");
            DataRow dr = null;
            int index;
            if (ViewState["categoryTable"] != null)
            {
                dt = (DataTable)ViewState["categoryTable"];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["Category"].Equals("Please select category"))
                    {
                        dt.Rows[0]["Category"] = dropCategory.SelectedValue;
                    }
                    else
                    {
                        dr = dt.NewRow();
                        index = dt.Rows.IndexOf(dr);
                        dr["Category"] = dropCategory.SelectedValue;
                        bool status = true;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["Category"].ToString() == dr["Category"].ToString())
                            {
                                string a=dr["Category"].ToString();
                                string b = dt.Rows[i]["Category"].ToString();
                                status = false;
                                lblCateValidation.Text = "please choose different category";
                                break;                               
                            }
                        }
                        if(status==true)
                            {
                            dt.Rows.Add(dr);
                            lblCateValidation.Text = "";

                        }
                    }
                    dgvCategory.DataSource = dt;
                    dgvCategory.DataBind();
                }
            }
            else
            {
                dr = dt.NewRow();
                dr["Category"] = dropCategory.SelectedValue;
                dt.Rows.Add(dr);
                dgvCategory.DataSource = dt;
                dgvCategory.DataBind();
            }
            ViewState["categoryTable"] = dt;
            SetPreviousCategoryData();
        }

        private void SetPreviousCategoryData()
        {
            int rowIndex = 0;
            if (ViewState["categoryTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["categoryTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Label LabelCategory = (Label)dgvCategory.Rows[rowIndex].Cells[0].FindControl("lblCategory");
                        LabelCategory.Text = dt.Rows[i]["Category"].ToString();
                        rowIndex++;
                    }
                }
            }
        }



        private void SetCategoryRowData()
        {
            int rowIndex = 0;
            if (ViewState["categoryTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["categoryTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                    {
                        Label LabelCategory = (Label)dgvCategory.Rows[rowIndex].Cells[0].FindControl("lblCategory");
                        drCurrentRow = dtCurrentTable.NewRow();
                        rowIndex++;
                    }

                    ViewState["categoryTable"] = dtCurrentTable;
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
        }

        protected void dgvCategory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                SetCategoryRowData();
                if (ViewState["categoryTable"] != null)
                {
                    DataTable dt = (DataTable)ViewState["categoryTable"];
                    DataRow drCurrentRow = null;
                    GridViewRow selectedRow = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                    int rowIndex = selectedRow.RowIndex;
                    if (dt.Rows.Count > 1)
                    {
                        dt.Rows.Remove(dt.Rows[rowIndex]);
                        drCurrentRow = dt.NewRow();
                        ViewState["categoryTable"] = dt;
                        dgvCategory.DataSource = dt;
                        dgvCategory.DataBind();
                    }
                    else if (dt.Rows.Count == 1)
                    {
                        dt.Rows[0]["Category"] = "Please select category";
                        dgvCategory.DataSource = dt;
                        dgvCategory.DataBind();
                    }
                }
            }
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderReportPage.aspx");
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrystalOrderReport.aspx");
        }

        protected void btnDateAdd_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Date");
            DataRow dr = null;
            int index;
            if (ViewState["dateTable"] != null)
            {
                dt = (DataTable)ViewState["dateTable"];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["Date"].Equals("Please select date"))
                    {
                        dt.Rows[0]["Date"] = dropMonth.SelectedValue + dropYear.SelectedValue;
                    }
                    else
                    {
                        dr = dt.NewRow();
                        index = dt.Rows.IndexOf(dr);
                        dr["Date"] = dropMonth.SelectedValue + dropYear.SelectedValue;
                        bool status = true;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (dt.Rows[i]["Date"].Equals(dr["Date"]))
                            {
                                status = false;
                                lblDateValidation.Text = "Please choose different date";
                                break;
                            }
                        }
                        if (status == true)
                        {
                            dt.Rows.Add(dr);
                            lblDateValidation.Text = "";
                        }

                    }
                    dgvDate.DataSource = dt;
                    dgvDate.DataBind();
                }
            }
            else
            {
                dr = dt.NewRow();
                dr["Date"] = dropMonth.SelectedValue + dropYear.SelectedValue;
                dt.Rows.Add(dr);
                dgvDate.DataSource = dt;
                dgvDate.DataBind();
            }
            ViewState["dateTable"] = dt;
            SetPreviousDateData();
        }

        private void SetPreviousDateData()
        {
            int rowIndex = 0;
            if (ViewState["dateTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["dateTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Label LabelDate = (Label)dgvDate.Rows[rowIndex].Cells[0].FindControl("lblDate");
                        LabelDate.Text = dt.Rows[i]["Date"].ToString();
                        rowIndex++;
                    }
                }
            }
        }
        private void SetDateRowData()
        {
            int rowIndex = 0;
            if (ViewState["dateTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["dateTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 0; i < dtCurrentTable.Rows.Count; i++)
                    {
                        Label LabelDate = (Label)dgvDate.Rows[rowIndex].Cells[0].FindControl("lblDate");
                        drCurrentRow = dtCurrentTable.NewRow();
                        rowIndex++;
                    }

                    ViewState["dateTable"] = dtCurrentTable;
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
        }

        protected void dgvDate_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                SetCategoryRowData();
                if (ViewState["dateTable"] != null)
                {
                    DataTable dt = (DataTable)ViewState["dateTable"];
                    DataRow drCurrentRow = null;
                    GridViewRow selectedRow = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                    int rowIndex = selectedRow.RowIndex;
                    if (dt.Rows.Count > 1)
                    {
                        dt.Rows.Remove(dt.Rows[rowIndex]);
                        drCurrentRow = dt.NewRow();
                        ViewState["dateTable"] = dt;
                        dgvDate.DataSource = dt;
                        dgvDate.DataBind();
                    }
                    else if (dt.Rows.Count == 1)
                    {
                        dt.Rows[0]["Date"] = "Please select date";
                        dgvDate.DataSource = dt;
                        dgvDate.DataBind();
                    }
                }
            }
        }
    }
}