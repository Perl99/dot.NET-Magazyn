using System.Net;
using Authorization = GameStore.REST.Security.Authorization;

namespace GameStore.WPF
{
    public class Session
    {
        private static Session _instance;

        public int UserId { get; set; }

        public string Token { get; set; }

        private Session()
        {
        }

        public static Session GetInstance => _instance ?? (_instance = new Session());

        public void ApplyHeaders(WebHeaderCollection headers)
        {
            headers.Add(Authorization.UserIdHeader, UserId.ToString());
            headers.Add(Authorization.AuthToken, Token);
        }
    }
}
