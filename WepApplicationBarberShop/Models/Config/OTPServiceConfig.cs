namespace WepApplicationBarberShop.Models.Config
{
    public class OTPServiceConfig
    {
        public string url { get; set; } = string.Empty;
        public string methodGenerate { get; set; } = string.Empty;
        public string methodValidate { get; set; } = string.Empty;
        public string transactionTypeGiroFacil { get; set; } = string.Empty;
        public string transactionTypeGiro { get; set; } = string.Empty;
        public string transactionTypeGiroCheque { get; set; } = string.Empty;
        public string user { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string token { get; set; } = string.Empty;
        public string appUserId { get; set; } = string.Empty;
    }
}