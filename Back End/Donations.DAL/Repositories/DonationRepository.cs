using Donations.DAL.Data;
using Donations.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Donations.DAL.Repositories
{
    public class DonationRepository : IDonationRepository
    {
        private readonly DonationDbContext _context;

        public DonationRepository(DonationDbContext context)
        {
            _context = context;
        }

        public void CreateDonation(Donation donation)
        {
            _context.Donations.Add(donation);
            _context.SaveChanges();
        }

        public List<Donation> GetDonations()
        {
            return _context.Donations.ToList();
        }

        public Donation GetDonation(int donationId)
        {
            return _context.Donations.FirstOrDefault(d => d.Id == donationId);
        }
        public void UpdateDonation(Donation updatedDonation)
        {
            var existingDonation = _context.Donations.Find(updatedDonation.Id);

            if (existingDonation != null)
            {
                existingDonation.Name = updatedDonation.Name;
                existingDonation.Amount = updatedDonation.Amount;
                existingDonation.EntityId = updatedDonation.EntityId;
                existingDonation.Destination = updatedDonation.Destination;
                existingDonation.Condition = updatedDonation.Condition;
                existingDonation.CurrencyId = updatedDonation.CurrencyId;
                existingDonation.ExchangeRate = updatedDonation.ExchangeRate;

                _context.SaveChanges();
            }
        }
        public void DeleteDonation(int donationId)
        {
            var donation = _context.Donations.Find(donationId);

            if (donation != null)
            {
                _context.Donations.Remove(donation);
                _context.SaveChanges();
            }
        }

        public List<PoliticalEntity> GetPoliticalEntities()
        {
            return _context.Entities.ToList();
        }
        public List<Currency> GetCurrencies()
        {
            return _context.Currencies.ToList();
        }
    }
}
