namespace WepApplicationBarberShop.Models.DTO.Request
{
    public class CreateClientRequest
    {
        public string trace { get; set; }
        public string? lastName { get; set; } = string.Empty;
        public string? motherLastName { get; set; } = string.Empty;
        public string? names { get; set; } = string.Empty;
        public string? email { get; set; } = string.Empty;
        public string? cellphone { get; set; } = string.Empty;
    }
}
