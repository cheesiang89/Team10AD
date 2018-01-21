using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
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

        public static void ReqStatusProcessing(ArrayList reqIdList)
        {
            using (Team10ADModel context = new Team10ADModel())
            {
                foreach (int id in reqIdList)
                {
                    Requisition r = context.Requisitions.Where(x => x.RequisitionID == id).First();
                    r.Status = "Processing";
                    context.SaveChanges();
                }
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

        public static Retrieval GetRetrievalById(int id)
        {
            Team10ADModel context = new Team10ADModel();

            Retrieval ret = context.Retrievals.Where(x => x.RetrievalID == id).First();
            return ret;

        }

        public static List<RetrievalDetail> GetRetrievalList(int id)
        {
            Team10ADModel context = new Team10ADModel();

            return context.RetrievalDetails.Where(r => r.RetrievalID == id).ToList();

        }

        //DEPRECATED. Unable to update existing table due to lazy instead of eager retrieve
        //public static void UpdateRetrievalDetails(List<RetrievalDetail> userinput)
        //{
        //    using (Team10ADModel context = new Team10ADModel())
        //    {
        //        //Updating quantities in Catalogue, Retrieval and RetrievalDetail tables
        //        foreach (RetrievalDetail userdetail in userinput)
        //        {
        //            userdetail.QuantityAfter = userdetail.Catalogue.BalanceQuantity - userdetail.RetrievedQuantity;
        //            Catalogue item = context.Catalogues.Where(x => x.ItemCode == userdetail.ItemCode).First();
        //            item.BalanceQuantity -= userdetail.RetrievedQuantity;
        //            item.PendingRequestQuantity -= userdetail.RetrievedQuantity;
        //            context.SaveChanges();
        //        }

        //        Retrieval retrieval = GetRetrievalById(userinput[0].RetrievalID);
        //        retrieval.Status = "Retrieved";
        //        context.SaveChanges();

        //        //Generate Disbursement and DisbursementDetails

        //    }
        //}

        public static void UpdateRetrievalDetailsEager(int retrievalid, List<RetrievalDetail> userinput, int clerkid)
        {
            using (Team10ADModel context = new Team10ADModel())
            {
                //Updating quantities in Catalogue, Retrieval and RetrievalDetail tables
                foreach (RetrievalDetail userdetail in userinput)
                {
                    RetrievalDetail existingdata = context.RetrievalDetails.Where(r => r.RetrievalID == userdetail.RetrievalID && r.ItemCode == userdetail.ItemCode).First();

                    existingdata.RetrievedQuantity = userdetail.RetrievedQuantity;
                    existingdata.QuantityAfter = existingdata.Catalogue.BalanceQuantity - userdetail.RetrievedQuantity;
                    
                    Catalogue item = context.Catalogues.Where(x => x.ItemCode == userdetail.ItemCode).First();
                    item.BalanceQuantity -= userdetail.RetrievedQuantity;
                    item.PendingRequestQuantity -= userdetail.RetrievedQuantity;

                    context.SaveChanges();
                }

                Retrieval retrieval = context.Retrievals.Where(x => x.RetrievalID == retrievalid).First();
                retrieval.Status = "Retrieved";
                context.SaveChanges();

                //Generate Disbursement and DisbursementDetails
                retrieval = context.Retrievals.Where(x => x.RetrievalID == retrievalid).First();
                List<RetrievalDetail> retrievaldetaillist = retrieval.RetrievalDetails.ToList();
                List<Requisition> reqlist = retrieval.Requisitions.ToList();
                List<Department> fulldeptlist = context.Departments.ToList();


                foreach (Department d in fulldeptlist)
                {
                    //Counter to check if disbursement record was generated for this department
                    //This will determine to create a new disbursement for this department or not
                    int deptcounter = 0;
                    List<DisbursementDetail> disDetailList = new List<DisbursementDetail>();
                    Disbursement disbursementnew = new Disbursement();

                    foreach (RetrievalDetail retrievaldetail in retrievaldetaillist)
                    {
                        //Preparing the retrieved qty of the item to be splitted amount the disbursement
                        int balretrievedqty;
                        if (retrievaldetail.RetrievedQuantity != null)
                        {
                            balretrievedqty = (int)retrievaldetail.RetrievedQuantity;
                        }
                        else
                        {
                            balretrievedqty = 0;
                        }

                        //Match all requisition record of this retrieval to see if any match a department


                        foreach (Requisition r in reqlist)
                        {
                            //If match department, loop through the requisition detail and save into disbursement detail
                            if (d.DepartmentCode == r.Employee.DepartmentCode)
                            {
                                deptcounter++;
                                //Creating a new disbursement
                                if (deptcounter == 1)
                                {
                                    Disbursement disbursement = new Disbursement();
                                    disbursement.CollectionDate = DateTime.Now;
                                    disbursement.PointID = r.Employee.Department.CollectionPoint.PointID;
                                    disbursement.DepartmentCode = r.Employee.DepartmentCode;
                                    disbursement.Status = "Uncollected";
                                    disbursement.StoreStaffID = clerkid;
                                    context.Disbursements.Add(disbursement);
                                    context.SaveChanges();

                                    disbursementnew = context.Disbursements.OrderByDescending(x => x.DisbursementID).First();
                                }
                                List<RequisitionDetail> reqDetailList = r.RequisitionDetails.ToList();
                                foreach (RequisitionDetail reqdetail in reqDetailList)
                                {
                                    //Counter to make sure no duplicates of the item is created in the details
                                    int itemcounter = 0;
                                    foreach (DisbursementDetail disDetail in disDetailList)
                                    {
                                        //If itemcode exist, increment the requested quantity in the disbursement
                                        //Assign the quantity retrieved to the corresponding requisition
                                        //Decrement from the temporary store of the balance retrieved quantity
                                        if (disDetail.ItemCode == reqdetail.ItemCode && reqdetail.ItemCode == retrievaldetail.ItemCode)
                                        {
                                            itemcounter++;
                                            if (balretrievedqty >= reqdetail.QuantityRequested)
                                            {
                                                disDetail.QuantityRequested += reqdetail.QuantityRequested;

                                                reqdetail.QuantityRetrieved = reqdetail.QuantityRequested;
                                                balretrievedqty -= (int)reqdetail.QuantityRequested;
                                            }
                                            else if ((balretrievedqty < reqdetail.QuantityRequested) && (balretrievedqty > 0))
                                            {
                                                disDetail.QuantityRequested = balretrievedqty;

                                                reqdetail.QuantityRetrieved = balretrievedqty;
                                                balretrievedqty -= balretrievedqty;
                                            }
                                            else
                                            {
                                                disDetail.QuantityRequested = 0;

                                                reqdetail.QuantityRetrieved = 0;
                                            }

                                        }
                                    }

                                    //If no existing itemcode in the List<RequisitionDetail>, create a new instance of it
                                    if (reqdetail.ItemCode == retrievaldetail.ItemCode && itemcounter == 0)
                                    {
                                        DisbursementDetail disburementdetail = new DisbursementDetail();
                                        disburementdetail.DisbursementID = disbursementnew.DisbursementID;
                                        disburementdetail.ItemCode = reqdetail.ItemCode;
                                        disburementdetail.QuantityRequested = reqdetail.QuantityRequested;

                                        if (balretrievedqty >= reqdetail.QuantityRequested)
                                        {
                                            disburementdetail.QuantityRequested += reqdetail.QuantityRequested;

                                            reqdetail.QuantityRetrieved = reqdetail.QuantityRequested;
                                            balretrievedqty -= (int)reqdetail.QuantityRequested;
                                        }
                                        else if ((balretrievedqty < reqdetail.QuantityRequested) && (balretrievedqty > 0))
                                        {
                                            disburementdetail.QuantityRequested = balretrievedqty;

                                            reqdetail.QuantityRetrieved = balretrievedqty;
                                            balretrievedqty -= balretrievedqty;
                                        }
                                        else
                                        {
                                            disburementdetail.QuantityRequested = 0;

                                            reqdetail.QuantityRetrieved = 0;
                                        }

                                        disDetailList.Add(disburementdetail);

                                        reqdetail.QuantityRetrieved = reqdetail.QuantityRequested;
                                    }
                                }
                            }
                        }
                    }
                    //Creating a new set of disbursement details
                    if (deptcounter > 0)
                    {
                        foreach (DisbursementDetail ddetail in disDetailList)
                        {
                            context.DisbursementDetails.Add(ddetail);
                            context.SaveChanges();
                        }
                    }
                }


            }
        }

        public static void GenerateAdjustmentVoucherDetails(List<RetrievalDetail> suggested, List<RetrievalDetail> userinput)
        {

        }
    }
}