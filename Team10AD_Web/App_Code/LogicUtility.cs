using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using Team10AD_Web.App_Code.Model;

namespace Team10AD_Web.App_Code
{
    public class LogicUtility
    {
        //private static LogicUtility instance;
        //private LogicUtility() { }

        //public static LogicUtility Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            instance = new LogicUtility();
        //        }
        //        return instance;
        //    }
        //}

        private static readonly LogicUtility instance = new LogicUtility();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static LogicUtility()
        {
        }

        private LogicUtility()
        {
        }

        public static LogicUtility Instance
        {
            get
            {
                return instance;
            }
        }

        public string SendEmailAuto(string toEmailAddress, string subject, string fromEmailAddress, string body)
        {
            //Usecases to send email:
            //1. Assign rep (HOD-> Employee)
            //2. Undelegate approval (HOD-> Employee)
            //3. Delegate approval (HOD-> Employee)
            //4. Submit requisition (Employee -> Approver)
            //5. Approve/reject requisition (Approver -> Employee)
            //6. Generate disbursement list (Clerk-> Rep)

            string username = "logicuniversity2018@gmail.com";
            string password = "team10ad";
            try
            {
                using (MailMessage mm = new MailMessage(fromEmailAddress, toEmailAddress))
                {
                    mm.Subject = subject;
                    mm.Body = body;

                    //For attachement (NOT USED)
                    //if (fuAttachment.HasFile)
                    //{
                    //    string FileName = Path.GetFileName(fuAttachment.PostedFile.FileName);
                    //    mm.Attachments.Add(new Attachment(fuAttachment.PostedFile.InputStream, FileName));
                    //}
                    mm.IsBodyHtml = true;

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential(username, password);
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);

                }
                return "SUCCESS";
            }
            catch (Exception e)
            {
                return e.Message;

            }
        }

        //On UnAssign or Assign rep, notify (HOD-> Employee)
        public string SendRepEmail(string repName, string flag)
        {
            string result = "ERROR";

            //Get email Details: 
            string repEmail = "";
            string body = "";
            string subject = "";
            string fromEmailAddress = "logicuniversity2018@gmail.com";

            using (Model.Team10ADModel m = new Model.Team10ADModel())
            {
                //FOR TESTING-Hardcoded email
                //repEmail = "e0227390@u.nus.edu";
                repEmail = m.Employees.Where(x => x.Name == repName).Select(x => x.Email).First();
            }

            if (flag == "ASSIGN")
            {
                //Construct body
                StringBuilder sb = new StringBuilder();
                sb.Append("Dear ");
                sb.Append(repName);
                sb.Append(", <br/> You are now a Department Representative. <br/> Sincerely, <br/> Logic University");
                body = sb.ToString();
                subject = "Representative Assignment Notification";

            }
            else if (flag == "UNASSIGN")
            {
                //Construct body
                StringBuilder sb = new StringBuilder();
                sb.Append("Dear ");
                sb.Append(repName);
                sb.Append(", <br/> You are no longer Department Representative. <br/> Sincerely, <br/> Logic University");
                body = sb.ToString();
                subject = "Representative Undelegation Notification";
            }

            if (!String.IsNullOrEmpty(repEmail))
            {
                result = LogicUtility.Instance.SendEmailAuto(repEmail, subject, fromEmailAddress, body);
            }
            return result;

        }

        //On Delegate approval, notify (HOD-> Employee)
        public string SendApproverEmail(string selectedApproverName, string startDate, string endDate)
        {
            string result = "ERROR";
            string approverEmail = "";
            string body = "";
            string subject = "";
            string fromEmailAddress = "logicuniversity2018@gmail.com";
            using (Model.Team10ADModel m = new Model.Team10ADModel())
            {
                //FOR TESTING-Hardcoded email
                //approverEmail = "e0227390@u.nus.edu";
                approverEmail = m.Employees.Where(x => x.Name == selectedApproverName).Select(x => x.Email).First();
            }

            //Construct body
            StringBuilder sb = new StringBuilder();
            sb.Append("Dear ");
            sb.Append(selectedApproverName);
            sb.Append(", <br/> You are now a Approver. <br/>");
            sb.Append("Start Date: " + startDate + "<br/>");
            sb.Append("End Date: " + endDate + "<br/>Sincerely, <br/> Logic University");
            body = sb.ToString();
            subject = "Approver Delegation Notification";

            if (!String.IsNullOrEmpty(approverEmail))
            {
                result = LogicUtility.Instance.SendEmailAuto(approverEmail, subject, fromEmailAddress, body);
            }
            return result;

        }

        //On Submit requisition (Employee -> Approver) notify
        public string SendRequisitionEmail(int requisitionID, int? requestorID, string requisitionDate)
        {
            string result = "ERROR";
            string approverEmail = "";
            int? approverID;
            string body = "";
            string subject = "";
            string fromEmailAddress = "logicuniversity2018@gmail.com";
            string requestorName = "";
            using (Model.Team10ADModel m = new Model.Team10ADModel())
            {
                //FOR TESTING-Hardcoded email
                //approverEmail = "e0227390@u.nus.edu";

                approverID = m.Employees.Where(x => x.EmployeeID == requestorID)
                    .Select(x => x.Department).Select(x => x.ApproverID).First();
                approverEmail = m.Employees.Where(x => x.EmployeeID == approverID).Select(x => x.Email).First();
                requestorName = m.Employees.Where(x => x.EmployeeID == requestorID).Select(x => x.Name).First();

            }

            //Construct body
            StringBuilder sb = new StringBuilder();
            sb.Append("<b>Stationery Requisition</b><br/>");
            sb.Append("<b>Requisition ID</b>: ");
            sb.Append(requisitionID + "<br/>");
            sb.Append("<b>Requisition Date</b>: ");
            sb.Append(requisitionDate + "<br/>");
            sb.Append("<b>Employee Name</b>: ");
            sb.Append(requestorName + "<br/><br/>");
            sb.Append(makeDetailsTable(requisitionID, "REQUISITION"));
            sb.Append("<br/>Sincerely, <br/> Logic University");
            body = sb.ToString();
            subject = "New Requisition pending approval";

            if (!String.IsNullOrEmpty(approverEmail))
            {
                result = LogicUtility.Instance.SendEmailAuto(approverEmail, subject, fromEmailAddress, body);
            }
            return result;

        }

        //On Approve/reject requisition (Approver -> Employee) notify
        public string SendRequisitionResponseEmail(int requisitionID, string remarks, string flag)
        {
            string result = "ERROR";
            string requestorEmail = "";
            string requisitionDate = "";
            string body = "";
            string subject = "";
            string fromEmailAddress = "logicuniversity2018@gmail.com";
            string requestorName = "";
            using (Model.Team10ADModel m = new Model.Team10ADModel())
            {
                //FOR TESTING-Hardcoded email
                // requestorEmail = "e0227390@u.nus.edu";
                int? requestorID = m.Requisitions.Where(x => x.RequisitionID == requisitionID).Select(x => x.RequestorID).First();
                requestorEmail = m.Employees.Where(x => x.EmployeeID == requestorID).Select(x => x.Email).First();
                requestorName = m.Employees.Where(x => x.EmployeeID == requestorID).Select(x => x.Name).First();
                requisitionDate = m.Requisitions.Where(x => x.RequisitionID == requisitionID).Select(x => x.RequisitionDate).First().ToString();
            }

            //Construct body
            StringBuilder sb = new StringBuilder();
            sb.Append("<b>Stationery Requisition</b><br/>");
            sb.Append("<b>Requisition ID</b>: ");
            sb.Append(requisitionID + "<br/>");
            sb.Append("<b>Requisition Date:</b> ");
            sb.Append(requisitionDate + "<br/>");
            sb.Append("<b>Employee Name</b>: ");
            sb.Append(requestorName + "<br/><br/>");
            sb.Append(makeDetailsTable(requisitionID, "REQUISITION"));
            if (flag == "APPROVED")
            {
                sb.Append("<br/><br/><b>Your requisition has been approved.</b><br/>");
            }
            else if (flag == "REJECTED")
            {
                sb.Append("<br/><br/><b>Your requisition has been rejected.</b><br/>");
            }
            sb.Append("<br/><b>Remarks</b>: " + remarks);
            sb.Append("<br/><br/>Sincerely, <br/> Logic University");
            body = sb.ToString();
            subject = "Requisition status update";

            if (!String.IsNullOrEmpty(requestorEmail))
            {
                result = LogicUtility.Instance.SendEmailAuto(requestorEmail, subject, fromEmailAddress, body);
            }
            return result;
        }

        //On Generate disbursement list (Clerk-> Rep)
        public string SendDisbursementEmail(int disbursementID)
        {

            string result = "ERROR";
            string repName = "";
            string repEmail = "";

            string collectionPoint = "";
            string body = "";
            string subject = "";
            string fromEmailAddress = "logicuniversity2018@gmail.com";

            using (Model.Team10ADModel m = new Model.Team10ADModel())
            {
                //FOR TESTING-Hardcoded email
                //repEmail = "e0227390@u.nus.edu";

                repName = m.Disbursements.Where(x => x.DisbursementID == disbursementID)
                    .Select(x => x.Department).Select(x => x.Employee).Select(x => x.Name).First();
                repEmail = m.Employees.Where(x => x.Name == repName).Select(x => x.Email).First();
                collectionPoint = m.Disbursements.Where(x => x.DisbursementID == disbursementID)
                    .Select(x => x.CollectionPoint).Select(x => x.PointName).First();

            }

            //Construct body
            StringBuilder sb = new StringBuilder();
            sb.Append("Hi ");
            sb.Append(repName + ",<br/>");
            sb.Append("Your stationery is ready for collection.<br/><br/>");
            sb.Append("<b>Disbursement No:</b>");
            sb.Append(disbursementID.ToString() + "<br/>");
            sb.Append("<b>Collection point: </b>");
            sb.Append(collectionPoint + "<br/><br/>");
            sb.Append(makeDetailsTable(disbursementID, "DISBURSEMENT"));
            sb.Append("<br/>Sincerely, <br/> Logic University");
            body = sb.ToString();
            subject = "Disbursement Ready for Collection";

            if (!String.IsNullOrEmpty(repEmail))
            {
                result = LogicUtility.Instance.SendEmailAuto(repEmail, subject, fromEmailAddress, body);
            }
            return result;

        }

        //Method used by SendDisbursementEmail(), CreateAdjustmentVoucher()
        public string makeDetailsTable(int ID, string flag)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table style='width: 100 %'><tr>");
            if (flag == "DISBURSEMENT")
            {
                int num = 1;
                string itemDescription = "";
                string quantityDisbursed = "";
                sb.Append("<th colspan='1' style='border:solid 1px'>S/N</th>");
                sb.Append("<th colspan='1' style='border:solid 1px'>Description</th>");
                sb.Append("<th colspan='2' style='border:solid 1px'>Quantity</th></tr>");
                using (Model.Team10ADModel m = new Model.Team10ADModel())
                {
                    List<DisbursementDetail> itemList = m.DisbursementDetails
                        .Where(x => x.DisbursementID == ID).Select(x => x).ToList();
                    foreach (var item in itemList)
                    {
                        //Get itemDescription, quantityDisbursed
                        itemDescription = m.Catalogues.Where(x => x.ItemCode == item.ItemCode).Select(x => x.Description).First();
                        quantityDisbursed = item.QuantityRequested.ToString();
                        sb.Append("<tr><td style='border:solid 1px'>");
                        sb.Append(num + "</td><td style='border:solid 1px'>");
                        sb.Append(itemDescription + "</td><td style='border:solid 1px'>");
                        sb.Append(quantityDisbursed + "</td></tr>");
                        num++;
                    }
                }
            }
            else if (flag == "REQUISITION")
            {
                int num = 1;
                string itemDescription = "";
                string quantityRequested = "";
                string unitOfMeasure = "";

                sb.Append("<th colspan='1' style='border:solid 1px'>S/N</th>");
                sb.Append("<th colspan='1' style='border:solid 1px'>Description</th>");
                sb.Append("<th colspan='2' style='border:solid 1px'>Quantity</th>");
                sb.Append("<th colspan='2' style='border:solid 1px'>Unit of Measure</th></tr>");
                using (Model.Team10ADModel m = new Model.Team10ADModel())
                {
                    List<RequisitionDetail> itemList = m.RequisitionDetails
                        .Where(x => x.RequisitionID == ID).Select(x => x).ToList();
                    foreach (var item in itemList)
                    {
                        //Get itemDescription, quantityDisbursed
                        itemDescription = m.Catalogues.Where(x => x.ItemCode == item.ItemCode).Select(x => x.Description).First();
                        quantityRequested = item.QuantityRequested.ToString();
                        unitOfMeasure = item.Catalogue.UnitOfMeasure;
                        sb.Append("<tr><td style='border:solid 1px'>");
                        sb.Append(num + "</td><td style='border:solid 1px'>");
                        sb.Append(itemDescription + "</td><td style='border:solid 1px'>");
                        sb.Append(quantityRequested + "</td><td></td><td style='border:solid 1px'>");
                        sb.Append(unitOfMeasure + "</td><td></td></tr>");
                        num++;
                    }
                }
            }
            else if (flag == "ADJUSTMENT")
            {
                int num = 1;
                string itemDescription = "";
                string quantityAdjusted = "";
                string reason = "";

                sb.Append("<th colspan='1' style='border:solid 1px'>S/N</th>");
                sb.Append("<th colspan='1' style='border:solid 1px'>Description</th>");
                sb.Append("<th colspan='2' style='border:solid 1px'>Quantity Adjusted</th>");
                sb.Append("<th colspan='2' style='border:solid 1px'>Reason</th></tr>");

                using (Model.Team10ADModel m = new Model.Team10ADModel())
                {
                    List<StockAdjustmentVoucherDetail> itemList = m.StockAdjustmentVoucherDetails
                        .Where(x => x.VoucherID == ID).Select(x => x).ToList();
                    foreach (var item in itemList)
                    {
                        //Get itemDescription, quantityDisbursed
                        itemDescription = m.Catalogues.Where(x => x.ItemCode == item.ItemCode).Select(x => x.Description).First();
                        quantityAdjusted = item.QuantityAdjusted.ToString();
                        reason = item.Reason;
                        sb.Append("<tr><td style='border:solid 1px'>");
                        sb.Append(num + "</td><td style='border:solid 1px'>");
                        sb.Append(itemDescription + "</td><td style='border:solid 1px'>");
                        sb.Append(quantityAdjusted + "</td><td></td><td style='border:solid 1px'>");
                        sb.Append(reason + "</td><td></td></tr>");
                        num++;
                    }
                }
            }
            sb.Append("</table>");
            return sb.ToString();
        }

        //On CreateAdjustmentVoucher (Clerk->Manager/Supervisor)
        public string SendAdjustmentEmail(int voucherID, int staffID)
        {

            string result = "ERROR";
            string supOrMgrName = "";
            string supOrMgrEmail = "";

            string body = "";
            string subject = "";
            string fromEmailAddress = "logicuniversity2018@gmail.com";

            using (Model.Team10ADModel m = new Model.Team10ADModel())
            {
                //FOR TESTING-Hardcoded email
                //repEmail = "e0227390@u.nus.edu";

                supOrMgrName = m.StoreStaffs.Where(x => x.StoreStaffID == staffID).Select(x => x.Name).First();
                supOrMgrEmail = m.StoreStaffs.Where(x => x.StoreStaffID == staffID).Select(x => x.Email).First();
            }

            //Construct body
            StringBuilder sb = new StringBuilder();
            sb.Append("Hi ");
            sb.Append(supOrMgrName + ",<br/>");
            sb.Append("Following stock were adjusted: <br/><br/>");
            sb.Append("<b>Adjustment Voucher No:</b>");
            sb.Append(voucherID.ToString() + "<br/><br/>");
            sb.Append(makeDetailsTable(voucherID, "ADJUSTMENT"));
            sb.Append("<br/>Sincerely, <br/> Logic University");
            body = sb.ToString();
            subject = "Stock Adjustment Notification";

            if (!String.IsNullOrEmpty(supOrMgrEmail))
            {
                result = LogicUtility.Instance.SendEmailAuto(supOrMgrEmail, subject, fromEmailAddress, body);
            }
            return result;

        }
    }
}
