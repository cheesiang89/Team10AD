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
            using (Team10ADModel entities = new Team10ADModel())
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


        public static object getDepartmentPendingRequisition(string departmentCode)
        {
            object empPendingReq = new object();
            using (App_Code.Model.Team10ADModel entities = new App_Code.Model.Team10ADModel())
            {

                var qry1 = from x in entities.Requisitions
                           from y in entities.Employees
                           where x.RequestorID == y.EmployeeID && y.DepartmentCode == departmentCode && x.Status == "Pending"
                           select new { x.RequestorID, x.RequisitionDate, y.Name,x.RequisitionID };

                empPendingReq = qry1.ToList();
                return empPendingReq;
            }
        }

        public static object getDepartmentRequisitionList(string departmentCode)
        {
            object empDptReqList = new object();
            using (App_Code.Model.Team10ADModel entities = new App_Code.Model.Team10ADModel())
            {
                var qry2 = from x in entities.Requisitions
                           from y in entities.Employees
                           where x.RequestorID == y.EmployeeID && y.DepartmentCode == departmentCode
                           select new { x.RequestorID, x.RequisitionDate, y.Name, x.RequisitionID, x.Status };
                empDptReqList = qry2.ToList();
                return empDptReqList;
            }
        }

        public static void approveRequisition(int requisitionId,string remarks, string approverID)
        {
            //DateTime approvalDate = new DateTime();
            using(Team10ADModel entities = new Team10ADModel())
            {
                Requisition req = entities.Requisitions.Where(p => p.RequisitionID == requisitionId).SingleOrDefault();
                req.Status = "Approved";
                req.Remarks = remarks;
                req.ApprovalDate = DateTime.Now;
                req.ApproverID = Convert.ToInt32(approverID);
                //RequisitionDetail reqDetails = entities.RequisitionDetails.Where()
                entities.SaveChanges();
            }

        }

        public static void updateItemStockLevel(Dictionary<string, int> reqListItems)
        {

            using(Team10ADModel entities = new Team10ADModel())
            {
                Catalogue catReqItem = new Catalogue();
                string key;
                int keyValue; int balance; int pendDelQty;
                int pendReqQty; int reorderLvl;
                int stockCheckQty;
                //for(int index = 0; index < reqListItems.Count; index++)
                //{
                //    key= reqListItems[  
                //    catReqItem = entities.Catalogues.Where(p => p.ItemCode == reqListItems[index].Key.ToString()).FirstOrDefault();

                //}

                foreach (KeyValuePair<string, int> catItem in reqListItems)
                {
                    key = catItem.Key;
                    keyValue = catItem.Value;
                    catReqItem = entities.Catalogues.Where(p => p.ItemCode == key).FirstOrDefault();
                    catReqItem.PendingRequestQuantity = keyValue;
                    balance = (int)catReqItem.BalanceQuantity;
                    pendDelQty = (int)catReqItem.PendingDeliveryQuantity;
                    pendReqQty = keyValue;
                    reorderLvl = (int)catReqItem.ReorderLevel;
                    stockCheckQty = balance + pendDelQty - pendReqQty;
                    //if the reorder level more than (balance+pending delivery quantity - pending request delivery), shortfall status = false
                    if (stockCheckQty < reorderLvl)
                    {
                        catReqItem.ShortfallStatus = "True";
                    }
                }

                entities.SaveChanges();
            }
        }


        public static void rejectRequisition(int requisitionId,string remarks)
        {
                using (Team10ADModel entities = new Team10ADModel())
                {
                    Requisition req = entities.Requisitions.Where(p => p.RequisitionID == requisitionId).SingleOrDefault();
                    req.Status = "Rejected";
                    req.Remarks = remarks;
                    entities.SaveChanges();
                }
            
        }

    }
}