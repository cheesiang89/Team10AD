using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team10AD_Web.Model;
using System.Web.Services;

namespace Team10AD_Web
{

    public class BusinessLogic_Sam
    {
        public static int getApproverIDfromName(string approverName)
        {
            using (Team10ADModel entities = new Team10ADModel())
            {
                Employee emp = entities.Employees.Where(x => x.Name == approverName).First();
                int approverID = emp.EmployeeID;
                return approverID;
            }
        }


        //Return EmployeeList excluding the HOD
        public static List<Employee> EmployeeList(string departmentCode, int hodID)
        {
            using (Team10ADModel entities = new Team10ADModel())
            {
                var deptEmp = (from x in entities.Employees where x.DepartmentCode == departmentCode && x.EmployeeID != hodID select x).ToList();
                return deptEmp;
            }
        }


        public static string checkCurrentApprover(string departmentCode)
        {
            using (Team10ADModel entities = new Team10ADModel())
            {
                var qry = entities.Departments.Where(x => x.DepartmentCode == departmentCode).Select(x => new { x.ApproverID }).First();
                int? approverID = qry.ApproverID;
               Employee currentApproverID = entities.Employees.Where(x => x.EmployeeID == approverID).First();
                string currentApproverName = currentApproverID.Name;
                return currentApproverName;
            }

        }

        public static string checkCurrentRep(string departmentCode)
        {
            using (Team10ADModel entities = new Team10ADModel())
            {
                var qry = entities.Departments.Where(x => x.DepartmentCode == departmentCode).Select(x => new { x.RepresentativeID }).First();
                int? repID = qry.RepresentativeID;
                Employee currentRepID = entities.Employees.Where(x => x.EmployeeID == repID).First();
                string currentRepName = currentRepID.Name;
                return currentRepName;
            }
        }

        public static int checkPendingRequisitionQuantity(string selectedApproverName)
        {
            using (Team10ADModel entities = new Team10ADModel())
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

            using (Team10ADModel entities = new Team10ADModel())
            {

                Department deptApprover = entities.Departments.Where(p => p.DepartmentCode == departmentCode).First<Department>();
                deptApprover.ApproverID = ApproverID;
                deptApprover.ApprovingPeriodStart = startDate;
                deptApprover.ApprovingPeriodEnd = endDate;
                entities.SaveChanges();
                //Send email
                string selectedApproverName = entities.Employees.Where(x => x.EmployeeID == ApproverID).Select(x => x.Name).First();
                LogicUtility.Instance.SendApproverEmail(selectedApproverName, startDate.ToShortTimeString(), endDate.ToShortTimeString());
                status = "success";
            }
            return status;
        }


        public static void assignNewRepresentative(string oldRepName, string newRepName, string departmentCode)
        {
            using (Team10ADModel entities = new Team10ADModel())
            {
                int newRepID = ((from x in entities.Employees where x.Name == newRepName select new { x.EmployeeID }).First()).EmployeeID;
                Department deptRepresentative = entities.Departments.Where(p => p.DepartmentCode == departmentCode).First<Department>();
                deptRepresentative.RepresentativeID = newRepID;
                LogicUtility.Instance.SendRepEmail(newRepName, "ASSIGN");
                LogicUtility.Instance.SendRepEmail(oldRepName, "UNASSIGN");
                entities.SaveChanges();

            }
        }


        public static object getDepartmentPendingRequisition(string departmentCode)
        {
            object empPendingReq = new object();
            using (Team10ADModel entities = new Team10ADModel())
            {

                var qry1 = from x in entities.Requisitions
                           from y in entities.Employees
                           where x.RequestorID == y.EmployeeID && y.DepartmentCode == departmentCode && x.Status == "Pending"
                           select new { x.RequestorID, x.RequisitionDate, y.Name, x.RequisitionID };

                empPendingReq = qry1.ToList();
                return empPendingReq;
            }
        }

        public static object getDepartmentRequisitionList(string departmentCode)
        {
            object empDptReqList = new object();
            using (Team10ADModel entities = new Team10ADModel())
            {
                var qry2 = from x in entities.Requisitions
                           from y in entities.Employees
                           where x.RequestorID == y.EmployeeID && y.DepartmentCode == departmentCode
                           select new { x.RequestorID, x.RequisitionDate, y.Name, x.RequisitionID, x.Status };
                empDptReqList = qry2.ToList();
                return empDptReqList;
            }
        }

        public static void approveRequisition(int requisitionId, string remarks, string approverID)
        {
            //DateTime approvalDate = new DateTime();
            using (Team10ADModel entities = new Team10ADModel())
            {
                Requisition req = entities.Requisitions.Where(p => p.RequisitionID == requisitionId).SingleOrDefault();
                req.Status = "Approved";
                req.Remarks = remarks;
                req.ApprovalDate = DateTime.Now;
                req.ApproverID = Convert.ToInt32(approverID);
                //RequisitionDetail reqDetails = entities.RequisitionDetails.Where()
                entities.SaveChanges();
                //Send email

                LogicUtility.Instance.SendRequisitionResponseEmail(requisitionId, remarks, "APPROVED");
            }

        }

        public static void updateItemStockLevel(Dictionary<string, int> reqListItems)
        {

            using (Team10ADModel entities = new Team10ADModel())
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


        public static void rejectRequisition(int requisitionId, string remarks)
        {
            using (Team10ADModel entities = new Team10ADModel())
            {
                Requisition req = entities.Requisitions.Where(p => p.RequisitionID == requisitionId).SingleOrDefault();
                req.Status = "Rejected";
                req.Remarks = remarks;
                entities.SaveChanges();
            }
            //Send email

            LogicUtility.Instance.SendRequisitionResponseEmail(requisitionId, remarks, "REJECTED");
        }

        public static string checkDepartmentCodefromName(string DepartmentName)
        {
            using (Team10ADModel entities = new Team10ADModel())
            {
                var qry = entities.Departments.Where(x => x.DepartmentName == DepartmentName).Select(x => new { x.DepartmentCode }).First();
                string departmentCode = qry.DepartmentCode;
                return departmentCode;
            }

        }


        ////If user selected 1 category, 3 dates and 3 departments
        //public static List<RequisitionReport> getReqReportByACatThDThDpt(string Category, List<int> Months, List<int> Years, List<string> DepartmentCode)
        //{
        //    using (Team10ADModel entities = new Team10ADModel())
        //    {
        //        int listMonthCount = Months.Count;
        //        int listYearCount = Years.Count;
        //        int listDptCount = DepartmentCode.Count;

        //        int month1 = Months[0]; int year1 = Years[0];
        //        int month2 = Months[1]; int year2 = Years[1];
        //        int month3 = Months[2]; int year3 = Years[2];
        //        string dptCode1 = DepartmentCode[0];
        //        string dptCode2 = DepartmentCode[1];
        //        string dptCode3 = DepartmentCode[2];

        //        var reqry = (from rd in entities.RequisitionDetails
        //                     join req in entities.Requisitions on rd.RequisitionID equals req.RequisitionID
        //                     join item in entities.Catalogues on rd.ItemCode equals item.ItemCode
        //                     join emp in entities.Employees on req.RequestorID equals emp.EmployeeID
        //                     join dept in entities.Departments on emp.DepartmentCode equals dept.DepartmentCode
        //                     where (item.Category == Category && ((req.RequisitionDate.Value.Month == month1 && req.RequisitionDate.Value.Year == year1) ||
        //                     (req.RequisitionDate.Value.Month == month2 && req.RequisitionDate.Value.Year == year2) ||
        //                     (req.RequisitionDate.Value.Month == month3 && req.RequisitionDate.Value.Year == year3))
        //                     && (emp.DepartmentCode == dptCode1 || emp.DepartmentCode == dptCode2) || emp.DepartmentCode == dptCode3)
        //                     select new DTO.RequisitionReport
        //                     {
        //                         RequisitionID = req.RequisitionID,
        //                         DepartmentCode = emp.DepartmentCode,
        //                         RequestorID = (int)req.RequestorID,
        //                         ReqDate = (DateTime)req.RequisitionDate,
        //                         ItemCode = item.ItemCode,
        //                         Category = item.Category,
        //                         QtyRequested = (int)rd.QuantityRequested,
        //                     }).ToList<RequisitionReport>();

        //        return reqry.ToList();
        //    }
        //}

        ////If user selected 1 category, 2 dates and 2 departments
        //public static List<RequisitionReport> getReqReportByACatTwoDTwoDpt(string Category, List<string> Date, List<string> DepartmentCode)
        //{
        //    using (Team10ADModel entities = new Team10ADModel())
        //    {
        //        int listDateCount = Date.Count;
        //        int listDptCount = DepartmentCode.Count;

        //        DateTime date1 = Convert.ToDateTime(Date[0]).Date;
        //        string dptCode1 = DepartmentCode[0];
        //        DateTime date2 = Convert.ToDateTime(Date[1]).Date;
        //        string dptCode2 = DepartmentCode[1];


        //        var reqry = (from rd in entities.RequisitionDetails
        //                     join req in entities.Requisitions on rd.RequisitionID equals req.RequisitionID
        //                     join item in entities.Catalogues on rd.ItemCode equals item.ItemCode
        //                     join emp in entities.Employees on req.RequestorID equals emp.EmployeeID
        //                     join dept in entities.Departments on emp.DepartmentCode equals dept.DepartmentCode
        //                     where (item.Category == Category && (req.RequisitionDate == date1 || req.RequisitionDate == date2) && (emp.DepartmentCode == dptCode1 || emp.DepartmentCode == dptCode2))
        //                     select new DTO.RequisitionReport
        //                     {
        //                         RequisitionID = req.RequisitionID,
        //                         DepartmentCode = emp.DepartmentCode,
        //                         RequestorID = (int)req.RequestorID,
        //                         ReqDate = (DateTime)req.RequisitionDate,
        //                         ItemCode = item.ItemCode,
        //                         Category = item.Category,
        //                         QtyRequested = (int)rd.QuantityRequested,
        //                     }).ToList();

        //        return reqry.ToList<RequisitionReport>();
        //    }
        //}


        ////Doesn't allow user to choose 1 date, 1 dept and 1 cat

        ////If user selected 1 Cat, 2 Date, 3 Dept
        ////If user selected 1 Cat 1 Date, 3 Dept
        ////If user selected 1 Cat, 1 Date, 2 Dept




        ////Get Order Quantity based on Categories
        //public static int GetOrderedQuantity(string category, int month, int year)
        //{
        //    using (Team10ADModel entities = new Team10ADModel())
        //    {
        //        List<string> itemCodeList = new List<string>();
        //        List<int> poItemQtyList = new List<int>();
        //        //get the list of PO ID from the selected months and years
        //        List<int> listPOID = entities.PurchaseOrders.Where
        //            (x => x.CreationDate.Value.Month == month && x.CreationDate.Value.Year == year).Select
        //            (x => x.POID).ToList();

        //        //filter the itemcode with condition that matches the category
        //        //find the suppliers of the itemcode
        //        //from the PO IDs get the itemCode matching category from PO details
        //        //foreach (int POID in listPOID)
        //        //{
        //        //    //List<int> orderQty = entities.PurchaseOrderDetails.Where(x=>x.POID==POID )
        //        //    var qry = from poitems in entities.PurchaseOrderDetails
        //        //              join polist in entities.PurchaseOrders on poitems.POID equals polist.POID
        //        //              join item in entities.Catalogues on poitems.ItemCode equals item.ItemCode
        //        //              where(poitems.POID==POID)
        //        //              select(poitems.ItemCode)

        //        //}
        //        //get the list of itemCode & qty requested from POdetails within the list of POIDs

        //        //get the list of itemCodes from POdetails within the list of POIDs
        //        foreach (int POID in listPOID)
        //        {
        //            itemCodeList = entities.PurchaseOrderDetails.Where(x => x.POID == POID).Select(x => x.ItemCode).ToList();
        //        }

        //        foreach (string itemCode in itemCodeList)
        //        {
        //            var qry = entities.PurchaseOrderDetails.Where(x => x.ItemCode == itemCode).Select(x => x.Quantity).ToList();
        //            if (qry.Any())
        //            {
        //                foreach (int itemqty in qry)
        //                {
        //                    poItemQtyList.Add(itemqty);
        //                }

        //            }
        //        }



        //        //sum the quantity
        //    }
       // }

    }
}