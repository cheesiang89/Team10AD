﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team10AD_Web.EmployeePage
{
    public partial class RequisitionCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            reqID.Value = ((int)Session["employeeid"]).ToString();
        }
    }
}