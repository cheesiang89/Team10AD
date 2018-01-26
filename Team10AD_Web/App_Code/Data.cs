using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team10AD_Web.Model;
using Team10AD_Web;

namespace Team10AD_Web
{
    public class Data
    {
        //////Voucher

        public static void InsertVoucher(List<StockAdjustmentVoucherDetail> detailList, int storeStaffID)
        {
            using (Team10ADModel m = new Team10ADModel())
            {
                StockAdjustmentVoucher voucher = new StockAdjustmentVoucher();
                voucher.StoreStaffID = storeStaffID;
                voucher.DateIssue = DateTime.Now;
                voucher.Status = "Pending";
                m.StockAdjustmentVouchers.Add(voucher);
                m.SaveChanges();

                foreach (StockAdjustmentVoucherDetail detail in detailList)
                {

                    detail.VoucherID = voucher.VoucherID;
                    m.StockAdjustmentVoucherDetails.Add(detail);
                    m.SaveChanges();
                }


            }
        }

        ////////UpdateDisbursement
        public static String UpdateDisbursement(List<DisbursementDetail> input)
        {
            using (Team10ADModel m = new Team10ADModel())
            {
                Disbursement disbursement = new Disbursement();
                //disbursement.DisbursementID = Convert.ToInt32(input[0].DisbursementID);
                int i = Convert.ToInt32(input[0].DisbursementID);
                disbursement = m.Disbursements.Where(x => x.DisbursementID == i).First();
                disbursement.Status = "Collected";
                m.SaveChanges();


                //disbursement.Status = "Collected";
                //m.Disbursements.Attach(disbursement);
                //m.Entry(disbursement).Property(x=>x.Status).IsModified = true;
                //m.SaveChanges();
                return i.ToString();

                //foreach (StockAdjustmentVoucherDetail detail in detailList)
                //{
                //    detail.VoucherID = voucher.VoucherID;
                //    m.StockAdjustmentVoucherDetails.Add(detail);
                //    m.SaveChanges();
                //}
            }
        }
        /////////////Catalogue
        public static List<Catalogue> ListCatalogues()
        {
            using (Team10ADModel m = new Team10ADModel())
            {
                return m.Catalogues.ToList<Catalogue>();
            }
        }

        public static Catalogue GetCatalogue(string itemCode)
        {
            using (Team10ADModel m = new Team10ADModel())
            {
                return m.Catalogues.Where
                        (p => p.ItemCode == itemCode).ToList<Catalogue>()[0];
            }
        }

        public static void InsertCustomer(Catalogue c)
        {
            using (Team10ADModel m = new Team10ADModel())
            {
                m.Catalogues.Add(c);
                m.SaveChanges();
            }
        }
        public static void UpdateCustomer(Catalogue c)
        {
            using (Team10ADModel m = new Team10ADModel())
            {
                m.Entry(c).State = System.Data.Entity.EntityState.Modified;
                m.SaveChanges();
            }
        }


        /////////////Retrieval & RetrievalDetail
        public static List<Retrieval> ListRetrievals()
        {
            using (Team10ADModel m = new Team10ADModel())
            {
                return m.Retrievals.ToList<Retrieval>();
            }
        }

        public static List<RetrievalDetail> ListRetrievalDetails(int retrievalID)
        {
            using (Team10ADModel m = new Team10ADModel())
            {
                return m.RetrievalDetails.Where(p => p.RetrievalID == retrievalID).ToList<RetrievalDetail>();
            }
        }


        public static List<Retrieval> ListUncollectedRetrievals()
        {
            using (Team10ADModel m = new Team10ADModel())
            {
                return m.Retrievals.Where(p => p.Status == "Unretrieved").ToList<Retrieval>();
            }
        }

        public static List<Retrieval> ListCollectedRetrievals()
        {
            using (Team10ADModel m = new Team10ADModel())
            {
                return m.Retrievals.Where(p => p.Status == "Retrieved").ToList<Retrieval>();
            }
        }
        public static string UpdateRetrievalDetails(List<RetrievalDetail> b)
        {
            using (Team10ADModel m = new Team10ADModel())
            {
                foreach (RetrievalDetail r in b)
                {
                    m.Entry(r).State = System.Data.Entity.EntityState.Modified;
                }
                m.SaveChanges();
            }

            return "xiiiii";
        }



        /////////////Disbursement & DisbursementDetail
        public static List<Disbursement> ListDisbursements(string status)
        {
            Team10ADModel m = new Team10ADModel();

            return m.Disbursements.Where(p => p.Status == status).ToList<Disbursement>();
        }

        public static List<DisbursementDetail> GetDisbursementDetails(int disbursementID)
        {
            Team10ADModel m = new Team10ADModel();

            return m.DisbursementDetails.Where(p => p.DisbursementID == disbursementID).ToList<DisbursementDetail>();
        }
        //////////Receive & ReceiveDetail
        public static List<PurchaseOrder> PendingReceive()
        {
            using (Team10ADModel m = new Team10ADModel())
            {
                return m.PurchaseOrders.ToList<PurchaseOrder>();
            }
        }
        public static List<PurchaseOrderDetail> PendingReceiveDetail(int poid)
        {
            using (Team10ADModel m = new Team10ADModel())
            {
                //return m.PurchaseOrderDetails.Where(p => p.POID == poid).ToList<PurchaseOrderDetail>();
                var po = (from s in m.PurchaseOrders where s.POID == poid select s).ToList();
                var poDetail = (from t in m.PurchaseOrderDetails where t.POID == poid select t).ToList();
                var supplier = (from o in m.Suppliers select o).ToList();
                var catalogue = (from o in m.Catalogues select o).ToList();
                var supplierName = (from s in po join k in supplier on s.SupplierCode equals k.SupplierCode select s).ToList();
                var item = (from s in poDetail join k in catalogue on s.ItemCode equals k.ItemCode select s).ToList();
                var result = (from s in supplierName join k in item on s.POID equals k.POID select k).ToList();
                return result;
            }
        }

        public static List<GoodsReceivedRecord> ReceivedList()
        {
            using (Team10ADModel m = new Team10ADModel())
            {
                return m.GoodsReceivedRecords.ToList<GoodsReceivedRecord>();
            }
        }

        public static List<GoodsReceivedRecordDetail> ReceivedDetailList(int receivedID)
        {
            using (Team10ADModel m = new Team10ADModel())
            {
                return m.GoodsReceivedRecordDetails.Where(p => p.GoodReceiveID == receivedID).ToList<GoodsReceivedRecordDetail>();
            }
        }

        ////////////Requisition & RequisitionDetail
        public static List<Requisition> RequisitionList()
        {
            using (Team10ADModel m = new Team10ADModel())
            {
                return m.Requisitions.ToList<Requisition>();
            }
        }
        public static List<Requisition> PendingRequisitionList()
        {
            Team10ADModel m = new Team10ADModel();
            return m.Requisitions.Where(p => p.Status == "Pending").ToList<Requisition>();

        }

        public static List<Requisition> PendingRequisitionListByEmp(int id)
        {
            Team10ADModel context = new Team10ADModel();
            return context.Requisitions.Where(p => p.Status == "Pending" && p.RequestorID == id).ToList<Requisition>();

        }

        public static List<Requisition> PartialRequisitionList()
        {
            using (Team10ADModel m = new Team10ADModel())
            {
                return m.Requisitions.Where(p => p.Status == "Partial").ToList<Requisition>();
            }
        }

        public static List<Requisition> ProcessedRequisitionList()
        {
            using (Team10ADModel m = new Team10ADModel())
            {
                return m.Requisitions.Where(p => p.Status == "Approved" || p.Status == "Rejected" || p.Status == "Ready To Collect").ToList<Requisition>();
            }
        }

        public static List<RequisitionDetail> GetRequisitionDetail(int requisitionID)
        {
            using (Team10ADModel m = new Team10ADModel())
            {
                return m.RequisitionDetails.Where(p => p.RequisitionID == requisitionID).ToList<RequisitionDetail>();
            }
        }

        public static List<Requisition> PersonalPendingRequisition(int requestorID)
        {
            using (Team10ADModel m = new Team10ADModel())
            {
                return m.Requisitions.Where
                        (p => p.RequestorID == requestorID && p.Status == "Pending").ToList<Requisition>();
            }
        }

        public static Requisition GetRequisitionById(int reqId)
        {
            using (Team10ADModel context = new Team10ADModel())
            {
                return context.Requisitions.Where(r => r.RequisitionID == reqId).First();
            }
        }

        public static List<RequisitionDetail> GetRequisitionDetailsById(int reqId)
        {
            Team10ADModel context = new Team10ADModel();

            return context.RequisitionDetails.Where(r => r.RequisitionID == reqId).ToList();
        }

        ////////////Delegate
        public static List<Employee> A_EmployeeList(string departmentCode)
        {
            using (Team10ADModel m = new Team10ADModel())
            {
                return m.Employees.Where(p => p.DepartmentCode == departmentCode && p.EmployeeID != p.Department.HODID).ToList<Employee>();
            }
        }
        public static void UpdateApprover(Employee r)
        {
            using (Team10ADModel m = new Team10ADModel())
            {
                var query = (from s in m.Departments where s.ApproverID == r.EmployeeID select s).ToList()[0];
                m.Entry(query).State = System.Data.Entity.EntityState.Modified;
                m.SaveChanges();
            }
        }

        public static Employee GetApprover(string departmentCode)
        {
            using (Team10ADModel m = new Team10ADModel())
            {
                var firstQuery = (from s in m.Departments where s.DepartmentCode == departmentCode select s).ToList();
                var secondQuery = (from t in m.Employees select t).ToList();
                var result = (from s in firstQuery join k in secondQuery on s.ApproverID equals k.EmployeeID select k).ToList()[0];
                return result;
            }
        }


        public static List<Requisition> checkRequisition(int employeeID)
        {
            using (Team10ADModel m = new Team10ADModel())
            {
                return m.Requisitions.Where(p => p.RequestorID == employeeID && p.Status == "Pending").ToList<Requisition>();
            }
        }


        ////////////Representative
        public static List<Employee> R_EmployeeList(string departmentCode)
        {
            using (Team10ADModel m = new Team10ADModel())
            {
                return m.Employees.Where(p => p.DepartmentCode == departmentCode && p.EmployeeID != p.Department.HODID && p.EmployeeID != p.Department.ApproverID).ToList<Employee>();
            }
        }

        public static void UpdateRep(Employee r)
        {
            using (Team10ADModel m = new Team10ADModel())
            {
                var query = (from s in m.Departments where s.RepresentativeID == r.EmployeeID select s).ToList()[0];
                m.Entry(query).State = System.Data.Entity.EntityState.Modified;
                m.SaveChanges();
            }
        }




        public static void UpdateCatalogues(List<Catalogue> clist)
        {
            using (Team10ADModel m = new Team10ADModel())
            {
                foreach (Catalogue c in clist)
                {
                    m.Entry(c).State = System.Data.Entity.EntityState.Modified;
                }
                m.SaveChanges();
            }
        }

        public static List<Employee> EmployeeLogIn()
        {
            using (Team10ADModel m = new Team10ADModel())
            {
                var firstQuery = (from s in m.Departments select s).ToList();
                var secondQuery = (from t in m.Employees select t).ToList();
                var result = (from s in firstQuery join k in secondQuery on s.HODID equals k.EmployeeID select k).ToList();
                return result;
            }
        }

        public static List<StoreStaff> ClerkLogIn()
        {
            using (Team10ADModel m = new Team10ADModel())
            {
                return m.StoreStaffs.Where(p => p.Title == "Clerk").ToList();
            }
        }

        //////////////////////////////GoodsReceiving
        public static Dictionary<PurchaseOrderDetail, PurchaseOrder> RecievingGoodsList(string poid)
        {
            Team10ADModel context = new Team10ADModel();

            Dictionary<PurchaseOrderDetail, PurchaseOrder> dictionary = new Dictionary<PurchaseOrderDetail, PurchaseOrder>();
            int id = Convert.ToInt32(poid);
            PurchaseOrder po = context.PurchaseOrders.Where(p => p.POID == id).First();
            List<PurchaseOrderDetail> poDetailList = context.PurchaseOrderDetails.Where(p => p.POID == id && p.Status != "Received").ToList();
            foreach (PurchaseOrderDetail d in poDetailList)
            {
                dictionary.Add(d, po);
            }
            return dictionary;

        }

        //Calculation to get total goods received so far for the PO
        public static int GetTotalGoodsReceived(int poid, string itemcode)
        {
            Team10ADModel context = new Team10ADModel();
            List<GoodsReceivedRecord> goodsrecordlist = context.GoodsReceivedRecords.Where(x => x.POID == poid).ToList();

            int totalqty = 0;

            if(goodsrecordlist != null)
            {
                foreach (GoodsReceivedRecord good in goodsrecordlist)
                {
                    GoodsReceivedRecordDetail item = context.GoodsReceivedRecordDetails.Where(x => x.ItemCode == itemcode && x.GoodReceiveID == good.GoodReceiveID).First();
                    if (item.ReceivedQuantity != null)
                    {
                        totalqty += (int)item.ReceivedQuantity;
                    }
                }
            }
            
            return totalqty;
        }

        //Saving goods received data into 5 tables
        public static void SavingGoodsReceived(int poid, GoodsReceivedRecord grr, List<GoodsReceivedRecordDetail> grrdlist)
        {
            Team10ADModel context = new Team10ADModel();
            context.GoodsReceivedRecords.Add(grr);
            context.SaveChanges();

            foreach (GoodsReceivedRecordDetail detail in grrdlist)
            {
                Catalogue item = context.Catalogues.Where(i => i.ItemCode == detail.ItemCode).First();
                item.BalanceQuantity += detail.ReceivedQuantity;
                item.PendingDeliveryQuantity -= detail.ReceivedQuantity;

                context.SaveChanges();

                detail.GoodReceiveID = grr.GoodReceiveID;
                detail.QuantityAfter = item.BalanceQuantity;
                context.GoodsReceivedRecordDetails.Add(detail);

                context.SaveChanges();
            }

            List<PurchaseOrderDetail> podetaillist = context.PurchaseOrderDetails.Where(x => x.POID == poid).ToList();
            foreach (PurchaseOrderDetail detail in podetaillist)
            {
                if (GetTotalGoodsReceived(poid, detail.ItemCode) >= detail.Quantity)
                {
                    detail.Status = "Received";
                }
                else if (GetTotalGoodsReceived(poid, detail.ItemCode) == 0)
                {
                    detail.Status = "Unreceived";
                }
                else
                {
                    detail.Status = "Partial";
                }
                context.SaveChanges();
            }

            PurchaseOrder po = context.PurchaseOrders.Where(x => x.POID == poid).First();
            int counter = 0;
            int partial = 0;
            foreach (PurchaseOrderDetail detail in podetaillist)
            {
                if (detail.Status == "Partial")
                {
                    counter++;
                    partial++;
                }
                else if (detail.Status == "Unreceived")
                {
                    counter++;
                }
            }
            if (counter == 0)
            {
                po.Status = "Received";
            }
            if (partial > 0)
            {
                po.Status = "Received";
            }
            context.SaveChanges();
        }

        public static List<PurchaseOrder> CompletedPurchaseOrderList()
        {
            Team10ADModel context = new Team10ADModel();
            List<PurchaseOrder> polist = context.PurchaseOrders.Where(x => x.Status == "Received").ToList();

            return polist;
        }

        public static List<PurchaseOrder> PendingPurchaseOrderList()
        {
            Team10ADModel context = new Team10ADModel();
            List<PurchaseOrder> polist = context.PurchaseOrders.Where(x => x.Status == "Unreceived" || x.Status == "Partial").ToList();

            return polist;
        }

        /////////////////////////////////Requisition

        public static void UpdateReqStatus(Requisition req)
        {
            using (Team10ADModel context = new Team10ADModel())
            {
                Requisition updateReq = context.Requisitions.Where(x => x.RequisitionID == req.RequisitionID).First();
                updateReq.RequestorID = req.RequestorID;
                updateReq.ApprovalDate = DateTime.Now;
                updateReq.Status = req.Status;
                updateReq.Remarks = req.Remarks;

                context.SaveChanges();
            }
        }
    }
}