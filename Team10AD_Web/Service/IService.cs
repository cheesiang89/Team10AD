using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using Team10AD_Web.App_Code.Model;
using System.Text;

namespace Team10AD_Web.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
    [ServiceContract]
    public interface IService
    {

            /////////////Voucher
    [OperationContract]
    [WebInvoke(UriTemplate = "/CreateVoucher", Method = "POST",
    RequestFormat = WebMessageFormat.Json,
    ResponseFormat = WebMessageFormat.Json)]
    string CreateVoucher(WCFVoucherDetail[] input);


    ////////////Voucher & UpdateDisbursement
    [OperationContract]
    [WebInvoke(UriTemplate = "/UpdateDisbursement", Method = "POST",
    RequestFormat = WebMessageFormat.Json,
    ResponseFormat = WebMessageFormat.Json)]
    string UpdateDisbursement(WCFDisbursementDetail[] input);

        /////////////Catalogue
        [OperationContract]
        [WebGet(UriTemplate = "/Catalogue/{itemCode}", ResponseFormat = WebMessageFormat.Json)]
        WCFCatalogue GetCatalogue(string itemCode);

        [OperationContract]
        [WebGet(UriTemplate = "/Catalogues", ResponseFormat = WebMessageFormat.Json)]
        WCFCatalogue[] ListCatalogues();

        ///////////Disbursement & DisbursementDetail
        [OperationContract]
        [WebGet(UriTemplate = "/Disbursement/{disbursementID}", ResponseFormat = WebMessageFormat.Json)]
        WCFDisbursementDetail[] ListDisbursementDetail(string disbursementID);

        [OperationContract]
        [WebGet(UriTemplate = "/Disbursements/{status}", ResponseFormat = WebMessageFormat.Json)]
        WCFDisbursement[] ListDisbursements(string status);

        /////////////Retrieval & RetrievalDetail
        [OperationContract]
        [WebGet(UriTemplate = "/Retrieval/{retrievalID}", ResponseFormat = WebMessageFormat.Json)]
        WCFRetrievalDetail[] ListRetrievalDetails(string retrievalID);

        [OperationContract]
        [WebGet(UriTemplate = "/UncollectedRetrievals", ResponseFormat = WebMessageFormat.Json)]
        WCFRetrieval[] ListUncollectedRetrievals();

        [OperationContract]
        [WebGet(UriTemplate = "/CollectedRetrievals", ResponseFormat = WebMessageFormat.Json)]
        WCFRetrieval[] ListCollectedRetrievals();

        [OperationContract]
        [WebInvoke(UriTemplate = "/UpdateRetrievalDetails", Method = "POST",
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json)]
        string UpdateRetrievalDetails(WCFRetrievalDetail[] b);

        ///////////////Receive & ReceiveDetail 
        [OperationContract]
        [WebGet(UriTemplate = "/Received", ResponseFormat = WebMessageFormat.Json)]
        WCFReceived[] ReceivedList();

        [OperationContract]
        [WebGet(UriTemplate = "/Received/{receiveID}", ResponseFormat = WebMessageFormat.Json)]
        WCFReceivedDetail[] ListReceivedDetail(string receiveID);

        //////////////Purchase
        [OperationContract]
        [WebGet(UriTemplate = "/PendingReceive", ResponseFormat = WebMessageFormat.Json)]
        WCFPendingReceive[] PendingReceiveList();

        [OperationContract]
        [WebGet(UriTemplate = "/PendingReceive/{poID}", ResponseFormat = WebMessageFormat.Json)]
        WCFPendingReceiveDetail[] PendingReceiveDetailList(string poID);

        //////////////Employee
        [OperationContract]
        [WebGet(UriTemplate = "/ApproverList/{depCode}", ResponseFormat = WebMessageFormat.Json)]
        WCFApprover[] ListApprover(string depCode);

        [OperationContract]
        [WebGet(UriTemplate = "/Approver/{depCode}", ResponseFormat = WebMessageFormat.Json)]
        WCFApprover GetApprover(string depCode);

        [OperationContract]
        [WebInvoke(UriTemplate = "/UpdateApprover", Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        void UpdateApprover(WCFApprover a);

        [OperationContract]
        [WebGet(UriTemplate = "/Representative/{depCode}", ResponseFormat = WebMessageFormat.Json)]
        WCFRep[] ListRep(string depCode);


        [OperationContract]
        [WebInvoke(UriTemplate = "/UpdateRep", Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        void UpdateRep(WCFRep r);

        /////////////Department
        [OperationContract]
        [WebGet(UriTemplate = "/Department", ResponseFormat = WebMessageFormat.Json)]
        WCFDepartment[] ListDepartment();


        /////////////LogIn
        [OperationContract]
        [WebGet(UriTemplate = "/EmployeeLogIn", ResponseFormat = WebMessageFormat.Json)]
        WCFEmployeeLogIn[] ListEmployeeLogIn();

        [OperationContract]
        [WebGet(UriTemplate = "/ClerkLogIn", ResponseFormat = WebMessageFormat.Json)]
        WCFClerkLogIn[] ListClerkLogIn();

        /////////////////Receving Goods
        [OperationContract]
        [WebGet(UriTemplate = "/ReceivingGoods/{poid}", ResponseFormat = WebMessageFormat.Json)]
        WCFReceivingGoodData[] ReceivingGoods(string poid);

        [OperationContract]
        [WebGet(UriTemplate = "/PendingPurchaseOrderList", ResponseFormat = WebMessageFormat.Json)]
        WCFPurchaseOrderList[] PendingPurchaseOrderList();

        [OperationContract]
        [WebGet(UriTemplate = "/CompletedPurchaseOrderList", ResponseFormat = WebMessageFormat.Json)]
        WCFPurchaseOrderList[] CompletedPurchaseOrderList();

        [OperationContract]
        [WebInvoke(UriTemplate = "/WCFReceivingGoods", Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        void SavingGoodsReceivedWCF(PostWCFReceivingGoodData[] goodwcflist);


        ///////////////////////Requisition
        [OperationContract]
        [WebGet(UriTemplate = "/PendingRequisitionList", ResponseFormat = WebMessageFormat.Json)]
        WCFRequisition[] PendingRequisitionList();

        [OperationContract]
        [WebGet(UriTemplate = "/PendingRequisitionListByEmp/{empid}", ResponseFormat = WebMessageFormat.Json)]
        WCFRequisition[] PendingRequisitionListByEmp(string empid);

        [OperationContract]
        [WebGet(UriTemplate = "/WCFRequisitionDetail/{reqid}", ResponseFormat = WebMessageFormat.Json)]
        WCFRequisitionDetail[] RequisitionDetailList(string reqid);

        [OperationContract]
        [WebInvoke(UriTemplate = "/WCFRequisitionApproval", Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        void RequisitionApproval(WCFRequisitionApproval wcfReq);

        //[OperationContract]
        //[WebGet(UriTemplate = "/ListDisbursementDetail/{disbursementID}", ResponseFormat = WebMessageFormat.Json)]
        //WCFDisbursementDetail[] ListDisbursementDetail(string disbursementID);

        //[OperationContract]
        //[WebGet(UriTemplate = "/ListDisbursementDetail/{disbursementID}", ResponseFormat = WebMessageFormat.Json)]
        //WCFDisbursementDetail[] ListDisbursementDetail(string disbursementID);


        //[OperationContract]
        //[WebGet(UriTemplate = "/ListDisbursement", ResponseFormat = WebMessageFormat.Json)]
        //WCFDisbursement[] ListDisbursements();

        /////////////Test
        [OperationContract]
        [WebGet(UriTemplate = "/Test", ResponseFormat = WebMessageFormat.Json)]
        Test TestM();
    }
    [DataContract]
    public class WCFVoucherDetail
    {
        string itemCode;
        string quantityAdjusted;
        string reason;
        int storeStaffID;

        public static WCFVoucherDetail Make(string itemCode, string quantityAdjusted, string reason, int storeStaffID)
        {
            WCFVoucherDetail t = new WCFVoucherDetail();
            t.itemCode = itemCode;
            t.quantityAdjusted = quantityAdjusted;
            t.reason = reason;
            t.storeStaffID = storeStaffID;
            return t;
        }

        [DataMember]
        public string ItemCode
        {
            get { return itemCode; }
            set { itemCode = value; }
        }
        [DataMember]
        public string QuantityAdjusted
        {
            get
            {
                return quantityAdjusted;
            }

            set
            {
                quantityAdjusted = value;
            }
        }
        [DataMember]
        public string Reason
        {
            get
            {
                return reason;
            }

            set
            {
                reason = value;
            }
        }
        [DataMember]
        public int StoreStaffID
        {
            get
            {
                return storeStaffID;
            }

            set
            {
                storeStaffID = value;
            }
        }
    }

    [DataContract]
    public class Test
    {
        string itemCode;
        WCFCatalogue[] catalogues;

        public static Test Make(string itemCode, WCFCatalogue[] catalogues)
        {
            Test t = new Test();
            t.itemCode = itemCode;
            t.catalogues = catalogues;
            return t;
        }

        [DataMember]
        public string ItemCode
        {
            get { return itemCode; }
            set { itemCode = value; }
        }

        [DataMember]
        public WCFCatalogue[] Catalogues
        {
            get { return catalogues; }
            set { catalogues = value; }
        }
    }

    [DataContract]
    public class WCFDisbursement
    {
        string disbursementID;
        string collectionDate;
        string pointName;
        string departmentName;
        string status;
        string storeStaffID;


        public static WCFDisbursement Make(string disbursementID, string collectionDate, string pointName, string departmentName, string status, string storeStaffID)
        {
            WCFDisbursement c = new WCFDisbursement();
            c.DisbursementID = disbursementID;
            c.CollectionDate = collectionDate;
            c.PointName = pointName;
            c.DepartmentName = departmentName;
            c.Status = status;
            c.StoreStaffID = storeStaffID;
            return c;
        }

        [DataMember]
        public string DisbursementID
        {
            get { return disbursementID; }

            set { disbursementID = value; }
        }

        [DataMember]
        public string CollectionDate
        {
            get { return collectionDate; }

            set { collectionDate = value; }
        }

        [DataMember]
        public string PointName
        {
            get { return pointName; }

            set { pointName = value; }
        }

        [DataMember]
        public string DepartmentName
        {
            get { return departmentName; }

            set { departmentName = value; }
        }
        [DataMember]
        public string Status
        {
            get { return status; }

            set { status = value; }
        }
        [DataMember]
        public string StoreStaffID
        {
            get { return storeStaffID; }

            set { storeStaffID = value; }
        }
    }


    [DataContract]
    public class WCFDisbursementDetail
    {
        string disbursementID;
        string remarks;
        string itemCode;
        string quantityRequested;
        string quantityCollected;
        string description;//catalogue
        string unitOfMeature;
        string storeStaffID;

        public static WCFDisbursementDetail Make(string disbursementID, string remarks, string itemCode, string quantityRequested, string quantityCollected, string description, string unitOfMeature)
        {
            WCFDisbursementDetail c = new WCFDisbursementDetail();
            c.DisbursementID = disbursementID;
            c.Remarks = remarks;
            c.ItemCode = itemCode;
            c.QuantityRequested = quantityRequested;
            c.QuantityCollected = quantityCollected;
            c.Description = description;
            c.unitOfMeature = unitOfMeature;
            return c;
        }


        [DataMember]
        public string DisbursementID
        {
            get { return disbursementID; }

            set { disbursementID = value; }
        }

        [DataMember]
        public string Remarks
        {
            get { return remarks; }

            set { remarks = value; }
        }

        [DataMember]
        public string ItemCode
        {
            get { return itemCode; }

            set { itemCode = value; }
        }

        [DataMember]
        public string QuantityRequested
        {
            get { return quantityRequested; }

            set { quantityRequested = value; }
        }

        [DataMember]
        public string QuantityCollected
        {
            get { return quantityCollected; }

            set { quantityCollected = value; }
        }

        [DataMember]
        public string Description
        {
            get { return description; }

            set { description = value; }
        }

        [DataMember]
        public string UnitOfMeature
        {
            get
            {
                return unitOfMeature;
            }

            set
            {
                unitOfMeature = value;
            }
        }
        [DataMember]
        public string StoreStaffID
        {
            get
            {
                return storeStaffID;
            }

            set
            {
                storeStaffID = value;
            }
        }
    }



    [DataContract]
    public class WCFCatalogue
    {
        string itemCode;
        string description;
        string location;
        int? balanceQuantity;
        string unitOfMeature;

        public static WCFCatalogue Make(string itemCode, string description, string location, int? balanceQuantity, string unitOfMeature)
        {
            WCFCatalogue c = new WCFCatalogue();
            c.itemCode = itemCode;
            c.description = description;
            c.location = location;
            c.balanceQuantity = balanceQuantity;
            c.UnitOfMeature = unitOfMeature;
            return c;
        }

        [DataMember]
        public string ItemCode
        {
            get { return itemCode; }
            set { itemCode = value; }
        }

        [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        [DataMember]
        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        [DataMember]
        public int? BalanceQuantity
        {
            get { return balanceQuantity; }
            set { balanceQuantity = value; }
        }

        public string UnitOfMeature
        {
            get
            {
                return unitOfMeature;
            }

            set
            {
                unitOfMeature = value;
            }
        }
    }



    [DataContract]
    public class WCFRetrieval
    {
        int retrievalID;
        string retrievalDate;
        //WCFRetrievalDetail[] retrievalDetails;

        public static WCFRetrieval Make(int retrievalID, string retrievalDate/*, WCFRetrievalDetail[] retrievalDetails*/)
        {
            WCFRetrieval c = new WCFRetrieval();
            c.retrievalID = retrievalID;
            c.retrievalDate = retrievalDate;
            //c.retrievalDetails = retrievalDetails;
            return c;
        }

        [DataMember]
        public int RetrievalID
        {
            get { return retrievalID; }
            set { retrievalID = value; }
        }

        [DataMember]
        public String RetrievalDate
        {
            get { return retrievalDate; }
            set { retrievalDate = value; }
        }

        //[DataMember]
        //public WCFRetrievalDetail[] RetrievalDetails
        //{
        //    get { return retrievalDetails; }
        //    set { retrievalDetails = value; }
        //}

    }

    [DataContract]
    public class WCFRetrievalDetail
    {
        int retrievalID;
        string itemCode;
        int? requestedQuantity;
        int? retrievedQuantity;
        //int? quantityAfter;

        public static WCFRetrievalDetail Make(int retrievalID, string itemCode, int? requestedQuantity, int? retrievedQuantity/*, int? quantityAfter*/)
        {
            WCFRetrievalDetail c = new WCFRetrievalDetail();
            c.retrievalID = retrievalID;
            c.itemCode = itemCode;
            c.requestedQuantity = requestedQuantity;
            c.retrievedQuantity = retrievedQuantity;
            return c;
        }

        [DataMember]
        public int RetrievalID
        {
            get { return retrievalID; }
            set { retrievalID = value; }
        }

        [DataMember]
        public string ItemCode
        {
            get { return itemCode; }
            set { itemCode = value; }
        }

        [DataMember]
        public int? RequestedQuantity
        {
            get { return requestedQuantity; }
            set { requestedQuantity = value; }
        }

        [DataMember]
        public int? RetrievedQuantity
        {
            get { return retrievedQuantity; }
            set { retrievedQuantity = value; }
        }

        //[DataMember]
        //public int? QuantityAfter
        //{
        //    get { return quantityAfter; }
        //    set { quantityAfter = value; }
        //}
    }

    [DataContract]
    public class WCFReceived
    {
        int receiveID;
        DateTime? receivedDate;
        int? poId;
        int? storeStaffId;

        public static WCFReceived Make(int receiveID, DateTime? receivedDate, int? poId, int? storeStaffId)
        {
            WCFReceived c = new WCFReceived();
            c.receiveID = receiveID;
            c.receivedDate = receivedDate;
            c.poId = poId;
            c.storeStaffId = storeStaffId;
            return c;
        }

        [DataMember]
        public int ReceiveId
        {
            get { return receiveID; }
            set { receiveID = value; }
        }

        [DataMember]
        public DateTime? ReceivedDate
        {
            get { return receivedDate; }
            set { receivedDate = value; }
        }

        [DataMember]
        public int? POID
        {
            get { return poId; }
            set { poId = value; }
        }

        [DataMember]
        public int? StoreStaffId
        {
            get { return storeStaffId; }
            set { storeStaffId = value; }
        }
    }

    [DataContract]
    public class WCFReceivedDetail
    {
        string itemCode;
        int? receivedQty;
        string description;
        string supplierName;
        public static WCFReceivedDetail Make(string itemCode, string description, int? receivedQty, string supplierName)
        {
            WCFReceivedDetail c = new WCFReceivedDetail();

            c.itemCode = itemCode;
            c.receivedQty = receivedQty;
            c.description = description;
            c.supplierName = supplierName;
            return c;
        }

        [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        [DataMember]
        public string ItemCode
        {
            get { return itemCode; }
            set { itemCode = value; }
        }

        [DataMember]
        public int? ReceivedQty
        {
            get { return receivedQty; }
            set { receivedQty = value; }
        }

        [DataMember]
        public string SupplierName
        {
            get { return supplierName; }
            set { supplierName = value; }
        }

    }

    [DataContract]
    public class WCFPendingReceive
    {
        int poID;
        DateTime? creationDate;
        string supplierCode;
        int? storeStaffId;

        public static WCFPendingReceive Make(int poID, DateTime? creationDate, string supplierCode, int? storeStaffId)
        {
            WCFPendingReceive c = new WCFPendingReceive();
            c.poID = poID;
            c.creationDate = creationDate;
            c.supplierCode = supplierCode;
            c.storeStaffId = storeStaffId;
            return c;
        }

        [DataMember]
        public int PoID
        {
            get { return poID; }
            set { poID = value; }
        }

        [DataMember]
        public DateTime? CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }

        [DataMember]
        public string SupplierCode
        {
            get { return supplierCode; }
            set { supplierCode = value; }
        }

        [DataMember]
        public int? StoreStaffId
        {
            get { return storeStaffId; }
            set { storeStaffId = value; }
        }
    }

    [DataContract]
    public class WCFPendingReceiveDetail
    {
        string itemCode;
        int poID;
        int? quantity;
        double? unitPrice;

        public static WCFPendingReceiveDetail Make(string itemCode, int poID, int? quantity, double? unitPrice)
        {
            WCFPendingReceiveDetail c = new WCFPendingReceiveDetail();
            c.itemCode = itemCode;
            c.poID = poID;
            c.quantity = quantity;
            c.unitPrice = unitPrice;
            return c;
        }

        [DataMember]
        public int PoID
        {
            get { return poID; }
            set { poID = value; }
        }

        [DataMember]
        public string ItemCode
        {
            get { return itemCode; }
            set { itemCode = value; }
        }

        [DataMember]
        public int? Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        [DataMember]
        public double? UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }
    }

    [DataContract]
    public class WCFApprover
    {
        int employeeID;
        string name;
        string departmentCode;

        public static WCFApprover Make(int employeeID, string name, string departmentCode)
        {
            WCFApprover c = new WCFApprover();
            c.employeeID = employeeID;
            c.name = name;
            c.departmentCode = departmentCode;
            return c;
        }

        [DataMember]
        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string DepartmentCode
        {
            get { return departmentCode; }
            set { departmentCode = value; }
        }
    }


    [DataContract]
    public class WCFRep
    {
        int employeeID;
        string name;
        string departmentCode;

        public static WCFRep Make(int employeeID, string name, string departmentCode)
        {
            WCFRep c = new WCFRep();
            c.employeeID = employeeID;
            c.name = name;
            c.departmentCode = departmentCode;
            return c;
        }

        [DataMember]
        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string DepartmentCode
        {
            get { return departmentCode; }
            set { departmentCode = value; }
        }
    }



    [DataContract]
    public class WCFDepartment
    {
        string departmentCode;
        string departmentName;
        int contactPersonID;
        int pointID;
        int repID;
        int approverID;
        DateTime approvingStart;
        DateTime approvingEnd;
        int hodID;

        public static WCFDepartment Make(string departmentCode, string departmentName, int contactPersonID, int pointID, int repID, int approverID, DateTime approvingStart, DateTime approvingEnd, int hodID)
        {
            WCFDepartment c = new WCFDepartment();
            c.departmentCode = departmentCode;
            c.departmentName = departmentName;
            c.contactPersonID = contactPersonID;
            c.pointID = pointID;
            c.repID = repID;
            c.approverID = approverID;
            c.approvingStart = approvingStart;
            c.approvingEnd = approvingEnd;
            c.hodID = hodID;
            return c;
        }

        [DataMember]
        public string DepartmentCode
        {
            get { return departmentCode; }
            set { departmentCode = value; }
        }

        [DataMember]
        public string DepartmentName
        {
            get { return departmentName; }
            set { departmentName = value; }
        }

        [DataMember]
        public int ContactPersonID
        {
            get { return contactPersonID; }
            set { contactPersonID = value; }
        }

        [DataMember]
        public int PointID
        {
            get { return pointID; }
            set { pointID = value; }
        }

        [DataMember]
        public int RepID
        {
            get { return repID; }
            set { repID = value; }
        }

        [DataMember]
        public int ApproverID
        {
            get { return approverID; }
            set { approverID = value; }
        }

        [DataMember]
        public DateTime ApprovingStart
        {
            get { return approvingStart; }
            set { approvingStart = value; }
        }

        [DataMember]
        public DateTime ApprovingEnd
        {
            get { return approvingEnd; }
            set { approvingEnd = value; }
        }

        [DataMember]
        public int HOID
        {
            get { return hodID; }
            set { hodID = value; }
        }
    }

    [DataContract]
    public class WCFEmployeeLogIn
    {
        int employeeID;
        string name;
        int? phone;

        public static WCFEmployeeLogIn Make(int employeeID, string name, int? phone)
        {
            WCFEmployeeLogIn c = new WCFEmployeeLogIn();
            c.employeeID = employeeID;
            c.name = name;
            c.phone = phone;
            return c;
        }

        [DataMember]
        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public int? Phone
        {
            get { return phone; }
            set { phone = value; }
        }
    }

    [DataContract]
    public class WCFClerkLogIn
    {
        int storeStaffID;
        string name;
        int? phone;

        public static WCFClerkLogIn Make(int storeStaffID, string name, int? phone)
        {
            WCFClerkLogIn c = new WCFClerkLogIn();
            c.storeStaffID = storeStaffID;
            c.name = name;
            c.phone = phone;
            return c;
        }

        [DataMember]
        public int StoreStaffID
        {
            get { return storeStaffID; }
            set { storeStaffID = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public int? Phone
        {
            get { return phone; }
            set { phone = value; }
        }
    }

    [DataContract]
    public class WCFReceivingGoodData
    {
        string creationDate;
        string poId;
        string itemCode;
        string quantity;
        string description;
        string supplierName;

        public static WCFReceivingGoodData Make(string creationDate, string poId, string itemCode, string quantity, string description, string supplierName)
        {
            WCFReceivingGoodData goods = new WCFReceivingGoodData();
            goods.creationDate = creationDate;
            goods.poId = poId;
            goods.itemCode = itemCode;
            goods.quantity = quantity;
            goods.description = description;
            goods.supplierName = supplierName;

            return goods;
        }

        [DataMember]
        public string CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }

        [DataMember]
        public string PoId
        {
            get { return poId; }
            set { poId = value; }
        }

        [DataMember]
        public string ItemCode
        {
            get { return itemCode; }
            set { itemCode = value; }
        }

        [DataMember]
        public string Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        [DataMember]
        public string SupplierName
        {
            get { return supplierName; }
            set { supplierName = value; }
        }
    }


    [DataContract]
    public class PostWCFReceivingGoodData
    {
        string poId;
        string itemCode;
        string quantity;
        string supplierName;
        string remark;
        string storeStaffID;

        public static PostWCFReceivingGoodData Make(string poId, string itemCode, string quantity, string supplierName, string remark, string storeStaffID)
        {
            PostWCFReceivingGoodData goods = new PostWCFReceivingGoodData();
            goods.poId = poId;
            goods.itemCode = itemCode;
            goods.quantity = quantity;
            goods.supplierName = supplierName;
            goods.remark = remark;
            goods.storeStaffID = storeStaffID;

            return goods;
        }

        [DataMember]
        public string PoId
        {
            get { return poId; }
            set { poId = value; }
        }

        [DataMember]
        public string ItemCode
        {
            get { return itemCode; }
            set { itemCode = value; }
        }

        [DataMember]
        public string Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        [DataMember]
        public string SupplierName
        {
            get { return supplierName; }
            set { supplierName = value; }
        }

        [DataMember]
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        [DataMember]
        public string StoreStaffID
        {
            get { return storeStaffID; }
            set { storeStaffID = value; }
        }
    }

    [DataContract]
    public class WCFPurchaseOrderList
    {
        string creationDate;
        string poId;
        string supplierName;

        public static WCFPurchaseOrderList Make(string creationDate, string poId, string supplierName)
        {
            WCFPurchaseOrderList poList = new WCFPurchaseOrderList();
            poList.creationDate = creationDate;
            poList.poId = poId;
            poList.supplierName = supplierName;

            return poList;
        }

        [DataMember]
        public string CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }

        [DataMember]
        public string PoId
        {
            get { return poId; }
            set { poId = value; }
        }

        [DataMember]
        public string SupplierName
        {
            get { return supplierName; }
            set { supplierName = value; }
        }
    }

    [DataContract]
    public class WCFRequisition
    {
        string reqId;
        string reqDate;
        string name;
        string empId;

        public static WCFRequisition Make(string reqId, string reqDate, string name, string empId)
        {
            WCFRequisition wcfreq = new WCFRequisition();
            wcfreq.reqId = reqId;
            wcfreq.reqDate = reqDate;
            wcfreq.name = name;
            wcfreq.empId = empId;

            return wcfreq;
        }

        [DataMember]
        public string ReqId
        {
            get { return reqId; }
            set { reqId = value; }
        }

        [DataMember]
        public string ReqDate
        {
            get { return reqDate; }
            set { reqDate = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string EmpId
        {
            get { return empId; }
            set { empId = value; }
        }
    }

    [DataContract]
    public class WCFRequisitionDetail
    {
        string reqId;
        string itemCode;
        string quantityRequested;
        string description;

        public static WCFRequisitionDetail Make(string reqId, string itemCode, string quantityRequested, string description)
        {
            WCFRequisitionDetail wcfreqdetail = new WCFRequisitionDetail();
            wcfreqdetail.reqId = reqId;
            wcfreqdetail.itemCode = itemCode;
            wcfreqdetail.quantityRequested = quantityRequested;
            wcfreqdetail.description = description;

            return wcfreqdetail;
        }

        [DataMember]
        public string ReqId
        {
            get { return reqId; }
            set { reqId = value; }
        }

        [DataMember]
        public string ItemCode
        {
            get { return itemCode; }
            set { itemCode = value; }
        }

        [DataMember]
        public string QuantityRequested
        {
            get { return quantityRequested; }
            set { quantityRequested = value; }
        }

        [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }

    [DataContract]
    public class WCFRequisitionApproval
    {
        string reqId;
        string status;
        string approverId;
        string remark;

        public static WCFRequisitionApproval Make(string reqId, string status, string approverId, string remark)
        {
            WCFRequisitionApproval req = new WCFRequisitionApproval();
            req.reqId = reqId;
            req.status = status;
            req.approverId = approverId;
            req.remark = remark;

            return req;
        }

        [DataMember]
        public string ReqId
        {
            get { return reqId; }
            set { reqId = value; }
        }

        [DataMember]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        [DataMember]
        public string ApproverId
        {
            get { return approverId; }
            set { approverId = value; }
        }

        [DataMember]
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
    }
}
