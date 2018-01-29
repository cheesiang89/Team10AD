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
         
                Team10ADModel m = new Team10ADModel();
                ddlDept.DataSource = m.Departments.Select(x => x.DepartmentName).ToList();
                ddlCategory.DataSource= m.Catalogues.Select(x => x.Category).Distinct().ToList();
                ddlDept.DataBind();
                ddlCategory.DataBind();
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
            if (!checkDuplicates(selectedDept, listDept))
            {
                listDept.Add(selectedDept);
                Session["deptListReport"] = listDept;
            }

            dataRefresh();
        }
        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            string selectedCategory = ddlCategory.SelectedItem.Text;
            if (!checkDuplicates(selectedCategory, listCategory))
            {
                listCategory.Add(selectedCategory);
                Session["categoryListReport"] = listCategory;

            }
            
            dataRefresh();

        }
        
        protected void btnAddDate_Click(object sender, EventArgs e)
        {
            string selectedMonth = ddlMonth.SelectedItem.Text;
            string selectedYear = ddlYear.SelectedItem.Text;
            DateDTO dateDTO;
            if (!checkDuplicateDate(selectedMonth,selectedYear,listDate))
            {
                dateDTO= new DateDTO(selectedMonth, selectedYear);
                listDate.Add(dateDTO);
                Session["dateListReport"] = listDate;
            }
          

            dataRefresh();

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
            List<RequisitionReportDTO> report = CS_BizLogic.CreateChartData(listDept, listCategory, listDate);
        }
    }
}