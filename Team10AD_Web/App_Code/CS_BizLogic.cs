using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Team10AD_Web.App_Code.Model;


namespace Team10AD_Web.App_Code
{
    public static class CS_BizLogic
    {
        private static int reqID;
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
            reqID = Int32.Parse(oldList.Select(x => x).First().reqid);

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
                    requisition.RequestorID = reqID;

                };
                context.Requisitions.Add(requisition);
                context.SaveChanges();
            }
            return requisitionList;
        }

        //Send notification
    }
}