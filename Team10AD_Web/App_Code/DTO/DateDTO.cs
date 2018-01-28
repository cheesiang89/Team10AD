using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team10AD_Web.DTO
{
    public class DateDTO
    {
        public DateDTO(string month, string year){
            Month = month;
            Year = year;
        }
        public string Month { get; set; }
        public string Year { get; set; }
       

    }
}