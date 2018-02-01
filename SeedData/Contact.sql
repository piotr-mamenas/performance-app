DELETE FROM Contact;
SET IDENTITY_INSERT Contact ON;

INSERT INTO Contact (ContactId,ContactName,ContactFirstName,ContactLastName,ContactEmail,ContactPhoneNumber,PartnerId,IsDeleted) VALUES (1,'Gordon Gekko','Gordon','Gekko','gordon.gekko@teldar.com','+0111111111',1,0);
INSERT INTO Contact (ContactId,ContactName,ContactFirstName,ContactLastName,ContactEmail,ContactPhoneNumber,PartnerId,IsDeleted) VALUES (2,'Jordan Belfort','Jordan','Belfort','jordan.belfort@stratton.com','+4133333333',2,0);
INSERT INTO Contact (ContactId,ContactName,ContactFirstName,ContactLastName,ContactEmail,ContactPhoneNumber,PartnerId,IsDeleted) VALUES (3,'Piotr Mamenas','Piotr','Mamenas','piotr.mamenas@gmail.com','+4822222226',2,0);

SET IDENTITY_INSERT Contact OFF;
