using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Team10AD_Web.Model;
using Team10AD_Web.DTO;

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
             (key, values) => new {
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
        public static List<RequisitionReportDTO> CreateChartData(List<string> listDept, List<string> listCategory, List<DateDTO> listDate)
        {
            List<RequisitionReportDTO> listDTO = new List<RequisitionReportDTO>();
            RequisitionReportDTO dto;
            using (Team10ADModel m = new Team10ADModel())
            {
                foreach (string dept in listDept)
                {
                    foreach (string category in listCategory)
                    {
                        foreach (DateDTO item in listDate)
                        {
                            dto = new RequisitionReportDTO();
                            dto.Category = category;
                            dto.DepartmentName = dept;
                            dto.Month = item.Month;
                            dto.Year = item.Year;
                            //dto.Quantity;
                        }
                    }
                }

            }
        }
        public static int GetQuantityRequested(string deptName, string category, int month, int year)
        {
            using (Team10ADModel m = new Team10ADModel())
            {
                //Get EmployeeIDs from Dept
                string deptCode = m.Departments.Where(x => x.DepartmentName == deptName).Select(x => x.DepartmentCode).First();
                List<int> employeeIDs = m.Employees.Where(x => x.DepartmentCode == deptCode).Select(x => x.EmployeeID).ToList();
                List<int> employeeRequisitionList= new List<int>();
                //Search the Requisitions with EmployeeIDs,RequisitonDates, Status = "Completed" to get RequisitionIDs
                Requisition req; 
                foreach (int employeeID in employeeIDs)
                {
                    req = m.Requisitions.
                        Where(x => x.RequestorID == employeeID &&
                        x.Status == "Completed" &&
                        x.RequisitionDate.Value.Month == month &&
                        x.RequisitionDate.Value.Year == year).Select(x => x).First();
                    employeeRequisitionList.Add(req.RequisitionID);
                }
                //Search the RequisitionDetails with RequisitionIDs to get ItemCodes
                foreach (int reqID in employeeRequisitionList)
                {

                }
                //Search the Catalogue with ItemCodes where Category == category 
            }



        }
    }
}