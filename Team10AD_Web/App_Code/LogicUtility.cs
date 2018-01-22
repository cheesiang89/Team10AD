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
        private static LogicUtility instance;
        private LogicUtility() { }

        public static LogicUtility Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LogicUtility();
                }
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
        public string SendRepEmail(string departmentCode, string flag)
        {
            string result="ERROR";

            //Get email Details: 
            string repName = BusinessLogic_Sam.checkCurrentRep(departmentCode);
            string repEmail = "";
            string body="";
            string subject="";
            string fromEmailAddress = "logicuniversity2018@gmail.com";

            using (Model.Team10ADModel m = new Model.Team10ADModel())
            {
                //FOR TESTING-Hardcoded email
                repEmail = "e0227390@u.nus.edu";
               // repEmail = m.Employees.Where(x => x.Name ==repName).Select(x => x.Email).First();
            }

            if (flag == "DELEGATE")
            {
                //Construct body
                StringBuilder sb = new StringBuilder();
                sb.Append("Dear ");
                sb.Append(repName);
                sb.Append(", <br/> You are now a Department Representative. <br/> Sincerely, <br/> Logic University");
                 body = sb.ToString();
                subject = "Representative Delegation Notification";
                
            }else if(flag == "UNDELEGATE"){
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
               result = LogicUtility.Instance.SendEmailAuto(repEmail, subject,fromEmailAddress,body);
            }
            return result;
            
        }
     
        //On Delegate approval, notify (HOD-> Employee)
        public string SendApproverEmail(string selectedApproverName,string startDate, string endDate)
        {
            string result = "ERROR";            
            string approverEmail = "";
            string body = "";
            string subject = "";
            string fromEmailAddress = "logicuniversity2018@gmail.com";
            using (Model.Team10ADModel m = new Model.Team10ADModel())
            {
                //FOR TESTING-Hardcoded email
                approverEmail = "e0227390@u.nus.edu";
                // approverEmail = m.Employees.Where(x => x.Name ==selectedApproverName).Select(x => x.Email).First();
            }

                //Construct body
                StringBuilder sb = new StringBuilder();
                sb.Append("Dear ");
                sb.Append(selectedApproverName);
                sb.Append(", <br/> You are now a Approver. <br/>");
                sb.Append("Start Date: " + startDate +"<br/>");
                sb.Append("End Date: "+ endDate + "<br/>Sincerely, <br/> Logic University");
                body = sb.ToString();
                subject = "Approver Delegation Notification";
                       
            if (!String.IsNullOrEmpty(approverEmail))
            {
                result = LogicUtility.Instance.SendEmailAuto(approverEmail, subject, fromEmailAddress, body);
            }
            return result;

        }
        //On Submit requisition (Employee -> Approver) notify
        public string SendRequisitionEmail(string requisitionID, int? requestorID, string requisitionDate)
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
                approverEmail = "e0227390@u.nus.edu";

                //approverID = m.Employees.Where(x => x.EmployeeID == requestorID)
                //    .Select(x => x.Department).Select(x => x.ApproverID).First();
                //approverEmail = m.Employees.Where(x => x.EmployeeID == approverID).Select(x => x.Email).First();
                requestorName = m.Employees.Where(x => x.EmployeeID == requestorID).Select(x => x.Name).First();

            }

            //Construct body
            StringBuilder sb = new StringBuilder();
            sb.Append("<b>Stationery Requisition<b/><br/>");
            sb.Append("Requisition ID: ");
            sb.Append(requisitionID +"<br/>");
            sb.Append("Date: ");
            sb.Append(requisitionDate + "<br/>");
            sb.Append("Employee Name: ");
            sb.Append(requestorName);
            body = sb.ToString();
            subject = "New Requisition pending approval";

            if (!String.IsNullOrEmpty(approverEmail))
            {
                result = LogicUtility.Instance.SendEmailAuto(approverEmail, subject, fromEmailAddress, body);
            }
            return result;

        }
        //4. Approve/reject requisition (Approver -> Employee)
        public void SendRequisitionResponseEmail(string requestorID)
        {
            //Need EmployeeID (Requestor)
        }
        //5. Generate disbursement list (Clerk-> Rep)
        public void SendDisbursementEmails()
        {//Need Disbursment ID

        }

    }
}
