if exists (SELECT name From sysobjects WHERE xtype = 'p' and name = 'InsertFile')
drop procedure dbo.InsertFile
GO

Create Procedure dbo.InsertFile
   @knowledgeName varchar(max), 
   @knowledgeTag varchar(max),
   @knowledgeHash bigint,
   @fileType nvarchar(max),
   @knowledgeDataName varchar(max)
As

DECLARE @sql NVARCHAR(max)
set @sql = N'insert into dbo.Knowledge(KnowledgeName,KnowledgeTag,KnowledgeHash,FileType,KnowledgeData)
select '''+@knowledgeName+''','''+@knowledgeTag+''','+convert(varchar(128),@knowledgeHash)+','''+@fileType+''',BulkColumn 
from OPENROWSET(BULK N'''+@knowledgeDataName+''', SINGLE_BLOB) as Document'
print @sql
EXECUTE sp_executesql @sql

GO

