namespace WepApplicationBarberShop.Models.Authentication
{
    public class AuthenticationEntitie
    {
        public string State { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public AuthenticationDataModel Data { get; set; } = new();

        public static AuthenticationEntitie ErrorAuthenticationModel(string statusCode, string message)
        {
            if (string.IsNullOrEmpty(message))
                return new AuthenticationEntitie
                {
                    State = "01",
                    Message = $"{statusCode} - ERROR DE SERVIDOR"
                };
            else
                return new AuthenticationEntitie
                {
                    State = "01",
                    Message = $"{statusCode} - {message.ToUpper()}"
                };
        }
    }
    public class AuthenticationDataModel
    {
        public int Id { get; set; } = 0;
        public string UserName { get; set; } = string.Empty;
        public string PublicToken { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string date { get; set; } = string.Empty;
    }
}