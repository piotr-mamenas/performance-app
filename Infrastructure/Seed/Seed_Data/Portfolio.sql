DELETE FROM Portfolio;
SET IDENTITY_INSERT Portfolio ON;

INSERT INTO Portfolio (PortfolioId,PortfolioNumber,PortfolioName,AccountId,IsDeleted) VALUES (1,'KKY109347470','Benchmark Portfolio',1,0);
INSERT INTO Portfolio (PortfolioId,PortfolioNumber,PortfolioName,AccountId,IsDeleted) VALUES (2,'KKZ971474733','Benchmark Portfolio',2,0);
INSERT INTO Portfolio (PortfolioId,PortfolioNumber,PortfolioName,AccountId,IsDeleted) VALUES (3,'CHZ102040562','Equity Portfolio',3,0);

SET IDENTITY_INSERT Portfolio OFF;
