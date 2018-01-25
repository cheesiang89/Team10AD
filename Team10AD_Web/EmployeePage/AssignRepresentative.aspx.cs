using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web.App_Code;

namespace Team10AD_Web.EmployeePage
{
    public partial class AssignRepresentative : System.Web.UI.Page
    {
        string departmentCode;
        int hodID;
        int employeeID;
        string repName;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["HODID"] = 104;
            Session["departmentid"] = "ARTS";
            Session["employeeid"] = 78;
            departmentCode = (string)Session["departmentid"];
            hodID = (int)Session["HODID"];
            employeeID = (int)Session["employeeid"];

            if (!IsPostBack)
            {
                //populate employee list excluding the HOD
                dgvAssignRep.DataSource = BusinessLogic_Sam.EmployeeList(departmentCode, hodID);
                dgvAssignRep.DataBind();
                //check current rep name
                repName = BusinessLogic_Sam.checkCurrentRep(departmentCode);
                for (int rowIndex = 0; rowIndex < dgvAssignRep.Rows.Count; rowIndex++)
                {
                    if (dgvAssignRep.Rows[rowIndex].Cells[0].Text == repName)
                    {
                        Button buttonAssign = (Button)dgvAssignRep.Rows[rowIndex].FindControl("btnAssign");
                        buttonAssign.Text = "Current";
                        buttonAssign.BackColor = System.Drawing.Color.Red;
                        dgvAssignRep.Rows[rowIndex].BackColor = System.Drawing.Color.LightBlue;
                        lblRepName.Text = repName;
                        Session["CurrentRep"] = repName;
                        lblRepSubtitle1.Text = " is the current Department Representative.";
                    }
                }

            }
        }

        protected void dgvAssignRep_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Assign")
            {
                //assign representative
                GridViewRow selectedRow = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                int selectedIndex = selectedRow.RowIndex;
                Button buttonAssign = (Button)dgvAssignRep.Rows[selectedIndex].FindControl("btnAssign");
                string buttonAssignText = buttonAssign.Text;
                string newRepName = dgvAssignRep.Rows[selectedIndex].Cells[0].Text;

                if (buttonAssignText == "Assign")
                {
                    try
                    {
                        string oldRepName = (string)Session["CurrentRep"];
                        lblRepName.Text = newRepName;
                        lblRepSubtitle1.Text = " is the current Department Representative.";
                        BusinessLogic_Sam.assignNewRepresentative(oldRepName, newRepName, departmentCode);
                        Session["CurrentRep"] = newRepName;
                        Response.Redirect("AssignRepresentative.aspx");
                    }
                    catch (Exception exp)
                    {
                        Response.Write(exp.ToString());
                    }
                   
                }
                else
                {
                    lblRepName.Text = newRepName;
                    lblRepSubtitle1.Text = " is the current Department Representative. ";
                    lblRepSubtitle2.Text = "Please reselect new employee for assignment.";
                }
            }
        }

    }
}