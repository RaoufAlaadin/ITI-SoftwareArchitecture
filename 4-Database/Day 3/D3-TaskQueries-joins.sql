USE Company_SD

--Notes
/*		1- if you an exact string use  city = 'Cairo'  instead of using Like
		2- if u need an exact value... --> go for the (id) instead of the name. 
				like what should happen in example(15)

*/

--1.	Display the Department id, name and id and the name of its manager.

select dname ,dnum,fname + ' ' + lname As Manger_Name
from Employee,Departments
where MGRSSN = SSN

--2.	Display the name of the departments and the name of the projects under its control.


select Departments.Dname, Project.Pname
from Departments,Project
where Departments.Dnum = Project.Dnum

--3.	Display the full data about all the dependence associated with the name of the employee they depend on him/her.


select Employee.Fname, Dependent.*
from Employee,Dependent
where Employee.SSN = Dependent.ESSN

--4.	Display the Id, name and location of the projects in Cairo or Alex city.



select Project.Pname , Project.Pnumber, Project.Plocation , Project.City 
from Project
where Project.City in ('alex','cairo')

--5.	Display the Projects full data of the projects with a name starts with "a" letter.

select Project.* from Project
where Project.Pname like 'a%'

--6.	display all the employees in department 30 whose salary from 1000 to 2000 LE monthly

 
select * from Employee
where salary > 1000 and salary < 2000 and Dno = 30

--7.	Retrieve the names of all employees in department 10 who works more than or equal10 hours per week on "AL Rabwah" project.
		
		-- we combined 3 tables as we needed 
		--			1- project name from project
		--			2- no. of work hours from works_for
		--			3- employee name from employee
		select fname , Works_for.Hours, Works_for.Pno from Employee inner join Works_for
		on Employee.SSN = Works_for.ESSn
		inner join Project
		on Works_for.Pno = Project.Pnumber
		where Employee.Dno = 10 and Works_for.Hours >= 10 and Project.Pname like 'al rabwah'
		
		

		
--8.	Find the names of the employees who directly supervised with Kamel Mohamed.

	-- inself join we just use the alias to create to virtual versions on the same table employee.

	select X.Fname AS Emp_name,  Y.Fname AS Supervised_by
	from Employee X , Employee Y
	where X.Superssn = Y.SSN and Y.fname like 'kamel'

	
--9.	Retrieve the names of all employees and the names of the projects they are working on, sorted by the project name.
		
		-- we had to combine 3 tables again. 

		select Employee.Fname ,Project.Pname from Employee inner join Works_for
		on Employee.SSN = Works_for.ESSn
		inner join Project
		on Works_for.Pno = Project.Pnumber 
		order by Project.Pname
		
		
--10.	For each project located in Cairo City , find the project number,
  -- the controlling department name ,the department manager last name ,address and birthdate.

  select Project.Pnumber , Departments.Dname, Employee.Lname, Employee.Address , Employee.Bdate
  from Project  inner join Departments
  on Project.Dnum = Departments.Dnum
  inner join Employee
  on Departments.MGRSSN = Employee.SSN
  where Project.City like 'cairo'

  
--11.	Display All Data of the managers

	-- right join because what is important is to full fill all the mgrssn in department

	select *    -- Employee.*  to view only the mangers data from the employee table. 
	from Employee right join Departments
	on Employee.SSN = Departments.MGRSSN
	

	--testing   select * from Employee

	--testing  select * from Departments

--12.	Display All Employees data and the data of their dependents even if they have no dependents
		
		-- even if they don't have dependents means to do a full outer join or left join will do the same thing.

		select * 
		from Employee full outer join Dependent
		-- OR you can do this, and it will do the same --- > from Employee left join Dependent
		on Employee.SSN = Dependent.ESSN
	
--13.	Insert your personal data to the employee table as a new employee in department number 30,
		--SSN = 102672, Superssn = 112233, salary=3000.

		 --testing   select * from Employee

		insert into Employee
		values ('Raouf','Alaadin',102672,'1997-09-14 00:00:00.000','alexandria' ,'M',3000,112233,30)


--14.	Insert another employee with personal data your friend as new employee in department number 30,
-- SSN = 102660, but don’t enter any value for salary or supervisor number to him.

		insert into Employee (Fname,Lname,SSN,Bdate,Address,Sex,Dno)
		values ('Tamer','Morsy',102660,'1999-09-14 00:00:00.000','Maiami' ,'M',30)
--15.	Upgrade your salary by 20 % of its last value.

update Employee
set Salary += 0.2*Salary

-- use the ID instead of the name as the name could be repeater
where Employee.Fname = 'Raouf'

-- use where employee.ssn =     for more accuracy in bigger databases.


-- for testing the result 
				select * from Employee

