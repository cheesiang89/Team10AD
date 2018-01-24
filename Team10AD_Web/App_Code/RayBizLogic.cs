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

                foreach (RequisitionDetail requisition in reqdetaillist)
                {
                    //Counter to check that there is no existing itemcode in the List<RequisitionDetail>
                    int itemcounter = 0;
                    foreach (RetrievalDetail retrieval in retrievallist)
                    {
                        //If itemcode exist and quantity not fulfilled, just increment the requested quantity
                        if ((retrieval.ItemCode == requisition.ItemCode && (requisition.QuantityRequested - requisition.QuantityRetrieved) > 0) || (retrieval.ItemCode == requisition.ItemCode && requisition.QuantityRetrieved == null))
                        {
                            itemcounter++;
                            if (requisition.QuantityRetrieved == null)
                            {
                                retrieval.RequestedQuantity += requisition.QuantityRequested;
                            }
                            else
                            {
                                retrieval.RequestedQuantity += (requisition.QuantityRequested - requisition.QuantityRetrieved);
                            }
                        }
                    }

                    //If no existing itemcode and quantity not fulfilled in the List<RetrievalDetail>, create a new instance of it
                    if ((itemcounter == 0 && (requisition.QuantityRequested - requisition.QuantityRetrieved) > 0) || (itemcounter == 0 && requisition.QuantityRetrieved == null))
                    {
                        RetrievalDetail ret = new RetrievalDetail();
                        ret.RetrievalID = retrievalnew.RetrievalID;
                        ret.ItemCode = requisition.ItemCode;
                        if (requisition.QuantityRetrieved == null)
                        {
                            ret.RequestedQuantity = requisition.QuantityRequested;
                        }
                        else
                        {
                            ret.RequestedQuantity = (requisition.QuantityRequested - requisition.QuantityRetrieved);
                        }
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
                var qry = from r in context.Retrievals orderby r.Status descending, r.RetrievalID descending select new { r.RetrievalID, r.RetrievalDate, r.Status };
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
        /////////////////////////////////Temp modify "userinput" to "retrievaldetaillist" START
        public static void UpdateRetrievalDetailsFull(int retrievalid, List<RetrievalDetail> retrievaldetaillist, int clerkid)
        {
            using (Team10ADModel context = new Team10ADModel())
            {
                //Updating quantities in Catalogue, Retrieval and RetrievalDetail tables
                foreach (RetrievalDetail userdetail in retrievaldetaillist)
                {
                    RetrievalDetail existingdata = context.RetrievalDetails.Where(r => r.RetrievalID == userdetail.RetrievalID && r.ItemCode == userdetail.ItemCode).First();

                    existingdata.RetrievedQuantity = userdetail.RetrievedQuantity;

                    Catalogue item = context.Catalogues.Where(x => x.ItemCode == userdetail.ItemCode).First();
                    item.BalanceQuantity -= userdetail.RetrievedQuantity;
                    item.PendingRequestQuantity -= userdetail.RetrievedQuantity;

                    context.SaveChanges();
                }

                Retrieval retrieval = context.Retrievals.Where(x => x.RetrievalID == retrievalid).First();
                retrieval.Status = "Retrieved";
                context.SaveChanges();

                //Generate Disbursement and DisbursementDetails
                //List<RetrievalDetail> retrievaldetaillist = retrieval.RetrievalDetails.ToList();

                /////////////////////////////////Temp modify "userinput" to "retrievaldetaillist" END

                List<Requisition> reqlist = retrieval.Requisitions.ToList();
                List<Department> fulldeptlist = context.Departments.ToList();

                //Preparing the retrieved qty of the item to be splitted amount the disbursement
                Dictionary<string, int> retrievedqtybal = new Dictionary<string, int>();
                foreach (RetrievalDetail rd in retrievaldetaillist)
                {
                    //Assign zero if there is no value stored
                    int balqty = (rd.RetrievedQuantity == null) ? 0 : (int) rd.RetrievedQuantity;
                    retrievedqtybal.Add(rd.ItemCode, balqty);
                }

                foreach (Department d in fulldeptlist)
                {
                    //Counter to check if disbursement record was generated for this department
                    //This will determine to create a new disbursement for this department or not
                    int deptcounter = 0;
                    List<DisbursementDetail> disDetailList = new List<DisbursementDetail>();

                    //Disbursement disbursementnew = new Disbursement();
                    Disbursement disbursement = new Disbursement();

                    foreach (RetrievalDetail retrievaldetail in retrievaldetaillist)
                    {
                        //Match all requisition record of this retrieval to see if any match a department
                        foreach (Requisition r in reqlist)
                        {
                            //Counter to check for partial or completed requisition
                            int notcompletedcheck = 0;

                            //If match department, loop through the requisition detail and save into disbursement detail
                            if (d.DepartmentCode == r.Employee.DepartmentCode)
                            {
                                deptcounter++;
                                //Creating a new disbursement
                                if (deptcounter == 1)
                                {
                                    //Disbursement disbursement = new Disbursement();
                                    disbursement.CollectionDate = DateTime.Now;
                                    disbursement.PointID = r.Employee.Department.CollectionPoint.PointID;
                                    disbursement.DepartmentCode = r.Employee.DepartmentCode;
                                    disbursement.Status = "Uncollected";
                                    disbursement.StoreStaffID = clerkid;
                                    context.Disbursements.Add(disbursement);
                                    context.SaveChanges();

                                    //disbursementnew = context.Disbursements.OrderByDescending(x => x.DisbursementID).First();
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

                                            //The outer if set checks if the retrieved qty is sufficient to split among the departments
                                            if (retrievedqtybal[disDetail.ItemCode] >= reqdetail.QuantityRequested)
                                            {
                                                //Checks for partial/new requisition cases
                                                //If null can ignore the quantity retrieved in the requisition
                                                if (reqdetail.QuantityRetrieved == null)
                                                {
                                                    disDetail.QuantityRequested += reqdetail.QuantityRequested;
                                                    reqdetail.QuantityRetrieved = reqdetail.QuantityRequested;
                                                    retrievedqtybal[disDetail.ItemCode] -= (int)reqdetail.QuantityRequested;
                                                }
                                                //If not null can safetly do the math
                                                else
                                                {
                                                    disDetail.QuantityRequested += (reqdetail.QuantityRequested - reqdetail.QuantityRetrieved);
                                                    reqdetail.QuantityRetrieved += (reqdetail.QuantityRequested - reqdetail.QuantityRetrieved);
                                                    retrievedqtybal[disDetail.ItemCode] -= (int)(reqdetail.QuantityRequested - reqdetail.QuantityRetrieved);
                                                }
                                            }
                                            else if ((retrievedqtybal[disDetail.ItemCode] < reqdetail.QuantityRequested) && (retrievedqtybal[disDetail.ItemCode] > 0))
                                            {
                                                if (reqdetail.QuantityRetrieved == null)
                                                {
                                                    disDetail.QuantityRequested += retrievedqtybal[disDetail.ItemCode];
                                                    reqdetail.QuantityRetrieved += retrievedqtybal[disDetail.ItemCode];
                                                    retrievedqtybal[disDetail.ItemCode] -= (int)retrievedqtybal[disDetail.ItemCode];
                                                }
                                                else
                                                {
                                                    if (reqdetail.QuantityRetrieved + retrievedqtybal[disDetail.ItemCode] > reqdetail.QuantityRequested)
                                                    {
                                                        disDetail.QuantityRequested += (retrievedqtybal[disDetail.ItemCode] - reqdetail.QuantityRetrieved);
                                                        reqdetail.QuantityRetrieved += (retrievedqtybal[disDetail.ItemCode] - reqdetail.QuantityRetrieved);
                                                        retrievedqtybal[disDetail.ItemCode] -= (int)(retrievedqtybal[disDetail.ItemCode] - reqdetail.QuantityRetrieved);
                                                    }
                                                    else
                                                    {
                                                        disDetail.QuantityRequested += retrievedqtybal[disDetail.ItemCode];
                                                        reqdetail.QuantityRetrieved += retrievedqtybal[disDetail.ItemCode];
                                                        retrievedqtybal[disDetail.ItemCode] -= retrievedqtybal[disDetail.ItemCode];
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                //Actually not necessary since balance available to split to disbursement is already 0
                                                //Just putting a zero incase of null value
                                                if (reqdetail.QuantityRetrieved == null)
                                                {
                                                    disDetail.QuantityRequested += 0;
                                                    reqdetail.QuantityRetrieved = 0;
                                                }

                                            }

                                        }


                                    }
                                    //If no existing itemcode in the List<RequisitionDetail>, create a new instance of it
                                    if (reqdetail.ItemCode == retrievaldetail.ItemCode && itemcounter == 0)
                                    {
                                        DisbursementDetail disburementdetail = new DisbursementDetail();
                                        disburementdetail.DisbursementID = disbursement.DisbursementID;
                                        disburementdetail.ItemCode = reqdetail.ItemCode;

                                        if (retrievedqtybal[disburementdetail.ItemCode] >= reqdetail.QuantityRequested)
                                        {
                                            //Checks for partial/new requisition cases
                                            //If null can ignore the quantity retrieved in the requisition
                                            if (reqdetail.QuantityRetrieved == null)
                                            {
                                                disburementdetail.QuantityRequested = reqdetail.QuantityRequested;
                                                reqdetail.QuantityRetrieved = reqdetail.QuantityRequested;
                                                retrievedqtybal[disburementdetail.ItemCode] -= (int)reqdetail.QuantityRequested;
                                            }
                                            //If not null can safetly do the math
                                            else
                                            {
                                                disburementdetail.QuantityRequested = (reqdetail.QuantityRequested - reqdetail.QuantityRetrieved);
                                                reqdetail.QuantityRetrieved += (reqdetail.QuantityRequested - reqdetail.QuantityRetrieved);
                                                retrievedqtybal[disburementdetail.ItemCode] -= (int)(reqdetail.QuantityRequested - reqdetail.QuantityRetrieved);
                                            }
                                        }
                                        else if ((retrievedqtybal[disburementdetail.ItemCode] < reqdetail.QuantityRequested) && (retrievedqtybal[disburementdetail.ItemCode] > 0))
                                        {
                                            if (reqdetail.QuantityRetrieved == null)
                                            {
                                                disburementdetail.QuantityRequested = retrievedqtybal[disburementdetail.ItemCode];
                                                reqdetail.QuantityRetrieved = retrievedqtybal[disburementdetail.ItemCode];
                                                retrievedqtybal[disburementdetail.ItemCode] -= retrievedqtybal[disburementdetail.ItemCode];
                                            }
                                            else
                                            {
                                                if (reqdetail.QuantityRetrieved + retrievedqtybal[disburementdetail.ItemCode] > reqdetail.QuantityRequested)
                                                {
                                                    disburementdetail.QuantityRequested = (retrievedqtybal[disburementdetail.ItemCode] - reqdetail.QuantityRetrieved);
                                                    reqdetail.QuantityRetrieved += (retrievedqtybal[disburementdetail.ItemCode] - reqdetail.QuantityRetrieved);
                                                    retrievedqtybal[disburementdetail.ItemCode] -= (int)(retrievedqtybal[disburementdetail.ItemCode] - reqdetail.QuantityRetrieved);
                                                }
                                                else
                                                {
                                                    disburementdetail.QuantityRequested = retrievedqtybal[disburementdetail.ItemCode];
                                                    reqdetail.QuantityRetrieved += retrievedqtybal[disburementdetail.ItemCode];
                                                    retrievedqtybal[disburementdetail.ItemCode] -= retrievedqtybal[disburementdetail.ItemCode];
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (reqdetail.QuantityRetrieved == null)
                                            {
                                                reqdetail.QuantityRetrieved = 0;
                                            }
                                            disburementdetail.QuantityRequested = 0;
                                        }

                                        disDetailList.Add(disburementdetail);
                                    }
                                }
                                //Loop through details of requisition to check for completeness
                                foreach (RequisitionDetail rd in reqDetailList)
                                {
                                    if (rd.QuantityRequested != rd.QuantityRetrieved)
                                    {
                                        notcompletedcheck++;
                                    }
                                }
                                if (notcompletedcheck == 0)
                                {
                                    r.Status = "Completed";
                                }
                                else
                                {
                                    r.Status = "Partial";
                                }
                                context.SaveChanges();
                            }

                        }
                    }
                    //Creating a new set of disbursement details
                    if (deptcounter > 0)
                    {
                        foreach (DisbursementDetail ddetail in disDetailList)
                        {
                            context.DisbursementDetails.Add(ddetail);
                            //TODO: Send notification email
                            context.SaveChanges();
                        }
                    }

                    LogicUtility.Instance.SendDisbursementEmail(disbursement.DisbursementID);
                }


            }
        }

        public static int GenerateAdjustmentVoucherDetails(List<RetrievalDetail> suggested, List<RetrievalDetail> userinput, int clerkid)
        {
            using (Team10ADModel context = new Team10ADModel())
            {
                //To be returned for redirecting to the correct adjustment detail
                int adjustmentVoucherId = 0;
                //Counter to check whether there is any item that need adjustment
                int needAdjustment = 0;

                //StockAdjustmentVoucher adjNew = new StockAdjustmentVoucher();
                List<StockAdjustmentVoucherDetail> adjDetailList = new List<StockAdjustmentVoucherDetail>();

                foreach (RetrievalDetail sDetail in suggested)
                {
                    foreach (RetrievalDetail uDetail in userinput)
                    {
                        if (sDetail.ItemCode == uDetail.ItemCode)
                        {
                            //Check that there is a change in suggested quantity and that the balance is below the requested quantity
                            //This is to give clerk the flexibility to still reduce the quantity and not trigger an adjustment
                            if (sDetail.RetrievedQuantity < sDetail.RequestedQuantity && sDetail.RetrievedQuantity != uDetail.RetrievedQuantity)
                            {
                                needAdjustment++;
                                if (needAdjustment == 1)
                                {
                                    StockAdjustmentVoucher adj = new StockAdjustmentVoucher();
                                    adj.StoreStaffID = clerkid;
                                    adj.DateIssue = DateTime.Now;
                                    adj.Status = "Pending";
                                    context.StockAdjustmentVouchers.Add(adj);
                                    context.SaveChanges();

                                    //adjNew = context.StockAdjustmentVouchers.OrderByDescending(x => x.VoucherID).First();
                                    //adjustmentVoucherId = adjNew.VoucherID;

                                    adjustmentVoucherId = adj.VoucherID;
                                }

                                StockAdjustmentVoucherDetail adjDetail = new StockAdjustmentVoucherDetail();
                                adjDetail.VoucherID = adjustmentVoucherId;
                                adjDetail.ItemCode = uDetail.ItemCode;
                                adjDetail.QuantityAdjusted = -(uDetail.Catalogue.BalanceQuantity - uDetail.RetrievedQuantity);

                                Catalogue item = context.Catalogues.Where(x => x.ItemCode == adjDetail.ItemCode).First();
                                item.BalanceQuantity -= (uDetail.Catalogue.BalanceQuantity - uDetail.RetrievedQuantity);

                                adjDetail.QuantityAfter = item.BalanceQuantity;
                                adjDetailList.Add(adjDetail);
                                context.SaveChanges();
                            }
                        }
                    }
                }

                if (needAdjustment > 0)
                {
                    foreach (StockAdjustmentVoucherDetail detail in adjDetailList)
                    {
                        context.StockAdjustmentVoucherDetails.Add(detail);
                        context.SaveChanges();
                    }
                }

                StoreStaff supervisor = context.StoreStaffs.Where(x => x.Title == "Supervisor").First();
                StoreStaff manager = context.StoreStaffs.Where(x => x.Title == "Manager").First();
                if (adjustmentVoucherId > 0 && AdjustmentVoucherCost(adjustmentVoucherId) <= 250)
                {
                    LogicUtility.Instance.SendAdjustmentEmail(adjustmentVoucherId, supervisor.StoreStaffID);
                }
                else if (adjustmentVoucherId > 0 && AdjustmentVoucherCost(adjustmentVoucherId) > 250)
                {
                    LogicUtility.Instance.SendAdjustmentEmail(adjustmentVoucherId, manager.StoreStaffID);
                }

                return adjustmentVoucherId;
            }
        }

        public static object AdjustmentVoucherDetailForGV(int needAdjustment)
        {
            using (Team10ADModel context = new Team10ADModel())
            {
                var qry = from v in context.StockAdjustmentVoucherDetails where v.VoucherID == needAdjustment select new { v.ItemCode, v.Catalogue.Description, v.QuantityAdjusted };
                return qry.ToList();
            }
        }

        public static List<StockAdjustmentVoucherDetail> AdjustmentVoucherDetailById(int needAdjustment)
        {
            using (Team10ADModel context = new Team10ADModel())
            {
                List<StockAdjustmentVoucherDetail> adjVoucherDetail = context.StockAdjustmentVoucherDetails.Where(x => x.VoucherID == needAdjustment).ToList();
                return adjVoucherDetail;
            }
        }

        public static object AdjustmentVoucherList()
        {
            using (Team10ADModel context = new Team10ADModel())
            {
                var qry = from v in context.StockAdjustmentVouchers orderby v.Status descending select new { v.VoucherID, v.StoreStaff.Name, v.DateIssue, v.Status, Approver = v.StoreStaff1.Name };
                return qry.ToList();
            }
        }

        public static object AdjustmentVoucherDetailList(int id)
        {
            using (Team10ADModel context = new Team10ADModel())
            {
                var qry = from v in context.StockAdjustmentVoucherDetails where (v.VoucherID == id) select new { v.ItemCode, v.QuantityAdjusted, v.Reason };
                return qry.ToList();
            }
        }

        public static double AdjustmentVoucherCost(int id)
        {
            using (Team10ADModel context = new Team10ADModel())
            {
                List<StockAdjustmentVoucherDetail> detailList = context.StockAdjustmentVoucherDetails.Where(v => v.VoucherID == id).ToList();

                double totalCost = 0;

                foreach (StockAdjustmentVoucherDetail d in detailList)
                {
                    double avgprice = (double) context.SupplierDetails.Where(i => i.ItemCode == d.ItemCode).Average(x => x.Price);
                    //Take the absolute value because can have negative or positive quantity adjustment
                    totalCost += (Math.Abs((int) d.QuantityAdjusted) * avgprice);
                }
                return totalCost;
            }
        }

        public static StoreStaff GetStoreStaffById(int id)
        {
            using (Team10ADModel context = new Team10ADModel())
            {
                return context.StoreStaffs.Where(x => x.StoreStaffID == id).First();
            }

        }

        public static StockAdjustmentVoucher GetStockAdjustmentVoucherById(int id)
        {
            using (Team10ADModel context = new Team10ADModel())
            {
                return context.StockAdjustmentVouchers.Where(v => v.VoucherID == id).First();
            }
        }
    }
}

