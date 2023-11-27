using System.ComponentModel.DataAnnotations;

namespace Donations.Models
{
    public class DonationRequest
    {
        const string alphaRegex = @"^[a-zA-Zא-ת ]+$";

        [Required(ErrorMessage = "Name is required.")]
        [RegularExpression(alphaRegex, ErrorMessage = "Name can only contain English or Hebrew characters")]
        public string Name { get; set; } = String.Empty;

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
        public decimal Amount { get; set; }
        public int EntityId { get; set; } 

        [Required(ErrorMessage = "Destination is required.")]
        [RegularExpression(alphaRegex, ErrorMessage = "Destination can only contain English or Hebrew characters")]
        public string Destination { get; set; } = String.Empty;


        [RegularExpression(alphaRegex, ErrorMessage = "Conditions can only contain English or Hebrew characters")]
        public string Condition { get; set; } = String.Empty;

        [Required(ErrorMessage = "Currency Type is required.")]
        public int CurrencyId { get; set; }

        [Required(ErrorMessage = "Exchange rate is required.")]

        public decimal ExchangeRate { get; set; }
    }
    
}
