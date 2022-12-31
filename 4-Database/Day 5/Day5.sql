--transact-SQL
select *
from Student
where st_address='alex'

select top(3) *
from Student

select top(1)*
from Student
where st_address='alex'

select top(3) st_fname
from Student

select Max(Salary)
from Instructor

select top(2) salary
from Instructor
order by salary desc

select top(6) with ties *
from Student
order by st_age

select Newid()  --GUID

select *,newid() as X
from Student
order by X

select top(1) *
from Student
order by newid()

--Uniqueidentifier   Newid()  PK
insert into student(id,name)
values(newid(),'ahmed')
-----------------------------
select st_fname+' '+st_lname as fullname
from Student
order by fullname

select st_fname+' '+st_lname as fullname
from Student
where fullname='ahmed hassan'

select st_fname+' '+st_lname as fullname
from Student
where st_fname+' '+st_lname='ahmed hassan'

select *
from(select st_fname+' '+st_lname as fullname
	 from Student) as newtable
where fullname='ahmed hassan'



--execution order
--from
--join
--on
--where
--group by
--having
--select
--order by
--top

--fullpath
ServerName.DBName.SchemaName.ObjectName

select * from Student

select *
from [DESKTOP-NQV7E6M].ITI.dbo.student

select *
from Company_SD.dbo.Project

select dept_name from Department
union all
select dname from Company_SD.dbo.Departments
----------------------------------------------
--select into
--DDL  create table from existing one
select * into table2
from Student

select * into table3
from Student

select * into company_sd.dbo.topic
from topic

select st_id,st_fname into table5
from student
where st_address='alex'

select * into table7
from student
where 1=2   --false condition
----------------------------------
--insert based on select
--DML
delete from tab5

select * from tab5

insert into tab5
select st_id,st_fname from student where st_age>25


Select *
from ( Select *, row_number() over(order by st_age desc)as RN
       from Student) as X
where RN=3

Select *
from (Select *, Dense_rank() over(order by st_age desc)as DR
      from Student) as X
where DR=1  

Select *
from (Select *, Ntile(3) over(order by st_age desc)as G
	  from Student) as X
where G=1

Select *
from ( Select *, row_number() over(Partition by dept_id order by st_age desc)as RN
       from Student) as X
where RN=1

Select *
from (Select *, Dense_rank() over(Partition by dept_id order by st_age desc)as DR
      from Student) as X
where DR=1


Select *
from (Select *, Ntile(2) over(Partition by dept_id order by st_id)as G
      from Student) as X
where G=1
--------------------------------------------
--types of insert
--simple insert
insert into tab5
values(44,'ahmed')

--insert constructor
insert into tab5
values(44,'ahmed'),(99,'ali'),(22,'eman')

--insert based on select
insert into tab5
select st_id,st_fname from Student where st_address='cairo'

--bulk insert
--insert data from file
bulk insert tab5
from 'f:\ITIstuds.txt'
with (fieldterminator=',')
--------------------------------------
--Redgate tools
--SSIS
--Powerquery - PowerView -  PowerPivot

-------------------------------------
--string functions
select upper(st_fname),lower(st_lname)
from student

select len(st_fname),st_fname
from Student

select substring(st_fname,1,3)
from student

select substring(st_fname,3,3)
from student

select substring(st_fname,1,1)
from student









