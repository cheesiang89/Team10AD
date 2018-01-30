using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Team10AD_Web.DTO
{
    public class ReportDTO:IComparable
    {
        public string Category { get; set; }
        public string DepartmentName { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public int Quantity { get; set; }

        public int CompareTo(object obj)
        {
            int compareNo = 0;
            ReportDTO otherObj = obj as ReportDTO;
            if (otherObj != null)
            {
                if (Int32.Parse(this.Year)< Int32.Parse(otherObj.Year))
                {
                    //This instance is smaller
                    compareNo = -1;
                   
                }
                else if (Int32.Parse(this.Year) > Int32.Parse(otherObj.Year))
                {   //Year larger - this instance is larger
                    compareNo = 1;
                }
                else
                {
                    //Year same
                    if (DateTime.ParseExact(this.Month, "MMM", CultureInfo.CurrentCulture).Month
                      < DateTime.ParseExact(otherObj.Month, "MMM", CultureInfo.CurrentCulture).Month)
                    {
                        //This instance Month is smaller
                        compareNo = -1;
                    }
                    else
                    {
                        //This instance Month is larger
                        compareNo = 1;
                    }
                }
            }            
            else
                throw new ArgumentException("Object is not a RequisitionReportDTO");
            return compareNo;
        }


    }
}