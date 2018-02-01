DELETE FROM Country;
SET IDENTITY_INSERT Country ON;

INSERT INTO Country (CountryId,CountryName,CountryCode,CurrencyId,CountryEnabled,IsDeleted) VALUES (1,'Poland','PL',2,1,0);
INSERT INTO Country (CountryId,CountryName,CountryCode,CurrencyId,CountryEnabled,IsDeleted) VALUES (2,'Switzerland','CH',1,1,0);
INSERT INTO Country (CountryId,CountryName,CountryCode,CurrencyId,CountryEnabled,IsDeleted) VALUES (3,'Germany','DE',3,1,0);
INSERT INTO Country (CountryId,CountryName,CountryCode,CurrencyId,CountryEnabled,IsDeleted) VALUES (4,'Great Britain','GB',4,1,0);
INSERT INTO Country (CountryId,CountryName,CountryCode,CurrencyId,CountryEnabled,IsDeleted) VALUES (5,'United States','US',5,1,0);

SET IDENTITY_INSERT Country OFF;
