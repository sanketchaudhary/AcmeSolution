using model = Acme.Data.Models;
using AutoMapper;
using dto = Acme.Business.Dtos.Address;
using Acme.Business.Dtos.Investor;

namespace Acme.Api.Utility
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // Mapping for Country
            CreateMap<model.Country, dto.CountryDto>();

            // Mapping for Postcode
            CreateMap<model.Postcodes, dto.PostcodesDto>();

            // Mapping for Investor
            CreateMap<InvestorDtoForCreate, model.InvestorDetails>();
        }
    }
}
