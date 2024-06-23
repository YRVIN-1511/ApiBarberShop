using System.ComponentModel.DataAnnotations;

namespace WepApplicationBarberShop.Models.DTO.Request
{
    public class CreateClientRequest
    {
        public string trace { get; set; } = string.Empty;
        public string? lastName { get; set; } = string.Empty;
        public string? motherLastName { get; set; } = string.Empty;
        public string? names { get; set; } = string.Empty;
        public string? email { get; set; } = string.Empty;
        public string? cellphone { get; set; } = string.Empty;
    }
    public class FilterClientRequest : CreateClientRequest
    {
        [RegularExpression("NAMES|EMAIL|CELLPHONE|", ErrorMessage = "ERROR FORMATO TIPO DE FILTRO, SOLO  SE ADMINTE NAMES, EMAIL, CELLPHONE")]
        public string typeFilter { get; set; } = string.Empty;
    }
}
