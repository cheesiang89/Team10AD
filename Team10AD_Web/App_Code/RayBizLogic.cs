using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team10AD_Web.App_Code.Model;

namespace Team10AD_Web.App_Code
{
    public static class RayBizLogic
    {
        public static List<Catalogue> SearchCatalogue(string search)
        {
            using (Team10ADModel context = new Team10ADModel())
            {
                return context.Catalogues.Where(x => x.Description.Contains(search) || x.Category.Contains(search)).ToList();
            }
        }

        public static List<Catalogue> CatalogueList()
        {
            using (Team10ADModel context = new Team10ADModel())
            {
                return context.Catalogues.ToList();
            }
        }

        public static string DepartmentId(string email)
        {
            using (Team10ADModel context = new Team10ADModel())
            {
                Model.Employee emp = context.Employees.Where(x => x.Email == email).First();
                return emp.DepartmentCode;
            }
        }

        public static int EmployeeId(string email)
        {
            using (Team10ADModel context = new Team10ADModel())
            {
                Model.Employee emp = context.Employees.Where(x => x.Email == email).First();
                return emp.EmployeeID;
            }
        }

        public static Model.Employee EmployeeObjById(int id)
        {
            using (Team10ADModel context = new Team10ADModel())
            {
                Model.Employee emp = context.Employees.Where(x => x.EmployeeID == id).First();
                return emp;
            }
        }

        public static List<Requisition> RequisitionList()
        {
            using (Team10ADModel context = new Team10ADModel())
            {
                return context.Requisitions.ToList();
            }
        }

        public static Requisition GetRequisitionById(string id)
        {
            int reqid = Convert.ToInt32(id);
            using (Team10ADModel context = new Team10ADModel())
            {
                Requisition req = context.Requisitions.Where(x => x.RequisitionID == reqid).First();
                return req;
            }
        }

        public static void CancelRequisition(int reqid)
        {
            using (Team10ADModel context = new Team10ADModel())
            {
                App_Code.Model.Requisition req = context.Requisitions.Where(x => x.RequisitionID == reqid).First();
                req.Status = "Cancelled";
                context.SaveChanges();
            }
        }

        public static List<Requisition> CombineReq(ArrayList reqIdList)
        {
            using (Team10ADModel context = new Team10ADModel())
            {
                List<Requisition> reqlist = new List<Requisition>();
                foreach (int id in reqIdList)
                {
                    reqlist.Add(context.Requisitions.Where(r => r.RequisitionID == id).First());
                }

                return reqlist;
            }
        }

        public static List<RequisitionDetail> CombineReqDetail(int id)
        {
            using (Team10ADModel context = new Team10ADModel())
            {
                return context.RequisitionDetails.Where(r => r.RequisitionID == id).ToList();
            }
        }

        public static void GenerateRetrievalList(List<RequisitionDetail> reqdetaillist, List<Requisition> reqList, int clerkid)
        {
            using (Team10ADModel context = new Team10ADModel())
            {
                List<RetrievalDetail> retrievallist = new List<RetrievalDetail>();

                //Creating a new retrieval record
                Retrieval retrievalnew = new Retrieval();
                retrievalnew.RetrievalDate = DateTime.Now;
                retrievalnew.StoreStaffID = clerkid;
                retrievalnew.Status = "Unretrieved";

                //Special bit of code to prevent Entity Framework from reinsert existing objects into database
                //The attach keyword lets EF become aware that the data existing. It only need to ref them
                //It prevents the entire graph from being added
                context.Retrievals.Add(retrievalnew);
                foreach (Requisition r in reqList)
                {
                    context.Requisitions.Attach(r);
                }   
                retrievalnew.Requisitions = reqList;
                context.SaveChanges();

                retrievalnew = context.Retrievals.OrderByDescending(x => x.RetrievalID).First();

                foreach (RequisitionDetail requisition in reqdetaillist)
                {
                    //Counter to check that there is no existing itemcode in the List<RequisitionDetail>
                    int itemcounter = 0;
                    foreach (RetrievalDetail retrieval in retrievallist)
                    {
                        //If itemcode exist, just increment the requested quantity
                        if (retrieval.ItemCode == requisition.ItemCode)
                        {
                            itemcounter++;
                            retrieval.RequestedQuantity += requisition.QuantityRequested;
                        }
                    }

                    //If no existing itemcode in the List<RequisitionDetail>, create a new instance of it
                    if (itemcounter == 0)
                    {
                        RetrievalDetail ret = new RetrievalDetail();
                        ret.RetrievalID = retrievalnew.RetrievalID;
                        ret.ItemCode = requisition.ItemCode;
                        ret.RequestedQuantity = requisition.QuantityRequested;
                        retrievallist.Add(ret);
                    }

                }

                //Saving the retrieval detail list into database
                foreach (RetrievalDetail retrieval in retrievallist)
                {
                    context.RetrievalDetails.Add(retrieval);
                    context.SaveChanges();
                }

            }

            //Havent check the quantity to make sure not complete
            //Havent enable partial retrieval based on balance quantity of items
        }

        public static object RetrievalListForGV()
        {
            using (Team10ADModel context = new Team10ADModel())
            {
                var qry = from r in context.Retrievals orderby r.Status descending select new { r.RetrievalID, r.RetrievalDate, r.Status };
                return qry.ToList();
            }
        }
    }
}