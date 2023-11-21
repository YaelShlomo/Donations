using Donations.Entities.Models;
using Donations.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AutoMapper;

namespace Donations.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DonationRequest, Donation>();
        }
    }
}

