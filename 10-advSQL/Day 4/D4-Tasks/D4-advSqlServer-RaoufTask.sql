use ITI 

--1. Create a stored procedure without parameters to show the number of
--students per department name.[use ITI DB]

go

select * from Student
select * from Department

go

create Procedure noOfStudentsPerDepartmentName
as
select Department.Dept_Name, count(Student.St_Id)as [no-of-students]
from Student inner join Department
on Student.Dept_Id = Department.Dept_Id
group by Department.Dept_Name


go

-- call -- storedProcedure with no input needed 

noOfstudentsPerDepartmentName

--------------------------------------------------------------------------------

--2. Create a stored procedure that 
--will check for the # of employees in the project p1 
--if they are more than 3 print message to the user “'The number of employees in the project p1 is 3 or more'” 
--if they are less display a message to the user “'The following employees work for the project p1'” in
--addition to the first name and last name of each one. [Company DB]

use SD

select count(Works_on.EmpNo)

select EmpFname,EmpLname, works_on.ProjectNo from HumanResources.Employee
inner join Works_on
on HumanResources.Employee.EmpNo = Works_on.EmpNo
where Works_on.ProjectNo = 'p1' 


alter Proc empPerProjectCheck
as
	if ((select count(Works_on.EmpNo) from Works_on where Works_on.ProjectNo = 'p1') >= 3)
		begin
		select 'The number of employees in the project p1 is 3 or more'  
		end
	else
		begin
		select 'The following employees work for the project p1'
		select EmpFname,EmpLname, works_on.ProjectNo from HumanResources.Employee
		inner join Works_on
		on HumanResources.Employee.EmpNo = Works_on.EmpNo
		where Works_on.ProjectNo = 'p1'
		end
--calling

empPerProjectCheck
------------------------------------------------------------------------------------------------
--3. Create a stored procedure that will be used in case there is an old
--employee has left the project and a new one become instead of him. 
--The procedure should take 3 parameters (old Emp. number, new Emp. number and the project number) 
--and it will be used to update works_on table.
--[Company DB]

go
create proc updateEmployeeList  @oldEmpNo int,@newEmpNo int , @projectNo nvarchar(50)
as
	/*  We will have to insert the data of the new employee,
		so We do not get a  conflict when updating the works_on table. 
		
		insert into HumanResources.Employee
		values(5111,'tamer','ahmed','d2',5000)
	*/
	update Works_on
	set EmpNo = @newEmpNo, ProjectNo = @projectNo
	where EmpNo = @oldEmpNo

go


-- this call will not work until I insert the new Employee data. 
updateEmployeeList 29346,5111,p3


--4. add column budget in project table and insert any draft values in it then
	--then Create an Audit table with the following structure
	--ProjectNo UserName ModifiedDate Budget_Old Budget_New
	--p2 Dbo 2008-01-31 95000 200000
	--This table will be used to audit the update trials on the Budget column in the (Project table, Company DB)
--Example:
		--If a user updated the budget column then the project number, user name
		--that made that update, the date of the modification and the value of the
		--old and the new budget will be inserted into the Audit table


		--Note: This process will take place only if the user updated the budget
		--column


		create table audit
(
ProjectNo nvarchar(20),
UserName nvarchar(80),
ModifiedDate date,
Budget_Old int,
Budget_New int
)

insert into audit
values ('p2', 'Dbo', '2008-01-31', 95000, 200000)

select * from audit


create trigger BudgetEditTracker
on Company.Project
after update
as
	if update(Budget)
		begin
			declare @old_Budget int,@new_Budget int,@old_ProjectNo nvarchar(50)

			select @old_Budget=Budget from deleted
			select @old_ProjectNo=ProjectNo from deleted
			select @new_Budget=Budget from inserted
			
			insert into audit
			values (@old_ProjectNo, suser_name(), getdate(), @old_Budget, @new_Budget)

		end


-- This update will give 
update Company.Project
set Budget = 5000
where Company.Project.ProjectNo = 'p2'

-- edit it back 
update Company.Project
set Budget = 95000
where Company.Project.ProjectNo = 'p2'


select * from audit



--5. Create a trigger to prevent anyone from inserting a new record in the
--Department table [ITI DB]
--“Print a message for user to tell him that he can’t insert a new record in
--that table”



use ITI

select * from Department



alter trigger preventInsertInDepartment
on Department
instead of insert
as
	select ' You can’t insert a new record in the Department table'



-- testing
insert into Department(Dept_Id)
values (80)


---------------------------------------------------------------------------------------------------------------------
--6. Create a trigger that prevents the insertion Process for Employee table in March [Company DB].

use SD

/* IMPORTANT NOTE !!!! ==> 

if your table has a different schema than dbo, you must include that in your trigger name !!!!

and if you want to alter the trigger and you have changed to a new schema, you have to change the schema of the trigger name again.

as the trigger inherits the schema of it's table automatically !!! 

*/

alter trigger HumanResources.preventInsertInMarch
on HumanResources.Employee
instead of insert
as
	if DATENAME(month, GETDATE())= 'March'
		begin
			select 'not allowed to Insert inMarch'
		end
	else
		begin
		insert into HumanResources.Employee
		select * from inserted -- this will take the data that should have beent inserted
		end


/* IMPORTANT NOTE !!!! ==> 

if your table has a different schema than dbo, you must include that in your trigger name !!!!

and if you want to alter the trigger and you have changed to a new schema, you have to change the schema of the trigger name again.

as the trigger inherits the schema of it's table automatically !!! 

*/


insert into HumanResources.Employee
		values(5111,'tamer','ahmed','d2',5000)

select * from HumanResources.Employee

delete from HumanResources.Employee
where EmpNo = 5111



/* Two methods could have been used ====> 1- instead of insert 
											2-after insert

											create trigger t300
on student
after insert
as
	if format(getdate(),'dddd')='friday'
		begin
			select 'not allowed'
		delete from student where st_id =(select st_id from inserted)
		end


create trigger t300
on student
instead of insert
as
	if format(getdate(),'dddd')='friday'
		begin
			select 'not allowed'
		end
	else
		insert into Student
		select * from inserted
											
*/


go


--7. Create a trigger on student table after insert to add Row in Student Audit
--table (Server User Name , Date, Note) where note will be 
--“[username] Insert New Row with Key=[Key Value] in table [table name]”



		create table auditStudent
(

UserName nvarchar(80),
ModifiedDate date,
Note nvarchar(250)

)

insert into auditStudent
values ('testUser', '2008-01-31','row was inserted in Student Table')

select * from auditStudent

select * from Student

use ITI

alter trigger studentInsertTracker
on Student
after insert
as
			declare @new_StudentID int

			select @new_StudentID=St_Id from inserted
			
			insert into auditStudent
			values (suser_name(), getdate(), CONCAT(suser_name(),' --- Insert New Row with Key =', @new_StudentID,'--- in table Student'))

	

insert into Student(St_Id)
values(20)

delete from Student
where St_Id = 20


select * from auditStudent



--8. Create a trigger on student table instead of delete to add Row in Student
--Audit table (Server User Name, Date, Note) where note will be“ try to
--delete Row with Key=[Key Value]”

alter trigger studentDeleteTracker
on Student
instead of delete
as
			declare @new_StudentID int

			select @new_StudentID=St_Id from deleted
			
			insert into auditStudent
			values (suser_name(), getdate(), CONCAT('try to delete Row with Key =', @new_StudentID))

delete from Student
where St_Id = 20

select * from auditStudent

select * from student

--9. Display all the data from the Employee table (HumanResources Schema)
		--As an XML document “Use XML Raw”. “Use Adventure works DB”
		--A) Elements
		--B) Attributes -- this means it appears beside the tag like in-line attributes in html
		--  the default display option is attribute


		-- *IMPORTANT* ===>  to diplay a mix of both elements and attributes... we would have to use other words than 'raw'
		

use AdventureWorks2012

-- AS Elements 
select * from HumanResources.Employee
for xml raw('Employee'),ELEMENTS xsinil,ROOT('AdventrureWorks_Employee')

-- AS attributes
select * from HumanResources.Employee
for xml raw('Employee')

--10. Display Each Department Name with its instructors. “Use ITI DB”
		--A) Use XML Auto
		--B) Use XML Path

use ITI

--A) Use XML Auto

go
select * from instructor
select * from department

select Department.Dept_Name,Instructor.Ins_Name
from Instructor,Department
where Instructor.Dept_Id = Department.Dept_Id
for xml auto,elements,ROOT('InstructorsInfo')

--B) Use XML Path

select Department.Dept_Name '@DeptName' ,
		Instructor.Ins_Name 'InsName'
from Instructor,Department
where Instructor.Dept_Id = Department.Dept_Id
for xml path('Department'),elements,ROOT('DeptInfo')






--11. Use the following variable to create a new table “customers” inside the company DB.
		--Use OpenXML

use SD

	declare @docs xml ='<customers>
              <customer FirstName="Bob" Zipcode="91126">
                     <order ID="12221">Laptop</order>
              </customer>
              <customer FirstName="Judy" Zipcode="23235">
                     <order ID="12221">Workstation</order>
              </customer>
              <customer FirstName="Howard" Zipcode="20009">
                     <order ID="3331122">Laptop</order>
              </customer>
              <customer FirstName="Mary" Zipcode="12345">
                     <order ID="555555">Server</order>
              </customer>
       </customers>'

declare @hdocs int
Exec sp_xml_preparedocument @hdocs output, @docs

SELECT * into  xmlCustomers
	FROM OPENXML (@hdocs, '//customer')  --levels  XPATH Code
	WITH (
		FirstName varchar(20) '@FirstName',
		Zipcode varchar(20) '@Zipcode',
		orderID int 'order/@ID',
		product varchar(20) 'order'
	)

Exec sp_xml_removedocument @hdocs

select * from xmlCustomers


