using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team10AD_Web.App_Code.Model;

namespace Team10AD_Web.App_Code
{
    public class BusinessLogic_Sam
    {
        public static void delegateApprover(int ApproverID, DateTime StartDate, DateTime EndDate)
        {
            using (Team10ADModel entities = new App_Code.Model.Team10ADModel())
            {
                //Assign ARTS department approver for now.
                Department deptApprover = entities.Departments.Where(p => p.DepartmentCode == "ARTS").First<Department>();
                deptApprover.ApproverID = ApproverID;
                deptApprover.ApprovingPeriodStart = StartDate;
                deptApprover.ApprovingPeriodEnd = EndDate;
                entities.SaveChanges();
            }
        }
    }
}