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
SET SHOWPLAN_XML off;

select 1 as g
go
select 1 as t

insert into FullQuery(FullQuery)
select 'select * from information_schema.tables'

insert into FullQuery(FullQuery)
select 'select * from information_schema.tables'
go
select * from trace1