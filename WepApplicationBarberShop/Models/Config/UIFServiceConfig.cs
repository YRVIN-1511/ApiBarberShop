namespace WepApplicationBarberShop.Models.Config
{
    public class UIFServiceConfig
    {
        public string url { get; set; } = string.Empty;
        public string methodConsult { get; set; } = string.Empty;
        public string methodRegister { get; set; } = string.Empty;
        public string methodExtorno { get; set; } = string.Empty;
        public string methodConsultUser { get; set; } = string.Empty;
        public string methodRegisterUser { get; set; } = string.Empty;
        public string methodExtornoUser { get; set; } = string.Empty;
        public List<UIFUsersConfig> usersUIF { get; set; } = new();

    }
    public class UIFUsersConfig
    {
        public string channel { get; set; } = string.Empty;
        public string nameService { get; set; } = string.Empty;
        public string user { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string token { get; set; } = string.Empty;
        public string codChannel { get; set; } = string.Empty;
        public string typeTrn { get; set; } = string.Empty;
        public string causalTrn { get; set; } = string.Empty;
        public string typePay { get; set; } = string.Empty;
    }
}
