--select * from ##temptt
--where [value] = 'SELECT INTO' -- 6

select  distinct tagname,[key],[value] from ##temptt
where 1=1
and tagname not in (select tagname from XmlPlanTags where isIgnorable = 1)
and [value] is not NULL
order by 1 ,2 ,3

select id,tagname,[key],[value] from ##temptt
where tagname = 'StmtSimple' and [key] = 'StmtSimple StatementText'
select distinct tagname,[key],[value] from ##temptt
where tagname = 'ColumnReference' --and [key] = ' Schema'
select distinct id,tagname,[key],[value] from ##temptt
where tagname = 'ColumnReference' and [key] = ' StatementType'
select distinct id,tagname,[key],[value] from ##temptt
where tagname = 'Object' 
/*
insert into XmlPlanTags(TagName ,isIgnorable )
select 'SetPredicate',1

*/