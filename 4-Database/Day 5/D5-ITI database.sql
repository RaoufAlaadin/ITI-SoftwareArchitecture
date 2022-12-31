
/*	Notes ---->     */



Use ITI



--1.	Retrieve number of students who have a value in their age. 

select count(Student.St_Age) from Student

--2.	Get all instructors Names without repetition

	select distinct Instructor.Ins_Name from Instructor

	
--3.	Display student with the following Format (use isNull function)
		--Student ID	Student Full Name	Department name

		-- note: we need is null because some students have only their first name or last name
		--		and if we combine them for full name we would get a full null. 

		-- isNull is really important when we concatenate names.
		select Student.St_Id , 
		(ISNULL(Student.St_Fname,'') + ''+ ISNULL(Student.St_Lname,'') ) Full_Name,
		ISnull(Department.Dept_Name,'N/a')
		from Student inner join Department
		on Student.Dept_Id = Department.Dept_Id
		
		select * from Department

		select * from Instructor
--4.	Display instructor Name and Department Name

--Note: display all the instructors if they are attached to a department or not
	--> To do that we added Left join

	select Instructor.Ins_Name, Department.Dept_Name 
	from Instructor left join Department
	on Instructor.Dept_Id = Department.Dept_Id



--5.	Display student full name and the name of the course he is taking
		--For only courses which have a grade  
		
		select (ISNULL(Student.St_Fname,'') + ''+ ISNULL(Student.St_Lname,'') ) Full_Name
		, Course.Crs_Name ,Stud_Course.Grade
		from Student inner join Stud_Course
		on Student.St_Id = Stud_Course.St_Id
		inner join Course
		on Course.Crs_Id = Stud_Course.Crs_Id
		where Stud_Course.Grade is not null
		-- note: all courses have grades, so the where statements won't make a difference
		select * from Stud_Course


--6.	Display number of courses for each topic name

		
		

		select count(Course.Crs_Id) , topic.Top_Name
		from Course inner join Topic
		on Course.Top_Id = Topic.Top_Id
		group by Topic.Top_Name

		select * from Course
		select * from Topic

		-- To do the same thing but extra complicated... 

			/*		select A.NumberOfCourses, A.Top_Id,Topic.Top_Name
					from( select count(Course.Crs_Id) As NumberOfCourses, Course.Top_Id
						from Course 
						group by Course.Top_Id) As A
						inner join Topic
						on A.Top_Id = Topic.Top_Id
			*/
		
--7.	Display max and min salary for instructors
	
		select max(Instructor.Salary) AS Max_salary, min(Instructor.Salary)  AS Min_salary
		from Instructor
--8.	Display instructors who have salaries less than the average salary of all instructors.

		select Instructor.* from Instructor
		where Instructor.Salary < (select avg(Instructor.salary) from Instructor)

--9.	Display the Department name that contains the instructor who receives the minimum salary.
	
		select Department.Dept_Name
		from Department,Instructor
		where  Department.Dept_Id = Instructor.Dept_Id and
		Instructor.Salary = (select min(Instructor.Salary) from Instructor)
	
--10.	 Select max two salaries in instructor table. 

	select top(2) * from Instructor
	order by salary desc

--11.	 Select instructor name and his salary 
--but if there is no salary display instructor bonus keyword. “use coalesce Function”

-- coalesce specify a value if the aimed value is NULL
-- Basically it selects the next non NULL value. 

		--instead of converting char to money, 
				--				just convert any number to a char. 

	select Instructor.Ins_Name, coalesce(convert(varchar(20),Instructor.Salary),'No Data')
	from Instructor



select * from Instructor



--12.	Select Average Salary for instructors 

	select avg(Instructor.Salary) As AvgSalary_For_Instructors from Instructor

--13.	Select Student first name and the data of his supervisor 

	select  Student.St_Fname, Instructor.*
	from Student,Instructor
	where Student.St_super = Instructor.Ins_Id

		select * from Student
		select * from Instructor
		select * from Department

--14.	Write a query to select the highest two salaries in Each Department 
--		for instructors who have salaries. “using one of Ranking Functions”


--Select *
--from (Select *, Dense_rank() over(order by st_age desc)as DR
--      from Student) as X
--where DR=1

-- it's ( is not null ) not (not null) .... BIG DIFFERENCE. 

select *
from ( select * , row_number() over( partition by instructor.dept_id order by 
		instructor.salary desc) As RN from Instructor ) As X -- it's a must to this bug chunk an alias
		where RN <= 2 and salary is not null

--15.	 Write a query to select a random  student from each department.  “using one of Ranking Functions”

		select * , newid() AS X
		from ( 
			select * , row_number() over ( partition by Student.Dept_Id order by Student.St_Age) AS RN
			from Student
		) AS Y 
		where RN = 1 and Dept_Id is not null
		order by X


		-- you can also use this if u don't need to show the id number,
		-- newid() will give random values to every row and order by them 
		-- with just how it's wrote once, no more work needs to ben done.  
		select * 
		from ( 
			select * , row_number() over ( partition by Student.Dept_Id order by newid()) AS RN
			from Student
		) AS Y 
		where RN = 1 and Dept_Id is not null
		
		