using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team10AD_Web.App_Code
{
       public class CartData
    {
        
        public string itemCode { get; set; }

        
        public string quantity { get; set; }

      
        public string reqid { get; set; }

        //[DataMember]
        //public string description { get; set; }
       

        //[DataMember]
        //public string uom { get; set; }
    }
}