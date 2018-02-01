DELETE FROM PortfolioAssets;
SET IDENTITY_INSERT PortfolioAssets ON;

INSERT INTO PortfolioAssets(PortfolioId,AssetId) VALUES (1,4);
INSERT INTO PortfolioAssets(PortfolioId,AssetId) VALUES (2,4);
INSERT INTO PortfolioAssets(PortfolioId,AssetId) VALUES (3,1);
INSERT INTO PortfolioAssets(PortfolioId,AssetId) VALUES (3,2);
INSERT INTO PortfolioAssets(PortfolioId,AssetId) VALUES (3,3);

SET IDENTITY_INSERT PortfolioAssets OFF;
