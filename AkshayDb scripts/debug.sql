--drop table if exists FullQuery
--Create table FullQuery
--(
--Id int primary key identity(1,1),
--FullQuery varchar(max)
--)

--drop table if exists FullQueryXmlPlan
--Create table FullQueryXmlPlan
--(
--Id int primary key identity(1,1),
--FullQueryXmlPlan varchar(max)
--)
--create table XmlPlanTags
--(
--TagName varchar(500) not null unique,
--isIgnorable bit not null
--)
SET STATISTICS XML ON;

drop table if exists #t
select * 
into #t
from information_schema.tables
select * from #t

select 1 as g
go
select 1 as t

insert into FullQuery(FullQuery)
select 'select * from information_schema.tables'

insert into FullQuery(FullQuery)
select 'select * from information_schema.tables'
go
select * from trace1