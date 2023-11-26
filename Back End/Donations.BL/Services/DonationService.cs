using System.Collections.Generic;
using Donations.DAL.Repositories;
using Donations.Entities.Models;
using Donations.Common.Email.Models;
using Donations.Common.Email.Services;

namespace Donations.BL.Services
{
    public class DonationService : IDonationService
    {
        private readonly IDonationRepository _donationRepository;
        private readonly IEmailService _emailService;

        public DonationService(IDonationRepository donationRepository, IEmailService emailService)
        {
            _donationRepository = donationRepository ?? throw new ArgumentNullException(nameof(donationRepository));
            _emailService = emailService;
        }

        public List<Donation> GetDonations()
        {
            return _donationRepository.GetDonations();
        }

        public Donation GetDonation(int id)
        {
            return _donationRepository.GetDonation(id);
        }
        public void CreateDonation(Donation donation)
        {
            _donationRepository.CreateDonation(donation);
            if (isSendEmail(donation.Amount))
            {
                EmailDto request = new EmailDto("yaelfrank100@gmail.com", "התקבלה תרומה גדולה", "<h1>התקבלה תרומה בסך:</h1>"+"<h1>"+donation.Amount.ToString()+"</h1>");
                _emailService.SendEmail(request);
            }
        }

        public Boolean isSendEmail(Decimal amount)
        {
            if (amount > 10000)
                return true;
            return false;
        }

        public void UpdateDonation(Donation donation)
        {
            _donationRepository.UpdateDonation(donation);
        }

        public void DeleteDonation(int donationId)
        {
            _donationRepository.DeleteDonation(donationId);
        }

        public List<PoliticalEntity> GetPoliticalEntities()
        {
            return _donationRepository.GetPoliticalEntities();
        }

        public List<Currency> GetCurrencies()
        {
            return _donationRepository.GetCurrencies();
        }
    }
}


