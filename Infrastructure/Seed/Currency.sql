DELETE FROM Currency;
SET IDENTITY_INSERT Currency ON;

INSERT INTO Currency(CurrencyId,CurrencyName,CurrencyCode,CurrencyEnabled,IsDeleted) VALUES (1,'Swiss Franc','CHF',1,0);
INSERT INTO Currency(CurrencyId,CurrencyName,CurrencyCode,CurrencyEnabled,IsDeleted) VALUES (2,'Zloty','PLN',1,0);
INSERT INTO Currency(CurrencyId,CurrencyName,CurrencyCode,CurrencyEnabled,IsDeleted) VALUES (3,'Euro','EUR',1,0);
INSERT INTO Currency(CurrencyId,CurrencyName,CurrencyCode,CurrencyEnabled,IsDeleted) VALUES (4,'Pound','GBP',1,0);
INSERT INTO Currency(CurrencyId,CurrencyName,CurrencyCode,CurrencyEnabled,IsDeleted) VALUES (5,'US Dollar','USD',1,0);

SET IDENTITY_INSERT Currency OFF;
