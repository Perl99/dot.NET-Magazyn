using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using GameStore.REST.JSONs;

namespace GameStore.REST.Services
{
    [ServiceContract]
    public interface IAuctionService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "get/{id}")]
        AuctionJson Get(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "list")]
        List<AuctionJson> List();

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "save")]
        void Save(AuctionJson json);
    }
}
