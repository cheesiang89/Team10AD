﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web.App_Code.Model;

namespace Team10AD_Web.EmployeePage
{
    public partial class DisbursementDetailsPage : System.Web.UI.Page
    {
        BusinessLogic b = new BusinessLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Disbursement disbursement = (Disbursement)Session["Disbursement"];
                dgvDisList.DataSource = b.ShowDisbursementDetails(disbursement.DisbursementID);
                dgvDisList.DataBind();
            }
        }
    }
}