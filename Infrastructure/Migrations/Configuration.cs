using System.Data.Entity;
using System.Data.Entity.Migrations;
using Core.Domain.Contact;
using Core.Domain.Country;
using Core.Domain.Currency;
using Core.Domain.Institution;
using Core.Domain.Partner;

namespace Infrastructure.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<PerformanceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PerformanceContext context)
        {
            SeedCountry(context.Countries);
            SeedContact(context.Contacts);
            SeedPartner(context.Partners);
            SeedCurrency(context.Currencies);
            SeedInstitution(context.Institutions);
            context.SaveChanges();
        }

        private static void SeedCountry(IDbSet<BaseCountry> set)
        {
            set.AddOrUpdate(c => c.Id,
                new BaseCountry
                {
                    Id = 1,
                    Name = "Poland",
                    Code = "PL",
                    IsEnabled = true
                },
                new BaseCountry
                {
                    Id = 2,
                    Name = "Switzerland",
                    Code = "CH",
                    IsEnabled = true
                },
                new BaseCountry
                {
                    Id = 3,
                    Name = "United Kingdom",
                    Code = "UK",
                    IsEnabled = true
                },
                new BaseCountry
                {
                    Id = 4,
                    Name = "Germany",
                    Code = "DE",
                    IsEnabled = true
                },
                new BaseCountry
                {
                    Id = 5,
                    Name = "Russia",
                    Code = "RU",
                    IsEnabled = true
                });
        }

        private static void SeedContact(IDbSet<BaseContact> set)
        {
            set.AddOrUpdate(c => c.Id,
                new BaseContact
                {
                    Id = 1,
                    Email = "gordon.gekko@teldar.com",
                    FirstName = "Gordon",
                    LastName = "Gekko",
                    Name = "Gordon Gekko",
                    PartnerId = 1,
                    PhoneNumber = "+41 111 111 111"
                },
                new BaseContact
                {
                    Id = 2,
                    Email = "piotr.mamenas@gmail.com",
                    FirstName = "Piotr",
                    LastName = "Mamenas",
                    Name = "Piotr Mamenas",
                    PartnerId = 1,
                    PhoneNumber = "+41 222 222 222"
                },
                new BaseContact
                {
                    Id = 3,
                    Email = "jordan.belfort@stratton.com",
                    FirstName = "Jordan",
                    LastName = "Belfort",
                    Name = "Jordan Belfort",
                    PartnerId = 2,
                    PhoneNumber = "+41 333 333 333"
                });
        }

        private static void SeedPartner(IDbSet<BasePartner> set)
        {
            set.AddOrUpdate(p => p.Id,
                new BasePartner
                {
                    Id = 1,
                    Name = "OCPD Trading Company",
                    Number = "LX249"
                },
                new BasePartner
                {
                    Id = 2,
                    Name = "Buffet Investments",
                    Number = "LX249"
                });
        }

        private static void SeedCurrency(IDbSet<BaseCurrency> set)
        {
            set.AddOrUpdate(c => c.Id,
                new BaseCurrency
                {
                    Id = 1,
                    Code = "CHF",
                    IsEnabled = true,
                    Name = "Swiss Franc"
                },
                new BaseCurrency
                {
                    Id = 2,
                    Code = "PLN",
                    IsEnabled = true,
                    Name = "Polish Zloty"
                },
                new BaseCurrency
                {
                    Id = 3,
                    Code = "EUR",
                    IsEnabled = true,
                    Name = "Euro"
                });
        }

        private static void SeedInstitution(IDbSet<BaseInstitution> set)
        {
            set.AddOrUpdate(i => i.Id,
                new BaseInstitution
                {
                    Id = 1,
                    Bic = "CRESCHZZ80A",
                    Name = "Credit Suisse"
                },
                new BaseInstitution
                {
                    Id = 2,
                    Name = "European Union"
                });
        }
    }
}
