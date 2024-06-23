namespace WepApplicationBarberShop.Models.Repository
{
    public class RegisterGiro
    {
        public string typeService { get; set; } = string.Empty;
        public string typeAffectation { get; set; } = string.Empty;
        public decimal amount { get; set; } = 0;
        public string currency { get; set; } = string.Empty;
        public string accountNumber { get; set; } = string.Empty;
        public string currencyAccountNumber { get; set; } = string.Empty;
        public decimal amountAccountOrigen { get; set; } = 0;
        public decimal exchangeRate { get; set; } = 1;
        public  string gloss { get; set; } = string.Empty;
        public string fundsOrigen { get; set; } = string.Empty;
        public string fundsDestination { get; set; } = string.Empty;
        public string channel { get; set; } = string.Empty;
        public string branchOffice { get; set; } = string.Empty;
        public string agency { get; set; } = string.Empty;
        public string teti { get; set; } = string.Empty;
        public string userReg { get; set; } = string.Empty;
    }
}
