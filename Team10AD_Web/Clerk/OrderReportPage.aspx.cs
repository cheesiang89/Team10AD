using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web;
using Team10AD_Web.DTO;
using Team10AD_Web.Model;

namespace Team10AD_Web.Clerk
{
    public partial class OrderReportPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            orderChart.DataSource = (DataTable)Session["OrderReportDataTable"];
            orderChart.Series["Series1"].XValueMember = "MonthYear";
            orderChart.Series["Series1"].YValueMembers = "Quantity0";
            orderChart.Series["Series1"].LegendText = (string)Session["OrderRtpSeries1"].ToString();

            //If 2 Series
            string orderRtpSeries2 = (string)Session["OrderRtpSeries2"].ToString();
            if (!string.IsNullOrEmpty(orderRtpSeries2))
            {
                orderChart.Series["Series2"].XValueMember = "MonthYear";
                orderChart.Series["Series2"].YValueMembers = "Quantity1";
                orderChart.Series["Series2"].LegendText = orderRtpSeries2;
            }
            else
            {
                orderChart.Series["Series2"].LegendText = "None";

            }

            //If 3 Series
            string orderRtpSeries3 = (string)Session["OrderRtpSeries3"].ToString();
            if (!string.IsNullOrEmpty(orderRtpSeries3))
            {
                orderChart.Series["Series3"].XValueMember = "MonthYear";
                orderChart.Series["Series3"].YValueMembers = "Quantity2";
            }
            else
            {
                orderChart.Series["Series3"].LegendText = "None";

            }
                        orderChart.Titles["Title1"].Text = "Order Reports";
           
        }
    }
}