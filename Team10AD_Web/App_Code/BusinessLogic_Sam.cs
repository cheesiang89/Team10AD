using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team10AD_Web.App_Code.Model;
using System.Web.Services;

namespace Team10AD_Web.App_Code
{


    public class BusinessLogic_Sam
    {

        public static int getApproverIDfromName(string approverName)
        {
            using (App_Code.Model.Team10ADModel entities = new App_Code.Model.Team10ADModel())
            {
                App_Code.Model.Employee emp = entities.Employees.Where(x => x.Name == approverName).First();
                int approverID = emp.EmployeeID;
                return approverID;
            }
        }


        //Return EmployeeList excluding the HOD
        public static List<Employee> EmployeeList(string departmentCode, int hodID)
        {
            using (App_Code.Model.Team10ADModel entities = new App_Code.Model.Team10ADModel())
            {
                var deptEmp = (from x in entities.Employees where x.DepartmentCode == departmentCode && x.EmployeeID != hodID select x).ToList();
                return deptEmp;
            }
        }


        public static string checkCurrentApprover(string departmentCode)
        {
            using (App_Code.Model.Team10ADModel entities = new App_Code.Model.Team10ADModel())
            {
                var qry = entities.Departments.Where(x => x.DepartmentCode == departmentCode).Select(x => new { x.ApproverID }).First();
                int? approverID = qry.ApproverID;
                App_Code.Model.Employee currentApproverID = entities.Employees.Where(x => x.EmployeeID == approverID).First();
                string currentApproverName = currentApproverID.Name;
                return currentApproverName;
            }

        }

        public static string checkCurrentRep(string departmentCode)
        {
            using (App_Code.Model.Team10ADModel entities = new App_Code.Model.Team10ADModel())
            {
                var qry = entities.Departments.Where(x => x.DepartmentCode == departmentCode).Select(x => new { x.RepresentativeID }).First();
                int? repID = qry.RepresentativeID;
                App_Code.Model.Employee currentRepID = entities.Employees.Where(x => x.EmployeeID == repID).First();
                string currentRepName = currentRepID.Name;
                return currentRepName;
            }
        }

        public static int checkPendingRequisitionQuantity(string selectedApproverName)
        {
            using (App_Code.Model.Team10ADModel entities = new App_Code.Model.Team10ADModel())
            {
                int selectedApproverID = ((from x in entities.Employees where x.Name == selectedApproverName select new { x.EmployeeID }).First()).EmployeeID;
                int pendingReqQty = (from x in entities.Requisitions where x.RequestorID == selectedApproverID && x.Status == "Pending" select x).Count();
                return pendingReqQty;
            }
        }

        //Need to pass in departmentCode here
        public static string delegateApprover(int ApproverID, DateTime startDate, DateTime endDate, string departmentCode)
        {
            string status = "";

            using (App_Code.Model.Team10ADModel entities = new App_Code.Model.Team10ADModel())
            {

                Department deptApprover = entities.Departments.Where(p => p.DepartmentCode == departmentCode).First<Department>();
                deptApprover.ApproverID = ApproverID;
                deptApprover.ApprovingPeriodStart = startDate;
                deptApprover.ApprovingPeriodEnd = endDate;
                entities.SaveChanges();
                status = "success";
            }
            return status;
        }


        public static void assignNewRepresentative(string newRepName, string departmentCode)
        {
            using (App_Code.Model.Team10ADModel entities = new App_Code.Model.Team10ADModel())
            {
                int newRepID = ((from x in entities.Employees where x.Name == newRepName select new { x.EmployeeID }).First()).EmployeeID;
                Department deptRepresentative = entities.Departments.Where(p => p.DepartmentCode == departmentCode).First<Department>();
                deptRepresentative.RepresentativeID = newRepID;
                entities.SaveChanges();

            }
        }

        public static List<Requisition> getDepartmentPendingRequisition(string departmentCode)
        {
            //get all requisitions status with "Pending"
            //get all requestorID where they are from the particular department
            //loop through the pending requisitions where the requestors are from that particular department
            List<int> deptEmpIdList = new List<int>();
            List<Requisition> allPendingRequisitionList = new List<Requisition>();
            List<Requisition> deptPendingRequisitionList = new List<Requisition>();
            Dictionary<int, string> deptEmployeeList = new Dictionary<int, string>();

            using (App_Code.Model.Team10ADModel entities = new App_Code.Model.Team10ADModel())
            {

                //Get the list of requisitions with status = "Pending"
                var qry = entities.Requisitions.Where(x => x.Status == "Pending");
                allPendingRequisitionList = qry.ToList();

                //Get the list of employees in that particular department
                List<Employee> deptEmpList = entities.Employees.Where(x => x.DepartmentCode == departmentCode).ToList();
                foreach (Employee emp in deptEmpList)
                {
                    deptEmpIdList.Add(emp.EmployeeID);
                    deptEmployeeList.Add(emp.EmployeeID, emp.Name);

                }

                //Get the list of Pending requisitions from that particular department
                foreach (Requisition req in allPendingRequisitionList)
                {
                    foreach (int reqId in deptEmpIdList)
                    {
                        if (req.RequestorID.Equals(reqId))
                        {
                            deptPendingRequisitionList.Add(req);
                        }
                    }
                }
                return deptPendingRequisitionList;
            }
        }


        public static object getEmployeeNamefromRequestorID(string departmentCode)
        {
            object empPendingReq = new object();
            using (App_Code.Model.Team10ADModel entities = new App_Code.Model.Team10ADModel())
            {

                var qry1 = from x in entities.Requisitions
                           from y in entities.Employees
                           where x.RequestorID == y.EmployeeID && y.DepartmentCode == departmentCode && x.Status == "Pending"
                           select new { x.RequestorID, x.RequisitionDate, y.Name };

                //var qry = (from x in entities.Requisitions
                //           join y in entities.Employees on x.RequestorID equals y.EmployeeID
                //           where y.DepartmentCode == departmentCode && x.Status == "Pending"
                //           select x).ToList();

                empPendingReq = qry1.ToList();
                return empPendingReq;


                //        //var projects = (from p in DBContext.projects
                //        //                join o in DBContext.organizations on p.organization_id equals o.organization_id
                //        //                join m in DBContext.members on o.organization_id equals m.organization_id
                //        //                where m.member_id == performed_by_id
                //        //                select p).ToList();
                //        //return projects;
                //    }
                //}

            }
        }
    }
}