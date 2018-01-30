using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web.DTO;

namespace Team10AD_Web.Clerk
{
    public partial class ClerkReqReport : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dgvReqRpt.DataSource = (List<RequisitionReportDTO>)Session["RequisitionReportDTOList"];
                dgvReqRpt.DataBind();
            }

            //DataTable dtReqRpt = new DataTable();
            //dtReqRpt.Columns.Add("Month",typeof(string));
            //dtReqRpt.Columns.Add("ClipQty", typeof(int));
            //dtReqRpt.Columns.Add("EnvelopeQty", typeof(int));
            ////DataRow dr = null;
            //dtReqRpt.Rows.Add("Jan",40,20);
            //dtReqRpt.Rows.Add("March",30,60);
            //dtReqRpt.Rows.Add("May",20,70);
            //chartRequisitionReport.DataSource = dtReqRpt;
            //chartRequisitionReport.Series["Series1"].XValueMember = "Month";
            //chartRequisitionReport.Series["Series1"].YValueMembers = "ClipQty";
            //chartRequisitionReport.Series["Series2"].XValueMember = "Month";
            //chartRequisitionReport.Series["Series2"].YValueMembers = "EnvelopeQty";
            //string dateStr1 = "Nov2017";
            //string dateStr2 = "Nov2017";
            //string dateStr3 = "Dec2016";
            //DateTime date1 = DateTime.ParseExact(dateStr1,"MMMyyyy", CultureInfo.InvariantCulture);
            //DateTime date2 = DateTime.ParseExact(dateStr2, "MMMyyyy", CultureInfo.InvariantCulture);
            //DateTime date3 = DateTime.ParseExact(dateStr3, "MMMyyyy", CultureInfo.InvariantCulture);
            //List<DateTime> dateList = new List<DateTime>();
            //dateList.Add(date1);
            //dateList.Add(date2);
            //dateList.Add(date3);
            //dateList.Sort();
            //dgvReqRpt.DataSource = dateList;
            //dgvReqRpt.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //dt = dgvReqRpt.DataSource as DataTable;
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add("Category", typeof(string));
            dt.Columns.Add("DeparmentName", typeof(string));
            dt.Columns.Add("Month", typeof(string));
            dt.Columns.Add("Year", typeof(int));
            dt.Columns.Add("Quantity", typeof(int));
            foreach (GridViewRow row in dgvReqRpt.Rows)
            {
                string cat = row.Cells[0].Text;
                string dptName = row.Cells[1].Text;
                string month = row.Cells[2].Text;
                int year = int.Parse(row.Cells[3].Text);
                int quantity = int.Parse(row.Cells[4].Text);
                dt.Rows.Add(cat, dptName, month, year, quantity);
            }
            DataView dv = new DataView(dt, "Category='Clip'","Year", DataViewRowState.CurrentRows);
            GridView1.DataSource = dv;
            GridView1.DataBind();
        }
    }
}