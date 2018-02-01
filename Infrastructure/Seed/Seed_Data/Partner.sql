DELETE FROM Partner;
SET IDENTITY_INSERT Partner ON;

INSERT INTO Partner(PartnerId,PartnerName,PartnerNumber,PartnerTypeId,IsDeleted) VALUES (1,'Inselbegabung & Co','PL1249',1,0);
INSERT INTO Partner(PartnerId,PartnerName,PartnerNumber,PartnerTypeId,IsDeleted) VALUES (2,'Dr. Wyler & Co','US3450',1,0);

SET IDENTITY_INSERT Partner OFF;
