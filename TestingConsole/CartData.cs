using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TestingConsole
{
    [Serializable]
    [DataContract]
    public class CartData
    {
        [DataMember]
        public string itemCode { get; set; }
        //[DataMember]
        //public string description { get; set; }
        [DataMember]
        public string quantity { get; set; }
        //[DataMember]
        //public string uom { get; set; }
    }
}