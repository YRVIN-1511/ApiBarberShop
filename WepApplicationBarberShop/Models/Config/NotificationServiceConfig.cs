namespace WepApplicationBarberShop.Models.Config
{
    public class NotificationServiceConfig
    {
        public string url { get; set; } = string.Empty;
        public string methodGenerate { get; set; } = string.Empty;
        public string user { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string token { get; set; } = string.Empty;
        public string appUserId { get; set; } = string.Empty;
        public string application { get; set; } = string.Empty;
        public string titleMessage { get; set; } = string.Empty;
        public string messageBody { get; set; } = string.Empty;
        public List<string> titleMessagesByTypeGiro { get; set; } = new List<string>();
        public configTarget target { get; set; } = new();

    }
    public class configTarget
    { 
        public bool push { get; set; } = false;
        public bool email { get; set; } = false;
        public bool sms { get; set; } = false;
        public bool whatsApp { get; set; } = false;
    }
}
