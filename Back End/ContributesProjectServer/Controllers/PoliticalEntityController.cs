using Donations.BL.Services;
using Donations.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace Donations.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PoliticalEntityController : ControllerBase
    {
        private readonly IDonationService _donationService;

        public PoliticalEntityController(IDonationService _donationService)
        {
            this._donationService = _donationService;
        }

        [HttpGet]
        public ActionResult<List<PoliticalEntity>> GetPoliticalEntities()
        {
            return _donationService.GetPoliticalEntities();
        }
    }
}
