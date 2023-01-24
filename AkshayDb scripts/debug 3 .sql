declare @xml xml, @xml_str varchar(max)--ShowPlanXML
select @xml = FullQueryXmlPlan ,@xml_str = FullQueryXmlPlan
from FullQueryXmlPlan where ID = 1
----------------------------
drop table if exists #t1
drop table if exists #t2
drop table if exists #t3
drop table if exists #t4
drop table if exists #t4_temp
drop table if exists #t5
drop table if exists #t6

drop table if exists #ta_1
drop table if exists #ta_2
drop table if exists #ta_3
drop table if exists #ta_4
drop table if exists #ta_5
drop table if exists #ta_6
----------------------------
select 
	Id = identity(int,1,1),
	value + '>' TagFull,
	iif(value like '% %',1,0) HasAtts
into #t1
from string_split(@xml_str,'>')
where isnull(value ,'') != ''
--select* from #t1
-----------------------------
select 
	*,
	case 
		when TagFull  like '</%' or TagFull  like '%/>'
		then 1
		else 0
		end as Closed
into #t2
from #t1
--select* from #t2
---------------------------------------
select * into #t3 from #t2
update #t3
set TagFull = replace(TagFull,'/>','')
update #t3
set TagFull = replace(TagFull,'</','')
update #t3
set TagFull = replace(TagFull,'<','')
update #t3
set TagFull = replace(TagFull,'>','')
--select* from #t3
----------------------------------
select *,cast(null as varchar(max)) Atts,cast(null as varchar(max)) TagName
into #t4
from #t3
update #t4
set Atts = Substring(TagFull,charindex(' ',TagFull)+ 1,len(TagFull))
where HasAtts = 1
update #t4
set Atts = replace(TagFull,'&#xa;',' ')
where HasAtts = 1
update #t4
set TagName 
	= case
		when HasAtts = 1
		then Substring(TagFull,1,charindex(' ',TagFull)-1)
		else TagFull
		end 
--select* from #t4 order by id
----------------------------------
select 
	Id,TagFull,TagName,Atts,HasAtts,Closed,Rno
	,AttsSplit = AttsSplit + iif(AttsSplit  like '%:' ,'',',') 
into #t4_temp
from
(
	select 
		#t4.*,
		AttsSplit = case
					when value like '%='
					then '"' + substring(value,1,len(value)-1)  + '":'
					else '"' + value  + '"'
					end,
		Row_number()over(order by (select 1)) Rno
	from #t4
	outer apply string_split(Atts,'"')
)s
update #t4_temp set AttsSplit = '"Test" : ' + '""' where AttsSplit= '"",'
--select '#t4_temp',AttsSplit from #t4_temp
select
	*,
	Attsjson = '{'+ (select 
							 '' + AttsSplit
						from #t4_temp 
						where Id = #t4.Id order by Rno for xml path(''))+'}'
into #t5
from #t4
update #t5 set Attsjson = replace(Attsjson,': """Test" : ""','')
--select '#t5',* from #t5
if exists(select '#t5_jsonErr',* from #t5 where HasAtts = 1 and ISJSON(Attsjson) <> 1)
	select '#t5_jsonErr',* from #t5 where HasAtts = 1 and ISJSON(Attsjson) <> 1
--------------------------------------
select t.Id
	,Rno = ROW_NUMBER()over(order by (select 1))
	,j.*
into #ta_1
from #t5 t
cross apply(select * from openjson(AttsJson))j
where HasAtts = 1 and j.[key] <>'Test'
--select '#ta_1',* from #ta_1
--------------------------------------
drop table if exists ##temptt
select  #t4.*,#ta_1.Rno,#ta_1.[key],#ta_1.[value]
into ##temptt
from #t4 left join #ta_1 on #t4.Id = #ta_1.Id
where 1=1
order by #t4.Id,#ta_1.rno
select * from ##temptt














/*declare @xml xml--ShowPlanXML
select @xml = FullQueryXmlPlan from FullQueryXmlPlan where ID = 4
SELECT T.c.query('..') AS result  
FROM   @xml.nodes('/xml') T(c)  

select @xml = replace(cast(replace(cast(@xml as varchar(max)),'</xml>','') as varchar(max)),'<xml>','')

select @xml

--SELECT T.c.query('.') AS result  
--FROM   @xml.nodes('xml/ShowPlanXML/.') T(c)  
SELECT T.c.query('.') AS result  
FROM   @xml.nodes('declare namespace MI="http://schemas.microsoft.com/sqlserver/2004/07/showplan";  
/MI:ShowPlanXML') T(c)  
*/