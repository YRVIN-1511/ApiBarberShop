using WepApplicationBarberShop.Models.DTO.Response;

namespace WepApplicationBarberShop.Models.DTO.Request
{
    public class UpdateBarberRequest
    {
        public string? trace { get; set; } = string.Empty;
        public Barber barber { get; set; } = new();

    }
}
