using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team10AD_Web.App_Code
{
    [Serializable]
    [DataContract]
    public class CartData
    {
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }
        public string Uom { get; set; }
    }
}