using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team10AD_Web.Model;
using System.Web.Services;
using Team10AD_Web.App_Code;
using Team10AD_Web.DTO;
using System.Globalization;

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

        //Get Order Quantity based on Categories selection
        public static int GetOrderedQuantity(string category, int month, int year)
        {
            int quantity = 0;
            using (Team10ADModel entities = new Team10ADModel())
            {
                List<string> itemCodeList = new List<string>();
                List<int> poItemQtyList = new List<int>();
                List<string> itemCodeMatchCatList = new List<string>();
                //get the list of PO ID from the selected months and years
                List<int> listPOID = entities.PurchaseOrders.Where
                    (x => x.CreationDate.Value.Month == month && x.CreationDate.Value.Year == year).Select
                    (x => x.POID).ToList();

                //get the list of itemCodes from POdetails within the list of POIDs 
                foreach (int POID in listPOID)
                {
                    itemCodeList = entities.PurchaseOrderDetails.Where(x => x.POID == POID).Select(x => x.ItemCode).ToList();
                }

                //get the list of itemCode matching the category
                foreach(string itemCode in itemCodeList)
                {
                    itemCodeMatchCatList = entities.Catalogues.Where(x => x.Category == category).Select(x => x.ItemCode).ToList();
                }

                int? orderedQty;

                //with the itemCodeMatchCatList, get the desired quantity of each item 
                foreach (string itemCodeMatchCat in itemCodeMatchCatList)
                {
                    foreach(int POID in listPOID)
                    {
                       orderedQty = entities.PurchaseOrderDetails.Where(x => x.ItemCode == itemCodeMatchCat & x.POID == POID).Select(x => x.Quantity).FirstOrDefault();
                        if (orderedQty!=null)
                        {
                            quantity += orderedQty.GetValueOrDefault();
                        }
                    }
                }
                return quantity;
            }
        }


        public static List<OrderReportDTO> CreateChartData(List<string> listCategory, List<DateDTO> listDate)
        {
            List<OrderReportDTO> listDTO = new List<OrderReportDTO>();
            using (Team10ADModel m = new Team10ADModel())
            {
                 foreach (string category in listCategory)
                    {
                        foreach (DateDTO item in listDate)
                        {
                            OrderReportDTO dto = new OrderReportDTO();
                            dto.Category = category;
                            dto.Month = item.Month;
                            dto.Year = item.Year;
                            int monthInInt = DateTime.ParseExact(item.Month, "MMM", CultureInfo.InvariantCulture).Month;
                            dto.OrderedQuantity = GetOrderedQuantity(category, monthInInt, Int32.Parse(item.Year));
                            listDTO.Add(dto);
                        }
                    } 
            }
            return listDTO;
        }

    }
}