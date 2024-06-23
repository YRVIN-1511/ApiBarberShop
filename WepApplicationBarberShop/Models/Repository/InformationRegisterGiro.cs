namespace WepApplicationBarberShop.Models.Repository
{
    public class InformationRegisterGiro
    {
        public string state { get; set; } = string.Empty;
        public string stateDescription { get; set; } = string.Empty;
        public string referenceGiro { get; set; } = string.Empty;
        public string typeService { get; set; } = string.Empty;
        public string typeAffectation { get; set; } = string.Empty;
        public decimal amount { get; set; } = 0;
        public string currency { get; set; } = string.Empty;
        public decimal amountCtaOrigen { get; set; } = 0;
        public string currencyCtaOrigen { get; set; } = string.Empty;
        public string accountNumber { get; set; } = string.Empty;        
        public decimal exchangeRate { get; set; } = 0;
        public string fundsOrigen { get; set; } = string.Empty;
        public string fundsDestination { get; set; } = string.Empty;
        public string dateTransaction { get; set; } = string.Empty;
        public string hourTransaction { get; set; } = string.Empty;
        public string dateUpdate { get; set; } = string.Empty;
        public string hourUpdate { get; set; } = string.Empty;
        public string gloss { get; set; } = string.Empty;
        public string branchOffice { get; set; } = string.Empty;
        public string agency { get; set; } = string.Empty;
        public string expiredDate { get; set; } = string.Empty;
        public string codeDownload { get; set; } = string.Empty;
        public string teti { get; set; } = string.Empty;
        public List<RegisterOrderingBeneficiary> informationOrderingBeneficiary { get; set; } = new();
    }
}
