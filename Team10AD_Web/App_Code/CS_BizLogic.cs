using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Team10AD_Web.Model;
using Team10AD_Web.DTO;
using System.Globalization;
using System.Data;

namespace Team10AD_Web
{
    public static class CS_BizLogic
    {
        private static int requestorID;
        //Combine duplicates
        public static List<CartData> CombineDuplicates(List<CartData> oldList)
        {
            List<CartData> newList = new List<CartData>();

            var result = oldList.GroupBy(x => x.itemCode,
             (key, values) => new
             {
                 itemCode = key,
                 quantity = values.Sum(x => Int32.Parse(x.quantity)),

             });

            CartData c;
            foreach (var item in result.ToList())
            {
                //Console.WriteLine(item.itemCode + ":"+item.quantity);
                c = new CartData();
                c.itemCode = item.itemCode; c.quantity = item.quantity.ToString();
                newList.Add(c);
            }

            return newList;
        }
        //Make into list of Requisition - Required: ItemCode, Quantity, RequestorID, RequisitionDate, Status
        public static List<RequisitionDetail> CreateRequisition(List<CartData> oldList)
        {
            requestorID = Int32.Parse(oldList.Select(x => x).First().reqid);

            List<CartData> cartList = CombineDuplicates(oldList);

            //Convert CartData to RequisitonDetail object
            List<RequisitionDetail> requisitionList = new List<RequisitionDetail>();


            foreach (var item in cartList)
            {
                RequisitionDetail requisitionDTO = new RequisitionDetail();
                requisitionDTO.ItemCode = item.itemCode;
                requisitionDTO.QuantityRequested = Int32.Parse(item.quantity);
                requisitionList.Add(requisitionDTO);

            }

            using (Team10ADModel context = new Team10ADModel())
            {


                Requisition requisition = new Requisition();
                {
                    requisition.RequisitionDate = DateTime.Now;
                    requisition.Status = "Pending";
                    requisition.RequisitionDetails = requisitionList;
                    requisition.RequestorID = requestorID;

                };
                context.Requisitions.Add(requisition);
                context.SaveChanges();
                //Send notification
                LogicUtility.Instance.SendRequisitionEmail(requisition.RequisitionID, requisition.RequestorID, requisition.RequisitionDate.ToString());
            }


            return requisitionList;
        }
        public static List<ReportDTO> CreateChartData(List<string> listDept, List<string> listCategory, List<DateDTO> listDate)
        {
            List<ReportDTO> listDTO = new List<ReportDTO>();
            using (Team10ADModel m = new Team10ADModel())
            {
                //If Order report
                if (listDept==null)
                {
                    foreach (string category in listCategory)
                    {
                        foreach (DateDTO item in listDate)
                        {
                            ReportDTO dto = new ReportDTO();
                            dto.Category = category;
                           dto.Month = item.Month;
                            dto.Year = item.Year;
                            int monthInInt = DateTime.ParseExact(item.Month, "MMM", CultureInfo.InvariantCulture).Month;

                            dto.Quantity = GetQuantityOrdered(category, monthInInt, Int32.Parse(item.Year));
                            listDTO.Add(dto);
                        }
                    }
                }
                //If Requisition report
                else {
                    foreach (string dept in listDept)
                    {
                        foreach (string category in listCategory)
                        {
                            foreach (DateDTO item in listDate)
                            {
                                ReportDTO dto = new ReportDTO();
                                dto.Category = category;
                                dto.DepartmentName = dept;
                                dto.Month = item.Month;
                                dto.Year = item.Year;
                                int monthInInt = DateTime.ParseExact(item.Month, "MMM", CultureInfo.InvariantCulture).Month;
                           
                                dto.Quantity = GetQuantityRequested(dept, category, monthInInt, Int32.Parse(item.Year));
                                listDTO.Add(dto);
                            }
                        }
                    }
                }
            }
            return listDTO;
        }
       

        public static int GetQuantityRequested(string deptName, string category, int month, int year)
        {
            int quantity = 0;
            using (Team10ADModel m = new Team10ADModel())
            {
                //Get EmployeeIDs from Dept
                string deptCode = m.Departments.Where(x => x.DepartmentName == deptName).Select(x => x.DepartmentCode).First();
                List<int> employeeIDs = m.Employees.Where(x => x.DepartmentCode == deptCode).Select(x => x.EmployeeID).ToList();
                List<int> employeeRequisitionList = new List<int>();
                //Search the Requisitions with EmployeeIDs,RequisitonDates, Status = "Completed" to get RequisitionIDs

                foreach (int employeeID in employeeIDs)
                {
                    var req = m.Requisitions.
                        Where(x => x.RequestorID == employeeID &&
                        x.Status == "Completed" &&
                        x.RequisitionDate.Value.Month == month &&
                        x.RequisitionDate.Value.Year == year).Select(x => x.RequisitionID);
                    if (req.Any())
                    {
                        foreach (int reqNo in req)
                        {
                            employeeRequisitionList.Add(reqNo);
                        }

                    }

                }
                //Search the Catalogue with ItemCodes where Category == category 
                List<string> itemCodeList = m.Catalogues.Where(x => x.Category == category).Select(x => x.ItemCode).ToList();

                //CheckQuantity is a variable to cater for null values
                int? checkQuantity;

                //Search the RequisitionDetails with RequisitionIDs to get ItemCodes
                foreach (string itemCode in itemCodeList)
                {
                    foreach (int reqID in employeeRequisitionList)
                    {
                        checkQuantity = m.RequisitionDetails.Where(x => x.RequisitionID == reqID && x.ItemCode == itemCode).
                            Select(x => x.QuantityRequested).FirstOrDefault();
                        if (checkQuantity != null)
                        {
                            quantity += checkQuantity.GetValueOrDefault();
                        }
                    }
                }
            }
            return quantity;
        }
        public static int GetQuantityOrdered(string category, int month, int year)
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
                foreach (string itemCode in itemCodeList)
                {
                    itemCodeMatchCatList = entities.Catalogues.Where(x => x.Category == category).Select(x => x.ItemCode).ToList();
                }

                int? orderedQty;

                //with the itemCodeMatchCatList, get the desired quantity of each item 
                foreach (string itemCodeMatchCat in itemCodeMatchCatList)
                {
                    foreach (int POID in listPOID)
                    {
                        orderedQty = entities.PurchaseOrderDetails.Where(x => x.ItemCode == itemCodeMatchCat & x.POID == POID).Select(x => x.Quantity).FirstOrDefault();
                        if (orderedQty != null)
                        {
                            quantity += orderedQty.GetValueOrDefault();
                        }
                    }
                }
                return quantity;
            }
    
        }
        public static DataTable CreateDataTable(List<ReportDTO> reportData, List<DateDTO> listDate, List<string> deptOrCatList, string flag)
        {
            //Method caters for 2 scenarios:
            //1. Fixed Department: User chooses 1 dept and up to 3 categories, with up to 3 dates
            //2. Fixed Category: User chooses 1 category with up to 3 dept, with up to 3 dates
            // User passes in the list of dates and category/dept depending on which scenario chosen

            DataTable table = new DataTable();

            //Sort reportData by date
            reportData.Sort();
            //Create DataTable
            //User passes in list of Date + list of Dept
            //Assumption:  all RequisitionReportDTO objects have same Cat (need add validation on page)

            //Make columns: Month/Year, Qty1stCat, Qty2ndCat...
            table.Columns.Add("MonthYear", typeof(string));

            for (int i = 0; i < deptOrCatList.Count; i++)
            {
                //Create column based on no of selected Categories
                table.Columns.Add("Quantity" + i, typeof(string));
            }

            DataRow dr = null;
            foreach (DateDTO dateObj in listDate)
            {
                //create new row
                dr = table.NewRow();
                foreach (ReportDTO item in reportData)
                {

                    for (int j = 0; j < deptOrCatList.Count; j++)
                    {
                        if (item.Month == dateObj.Month && item.Year == dateObj.Year)
                        {
                            string monthYear = item.Month + " " + item.Year;
                            if (flag == "FIXEDDEPT")
                            {
                                //Iterate the Category list
                                //Add data to 2nd column if 1stCat, 3rd column if 2ndCat...
                                if (item.Category == deptOrCatList[j])
                                {
                                    dr["MonthYear"] = monthYear;
                                    dr["Quantity" + j] = item.Quantity;
                                }

                            }
                            else if (flag == "FIXEDCAT")
                            {
                                //Iterate the Dept list
                                //Add data to 2nd column if 1stDept, 3rd column if 2ndDept...
                                if (item.DepartmentName == deptOrCatList[j])
                                {
                                    dr["MonthYear"] = monthYear;
                                    dr["Quantity" + j] = item.Quantity;
                                }
                            }
                            else if (flag == "ORDER")
                            {
                                
                                //Add data to 2nd column if 1stCat, 3rd column if 2ndCat...
                                    dr["MonthYear"] = monthYear;
                                    dr["Quantity" + j] = item.Quantity;
                               
                            }
                        }
                    }
                    //add the row to DataTable if all values filled
                }
                if (!AreAnyColumnsEmpty(dr))
                {
                    table.Rows.Add(dr);
                }

            }
            return table;

        }


        public static bool AreAnyColumnsEmpty(DataRow dr)
        {
            if (dr == null)
            {
                return true;
            }
            else
            {
                if (String.IsNullOrEmpty(dr[0].ToString()))
                {
                    return true;
                }
                return false;
            }
        }
    }
}