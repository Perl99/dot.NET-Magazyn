using System.Diagnostics;
using System.Net;
using System.ServiceModel.Web;
using GameStore.Domain.Abstract;
using GameStore.REST.JSONs;
using Authorization = GameStore.REST.Security.Authorization;

namespace GameStore.REST.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository userRepository;

        public LoginService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public int Login(LoginJson json)
        {
            var user = userRepository.FindByLoginAndPassword(json.Login, json.Password);

            if (user == null)
            {
                throw new WebFaultException(HttpStatusCode.Unauthorized);
            }

            Debug.Assert(WebOperationContext.Current != null, "WebOperationContext.Current != null");
            WebOperationContext.Current.OutgoingResponse.Headers.Add(Authorization.AuthToken, Authorization.GenerateToken(json.Login, json.Password));

            return user.Id;
        }

        public void Register(UserJson json)
        {
            // TODO: walidacja
            userRepository.Add(json.ToUser());
        }

    }
}
