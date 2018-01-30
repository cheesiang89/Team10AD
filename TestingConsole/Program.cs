using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TestingConsole.Model;
namespace TestingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            List<CartData> originalCart = createList();
            foreach (var item in originalCart)
            {
                Console.WriteLine("Original list: Item code is - "+ item.itemCode + "| Quantity is - "+ item.quantity);
               
            }

           List<CartData> newCart = CombineDuplicates(originalCart);
            foreach (var item in newCart)
            {
                Console.WriteLine("New list: Item code is - " + item.itemCode + "| Quantity is - " + item.quantity);

            }

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
             (key, values) => new
             {
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
                Console.WriteLine(c.itemCode + "," + c.quantity);
            }

            return newList;
        }
        public static string GetQuantityRequested(string deptName, string category, string month, string year)
        {
            int quantity = 0;
            Team10ADModel m = new Team10ADModel();

                //Get EmployeeIDs from Dept
            string deptCode = m.Departments.Where(x => x.DepartmentName == deptName).Select(x => x.DepartmentCode).First();
            return deptCode;
                //Search the Requisitions with EmployeeIDs,RequisitonDates, Status = "Completed" to get RequisitionIDs

                //Search the RequisitionDetails with RequisitionIDs to get ItemCodes

                //Search the Catalogue with ItemCodes where Category == category
            



        }
    }
}
