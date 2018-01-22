using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

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

        public void SendEmailAuto(string toEmailAddress, string subject, string fromEmailAddress, string body)
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
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);

            }
            catch (SmtpFailedRecipientException e)
            {
                Console.WriteLine(e.Message);

            }
            catch (SmtpException e)
            {
                Console.WriteLine(e.Message);

            }


        }
        //Assign rep (HOD-> Employee)
        public void SendDelegateRepEmail()
        {        //Need new DelegatedID
            
        }
        public void SendUndelegateRepEmail(string departmentCode)
        {    //Need old Delegated email: 
            string oldRepName = BusinessLogic_Sam.checkCurrentRep(departmentCode);
            string oldRepEmail = "";
            using (Model.Team10ADModel m = new Model.Team10ADModel())
            {
                oldRepEmail = m.Employees.Where(x => x.Name == oldRepName).Select(x => x.Email).First();
            }
            //Construct body
            StringBuilder sb = new StringBuilder();
            sb.Append("Dear ");
            sb.Append(oldRepName);
            sb.Append(", <br/> You are no longer Department Representative. <br/> Sincerely, <br/> Logic University");
            string body = sb.ToString();
            //return String.Format(oldRepEmail + "***" + body);
            string subject = "Representative Undelegation Notification";
            string fromEmailAddress = "logicuniversity2018@gmail.com";
            if (!String.IsNullOrEmpty(oldRepEmail))
            {
                //FOR TESTING- USE hardcoded email
                oldRepEmail= "e0227390@u.nus.edu";
                 LogicUtility.Instance.SendEmailAuto(oldRepEmail,subject,fromEmailAddress,body);
            }
            
        }

        //2. Delegate approval (HOD-> Employee)
        public void SendDelegateApproverEmail()
        {
            //Sends 2 email: to delegated & undelegated
            //Need ReceiverID, startdate, enddate
        }
        //3. Submit requisition (Employee -> Approver)
        public void SendRequisitionEmail()
        {
            //Need EmployeeID

        }
        //4. Approve/reject requisition (Approver -> Employee)
        public void SendRequisitionResponseEmail()
        {
            //Need EmployeeID (Requestor)
        }
        //5. Generate disbursement list (Clerk-> Rep)
        public void SendDisbursementEmails()
        {//Need Disbursment ID

        }

    }
}
