using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team10AD_Web
{
       public class CartData
    {
        
        public string itemCode { get; set; }

        
        public string quantity { get; set; }

      
        public string reqid { get; set; }


        public string description { get; set; }

        
        public string uom { get; set; }
    }
}