using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.ServiceModel.Web;
using System.Text;
using GameStore.Domain.Abstract;
using GameStore.Domain.Entities;

namespace GameStore.REST.Security
{
    public class Authorization
    {
        private IUserRepository userRepository;

        public static string UserIdHeader = "X-UserId";
        public static string AuthToken = "X-AuthToken";

        public Authorization(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public bool IsAuthorized()
        {
            Debug.Assert(WebOperationContext.Current != null, "WebOperationContext.Current != null");
            string userId = WebOperationContext.Current.OutgoingResponse.Headers.Get(UserIdHeader);
            string token = WebOperationContext.Current.OutgoingResponse.Headers.Get(AuthToken);

            if (userId == null || token == null) return false;

            User user = userRepository.Find(int.Parse(userId));

            if (user == null) return false;

            return GenerateToken(user.Login, user.Password) == token;
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