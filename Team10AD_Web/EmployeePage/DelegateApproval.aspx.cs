using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web;
using Team10AD_Web.App_Code.Model;
using Team10AD_Web.App_Code;
using System.Web.Services;

namespace Team10AD_Web.EmployeePage
    
    //Can approver also be rep????
{
    public partial class DelegateApproval : System.Web.UI.Page
    {
        string approverName;
        DateTime approvalStartDate;
        DateTime approvalEndDate;
        string departmentCode;
        int hodID;
        int employeeID;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Need to check the identity of the logged in user before we can load the employee list.
            //Need to get the HODID based on logged in employeeID
            //For now, we will always load the ARTS employee list.
            //Need to filter the HOD ID from the employee list from display[get from session state]. 

            //Change: Need to get employeeid, HODID, departmentid from Session state.
            Session["HODID"] = 104;
            Session["departmentid"] = "ARTS";
            Session["employeeid"] = 78;
            departmentCode = (string)Session["departmentid"];
            hodID = (int)Session["HODID"];
            employeeID = (int)Session["employeeid"];

            if (!IsPostBack)
            {       //Change: need to rename businesslogic path here
                    //only shows a particular employee list, excluding HOD name on the list to prevent unnecessary click.
                dgvDelegateApproval.DataSource = BusinessLogic_Sam.EmployeeList(departmentCode, hodID);
                dgvDelegateApproval.DataBind();

                //Check who is the current approver (if any) and change the button text to "Undelegate" & color to red, current approver row is highlighted
                approverName = BusinessLogic_Sam.checkCurrentApprover(departmentCode);
                if (approverName != null)
                {
                    for (int rowIndex = 0; rowIndex < dgvDelegateApproval.Rows.Count; rowIndex++)
                    {
                        if (dgvDelegateApproval.Rows[rowIndex].Cells[0].Text == approverName)
                        {
                            Button buttonDelegate = (Button)dgvDelegateApproval.Rows[rowIndex].FindControl("btnDelegate");
                            buttonDelegate.Text = "Undelegate";
                            buttonDelegate.BackColor = System.Drawing.Color.Red;
                            dgvDelegateApproval.Rows[rowIndex].BackColor = System.Drawing.Color.LightBlue;
                        }
                    }
                }
            }
        }


        protected void dgvDelegateApproval_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //Getting the row index of selected row & detect the delegate button's text.
                GridViewRow selectedRow = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                int selectedIndex = selectedRow.RowIndex;
                Button buttonDelegate = (Button)dgvDelegateApproval.Rows[selectedIndex].FindControl("btnDelegate");
                string buttonDelegateText = buttonDelegate.Text;

                //HOD taking back the authority 
                if (buttonDelegateText == "Undelegate")
                {
                    int approverID = (int)Session["HODID"];
                    approvalStartDate = new DateTime(2018, 1, 1);
                    approvalEndDate = new DateTime(2099, 1, 1);
                    try
                    {
                        //Change: need to rename businesslogic path here
                        BusinessLogic_Sam.delegateApprover(approverID, approvalStartDate, approvalEndDate, departmentCode);
                        //TODO: Send undelegate email

                        Response.Redirect("DelegateApproval.aspx");
                    }
                    catch (Exception exp)
                    {
                        Response.Write(exp.ToString());
                    }
                    //finally
                    //{
                       
                    //}
                }

                //if there are outstanding requisitions, delegation is not allowed and redirect to another page.
                else if (buttonDelegateText == "Delegate")
                {
                    //get the selectedApprover ID and calculate his/her pending requisitions
                    string selectedApproverName = selectedRow.Cells[0].Text;
                    //Change: need to rename businesslogic path here
                    int pendingReqQty = BusinessLogic_Sam.checkPendingRequisitionQuantity(selectedApproverName);
                    if (pendingReqQty == 0)
                    {
                        lblApprover.Text = selectedApproverName;
                        txtStartDate.Attributes["min"] = DateTime.Now.ToString("yyyy-MM-dd");
                        txtEndDate.Attributes["min"] = DateTime.Now.ToString("yyyy-MM-dd");
                        mPop1.Show();
                    }
                    else
                    {
                        lblFailApprover.Text = selectedRow.Cells[0].Text;
                        mPop2.Show();
                    }
                }
            }
        }

        //Cancel to Close Popup Panel 1
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            mPop1.Hide();
        }

        //Confirm to update new Approver
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            string approverName = lblApprover.Text;
            //Change: need to rename businesslogic path here
            int approverID = BusinessLogic_Sam.getApproverIDfromName(approverName);
            string startdate = txtStartDate.Text;
            DateTime approvalStartDate = Convert.ToDateTime(startdate);
            string enddate = txtEndDate.Text;
            DateTime approvalEndDate = Convert.ToDateTime(enddate);
            try
            {
                //Change: need to rename businesslogic path here
                BusinessLogic_Sam.delegateApprover(approverID, approvalStartDate, approvalEndDate,departmentCode);
                //TODO: Send Delegate email
            }
            catch (Exception exp)
            {
                Response.Write(exp.ToString());
            }
            finally
            {
                Response.Redirect("DelegateApproval.aspx");
            }
        }

        //Confirm to proceed to Deparment Requisition to approve pending requisitons 
        protected void btnConfirmProceed_Click(object sender, EventArgs e)
        {
            Response.Redirect("DepartmentRequisition.aspx");
        }

        //Cancel to close the Popup panel 2
        protected void btnCancelProceed_Click(object sender, EventArgs e)
        {
            mPop2.Hide();
        }

    }
}
