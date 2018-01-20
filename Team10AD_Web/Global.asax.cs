using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using Team10AD_Web;

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
            Session["employeeid"] = 78;
            //Stores clerk id to pass to detail page
            Session["clerkid"] = 10001;
            //Stores department id to pass to detail page
            Session["departmentcode"] = "ARTS";
            //Stores requisition id to pass to requisition detail page
            Session["requisitiondetail"] = "";
            //Stores HOD ID
            Session["HODID"] = 0;
        }
    }
}
