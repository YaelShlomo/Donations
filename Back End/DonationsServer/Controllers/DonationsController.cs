﻿
using Donations.Models;
using Donations.BL.Services;
using Donations.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Donations.Extensions.AutoMapperConfig;
using AutoMapper;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Donations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationsController : ControllerBase
    {
        private readonly IDonationService _donationService;
        private readonly IMapper _mapper;

        public DonationsController(IDonationService _donationService, IMapper mapper)
        {
            this._donationService = _donationService;
            this._mapper = mapper;
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
           
            var donation = _mapper.Map<Donation>(donationRequest);
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

            _mapper.Map(donationRequest, existingDonation);
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
