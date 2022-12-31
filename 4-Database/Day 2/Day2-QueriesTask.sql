USE Company_SD


--1- Display all the employees Data 

select * from Employee 

 -- 2- Display the employee First name, last name , salary and department number

 select fname,lname,salary,dno from employee

 -- 3- Display all the proejcts names,locations and the departments which is responsible about it.

 select Pname,Plocation,Dnum from Project

 -- 4- Annual commission specific percent equal 10% of their salary
		-- display full name and his annual commission in annual comm column (alias)

	select fname,lname, (0.1*12*salary) AS AnnualComission
	from Employee

-- 5- Display id, name and who earns more than 1000 l.e monthly

	select ssn, fname+lname as full_Name, salary 
	from employee
	where salary > 1000

-- 6- Display id, name and who earns more than 1000 l.e annualy

	select ssn, fname+' ' +lname as full_Name, salary 
	from employee
	where salary*12 > 10000

-- 7- Display the names and salaries of female employees

	select ssn, fname+' ' +lname as full_Name
	from employee
	where sex = 'F' 

-- 8- display each departmen id, name which manged by a manger with id equal 968574

	select Dnum, Dname
	from Departments
	where MGRSSN = 968574

	 -- testing  select * from Departments

-- 9- display the ids and names and location of project which are controled with dp 10

	select Pname, Pnumber, Plocation , Dnum
	from Project
	where  Dnum = 10 


	




