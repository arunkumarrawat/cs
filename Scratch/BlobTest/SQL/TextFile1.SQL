Create Database Test;
GO;
Use Test;
if exist (SELECT name From sysobjects WHERE xtype = 'u' and name = 'BlobTest')
drop Table dbo.BlobTest
Go
Create Table BlobTest
(
Id int identity(1,1) primary key,
BlobName nvarchar(128),
BlobTag nvarchar(512),
BlobData varbinary(MAX)
);

INSERT INTO BlobTest(BlobName, BlobData)
SELECT  'First test file',BulkColumn
FROM OPENROWSET(BULK N'C:\workspace\awork\pic\2011-1-5\mock-up-site.png', SINGLE_BLOB) AS Document;

Use Firebird;
Go
if exists (SELECT name From sysobjects WHERE xtype = 'u' and name = 'Knowledge')
drop Table dbo.BlobTest
Go
Create Table Knowledge
(
Id bigint identity(1,1) primary key,
KnowledgeName nvarchar(max),
KnowledgeTag nvarchar(max),
KnowledgeHash bigint,
FileType nvarchar(max),
KnowledgeData varbinary(MAX)
);

if exists (SELECT name From sysobjects WHERE xtype = 'u' and name = 'RevertTag')
drop Table dbo.RevertTag

Create Table RevertTag
(
Id bigint identity(1,1) primary key,
keyword nvarchar(max),
KnowledgeId bigint
);

alter table dbo.RevertTag add constraint FK_Revert_Knowledge foreign key (KnowledgeId) references Knowledge(Id)


