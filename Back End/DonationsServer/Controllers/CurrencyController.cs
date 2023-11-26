using Donations.BL.Services;
using Donations.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace Donations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController
    {
        private readonly IDonationService _donationService;

        public CurrencyController(IDonationService _donationService)
        {
            this._donationService = _donationService;
        }

        [HttpGet]
        public ActionResult<List<Currency>> GetCurrencies()
        {
            return _donationService.GetCurrencies();
        }
    }
}
