DELETE FROM AssetPrice;
SET IDENTITY_INSERT AssetPrice ON;

INSERT INTO AssetPrice (AssetPriceId,AssetId,CurrencyId,Timestamp,Amount,IsDeleted) VALUES (1,2,5,'2017-11-17 11:07:02.0000000',84.29,0);
INSERT INTO AssetPrice (AssetPriceId,AssetId,CurrencyId,Timestamp,Amount,IsDeleted) VALUES (2,1,5,'2017-11-16 12:17:47.0000000',101.34,0);
INSERT INTO AssetPrice (AssetPriceId,AssetId,CurrencyId,Timestamp,Amount,IsDeleted) VALUES (3,1,5,'2017-11-15 10:17:47.0000000',97.34,0);
INSERT INTO AssetPrice (AssetPriceId,AssetId,CurrencyId,Timestamp,Amount,IsDeleted) VALUES (4,2,5,'2017-11-17 12:47:47.0000000',64.01,0);
INSERT INTO AssetPrice (AssetPriceId,AssetId,CurrencyId,Timestamp,Amount,IsDeleted) VALUES (5,2,5,'2017-11-16 12:17:47.0000000',64.34,0);
INSERT INTO AssetPrice (AssetPriceId,AssetId,CurrencyId,Timestamp,Amount,IsDeleted) VALUES (6,2,5,'2017-11-15 10:37:47.0000000',65.89,0);
INSERT INTO AssetPrice (AssetPriceId,AssetId,CurrencyId,Timestamp,Amount,IsDeleted) VALUES (7,3,5,'2017-11-17 12:57:47.0000000',87.12,0);
INSERT INTO AssetPrice (AssetPriceId,AssetId,CurrencyId,Timestamp,Amount,IsDeleted) VALUES (8,3,5,'2017-11-16 13:17:11.0000000',85.92,0);
INSERT INTO AssetPrice (AssetPriceId,AssetId,CurrencyId,Timestamp,Amount,IsDeleted) VALUES (9,3,5,'2017-11-17 11:07:02.0000000',84.29,0);
INSERT INTO AssetPrice (AssetPriceId,AssetId,CurrencyId,Timestamp,Amount,IsDeleted) VALUES (10,3,5,'2017-11-18 11:07:02.0000000',81.29,0);
INSERT INTO AssetPrice (AssetPriceId,AssetId,CurrencyId,Timestamp,Amount,IsDeleted) VALUES (11,3,5,'2017-11-19 11:07:02.0000000',92.16,0);
INSERT INTO AssetPrice (AssetPriceId,AssetId,CurrencyId,Timestamp,Amount,IsDeleted) VALUES (12,3,5,'2017-11-20 11:07:02.0000000',89.57,0);
INSERT INTO AssetPrice (AssetPriceId,AssetId,CurrencyId,Timestamp,Amount,IsDeleted) VALUES (13,3,5,'2017-11-21 11:07:02.0000000',90.47,0);

SET IDENTITY_INSERT AssetPrice OFF;
