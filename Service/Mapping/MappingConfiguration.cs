using AutoMapper;
using Service.Mapping.Profiles;
using Service.Mapping.Profiles.Converters;

namespace Service.Mapping
{
    public static class MappingConfiguration
    {
        public static void InitializeMapper()
        {
            Mapper.Initialize(cfg => cfg.AddProfiles(typeof(AccountProfile),
                typeof(ContactProfile), 
                typeof(CountryProfile), 
                typeof(PartnerProfile), 
                typeof(InstitutionProfile), 
                typeof(CurrencyProfile),
                typeof(AssetProfile),
                typeof(PortfolioProfile),
                typeof(DateProfiles)));
        }
    }
}
