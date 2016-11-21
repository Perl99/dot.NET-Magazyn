using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using GameStore.Domain.Entities;

namespace GameStore.REST
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "get/{id}")]
        Product Get(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "list")]
        List<Product> List();
    }
}
