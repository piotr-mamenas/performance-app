DELETE FROM AssetClass;
SET IDENTITY_INSERT AssetClass ON;

INSERT INTO AssetClass (AssetClassId, AssetClassName, AssetClassEnabled, IsDeleted) VALUES (1,'Bond',1,0);
INSERT INTO AssetClass (AssetClassId, AssetClassName, AssetClassEnabled, IsDeleted) VALUES (2,'Equity',1,0);

SET IDENTITY_INSERT AssetClass OFF;
