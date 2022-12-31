use SD

-- 1- Department Table 


CREATE TABLE Department (
    DeptNo nvarchar(50) Primary key,
    DeptName nvarchar(200),
    Location Loc
);


Create Type Loc    
from nchar(2) ; 

-- We are getting a syntax warrning,
-- because it wants the rule to be the only thing in the query.
Create Rule Loc_Rule 
as @Loc in ('NY','DS','KW');

create default Loc_NY as 'NY'; 

sp_bindrule Loc_Rule,Loc ;

sp_bindefault Loc_NY,Loc; 


INSERT INTO Department (DeptNo, DeptName, Location)
VALUES ('d1', 'Research', 'NY');

INSERT INTO Department (DeptNo, DeptName, Location)
VALUES ('d2', 'Accounting', 'DS');

INSERT INTO Department (DeptNo, DeptName, Location)
VALUES ('d3', 'Marketing', 'KW');


-- 2- Employee Table 


CREATE TABLE Employee  (
    EmpNo int ,
    EmpFname nvarchar(200) not null,
    EmpLname nvarchar(200) not null,
	--DeptNo nvarchar(50) FOREIGN KEY REFERENCES Department(DeptNo),
	DeptNo nvarchar(50),
	Salary int ,


	constraint c1 primary key(EmpNo),
	constraint c2 foreign key(DeptNo) references Company.Department(DeptNo),
	constraint c3 unique (Salary)

);



-- Salary rule and binding it to the column
Create Rule Salary_Rule 
as @Salary < 6000;

sp_bindrule Salary_Rule,'Employee.Salary' ;



INSERT INTO Employee
VALUES ( 25348, 'Mathew', 'Smith','d3',2500);

INSERT INTO HumanResources.Employee
VALUES ( 10102, 'Ann', 'Jones','d3',3000);

INSERT INTO Employee
VALUES ( 18316, 'John', 'Barrimore','d1',2400);

INSERT INTO Employee
VALUES ( 29346, 'James', 'James','d2',2800);

INSERT INTO Employee
VALUES ( 9031, 'Lisa', 'Bertoni','d2',4000);

INSERT INTO Employee
VALUES ( 2581, 'Elisa', 'Hansel','d2',3600);

INSERT INTO Employee
VALUES ( 28559, 'Sybl', 'Moser','d1',2900);



--  3- Table testing/modification 

-- a- testing 

--1-Add new employee with EmpNo =11111 In the works_on table [what will
--happen]

INSERT INTO Works_on(EmpNo)
VALUES ( 11111);

----Cannot insert the value NULL in Project.no and enter date. 


--2-Change the employee number 10102 to 11111 in the works on table [what will
--happen]

update Works_on
set EmpNo = 11111
where EmpNo = 10102 ; 

-- cannot add a emp no in works_on -- that does not exist in employee


--3-Modify the employee number 10102 in the employee table to 22222. [what will
--happen]

update HumanResources.Employee
set EmpNo = 22222
where EmpNo = 10102

-- could not modify it as it's used in works_on



--4-Delete the employee with id 10102

delete from HumanResources.Employee
where EmpNo = 10102

-- conflict 


-- b- modification 

ALTER TABLE Employee
ADD TelephoneNumbers nvarchar(200);

ALTER TABLE Employee
Drop COLUMN TelephoneNumbers ;


-- 4- Schema 

create schema Company;

alter schema Company transfer Department;


create schema HumanResources;

alter schema HumanResources transfer Employee;


-- 5- 3. Write query to display the constraints for the Employee table.

SELECT CONSTRAINT_NAME, CONSTRAINT_TYPE
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
WHERE TABLE_NAME='Employee';

--select * from sys.sysconstraints

--4. Create Synonym for table Employee as Emp and then run the
--following queries and describe the results

--https://learn.microsoft.com/en-us/sql/t-sql/statements/create-synonym-transact-sql?view=sql-server-ver16

CREATE SYNONYM Emp  
FOR HumanResources.Employee; 

Select * from Employee
Select * from HumanResources.Employee
Select * from Emp
Select * from HumanResource.Emp


--5. Increase the budget of the project where the manager number is
--10102 by 10%.

UPDATE Company.Project
SET Budget = Budget*1.1 
WHERE Company.Project.ProjectNo in ( 

select Works_on.ProjectNo from Works_on

-- edit the budget to orginal values.
where Works_on.Job = 'Manger' and Works_on.EmpNo = 10102
)

--6. Change the name of the department for which the employee named
--James works.The new department name is Sales

UPDATE Company.Department
set DeptName = 'Sales'
where Company.Department.DeptNo = ( 

select HumanResources.Employee.DeptNo
from HumanResources.Employee
where HumanResources.Employee.EmpFname = 'James'
)



--.7. Change the enter date for the projects 
--for those employees who
--work in project p1 
--and belong to department ‘Sales’. The new date is
--12.12.2007.

update Works_on
set Enter_Date = '12.12.2007'
where Works_on.EmpNo in (

select Works_on.EmpNo
from Works_on inner join HumanResources.Employee
on Works_on.EmpNo = HumanResources.Employee.EmpNo
inner join Company.Department
on HumanResources.Employee.DeptNo = Company.Department.DeptNo
where DeptName = 'Sales' and Works_on.ProjectNo = 'p1' 
) 

and Works_on.ProjectNo = 'p1'

-- 9031    29346 

--select Works_on.EmpNo,Company.Department.DeptName,Works_on.ProjectNo
--from Works_on inner join HumanResources.Employee
--on Works_on.EmpNo = HumanResources.Employee.EmpNo
--inner join Company.Department
--on HumanResources.Employee.DeptNo = Company.Department.DeptNo
--where DeptName = 'Sales' and Works_on.ProjectNo = 'p1' 



 
--8. Delete the information in the works_on table for all employees who
--work for the department located in KW.


DELETE FROM Works_on
WHERE Works_on.EmpNo in (
select distinct Works_on.EmpNo from Works_on inner join HumanResources.Employee
on Works_on.EmpNo = HumanResources.Employee.EmpNo
inner join Company.Department
on HumanResources.Employee.DeptNo = Company.Department.DeptNo
where Company.Department.Location = 'KW')

-- 3 rows will be affected... with or without the 

--9. Try to Create Login Named(ITIStud) who can access Only student and
--Course tables from ITI DB then allow him to select and insert data into
--tables and deny Delete and update .(Use ITI DB)

/*
	1- we change the server properties --- security -- mixed (accepts both windows and sql server user ) 
	2- go to the main security folder and create  a new login  (ID and pw ) 
	3- restart the server so the new user is registered in sql server 
	4- then go into the requeired database ---security --- users--- create a new user 
	5- go to the securable tab and choose the wanted permissions. 

	*note*
	6- remember to choose the tables you want to apply the properties on 

*/






