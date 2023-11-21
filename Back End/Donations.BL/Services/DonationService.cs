using System.Collections.Generic;
using Donations.DAL.Repositories;
using Donations.Entities.Models;

namespace Donations.BL.Services
{
    public class DonationService : IDonationService
    {
        private readonly IDonationRepository _donationRepository;

        public DonationService(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository ?? throw new ArgumentNullException(nameof(donationRepository));
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


