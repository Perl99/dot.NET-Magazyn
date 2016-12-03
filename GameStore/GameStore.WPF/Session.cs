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
    }
}
