DELETE FROM Asset;
SET IDENTITY_INSERT Asset ON;

INSERT INTO Asset (AssetId, AssetName, AssetIsin, ClassId, IsDeleted, BondIssueDate,BondMaturityDate,BondCouponRate,BondCouponAmount,CurrencyId,BondFaceValue, AssetType) VALUES (1,'Apple','US0378331005',2,0,null,null,null,null,null,null,2);
INSERT INTO Asset (AssetId, AssetName, AssetIsin, ClassId, IsDeleted, BondIssueDate,BondMaturityDate,BondCouponRate,BondCouponAmount,CurrencyId,BondFaceValue, AssetType) VALUES (2,'Accenture','IE00B4BNMY34',2,0,null,null,null,null,null,null,2);
INSERT INTO Asset (AssetId, AssetName, AssetIsin, ClassId, IsDeleted, BondIssueDate,BondMaturityDate,BondCouponRate,BondCouponAmount,CurrencyId,BondFaceValue, AssetType) VALUES (3,'UBS','CH0244767585',2,0,null,null,null,null,null,null,2);
INSERT INTO Asset (AssetId, AssetName, AssetIsin, ClassId, IsDeleted, BondIssueDate,BondMaturityDate,BondCouponRate,BondCouponAmount,CurrencyId,BondFaceValue, AssetType) VALUES (4,'US Standard Bond','US0378331005',1,0,'2017-12-28 15:31:05.8113783','2018-01-05 00:00:00.0000000',0.04,200.00,1,100.00,1);

SET IDENTITY_INSERT Asset OFF;
