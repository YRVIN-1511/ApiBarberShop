namespace WepApplicationBarberShop.Models.DTO.Request
{
    public class CreateUserRequest
    {
        public string? trace { get; set; } = string.Empty;
        public int idPerfil { get; set; }
        public DataBasicUser? user { get; set; } = new DataBasicUser();
        public AuthenticationUser? loginUser { get; set; } = new AuthenticationUser();
    }
    public class DataBasicUser
    {
        public string? lastName { get; set; } = string.Empty;
        public string? motherLastName { get; set; } = string.Empty;
        public string? names { get; set; } = string.Empty;
    }
    public class AuthenticationUser
    {
        public string? userName { get; set; } = string.Empty;
        public string? passwordName { get; set; } = string.Empty;
    }
}
