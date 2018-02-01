DELETE FROM WorkflowStatus;
SET IDENTITY_INSERT WorkflowStatus ON;

INSERT INTO WorkflowStatus(WorkflowStatusId, WorkflowStatusName, WorkflowStatusCaption, WorkflowStatusCode, WorkflowEnabled, IsDeleted) VALUES (1,'Account Opened Status','Open','1000000001',1,0);
INSERT INTO WorkflowStatus(WorkflowStatusId, WorkflowStatusName, WorkflowStatusCaption, WorkflowStatusCode, WorkflowEnabled, IsDeleted) VALUES (2,'Account Closed Status','Closed','1000000002',1,0);
INSERT INTO WorkflowStatus(WorkflowStatusId, WorkflowStatusName, WorkflowStatusCaption, WorkflowStatusCode, WorkflowEnabled, IsDeleted) VALUES (3,'Account Reopened Status','Reopened','1000000003',1,0);

SET IDENTITY_INSERT WorkflowStatus OFF;
