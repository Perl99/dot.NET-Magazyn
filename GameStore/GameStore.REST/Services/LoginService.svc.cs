using System.Diagnostics;
using System.ServiceModel.Web;
using GameStore.Domain.Abstract;
using GameStore.REST.JSONs;
using GameStore.REST.Security;

namespace GameStore.REST.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository userRepository;

        public LoginService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void Login(LoginJson json)
        {
            var user = userRepository.FindByLoginAndPassword(json.Login, json.Password);
            if (user != null)
            {
                Debug.Assert(WebOperationContext.Current != null, "WebOperationContext.Current != null");
                WebOperationContext.Current.OutgoingResponse.Headers.Add(Authorization.AuthToken, Authorization.GenerateToken(json.Login, json.Password));
            }
        }

        public void Register(UserJson json)
        {
            // TODO: walidacja
            userRepository.Add(json.ToUser());
        }

    }
}
