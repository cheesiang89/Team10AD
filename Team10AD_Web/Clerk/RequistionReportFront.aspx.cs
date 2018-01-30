using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web.Model;
using Team10AD_Web.DTO;

namespace Team10AD_Web.Clerk
{
    public partial class RequistionReportFront : System.Web.UI.Page
    {
        List<string> listDept;
        List<string> listCategory;
        List<DateDTO> listDate;
    
        protected void Page_Load(object sender, EventArgs e)
        {
            listDept = (List<string>)Session["deptListReport"];
            listCategory = (List<string>)Session["categoryListReport"];
            listDate = (List<DateDTO>)Session["dateListReport"];
           
            if (!IsPostBack)
            {
                //reqChart.Visible = false;
                Team10ADModel m = new Team10ADModel();
                ddlDept.DataSource = m.Departments.Select(x => x.DepartmentName).ToList();
                ddlCategory.DataSource= m.Catalogues.Select(x => x.Category).Distinct().ToList();
                ddlDept.DataBind();
                ddlCategory.DataBind();

                //Remove default set
                ddlDept.Items.Insert(0, new ListItem(string.Empty, string.Empty));
                ddlCategory.Items.Insert(0, new ListItem(string.Empty, string.Empty));
                ddlDept.SelectedIndex = 0;
                ddlCategory.SelectedIndex = 0;
            }
        }
        public void dataRefresh()
        {
            gridDept.DataSource = listDept;
            gridDept.DataBind();
            gridCategory.DataSource = listCategory;
            gridCategory.DataBind();
            //Use DataTable here as gridDate has 2 List -Month +Year
            // Combine Month+Year to a DTO and Add to List
          
           
           gridDate.DataSource = listDate;
            gridDate.DataBind();
           
        }


        protected void btnAddDept_Click(object sender, EventArgs e)
        {
            string selectedDept = ddlDept.SelectedItem.Text;
            //Check not empty
            if (!String.IsNullOrEmpty(selectedDept))
            {
                //If Multiple Categories
                if (rdoCatorDept.SelectedValue == "category")
                {
                    //Only allow 1 department
                    listDept.Clear();
                    listDept.Add(selectedDept);
                    Session["deptListReport"] = listDept;
                }
                if (!checkDuplicates(selectedDept, listDept))
                {
                    listDept.Add(selectedDept);
                    Session["deptListReport"] = listDept;
                }
            }
          

            dataRefresh();
        }
        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            string selectedCategory = ddlCategory.SelectedItem.Text;
            //Check not empty
            if (!String.IsNullOrEmpty(selectedCategory))
            {
                //If Multiple Departments
                if (rdoCatorDept.SelectedValue == "dept")
                {
                    //Only allow 1 Category
                    listCategory.Clear();
                    listCategory.Add(selectedCategory);
                    Session["categoryListReport"] = listCategory;

                }
                if (!checkDuplicates(selectedCategory, listCategory))
                {
                    listCategory.Add(selectedCategory);
                    Session["categoryListReport"] = listCategory;

                }
                dataRefresh();
            }
            
        }
        
        protected void btnAddDate_Click(object sender, EventArgs e)
        {
            string selectedMonth = ddlMonth.SelectedItem.Text;
            string selectedYear = ddlYear.SelectedItem.Text;
            DateDTO dateDTO;
            //Check not empty
            if (!String.IsNullOrEmpty(selectedMonth) && !String.IsNullOrEmpty(selectedYear))
            {
                if (!checkDuplicateDate(selectedMonth, selectedYear, listDate))
                {
                    dateDTO = new DateDTO(selectedMonth, selectedYear);
                    listDate.Add(dateDTO);
                    Session["dateListReport"] = listDate;
                }


                dataRefresh();
            }

        }

        protected void gridDept_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Department";
            }
            

        }

        protected void gridCategory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Category";
            }
           
        }

        protected void gridDate_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Month";
                e.Row.Cells[1].Text = "Year";
            }

        }

        protected void gridDept_RowCreated(object sender, GridViewRowEventArgs e)
        {
            GridViewRow row = e.Row;

            TableCell cell = row.Cells[0];
            row.Cells.Remove(cell);
            row.Cells.Add(cell);
        }
        protected void gridCategory_RowCreated(object sender, GridViewRowEventArgs e)
        {
            GridViewRow row = e.Row;

            TableCell cell = row.Cells[0];
            row.Cells.Remove(cell);
            row.Cells.Add(cell);
        }
        protected void gridDate_RowCreated(object sender, GridViewRowEventArgs e)
        {
            GridViewRow row = e.Row;

            TableCell cell = row.Cells[0];
            row.Cells.Remove(cell);
            row.Cells.Add(cell);
        }

        protected void btnDeleteDept_Click(object sender, EventArgs e)
        {
            //Delete dept in row from List
            GridViewRow gridViewRow = (GridViewRow)(sender as Control).Parent.Parent;
            int index = gridViewRow.RowIndex;
            string deptName = gridDept.Rows[index].Cells[0].Text;
            deleteItemFromList(deptName,listDept);
        }
        protected void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            //Delete dept in row from List
            GridViewRow gridViewRow = (GridViewRow)(sender as Control).Parent.Parent;
            int index = gridViewRow.RowIndex;
            string catName = gridCategory.Rows[index].Cells[0].Text;
            deleteItemFromList(catName,listCategory);
        }
        protected void btnDeleteDate_Click(object sender, EventArgs e)
        {
            //Delete date in row from List
            GridViewRow gridViewRow = (GridViewRow)(sender as Control).Parent.Parent;
            int index = gridViewRow.RowIndex;
            string monthName = gridDate.Rows[index].Cells[0].Text;
            string yearName = gridDate.Rows[index].Cells[1].Text;
           
            deleteDateFromList(monthName, yearName, listDate);
           
        }

        protected void deleteItemFromList(string item, List<string> listSource)
        {
            listSource.Remove(item);
            dataRefresh();           
        }
        protected void deleteDateFromList(string selectedMonth, string selectedYear, List<DateDTO> listSource)
        {
            List<DateDTO> newList = new List<DateDTO>();
            newList = listSource.ToList();
            foreach (DateDTO item in newList)
            {
                if (item.Month== selectedMonth && item.Year==selectedYear)
                {
                    listSource.Remove(item);

                }
            }
            
            dataRefresh();
        }
        public bool checkDuplicates(string name, List<string> listSource)
        {
            bool isDuplicate = false;
            //Iterate list in sessionState
            foreach (string item in listSource)
            {
                if (name == item)
                {
                    isDuplicate = true;
                }
            }
            return isDuplicate;
        }
        public bool checkDuplicateDate(string selectedMonth, string selectedYear, List<DateDTO> listSource)
        {
            bool isDuplicate = false;
            //Iterate list in sessionState
            foreach (DateDTO item in listSource)
            {             
                    if (selectedMonth == item.Month && selectedYear==item.Year)
                    {
                        isDuplicate = true;
                    }
            }
            return isDuplicate;
        }

        protected void btnMakeChart_Click(object sender, EventArgs e)
        {
            //Ensure at least 1 dept, 1 category selected
            if ((listCategory.Count > 0) && (listDept.Count > 0))
            {
                List<RequisitionReportDTO> report = CS_BizLogic.CreateChartData(listDept, listCategory, listDate);
                DataTable table= new DataTable();
                //Multiple categories
                if (rdoCatorDept.SelectedValue == "category")
                {
                   table = CS_BizLogic.CreateDataTable(report, listDate, listCategory, "FIXEDDEPT");
                    Session["ReqRtpSeries1"] = gridCategory.Rows[0].Cells[0].Text;
                    Session["ReqRtpSeries2"] = gridCategory.Rows[1].Cells[0].Text;
                    Session["ReqRtpSeries3"] = gridCategory.Rows[2].Cells[0].Text;

                }
                //Multiple departments
                else if (rdoCatorDept.SelectedValue == "dept")
                {
                table = CS_BizLogic.CreateDataTable(report, listDate, listDept, "FIXEDCAT");
                    Session["ReqRtpSeries1"] = gridDept.Rows[0].Cells[0].Text;
                    Session["ReqRtpSeries2"] = gridDept.Rows[1].Cells[0].Text;
                    Session["ReqRtpSeries3"] = gridDept.Rows[2].Cells[0].Text;

                }
                //Setting session- Chart Type
                checkChartType();
                //Setting session, pass DataTable
                Session["RequisitionReportDataTable"] = table;
                Response.Redirect("~/Clerk/RequisitionReportPage");
                
            }
        }
        protected void rdoCatorDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Reset the gridviews and dropdownlist
            listCategory.Clear();
            listDept.Clear();
            listDate.Clear();
            dataRefresh();
            ddlCategory.SelectedIndex = 0;
            ddlDept.SelectedIndex = 0;
            ddlMonth.SelectedIndex = 0;
            ddlYear.SelectedIndex = 0;
            //Show panel
            pnlReportContent.Visible = true;
          
        }
        protected void checkChartType()
            {
                //if rdoCatorDept selected value == category or dept
                //set the Session["ChartType"] = category/dept
                //chart title will be different.
                if (rdoCatorDept.SelectedValue == "dept")
                {
                    Session["ChartType"] = "dept";
                }
                else
                {
                    Session["ChartType"] = "category";
                }

              

            }
    }
}