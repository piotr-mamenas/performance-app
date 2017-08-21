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
        }

        private static void SeedCountry(IDbSet<BaseCountry> set)
        {
            set.AddOrUpdate(new BaseCountry
            {
                Id = 1,
                Name = "Poland",
                Code = "PL",
                IsEnabled = true
            });

            set.AddOrUpdate(new BaseCountry
            {
                Id = 2,
                Name = "Switzerland",
                Code = "CH",
                IsEnabled = true
            });

            set.AddOrUpdate(new BaseCountry
            {
                Id = 3,
                Name = "Second Poland",
                Code = "GB",
                IsEnabled = true
            });
        }

        private static void SeedContact(IDbSet<BaseContact> set)
        {
            set.AddOrUpdate(new BaseContact
            {
                Id = 1,
                Email = "piotr.mamenas@gmail.com",
                FirstName = "Piotr",
                LastName = "Mamenas",
                Name = "you are part of a machine",
                PartnerId = 1,
                PhoneNumber = "+41 799 799 799"
            });

            set.AddOrUpdate(new BaseContact
            {
                Id = 2,
                Email = "warren.buffet@wb.com",
                FirstName = "Warry",
                LastName = "Buffy",
                Name = "you are not a human being",
                PartnerId = 2,
                PhoneNumber = "Secret"
            });
        }

        private static void SeedPartner(IDbSet<BasePartner> set)
        {
            set.AddOrUpdate(new BasePartner
            {
                Id = 1,
                Name = "OCPD Trading Company",
                Number = "LX249"
            });

            set.AddOrUpdate(new BasePartner
            {
                Id = 2,
                Name = "Buffet Investments",
                Number = "LX249"
            });
        }

        private static void SeedCurrency(IDbSet<BaseCurrency> set)
        {
            set.AddOrUpdate(new BaseCurrency
            {
                Id = 1,
                Code = "CHF",
                IsEnabled = true,
                Name = "Swiss Franc"
            });

            set.AddOrUpdate(new BaseCurrency
            {
                Id = 2,
                Code = "PLN",
                IsEnabled = true,
                Name = "Polish Zloty"
            });

            set.AddOrUpdate(new BaseCurrency
            {
                Id = 3,
                Code = "EUR",
                IsEnabled = true,
                Name = "Euro"
            });
        }

        private static void SeedInstitution(IDbSet<BaseInstitution> set)
        {
            set.AddOrUpdate(new BaseInstitution
            {
                Id = 1,
                Bic = "CRESCHZZ80A",
                Name = "Credit Suisse"
            });

            set.AddOrUpdate(new BaseInstitution
            {
                Id = 2,
                Name = "European Union"
            });
        }
    }
}
