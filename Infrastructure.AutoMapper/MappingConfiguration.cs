using AutoMapper;
using Infrastructure.AutoMapper.Profiles;
using Infrastructure.AutoMapper.Profiles.Converters;

namespace Infrastructure.AutoMapper
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
                typeof(TileWidgetProfile),
                typeof(DateProfiles)));
        }
    }
}
