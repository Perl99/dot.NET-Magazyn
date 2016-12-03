using System.Diagnostics;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using GameStore.REST.Services;
using Authorization = GameStore.REST.Security.Authorization;

namespace GameStore.WPF.Services
{

    [System.CodeDom.Compiler.GeneratedCode("System.ServiceModel", "4.0.0.0")]
    public class LoginServiceClient : ClientBase<ILoginService>, ILoginService
    {

        public LoginServiceClient(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {
        }

        public LoginServiceClient(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public LoginServiceClient(string endpointConfigurationName, EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public LoginServiceClient(Binding binding, EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        public int Login(REST.JSONs.LoginJson json)
        {
            int userId;
            using (new OperationContextScope(InnerChannel))
            {

                userId = Channel.Login(json);

                var context = WebOperationContext.Current;
                Debug.Assert(context != null, "context != null");
                var headers = context.IncomingResponse.Headers;
                foreach (var h in headers)
                {
                    Debug.WriteLine(h.ToString());
                }

                Session s = Session.GetInstance;
                s.userId = userId;
                s.token = headers.Get(Authorization.AuthToken);
            }

            return userId;
        }

        public void Register(REST.JSONs.UserJson json)
        {
            Channel.Register(json);
        }
    }
}
