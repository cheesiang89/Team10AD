using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using Team10AD_Web;
using Team10AD_Web.Model;
namespace Team10AD_Web.Service
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CartService
    {
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";

        [WebGet()]
        [OperationContract]
        public string Greeting()
        {
            // Add your operation implementation here
            return   "Hello world"; ;
        }

        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
              RequestFormat = WebMessageFormat.Json,
              ResponseFormat = WebMessageFormat.Json)]
        public string GetJSON(List<CartData> cart)
        {
            List<RequisitionDetail> newCart = CS_BizLogic.CreateRequisition(cart);

            string s = "";
           
            foreach (var item in newCart)
            {
                s += "**" + item.ItemCode + "," + item.QuantityRequested + "**";
            }

            return s;



        }
    }
}
