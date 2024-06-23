namespace WepApplicationBarberShop.Models.DTO.Request
{
    public class CreateTurnRequest
    {
        public string? trace { get; set; } = string.Empty;
        public int interval { get; set; } = 0;
        public string? hourInit { get; set; } = string.Empty;
        public string? hourEnd { get; set; } = string.Empty;
    }
}
