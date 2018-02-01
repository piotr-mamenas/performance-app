DELETE FROM Position;
SET IDENTITY_INSERT Position ON;

INSERT INTO Position(PositionId,PositionAmount,CurrencyId,AssetId,PortfolioId,PositionTimestamp,IsDeleted) VALUES (1,5,5,1,3,'2017-11-15 11:07:02.0000000',0);
INSERT INTO Position(PositionId,PositionAmount,CurrencyId,AssetId,PortfolioId,PositionTimestamp,IsDeleted) VALUES (1,4,5,2,3,'2017-11-16 11:07:02.0000000',0);
INSERT INTO Position(PositionId,PositionAmount,CurrencyId,AssetId,PortfolioId,PositionTimestamp,IsDeleted) VALUES (1,4,5,3,3,'2017-11-17 11:07:02.0000000',0);
INSERT INTO Position(PositionId,PositionAmount,CurrencyId,AssetId,PortfolioId,PositionTimestamp,IsDeleted) VALUES (1,1,5,1,3,'2017-11-15 11:07:02.0000000',0);
INSERT INTO Position(PositionId,PositionAmount,CurrencyId,AssetId,PortfolioId,PositionTimestamp,IsDeleted) VALUES (1,4,5,2,3,'2017-11-16 11:07:02.0000000',0);
INSERT INTO Position(PositionId,PositionAmount,CurrencyId,AssetId,PortfolioId,PositionTimestamp,IsDeleted) VALUES (1,10,5,3,3,'2017-11-17 11:07:02.0000000',0);
INSERT INTO Position(PositionId,PositionAmount,CurrencyId,AssetId,PortfolioId,PositionTimestamp,IsDeleted) VALUES (1,64,5,1,3,'2017-11-15 11:07:02.0000000',0);
INSERT INTO Position(PositionId,PositionAmount,CurrencyId,AssetId,PortfolioId,PositionTimestamp,IsDeleted) VALUES (1,34,5,2,3,'2017-11-16 11:07:02.0000000',0);
INSERT INTO Position(PositionId,PositionAmount,CurrencyId,AssetId,PortfolioId,PositionTimestamp,IsDeleted) VALUES (1,70,5,3,3,'2017-11-17 11:07:02.0000000',0);

SET IDENTITY_INSERT Position OFF;
