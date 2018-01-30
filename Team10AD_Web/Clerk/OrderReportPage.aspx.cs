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
            orderChart.Series["Series2"].XValueMember = "MonthYear";
            orderChart.Series["Series2"].YValueMembers = "Quantity1";
                   
                orderChart.Titles["Title1"].Text = "Order Reports";
           
        }
    }
}