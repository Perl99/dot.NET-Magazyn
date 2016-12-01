using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using GameStore.REST.JSONs;

namespace GameStore.REST.Services
{
    [ServiceContract]
    interface IOfferService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "get/{id}")]
        OfferJson Get(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "auction/{auctionId}/list")]
        List<OfferJson> List(string auctionId);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "auction/{auctionId}/save")]
        void Save(string auctionId, OfferJson json);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "auction/{auctionId}/accept/{id}")]
        void Accept(string auctionId, string id);
    }
}
