using Donations.Entities.Models;
using System.Collections.Generic;


namespace Donations.BL.Services
{
    public interface IDonationService
    {
        List<Donation> GetDonations();
        Donation GetDonation(int id);
        void CreateDonation(Donation donation);
        void UpdateDonation(Donation donation);
        void DeleteDonation(int donationId);
        List<PoliticalEntity> GetPoliticalEntities();
        List<Currency> GetCurrencies();

    }
}
