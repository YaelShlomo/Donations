using AutoMapper;
using Donations.Entities.Models;
using Donations.Models;

namespace Donations.Extensions.AutoMapperConfig
{
    public class DonationMappingProfile : Profile
    {
        public DonationMappingProfile()
        {
            CreateMap<DonationRequest, Donation>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
