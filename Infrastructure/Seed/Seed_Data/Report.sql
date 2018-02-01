DELETE FROM Report;
SET IDENTITY_INSERT Report ON;

INSERT INTO Report (ReportId,ReportName,ReportDescription,ReportHash,IsDeleted) VALUES (1,'templateA.pdf','Description of the Report','12390ddxcs32xccds',0);
INSERT INTO Report (ReportId,ReportName,ReportDescription,ReportHash,IsDeleted) VALUES (2,'templateB.pdf','Description of the Report','sdfdsf234dfxDK4xss',0);
INSERT INTO Report (ReportId,ReportName,ReportDescription,ReportHash,IsDeleted) VALUES (3,'templateC.pdf','Description of the Report','SJIJD2ewzxc920dxp',0);

SET IDENTITY_INSERT Report OFF;
