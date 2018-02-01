DELETE FROM PartnerInstitutions;
SET IDENTITY_INSERT PartnerInstitutions ON;

INSERT INTO PartnerInstitutions(PartnerId,InstitutionId) VALUES (1,1);
INSERT INTO PartnerInstitutions(PartnerId,InstitutionId) VALUES (2,1);

SET IDENTITY_INSERT PartnerInstitutions OFF;
