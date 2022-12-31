USE Company_SD

--1.	Display (Using Union Function)

		--a.	 The name and the gender of the dependence that's gender is Female 
				--and depending on Female Employee.

				select Dependent.Dependent_name
				from Dependent
				where Dependent.Sex = 'F'
				union all 
				select Employee.Fname
				from Employee
				where Employee.Sex = 'F'

				-- We have (another option) by using subqueries

				select *  -- could have specified  to show only names here.
							-- (*) is going to refer to all the data we get from the query
							-- which is only the name and sex
				from (
						select Dependent.Dependent_name, Dependent.Sex
						from Dependent
						union all
						select Employee.Fname, Employee.Sex
						from Employee ) A   --we have to give this subquery an alias
											-- to be able to call it inside the Where
				where A.Sex = 'F'
				

		--b.	 And the male dependence that depends on Male Employee.

		select Dependent.Dependent_name , Dependent.Sex
				from Dependent
				where Dependent.Sex = 'M'
				union all 
				select Employee.Fname , Employee.Sex
				from Employee
				where Employee.Sex = 'M'

--2.	For each project, list the project name and the total hours per week (for all employees) 
	--spent on that project.

		select distinct Project.Pnumber,sum(Works_for.Hours) AS total_hours_PerWeek
		from Project,Works_for
		where Project.Pnumber = Works_for.Pno
		group by Project.Pnumber				
		
		--	or use the following:
		--		from Project inner join Works_for
		--		on Project.Pnumber = Works_for.Pno
		
		-- Just always remember,When you join 2 Tables... a Where condition is a MUST !! 
		--				OR ---> use an Inner join like above. 
												
		--select * from Project
		--select * from Works_for
		

--3.	Display the data of the department which has the smallest employee ID over all employees' ID.

		select Departments.* 
		from Departments inner join Employee
		on Departments.Dnum = Employee.Dno
		where Employee.SSN = ( select max(Employee.SSN) from Employee) 

		
		--select * from Employee

--4.	For each department, retrieve the department name and 
		--the maximum, minimum and average salary of its employees.

		select Departments.Dname, 
		max(Employee.Salary) MaxSalary ,  min(Employee.Salary) MinSalary , avg(Employee.Salary) AvgSalary
		from Departments inner join Employee
		on Departments.Dnum = Employee.Dno
		group by Departments.Dname


		--select * from Employee
		


--5.	List the full name of all managers who have no dependents.

		select (Employee.Fname + ' ' + Employee.Lname) As Full_name
		from Employee inner join Departments
		on Employee.SSN = Departments.MGRSSN
		where Employee.SSN not in ( select Dependent.ESSN from Dependent)

		-- this is a tricky one. -- > you need to join employee and departments to get list of mangers
		-- then you need an array of essn in depandent from the subquery
		-- to see who is not there. 

		-- the result will show me manging 2 departments as of kamel left the comapny
		
--6.	For each department-- if its average salary is less than the average salary of all employees--
  -- display its number, name and number of its employees.

		select Departments.Dname, Departments.Dnum,avg(Employee.Salary) As AvgSalaryPerDepartment,
		count(Employee.SSN) As Employee_count

		from Departments, Employee
		where Departments.Dnum = Employee.Dno
		group by Departments.Dname, Departments.Dnum 
		--  the having was looking at the avg salary for each department without me stating it.
		-- Adding it in the select statement helped us visualize what was happening implicitly.
		having avg(salary) < (select avg(Employee.Salary) from Employee)

		select * from Employee


--7.	Retrieve a list of employees names and the projects names they are working on 
			-- ordered by department number and within each department, 
			--ordered alphabetically by last name, first name.

			select (Employee.Fname + ' ' + Employee.Lname) As full_name, Project.Pname ,Employee.Dno
			from Employee inner join Works_for
			on Employee.SSN = Works_for.ESSn
			inner join Project
			on Project.Pnumber = Works_for.Pno
			order by Employee.Dno ,Employee.Lname,Employee.Fname
			
--8.	Try to get the max 2 salaries using subquery
	
			-- a) we get the 1st max from a direct sub query inside the main select
			-- b) for the 2nd max we would need an extra where clause in sql 
			select ( select max(Employee.Salary) from Employee) As maxSalary,
				max(Employee.Salary) As sec_salary
				from Employee
				where Employee.Salary not in ( select max(Employee.Salary) from Employee)

				-- Method 2 

				select top 2 Employee.Salary
				from Employee
				order by salary desc

				-- mysql --> limit 
				-- sql server --> top 

				-- Method 3 
				 -- Eng/mohamed fahmy recommendation. 

				-- use union, where you get the max first
				-- then get the second max by the 'not in' method
				-- basically you do the same as method 1 but using union instead
				-- of that first subquery. 

				

				select * from Employee
--9.	Get the full name of employees that is similar to any dependent name

		select * from Dependent 

		/*Questions	on comparing strings		
							1-	How does intersect compare strings

							2- is there a way to compare two lists to find the closest match?
								"without it being exact" 

								--> still needs answers  ...
								 I think this needs more of an AI to find the needed Like' ' pattern
								 from each row, then comparning it to the opposite list, then changing
								 the pattern agian based on the second row.

							3- How read only the first name from the dependent name to compare it?
							--> this one is answered in lecture 5, 
									using subString(fname,1,3) -- this starts from letter 1 to letter 3
		*/ 

		select (Employee.Fname + ' ' + Employee.Lname) AS full_name
		from Employee
		intersect
		select Dependent.Dependent_name
		from Dependent

		-- Pro tip: you could also create a long pattern with like and adding column names

	select * from Employee
	select * from Dependent
--10.	Display the employee number and name 
--if at least one of them have dependents (use exists keyword) self-study.

	select Employee.SSN , Employee.Fname
	from Employee
	where exists (select Dependent.ESSN from Dependent where Employee.SSN = Dependent.ESSN)

						-- note: the difference between this and using exists
						-- is that exists also add distinct implicitly, so no repated values
	-- adding distinct make them exact. 
	select distinct Employee.SSN , Employee.Fname
	from Employee, Dependent
	where Employee.SSN = Dependent.ESSN

   /* But Why use Exists ? because it's faster if you just want to check if something exist or not
    other methods like the inner join we did here has to join tables then compare.
	if the tables are big... then this is baaaaaaaad....
	
	Also note: the subquery here is corrlated query as it depends on the Employee written outside
				and it cannot run on it's own... it would give an error.
	https://www.youtube.com/watch?v=zfgJ3ZmAgNw&ab_channel=DatabasebyDoug    
	
	*/


 
--11.	In the department table insert new department called "DEPT IT" , 
--with id 100, employee with SSN = 112233 as a manager for this department. 
--The start date for this manager is '1-11-2006'

insert into Departments
values('DEPT IT',100,112233,1-11-2006)


select * from Departments

update Departments
set [MGRStart Date] = '2022-01-06'
where Departments.Dnum = 100



--12.	Do what is required if you know that 
--: Mrs.Noha Mohamed(SSN=968574)  moved to be the manager of the new department (id = 100), 
--and they give you(your SSN =102672) her position (Dept. 20 manager) 

select * from Employee
select * from Departments




--a.	First try to update her record in the department table
				update Departments
				set MGRSSN = 968574
				where Departments.Dnum = 100
--b.	Update your record to be department 20 manager.

			update Departments
			set MGRSSN = 102672
			where Departments.Dnum = 20
--c.	Update the data of employee number=102660 to be in your teamwork 
		-- (he will be supervised by you) (your SSN =102672)
			update Employee
			set Superssn = 102672
			where Employee.SSN = 102660

--13.	Unfortunately the company ended the contract with Mr. Kamel Mohamed (SSN=223344)
--so try to delete his data from your database in case you know that 
--you will be temporarily in his position.

/*Hint: (		Check if Mr. Kamel has dependents,
							works as a department manager,
											supervises any employees 
													or works in any projects and handle these cases).
	*/
			-- 1- changing mgr
			update Departments
			set MGRSSN = 102672
			where Departments.MGRSSN = 223344

			-- 2- changing supervisors

			update Employee
			set Superssn = 102672
			where Employee.Superssn = 223344

			-- 3- dependants removal 

			delete from Dependent
			where Dependent.ESSN = 223344

			--4-  Working on project removal 

			delete from Works_for
			where Works_for.ESSn = 223344

			-- now deleteing the employee row.
			delete from Employee
			where Employee.SSN = 223344

	select * from Employee
	select * from Departments
	select * from Project
	select * from Works_for
	select * from Dependent

--14.	Try to update all salaries of employees who work in Project ‘Al Rabwah’ by 30%

	update Employee
	set Salary += 0.3*Salary
	where Employee.SSN in 
		(select Works_for.ESSn from Works_for,Project 
		where Project.Pname = 'Al Rabwah' and Works_for.Pno = Project.Pnumber)


	select * from Employee
	select * from Works_for
	select * from Project