DELETE FROM Account;
SET IDENTITY_INSERT Account ON;

INSERT INTO Account (AccountId, AccountName, AccountNumber, OpenedDate, ClosedDate, PartnerId, StatusId, IsDeleted) VALUES (1,'Private WM Account','CH470217','2018-01-31 14:30:51.2117638',null,1,1,0);
INSERT INTO Account (AccountId, AccountName, AccountNumber, OpenedDate, ClosedDate, PartnerId, StatusId, IsDeleted) VALUES (2,'Private WM Account','GB471717','2018-01-31 14:30:51.2117638',null,1,1,0);
INSERT INTO Account (AccountId, AccountName, AccountNumber, OpenedDate, ClosedDate, PartnerId, StatusId, IsDeleted) VALUES (3,'Institutional Speculation Account','PL470217','2018-01-31 14:30:51.2117638','2018-01-31 17:30:51.2117638',2,2,0);

SET IDENTITY_INSERT Account OFF;
