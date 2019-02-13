using AutoMapper;
using Web.Mapping.Profiles;

namespace Web.Mapping
{
    public static class MappingConfiguration
    {
        public static void InitializeMapper()
        {
            Mapper.Initialize(cfg => cfg.AddProfiles(typeof(AccountProfile),
                typeof(ContactProfile),
                typeof(AssetProfile),
                typeof(PartnerProfile), 
                typeof(PortfolioProfile),
                typeof(CurrencyProfile),
                typeof(TileWidgetProfile)));
        }
    }
}
