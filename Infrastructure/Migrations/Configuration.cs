using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Core.Domain.Accounts;
using Core.Domain.Assets;
using Core.Domain.Contacts;
using Core.Domain.Countries;
using Core.Domain.Currencies;
using Core.Domain.Institutions;
using Core.Domain.Partners;

namespace Infrastructure.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            SeedAccount(context.Accounts);
            SeedContact(context.Contacts);
            SeedPartner(context.Partners);
            SeedCurrency(context.Currencies);
            context.SaveChanges();
            SeedCountry(context.Countries);
            SeedInstitution(context.Institutions);
            SeedAsset(context.Assets);
            context.SaveChanges();
        }

        private static void SeedAsset(IDbSet<Asset> set)
        {
            set.AddOrUpdate(a => a.Id,
                new Equity
                {
                    Id = 1,
                    Name = "Apple Stock",
                    Isin = "US0378331005"
                });

            set.AddOrUpdate(a => a.Id,
                new Bond
                {
                    CurrencyId = 1,
                    FaceValue = 100,
                    IssueDate = DateTime.Now,
                    MaturityDate = DateTime.Today,
                    Name = "US Standard Bond",
                    Coupon = new BondCoupon
                    {
                        Amount = 200,
                        Rate = new decimal(0.04)
                    }
                });
        }

        private static void SeedAccount(IDbSet<Account> set)
        {
            set.AddOrUpdate(a => a.Id,
                new Account
                {
                    Id = 1,
                    OpenedDate = DateTime.Now,
                    Name = "Account",
                    Number = "ABC010203"
                });
        }

        private static void SeedCountry(IDbSet<Country> set)
        {
            set.AddOrUpdate(c => c.Id,
                new Country
                {
                    Id = 1,
                    Name = "Poland",
                    Code = "PL",
                    CurrencyId = 2,
                    IsEnabled = true
                },
                new Country
                {
                    Id = 2,
                    Name = "Switzerland",
                    Code = "CH",
                    CurrencyId = 1,
                    IsEnabled = true
                },
                new Country
                {
                    Id = 4,
                    Name = "Germany",
                    Code = "DE",
                    CurrencyId = 3,
                    IsEnabled = true
                });
        }

        private static void SeedContact(IDbSet<Contact> set)
        {
            set.AddOrUpdate(c => c.Id,
                new Contact
                {
                    Id = 1,
                    Email = "gordon.gekko@teldar.com",
                    FirstName = "Gordon",
                    LastName = "Gekko",
                    Name = "Gordon Gekko",
                    PartnerId = 1,
                    PhoneNumber = "+41 111 111 111"
                },
                new Contact
                {
                    Id = 2,
                    Email = "piotr.mamenas@gmail.com",
                    FirstName = "Piotr",
                    LastName = "Mamenas",
                    Name = "Piotr Mamenas",
                    PartnerId = 1,
                    PhoneNumber = "+41 222 222 222"
                },
                new Contact
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

        private static void SeedPartner(IDbSet<Partner> set)
        {
            set.AddOrUpdate(p => p.Id,
                new Partner
                {
                    Id = 1,
                    Name = "OCPD Trading Company",
                    Number = "LX249"
                },
                new Partner
                {
                    Id = 2,
                    Name = "Buffet Investments",
                    Number = "LX249"
                });
        }

        private static void SeedCurrency(IDbSet<Currency> set)
        {
            set.AddOrUpdate(c => c.Id,
                new Currency
                {
                    Id = 1,
                    Code = "CHF",
                    IsEnabled = true,
                    Name = "Swiss Franc"
                },
                new Currency
                {
                    Id = 2,
                    Code = "PLN",
                    IsEnabled = true,
                    Name = "Polish Zloty"
                },
                new Currency
                {
                    Id = 3,
                    Code = "EUR",
                    IsEnabled = true,
                    Name = "Euro"
                });
        }

        private static void SeedInstitution(IDbSet<Institution> set)
        {
            set.AddOrUpdate(i => i.Id,
                new Institution
                {
                    Id = 2,
                    Name = "European Union"
                });

            set.AddOrUpdate(i => i.Id,
                new Bank
                {
                    Id = 1,
                    Bic = "CRESCHZZ80A",
                    Name = "Credit Suisse"
                });


        }
    }
}
