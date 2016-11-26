using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.ServiceModel.Web;
using System.Text;
using GameStore.Domain.Abstract;
using GameStore.REST.JSONs;

namespace GameStore.REST.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LoginService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LoginService.svc or LoginService.svc.cs at the Solution Explorer and start debugging.
    public class LoginService : ILoginService
    {
        private IUserRepository userRepository;

        public static string UserIdHeader = "X-UserId";
        public static string AuthToken = "X-AuthToken";

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
                WebOperationContext.Current.OutgoingResponse.Headers.Add(AuthToken, GenerateToken(json.Login, json.Password));
            }
        }

        public void Register(UserJson json)
        {
            // TODO: walidacja
            userRepository.Add(json.ToUser());
        }

        public static string GenerateToken(string login, string password)
        {
            string value = login + password;
            using (SHA256 hash = SHA256.Create())
            {
                return string.Join("", hash
                    .ComputeHash(Encoding.UTF8.GetBytes(value))
                    .Select(item => item.ToString("x2")));
            }
        }
    }
}
