namespace WepApplicationBarberShop.Models.DTO.Request
{
    public class FilterBarberByService
    {
        public string trace { get; set; } = string.Empty;
        public List<string> idServices { get; set; } = new();
    }
}
