using AutoMapper;
using Infrastructure.AutoMapper.Profiles;

namespace Infrastructure.AutoMapper
{
    public static class MappingConfiguration
    {
        public static void InitializeMapper()
        {
            Mapper.Initialize(cfg => cfg.AddProfiles(typeof(ContactProfile), 
                typeof(CountryProfile), 
                typeof(PartnerProfile), 
                typeof(InstitutionProfile), 
                typeof(CurrencyProfile)));
        }
    }
}
