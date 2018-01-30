using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team10AD_Web.Clerk
{
    public partial class RequisitionReportPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            reqChart.DataSource = (DataTable)Session["RequisitionReportDataTable"];
            reqChart.Series["Series1"].XValueMember = "MonthYear";
            reqChart.Series["Series1"].YValueMembers = "Quantity0";
            reqChart.Series["Series2"].XValueMember = "MonthYear";
            reqChart.Series["Series2"].YValueMembers = "Quantity1";
            reqChart.Series["Series3"].XValueMember = "MonthYear";
            reqChart.Series["Series3"].YValueMembers = "Quantity2";

            reqChart.Series["Series1"].LegendText = (string)Session["ReqRtpSeries1"].ToString();
            reqChart.Series["Series2"].LegendText = (string)Session["ReqRtpSeries2"].ToString();
            reqChart.Series["Series3"].LegendText = (string)Session["ReqRtpSeries3"].ToString();

            if ((string)Session["ChartType"] == "dept")
            {
                //reqChart.Titles.Add("NewTitle");
                reqChart.Titles["Title1"].Text = "Requisition Reports with Department Comparison";
                //reqChart.Titles["Title1"].TextStyle
             

            }
            else
            {
                //reqChart.Titles.Add("NewTitle");
                reqChart.Titles["Title1"].Text = "Requisition Reports with Category Comparison";
            }
        }






    }
}