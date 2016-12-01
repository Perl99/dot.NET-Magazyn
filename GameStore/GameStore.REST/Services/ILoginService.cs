using System.ServiceModel;
using System.ServiceModel.Web;
using GameStore.REST.JSONs;

namespace GameStore.REST.Services
{
    [ServiceContract]
    public interface ILoginService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "login")]
        void Login(LoginJson json);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "register")]
        void Register(UserJson json);
    }
}
