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
        //Combine duplicates
        public static List<CartData> combineDuplicates(List<CartData> list)
        {
            List<CartData> newList = new List<CartData>();

            var result = list.GroupBy(x => x.itemCode,
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
        public static void CreateRequisition(string user, int foodID, string foodname,
string size, string chilli, string salt, string pepper)
        {
            using (Team10ADModel context = new Team10ADModel())
            {
                //RequisitionDetail = new RequisitionDetail();

                //Requisition order = new Requisition();
                //{
                //    RequisitionDate = user,
                //    RequestorID = foodID,
                //    Status = foodname,
                //    Size = size,
                //    Chilli = chilli,
                //    MoreSalt = salt,
                //    Pepper = pepper
                //};
                //entities.Orders.Add(order);
                //entities.SaveChanges();
            }
        }


        //public DateTime? RequisitionDate { get; set; }

        //public int? RequestorID { get; set; }

        //[StringLength(50)]
        //public string Status { get; set; }

        //RequisitionDetails = new HashSet<RequisitionDetail>();

        //      public string ItemCode { get; set; }

        //public int? QuantityRequested { get; set; }
        //Send notification
    }
}