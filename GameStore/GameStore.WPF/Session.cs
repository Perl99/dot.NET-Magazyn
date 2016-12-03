using System.Net;
using Authorization = GameStore.REST.Security.Authorization;

namespace GameStore.WPF
{
    public class Session
    {
        private static Session _instance;

        public int userId { get; set; }

        public string token { get; set; }

        private Session()
        {
        }

        public static Session GetInstance => _instance ?? (_instance = new Session());

        public void ApplyHeaders(WebHeaderCollection headers)
        {
            headers.Add(Authorization.UserIdHeader, userId.ToString());
            headers.Add(Authorization.AuthToken, token);
        }
    }
}
