using Donations.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Donations.DAL.Repositories
{
    public interface IDonationRepository
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
