using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team10AD_Web.App_Code;

namespace Team10AD_Web.EmployeePage
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Call bizLogic to test
            if (!IsPostBack)
            {
               // BuildEmailAsLink();
            }

        }
        //protected void BuildEmailAsLink()
        //{
        //    //Email is different because we have to make the link clickable.
        //    //navigateurl="mailto:user@example.com?subject=MessageTitle&body=MessageContent"

        //    var email = lnkEmail.Text;

        //    //Only need to load the email address once on pageload. otherwise reuse it from the UI.
        //    if (!string.IsNullOrEmpty(email) && (email.Length > 1) && email.Contains("@"))
        //    {
        //        //continue;
        //    }
        //    else
        //    {
        //        email = lnkEmail.Text.Trim();
        //    }

        //    if (string.IsNullOrEmpty(email) == false)
        //    {
        //        lnkEmail.NavigateUrl = lnkEmail.NavigateUrl.Replace("user@example.com", email);
        //        lnkEmail.NavigateUrl = lnkEmail.NavigateUrl.Replace("MessageTitle", "Reaching Out");
        //        lnkEmail.NavigateUrl = lnkEmail.NavigateUrl.Replace("MessageContent",
        //           "HELLLOOO");

        //        lnkEmail.Text = email;
        //        lnkEmail.Visible = true;
        //    }
        //}
        //public void SendEmailAuto(string toEmailAddress, string subject, string fromEmailAddress, string body){
        //    //Usecases to send email:
        //    //1. Assign rep (HOD-> Employee)
        //    //2. Undelegate approval (HOD-> Employee)
        //    //3. Delegate approval (HOD-> Employee)
        //    //4. Submit requisition (Employee -> Approver)
        //    //5. Approve/reject requisition (Approver -> Employee)
        //    //6. Generate disbursement list (Clerk-> Rep)

        //     string username = "logicuniversity2018@gmail.com";
        //    string password = "team10ad";
        //    try
        //    {
        //        using (MailMessage mm = new MailMessage(username, toEmailAddress))
        //        {
        //            mm.Subject = subject;
        //            mm.Body = body;

        //            //For attachement (NOT USED)
        //            //if (fuAttachment.HasFile)
        //            //{
        //            //    string FileName = Path.GetFileName(fuAttachment.PostedFile.FileName);
        //            //    mm.Attachments.Add(new Attachment(fuAttachment.PostedFile.InputStream, FileName));
        //            //}
        //            mm.IsBodyHtml = true;

        //            SmtpClient smtp = new SmtpClient();
        //            smtp.Host = "smtp.gmail.com";
        //            smtp.EnableSsl = true;
        //            NetworkCredential NetworkCred = new NetworkCredential(username, password);
        //            smtp.UseDefaultCredentials = true;
        //            smtp.Credentials = NetworkCred;
        //            smtp.Port = 587;
        //            smtp.Send(mm);
        //            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);
        //        }
        //    } catch (InvalidOperationException e)
        //    {
        //        Console.WriteLine(e.Message);

        //    }
        //    catch (SmtpFailedRecipientException e)
        //    {
        //        Console.WriteLine(e.Message);

        //    }
        //    catch (SmtpException e)
        //    {
        //        Console.WriteLine(e.Message);

        //    }


        //}


            protected void btnAutoEmail_Click(object sender, EventArgs e)
        {
            //Send email Test
            //string toEmailAddress = "e0227390@u.nus.edu";
            //string fromEmailAddress = "logicuniversity2018@gmail.com";
            //string subject = "Test subject xxxx";
            //string body = @"This is a test email.";
            //SendEmailAuto(toEmailAddress, subject, fromEmailAddress, body);
            //ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);

           LogicUtility.Instance.SendUndelegateRepEmail("ARTS");
        }
    }
}


