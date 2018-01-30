using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using Team10AD_Web;
using Team10AD_Web.Model;
using Team10AD_Web.DTO;
namespace Team10AD_Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AuthConfig.RegisterOpenAuth();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            Session["requisitionCart"] = new List<string>();
            Session["departmentdetail"] = "";
            Session["Supplier"] = "";
            //Stores employee id to pass to detail page
            Session["employeeid"] = 112;
            //Stores clerk id to pass to detail page
            Session["clerkid"] = 10004;
            //Stores department id to pass to detail page
            Session["departmentcode"] = "CHEM";
            //Stores requisition id to pass to requisition detail page
            Session["requisitiondetail"] = "";
            //Stores HOD ID
            Session["HODID"] = 114;
            //Stores Approver ID
            Session["ApproverID"] =114;
           //Store shortfall items
            Session["Shortfall"]= new List<Catalogue>();
            Session["Catalogue"] = "";
            Session["deptListReport"]=new List<string>();
            Session["categoryListReport"]= new List<string>();
            Session["dateListReport"] = new List<DateDTO>();
            Session["listOrderCategory"] = new List<string>();
            Session["listOrderDates"] = new List<DateDTO>();
            Session["RequisitionReportDTOList"] = new List<RequisitionDTO>();
            Session["ChartType"] = "";
            Session["RequisitionReportDataTable"] = "";
            Session["ReqRtpSeries1"] = "";
            Session["ReqRtpSeries2"] = "";
            Session["ReqRtpSeries3"] = "";


        
        }
    }
}
