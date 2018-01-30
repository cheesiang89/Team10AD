using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web.App_Code;
using Team10AD_Web.DTO;
using Team10AD_Web.Model;

namespace Team10AD_Web.Clerk
{
    public partial class OrderReportPage : System.Web.UI.Page
    {
        List<string> listCategory;
        List<DateDTO> listDate;
      

        protected void Page_Load(object sender, EventArgs e)
        {
            listCategory = (List<string>)Session["listOrderCategory"];
            listDate = (List<DateDTO>)Session["listOrderDates"];
            if (!IsPostBack)
            {
                using (Team10ADModel entities = new Team10ADModel())
                {
                    ddlCat.DataSource = entities.Catalogues.Select(x => x.Category).Distinct().ToList();
                    ddlCat.DataBind();
                }
            }

        }

        public void BindGrid()
        {
            dgvCategory.DataSource = listCategory;
            dgvCategory.DataBind();
            dgvDate.DataSource = listDate;
            dgvDate.DataBind();
        }
        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            string selectedCat = ddlCat.SelectedItem.Text;
            if (!checkDuplication(selectedCat, listCategory))
            {
                listCategory.Add(selectedCat);
                Session["listOrderCategory"] = listCategory;
            }

            BindGrid();

        }

        protected void btnDeleteCat_Click(object sender, EventArgs e)
        {

            GridViewRow gridViewRow = (GridViewRow)(sender as Control).Parent.Parent;
            int index = gridViewRow.RowIndex;
            string catName = dgvCategory.Rows[index].Cells[0].Text;
            deleteCatFromList(catName, listCategory);
        }

        protected void btnAddDate_Click(object sender, EventArgs e)
        {
            string selectedMonth = dropMonth.SelectedItem.Text;
            string selectedYear = dropYear.SelectedItem.Text;
            int selectedMonthInt = Int32.Parse(dropMonth.SelectedValue);
            DateDTO dateDTO;

            if (!checkDateDuplication(selectedMonth, selectedYear, listDate))
            {
                dateDTO = new DateDTO(selectedMonth, selectedYear);
                listDate.Add(dateDTO);
                Session["listOrderDates"] = listDate;
            }
            BindGrid();
        }

        protected void btnDeleteDate_Click(object sender, EventArgs e)
        {
            //Delete date in row from List
            GridViewRow gridViewRow = (GridViewRow)(sender as Control).Parent.Parent;
            int index = gridViewRow.RowIndex;
            string monthName = dgvDate.Rows[index].Cells[0].Text;
            string yearName = dgvDate.Rows[index].Cells[1].Text;
            deleteDateFromList(monthName, yearName, listDate);

        }

        protected void dgvCategory_RowCreated(object sender, GridViewRowEventArgs e)
        {
            GridViewRow row = e.Row;
            TableCell cell = row.Cells[0];
            row.Cells.Remove(cell);
            row.Cells.Add(cell);
        }

        protected void dgvCategory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Category";
            }
        }

        protected void gridDate_RowCreated(object sender, GridViewRowEventArgs e)
        {
            GridViewRow row = e.Row;
            TableCell cell = row.Cells[0];
            row.Cells.Remove(cell);
            row.Cells.Add(cell);
        }

        protected void gridDate_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Month";
                e.Row.Cells[1].Text = "Year";
            }

        }

        protected bool checkDuplication(string data, List<string> listDataSource)
        {
            bool hasDuplication = false;
            foreach (string item in listDataSource)
            {
                if (data == item)
                {
                    hasDuplication = true;
                }
            }
            return hasDuplication;
        }

        protected bool checkDateDuplication(string selectedMonth, string selectedYear, List<DateDTO> listDates)
        {
            bool hasDuplicateDate = false;

            foreach (DateDTO date in listDates)
            {
                if (selectedMonth == date.Month && selectedYear == date.Year)
                {
                    hasDuplicateDate = true;
                }
            }
            return hasDuplicateDate;
        }

        protected void deleteCatFromList(string cat, List<string> listCat)
        {
            listCat.Remove(cat);
            BindGrid();
        }

        protected void deleteDateFromList(string selectedMonth, string selectedYear, List<DateDTO> listSource)
        {
            List<DateDTO> newList = new List<DateDTO>();
            newList = listSource.ToList();
            foreach (DateDTO item in newList)
            {
                if (item.Month == selectedMonth && item.Year == selectedYear)
                {
                    listSource.Remove(item);
                }
            }
            BindGrid();
        }

        protected void btnGenerateReport_Click(object sender, EventArgs e)
        {
            List<OrderReportDTO> orderReportDTOList = BusinessLogic_Sam.CreateChartData(listCategory,listDate);

        }
    }
}