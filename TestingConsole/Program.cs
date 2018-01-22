using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TestingConsole.AppCode;

namespace TestingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Combine cart Test
            // List<CartData> originalCart = createList();
            // foreach (var item in originalCart)
            // {
            //     Console.WriteLine("Original list: Item code is - "+ item.itemCode + "| Quantity is - "+ item.quantity);

            // }
            //List<CartData> newCart = CombineDuplicates(originalCart);
            // foreach (var item in newCart)
            // {
            //     Console.WriteLine("New list: Item code is - " + item.itemCode + "| Quantity is - " + item.quantity);

            // }


            //Send email Test
            //string toEmailAddress = "e0227390@u.nus.edu";
            //string fromEmailAddress = "ben@contoso.com";
            //string subject = "Using the new SMTP client.";
            //string body = @"Using this new feature, you can send an e-mail message from an application very easily.";
            //Console.WriteLine(SendEmailAuto(toEmailAddress, subject, fromEmailAddress, body));

            //SendUndelegateRepEmail test
            string departmentCode = "ARTS";
            Program t = new Program();
            Console.WriteLine(t.SendUndelegateRepEmail(departmentCode));
            Console.ReadLine();
        }
        public static List<CartData> createList()
        {
            //Method is to create list of 10 values with 3 duplicated

            List<CartData> cart = new List<CartData>();
            CartData a = new CartData();
            a.itemCode = "C001"; a.quantity = "10"; //a.description = "Max";a.uom = "dozen";
            CartData b = new CartData();
            b.itemCode = "C002"; b.quantity = "10"; //b.description = "Max";  b.uom = "dozen";
            CartData c = new CartData();
            c.itemCode = "C003"; c.quantity = "10"; //c.description = "Max";  c.uom = "dozen";
            CartData d = new CartData();
            d.itemCode = "C004"; d.quantity = "10"; //d.description = "Max";  d.uom = "dozen";

            //DUPLICATE
            CartData e = new CartData();
            e.itemCode = "C001"; e.quantity = "10";//e.description = "Max";  e.uom = "dozen";

            CartData f = new CartData();
            f.itemCode = "C005"; f.quantity = "10";//f.description = "Max";  f.uom = "dozen";
            CartData g = new CartData();
            g.itemCode = "C006"; g.quantity = "10";//g.description = "Max";  g.uom = "dozen";

            //DUPLICATE
            CartData h = new CartData();
            h.itemCode = "C001"; h.quantity = "10";//h.description = "Max";  h.uom = "dozen";

            CartData i = new CartData();
            i.itemCode = "C008"; i.quantity = "10"; //i.description = "Max"; i.uom = "dozen";
            CartData j = new CartData();
            j.itemCode = "C009"; j.quantity = "10";//j.description = "Max";  j.uom = "dozen";

            cart.Add(a); cart.Add(b); cart.Add(c); cart.Add(d); cart.Add(e); cart.Add(f); cart.Add(g);
            cart.Add(h); cart.Add(i); cart.Add(j);

            return cart;
        }


        public static List<CartData> CombineDuplicates(List<CartData> oldList)
        {
            List<CartData> newList = new List<CartData>();

            var result = oldList.GroupBy(x => x.itemCode,
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
                Console.WriteLine(c.itemCode+","+c.quantity);
            }

            return newList;
        }
        public static bool SendEmailAuto(string toEmailAddress, string subject, string fromEmailAddress, string body)
        {
            bool isSent = false;
            //Usecases to send email:
            //1. Assign rep (HOD-> Employee)
            //2. Undelegate approval (HOD-> Employee)
            //3. Delegate approval (HOD-> Employee)
            //4. Submit requisition (Employee -> Approver)
            //5. Approve/reject requisition (Approver -> Employee)
            //6. Generate disbursement list (Clerk-> Rep)
            
            //Email address used for sending: logicuniversity2018@gmail.com , team10ad
            try
            {
                if (!string.IsNullOrEmpty(toEmailAddress))
                {
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 465);
                    client.UseDefaultCredentials = true;
                    client.Credentials = new System.Net.NetworkCredential
                    (@"logicuniversity2018@gmail.com", "team10ad");
                    client.EnableSsl = true;
                    //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    //ALT 2:
                    //client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.PickupDirectoryFromIis;

                    MailMessage mm = new MailMessage();
                    mm.To.Add(toEmailAddress);
                    mm.From = new MailAddress(fromEmailAddress);
                    mm.Subject = subject;
                    mm.Body = body;
                    mm.IsBodyHtml = true;
                    mm.BodyEncoding = System.Text.Encoding.UTF8;
                    client.Send(mm);
                    isSent = true;
                }
                return isSent;
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
                return isSent;
            }
            catch (SmtpFailedRecipientException e)
            {
                Console.WriteLine(e.Message);
                return isSent;
            }
            catch (SmtpException e)
            {
                Console.WriteLine(e.Message);
                return isSent;
            }
        }
        public static string SendEmailClient(string toEmailAddress, string subject, string fromEmailAddress, string body)
        {
            //Function will open email client with fields filled up
            // "fromEmailAddress" is not used because assumption is sender will be sending with corporate email client tied to own a/c
           // navigateurl = "mailto:user@example.com?subject=MessageTitle&body=MessageContent";

            //Construct NavigateUrl string
            StringBuilder sb = new StringBuilder();
            sb.Append("mailto:");
            sb.Append(toEmailAddress);
            sb.Append("?subject=");
            sb.Append(subject);
            sb.Append("&body=");
            sb.Append(body);

            return sb.ToString();
        }
        public string SendUndelegateRepEmail(string departmentCode)
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
            return String.Format(oldRepEmail+"***"+body);
        }


    }

}

