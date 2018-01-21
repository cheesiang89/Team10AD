using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Team10AD_Web.App_Code
{
    [DataContract]
    [Serializable]
  
    public class Cart
    {
        [DataMember]
        public List<CartData> cart { get; set; }
    }
}