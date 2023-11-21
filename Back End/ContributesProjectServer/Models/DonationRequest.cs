using System.ComponentModel.DataAnnotations;

namespace Donations.Models
{
    public class DonationRequest
    {
        const string alphaRegex = @"^[a-zA-Zא-ת ]+$";

        [Required(ErrorMessage = "Name is required.")]
        [RegularExpression(alphaRegex, ErrorMessage = "Name can only contain English or Hebrew characters")]
        public string EntityName { get; set; } = String.Empty;

        [Required(ErrorMessage = "Amount is required.")]
        public decimal Amount { get; set; }

        //[Required(ErrorMessage = "Political Entity type is required.")]
        //[RegularExpression(alphaRegex, ErrorMessage = "Political Entity can only contain English or Hebrew characters")]
        public int EntityId { get; set; } 

        [Required(ErrorMessage = "Destination is required.")]
        [RegularExpression(alphaRegex, ErrorMessage = "Destination can only contain English or Hebrew characters")]
        public string Destination { get; set; } = String.Empty;


        [RegularExpression(alphaRegex, ErrorMessage = "Conditions can only contain English or Hebrew characters")]
        public string Conditions { get; set; } = String.Empty;

        [Required(ErrorMessage = "Currency Type is required.")]
        public int CurrencyId { get; set; }

        [Required(ErrorMessage = "Exchange rate is required.")]

        public decimal ExchangeRate { get; set; }
    }
    
}
