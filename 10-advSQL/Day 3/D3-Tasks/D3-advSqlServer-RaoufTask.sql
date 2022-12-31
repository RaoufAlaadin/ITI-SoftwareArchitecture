use ITI


--1. Create a view that displays student full name, course name if the
--student has a grade more than 50.

go

select * from Student
select * from Stud_Course
select * from Course

go

alter view stdWithGradesOver50(fullName,courseName)
as
	select CONCAT(St_Fname,' ',St_Lname) as Fullname,Course.Crs_Name
	from Student inner join Stud_Course
	on Student.St_Id = Stud_Course.St_Id
	inner join Course
	on Stud_Course.Crs_Id = Course.Crs_Id
	where Stud_Course.Grade > 50
	

go
-- this line will show us the code that created the view. 
Sp_helptext 'stdWithGradesOver50'

-- calling 
select * from stdWithGradesOver50

--2. Create an Encrypted view that displays manager names and the topics
--they teach.

go

alter view mangerAndCourseTopics(fullName,courseName)
with encryption
as
	select Instructor.Ins_Name,Course.Crs_Name
	from Instructor inner join Ins_Course
	on Instructor.Ins_Id =Ins_Course.Ins_Id
	inner join Course
	on Course.Crs_Id = Ins_Course.Crs_Id
	

go

-- This line will tell you that the view's code is encrypted
Sp_helptext 'mangerAndCourseTopics'

-- calling 
select * from mangerAndCourseTopics

--3. Create a view that will display Instructor Name, Department Name for
--the ‘SD’ or ‘Java’ Department

select * from Instructor
select * from Department

go
create view SDandJavaInfo(InstructorName,DepartmentName)

as
	select Instructor.Ins_Name,Department.Dept_Name
	from Instructor inner join Department
	on Instructor.Dept_Id = Department.Dept_Id
	where Department.Dept_Name in ('java','SD')

go
-- calling 
select * from SDandJavaInfo


--4. Create a view “V1” that displays student data for student who lives in
--Alex or Cairo.
--Note: Prevent the users to run the following query
--Update V1 set st_address=’tanta’
--Where st_address=’alex’;

select * from student

create view V1
as
	select  *
   from Student
   where St_Address in ('Alex', 'Cairo')
   with check option
   -- just writing (with Check option) will prevent insert and update on the view


 select * from V1 

 -- checking the constrain 
 -- ( will give an error as I have a check option in the view, that prevents insert and update) 
Update V1 
set St_Address='tanta'
Where St_Address='alex'


----------------------------------------------------------------------------------
use SD

--5. Create a view that will display the project name and the number of
--employees work on it. “Use SD database”

create view employeeCountPerProject
as
	select Company.Project.ProjectName, count(Works_on.EmpNo) as numberOfEmployee
	from Company.Project inner join Works_on
	on Company.Project.ProjectNo = Works_on.ProjectNo
	group by company.Project.ProjectName

--calling 

select * from employeeCountPerProject


--6. Create index on column (Hiredate) that allow u to cluster the data in
--table Department. What will happen?

use ITI
select * from Department

create clustered index hireDateIndex
on Department(Manager_hiredate)

--Results: 
-- Cannot create more than one clustered index on table 'Department'. Drop the existing clustered index 'PK_Department' before creating another.

/* The primary key of the table is a clustered index by default
and you are only allowed (one clustered key per Table) */ 


--7. Create index that allow u to enter unique ages in student table. What will
--happen?

select * from Student


create unique index i4   ---->unique constraint + nonclustered index
on Student(St_Age)

--Results: 
--The CREATE UNIQUE INDEX statement terminated because a duplicate key was found for the object name 'dbo.Student' a
--nd the index name 'i4'. The duplicate key value is (21).

/* We already have duplicates so we can't create a*/


--8. Using Merge statement between the following two tables [User ID,
--Transaction Amount]

/*	last transaction-- static 
	while dailyTransaction is dynamic 
	so.... daily => source
			last => target 
		we merge into last
	*/

create table dailyTransactions (
			userID int,
			transactionAmount int 
			)

create table lastTransactions (
			userID int,
			transactionAmount int 
			)

insert into dailyTransactions
values (1,1000),
		(2,2000),
		(3,1000)

insert into lastTransactions
values (1,4000),
		(4,2000),
		(2,10000)


MERGE INTO lastTransactions AS l    -- Target -- We always merge to target (master branch)
 USING dailyTransactions AS d         -- Source
 ON d.userID = l.userID -- a column that exists in both tables 


 WHEN MATCHED THEN                        -- On match update
 UPDATE SET l.userID =d.userID,
      l.transactionAmount = d.transactionAmount
      

-- We insert the data of the branch to the master. 
 WHEN NOT MATCHED THEN                    -- Add missing
 INSERT (userID,transactionAmount)
 VALUES (d.userID,d.transactionAmount);



 -- lastTransactions now have everything updated. 
 select * from lastTransactions
 order by userID

 select * from dailyTransactions

 /*		row 1 --- updated to 1000
		row 2 ---  updated to 2000
		row 3 ---- inserted as it doesn't exsit in lastTranscation -- 1000
		row 4 ----  stays the same --2000
		
*/







--Part2: use SD_DB
go
use SD
--1) Create view named “v_clerk” that will display employee#,project#, the date of hiring of
--all the jobs of the type 'Clerk'.

go
create view v_clerk
as
	select Works_on.EmpNo,Works_on.ProjectNo,Works_on.Enter_Date
	from Works_on
	where Job = 'Clerk'

	

go

--calling 
select * from v_clerk

--2) Create view named “v_without_budget” that will display all the projects data
--without budget

alter view v_without_budget
as

select ProjectNo,ProjectName
from Company.Project 

--calling 
select * from v_without_budget


--3) Create view named “v_count “ that will display the project name and the # of jobs in it

create view v_count 
as 
	select Company.Project.ProjectName, count(Works_on.Job) as #ofJobs
	from Works_on inner join Company.Project 
	on Works_on.ProjectNo = Company.Project.ProjectNo
	group by Company.Project.ProjectName

--calling 
select * from v_count


--4) Create view named ” v_project_p2” that will display the emp# for the project# ‘p2’
--use the previously created view “v_clerk”



create view v_project_p2 
as
	select EmpNo from v_clerk
	where ProjectNo = 'p2'

select * from v_project_p2

--5) modifey the view named “v_without_budget” to display all DATA in project p1 and p2

alter view v_without_budget
as
select *
from Company.Project 
where Company.Project.ProjectNo in ('p1','p2')

-- calling

select * from v_without_budget

--6) Delete the views “v_ clerk” and “v_count”

drop view v_clerk
drop view v_count

-- testing to check if they got deleted successfully or not
select * from v_clerk
select * from v_count
--7) Create view that will display the emp# and emp lastname who works on dept# is ‘d2’

go
create view emp_d2
as 
	select HumanResources.Employee.EmpNo, HumanResources.Employee.EmpLname
	from HumanResources.Employee 
	where HumanResources.Employee.DeptNo = 'd2'
go

--calling 

select * from emp_d2

--8) Display the employee lastname that contains letter “J”
--Use the previous view created in Q#7


select * from emp_d2
where EmpLname like  '%J%'

-- writing it like '%J' will search for it in the start-middle-end... so basically everywhere


--9) Create view named “v_dept” that will display the department# and department name.

create view v_dept
as

	select Company.Department.DeptNo,Company.Department.DeptName
	from Company.Department


--calling 

select * from v_dept

--10) using the previous view try enter new department data where dept# is ’d4’ and dept name
--is ‘Development’

INSERT INTO v_dept
VALUES ('d4','Development')

--checking to see the new row
select * from v_dept

--11) Create view name “v_2006_check” that will display employee#, the project #where he
--works and the date of joining the project which must be from the first of January and the
--last of December 2006

create view v_2006_check
as 

	select Works_on.EmpNo,Works_on.ProjectNo,Works_on.Enter_Date
	from Works_on
	where Enter_Date between '2006/1/1' and '2006/12/31'

select * from v_2006_check