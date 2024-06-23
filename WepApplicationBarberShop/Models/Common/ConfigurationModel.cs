namespace WepApplicationBarberShop.Models.Common
{
    public class ConfigurationModel
    {
        public ApiConfigurationModel Config { get; set; } = new ApiConfigurationModel();
    }
    public class ApiConfigurationModel
    {
        public int valueBack { get; set; }
    }
}
