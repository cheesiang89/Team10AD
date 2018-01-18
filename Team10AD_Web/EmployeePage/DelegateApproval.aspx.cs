using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web;
using Team10AD_Web.App_Code.Model;
using Team10AD_Web.App_Code;

namespace Team10AD_Web.EmployeePage
{
    public partial class DelegateApproval : System.Web.UI.Page
    {
        String approverName;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Need to check the identity of the user before we can load the employee list.
            //For now, we will always load the ARTS employee list.
            //Need to filter the HOD ID from the employee list for display[get from session state]. 

            if (!IsPostBack)
            {
                using (Team10ADModel m = new Team10ADModel())
                {
                    dgvDelegateApproval.DataSource = m.Employees.Where(x => x.DepartmentCode == "ARTS").ToList();
                    dgvDelegateApproval.DataBind();
                    //Need to check who is the current approver (if any) and change the button text to "Undelegate" & color to red 
                    //If already is current approver & not null, need to prompt this is the current approver if button click/disable selection
                    var qry = m.Departments.Where(x => x.DepartmentCode == "ARTS").Select(x => new { x.ApproverID }).First();
                    if (qry != null)
                    {
                        int? approverID = qry.ApproverID;
                        String appID = approverID.ToString();
                        //For verification only
                        lblApproverID.Text = appID;
                        App_Code.Model.Employee currentApproverName = m.Employees.Where(x => x.EmployeeID == approverID).First();
                        approverName = currentApproverName.Name;
                        lblApproverName.Text = approverName;
                        if (approverName != null)
                        {
                            for (int rowIndex = 0; rowIndex < dgvDelegateApproval.Rows.Count; rowIndex++)
                            {
                                //dgvDelegateApproval.Rows[rowIndex].Cells[0].Text;

                                if (dgvDelegateApproval.Rows[rowIndex].Cells[0].Text == approverName)
                                {
                                    Button buttonDelegate = (Button)dgvDelegateApproval.Rows[rowIndex].FindControl("btnDelegate");
                                    buttonDelegate.Text = "Undelegate";
                                    buttonDelegate.BackColor = System.Drawing.Color.Red;
                                }
                            }
                        }
                    }

                }

            }
        }

        protected void dgvDelegateApproval_SelectedIndexChanged(object sender, EventArgs e)
        {
            //on click pop-up to delegate the approver:
            //update database table: ApproverID (EmployeeID), Start Date, End Date
            //String index = dgvDelegateApproval.SelectedIndex.ToString();
            //Label1.Text = index + "Selected";
      
        }

        protected void dgvDelegateApproval_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //int index = Convert.ToInt16(e.CommandArgument);
                //GridViewRow selectedRow = dgvDelegateApproval.Rows[index];
                //GridViewRow selectedRow = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                //lblApprover.Text = selectedRow.Cells[0].Text;
                //txtStartDate.Attributes["min"] = DateTime.Now.ToString("yyyy-MM-dd");
                //txtEndDate.Attributes["min"] = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            using (Team10ADModel mm = new Team10ADModel())
            {
                String approverName = lblApprover.Text;
                App_Code.Model.Employee emp = mm.Employees.Where(x => x.Name == approverName).First();
                int approverID = emp.EmployeeID;
                lblID.Text = approverID.ToString();
                String startdate = txtStartDate.Text;
                DateTime approvalStartDate = Convert.ToDateTime(startdate);
                String enddate = txtEndDate.Text;
                DateTime approvalEndDate = Convert.ToDateTime(enddate);

                try
                {
                    BusinessLogic_Sam.delegateApprover(approverID, approvalStartDate, approvalEndDate);
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





        }


        }
}