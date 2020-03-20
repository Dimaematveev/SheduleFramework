CREATE procedure [dbo].[SelectTable]
as
begin
/*
-------------------------------------
Процедура делает таблицу из PlanToTwoWeek с условием разбивки на TypeofClasses
-------------------------------------
*/
If OBJECT_ID('tempdb..#tabl1') is not null drop table #tabl1
If OBJECT_ID('tempdb..#Ready') is not null drop table #Ready
create table  #tabl1 (
	[PlanID] [int]  NOT NULL,
	[GroupID] [int] NOT NULL,
	[SubjectID] [int] NOT NULL,
	[Num] [int] NULL,
	TypeofClasses int Not null)

insert into #tabl1
select PlanID,GroupID,SubjectID,NumLab,3 as TypeofClasses
from dbo.PlanToTwoWeek

insert into #tabl1
select PlanID,GroupID,SubjectID,NumLec,1 as TypeofClasses 
from dbo.PlanToTwoWeek

insert into #tabl1
select PlanID,GroupID,SubjectID,NumPract,2 as TypeofClasses 
from dbo.PlanToTwoWeek



create table  #Ready (
	ID int IDENTITY NOT NULL  PRIMARY KEY ,
	[PlanID] [int]  NOT NULL,
	[GroupID] [int] NOT NULL,
	[SubjectID] [int] NOT NULL,
	[Num] [int] NULL,
	TypeofClasses int Not null)

insert into #Ready 
select * 
from #tabl1
where Num>0
Order by PlanID,TypeOfClasses

select * 
from #Ready


If OBJECT_ID('tempdb..#tabl1') is not null drop table #tabl1
If OBJECT_ID('tempdb..#Ready') is not null drop table #Ready
End
