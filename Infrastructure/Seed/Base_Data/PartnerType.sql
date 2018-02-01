DELETE FROM PartnerType;
SET IDENTITY_INSERT PartnerType ON;

INSERT INTO PartnerType (PartnerTypeId,PartnerTypeName,IsDeleted) VALUES (1,'Private Client',0);

SET IDENTITY_INSERT PartnerType OFF;
