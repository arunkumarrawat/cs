use Test

if exists (select * from sys.objects where name = 'DataTest' and type = 'U')
    drop table DataTest
GO

CREATE TABLE DataTest
(
    Id int identity(1,1) primary key,
    string nvarchar(128),
)
GO

if exists (select * from sys.objects where name = 'GetDataTest' and type = 'P')
    drop procedure dbo.GetDataTest
GO

CREATE PROCEDURE GetDataTest
AS 
   select Id,string from DataTest;
GO

insert into DataTest(string) values ('test1')
insert into DataTest(string) values ('test2')
insert into DataTest(string) values ('test3')
insert into DataTest(string) values ('test4')

-- site controller-Id block-name downloadType Total version﻿
if exists (select * from sys.objects where name = 'pendingblock' and type = 'U')
    drop table pendingblock
GO
create table pendingblock
(siteId int not null primary key,
 controllerId int not null,
 blockName nvarchar(128) not null,
 downloadType int not null,
 Total int not null,
 version int not null
 )

 if exists (select * from sys.objects where name = 'InsertPendingBlock' and type = 'P')
    drop procedure dbo.InsertPendingBlock
GO
create procedure InsertPendingBlock
  @siteId int,
  @controllerId int,
  @blockName nvarchar(128),
  @downloadType int,
  @total int,
  @version int
AS
  insert into pendingblock(SiteId, ControllerId,BlockName,DownloadType,Total,Version)
  select @siteId,@controllerId,@blockName,@downloadType,@total,@version
GO

--exec dbo.GetDataTest
