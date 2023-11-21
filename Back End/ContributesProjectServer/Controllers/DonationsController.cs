
using Donations.Models;
using Donations.BL.Services;
using Donations.Entities.Models;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Donations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationsController : ControllerBase
    {
        private readonly IDonationService _donationService;

        public DonationsController(IDonationService _donationService)
        {
            this._donationService = _donationService;
        }
        // GET: api/<DonationsController>
        [HttpGet]
        public ActionResult<List<Donation>> GetDonations()
        {
            return _donationService.GetDonations();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Donation> GetDonation(int id)
        {
            var donation = _donationService.GetDonation(id);
            if (donation == null)
            {
                return NotFound($"Donation with id = {id} not founded");
            }
            return donation;
        }

        // POST api/<DonationsController>
        [HttpPost]
        public ActionResult<Donation> Post([FromBody] DonationRequest donationRequest)
        {
            if (!ModelState.IsValid)
            {
                var errorMessages = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                return BadRequest(string.Join(" ", errorMessages));
            }
            var donation = new Donation
            {
                Name = donationRequest.EntityName,
                Amount = donationRequest.Amount,
                EntityId = donationRequest.EntityId,
                Destination = donationRequest.Destination,
                Condition = donationRequest.Conditions,
                CurrencyId = donationRequest.CurrencyId,
                ExchangeRate = donationRequest.ExchangeRate
            };
            _donationService.CreateDonation(donation);
            return CreatedAtAction(nameof(GetDonation), new { id = donation.Id }, donation);
        }
        

        // PUT api/<DonationsController>/5
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] DonationRequest donationRequest)
        {
            var existingDonation = _donationService.GetDonation(id);
            if (existingDonation == null)
            {
                return NotFound($"The donation does not founded");
            }
            existingDonation.Name = donationRequest.EntityName;
            existingDonation.Amount = donationRequest.Amount;
            existingDonation.EntityId = donationRequest.EntityId;
            existingDonation.Destination = donationRequest.Destination;
            existingDonation.Condition = donationRequest.Conditions;
            existingDonation.CurrencyId = donationRequest.CurrencyId;
            existingDonation.ExchangeRate = donationRequest.ExchangeRate;

            _donationService.UpdateDonation(existingDonation);
            return NoContent();
        }

        //DELETE api/<DonationsController>/5
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var donation = _donationService.GetDonation(id);
            if (donation == null)
            {
                return NotFound($"Donation with id = {id} not founded");
            }
            _donationService.DeleteDonation(donation.Id);
            return Ok($"Donation with id = {id} deleted");
        }

    }
}
