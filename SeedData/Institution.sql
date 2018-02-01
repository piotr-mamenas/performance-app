DELETE FROM Institution;
SET IDENTITY_INSERT Institution ON;

INSERT INTO Institution (InstitutionId,InstitutionName,IsDeleted,BankBicCode,InstitutionType) VALUES (1,'Credit Suisse',0,'CRESCHZZ80A',1);
INSERT INTO Institution (InstitutionId,InstitutionName,IsDeleted,BankBicCode,InstitutionType) VALUES (2,'European Union',0,null,null);

SET IDENTITY_INSERT Institution OFF;
