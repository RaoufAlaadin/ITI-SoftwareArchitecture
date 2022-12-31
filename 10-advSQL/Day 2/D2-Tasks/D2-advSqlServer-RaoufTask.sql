use ITI

--1. Create a scalar function that takes date and returns Month name of that
--date.
go

		create function getMonthName(@x date) 
		returns nvarchar(30)
			begin
				declare @inputDate nvarchar(30)
				return DATENAME(MONTH, @x)
			end
	
go
		select dbo.getMonthName('2020-10-5')

--2. Create a multi-statements table-valued function that takes 2 integers
--and returns the values between them.


/* difference between inline and multi-line statement performance wise
		https://stackoverflow.com/questions/2554333/multi-statement-table-valued-function-vs-inline-table-valued-function
		https://www.sqlservercentral.com/forums/topic/create-function-with-a-while-loop

		*Important*===> we can only use while loops inside multi

		https://www.sqlservercentral.com/forums/topic/create-function-with-a-while-loop
*/
		--multi
go

		alter function valueBetweenTwoInts(@x int, @y int)
		returns @numberTable table
					( numbers int)
		as

		-- from here we started our logic
		begin
		DECLARE @i int = @x + 1;
		while (@i < @y )
			begin
					INSERT @numberTable VALUES (@i);
					SET @i = @i+1;
			end
				return
		end
go

		--calling
		select * from valueBetweenTwoInts(1,6)

go


--3. Create inline function that takes Student No and returns Department
--Name with Student full name.

select * from Student
select * from Department

go
		alter function getStdInfo(@stdID int)
		returns table
		as
		return (
			-- We must use (as) after CONCAT to define the result
			select CONCAT(St_Fname, ' ',  St_Lname) as full_name ,Dept_Name
			from Student inner join Department
			on Department.Dept_Id = Student.Dept_Id
			where St_Id = @stdID

			)

go


-- calling 

select * from getStdInfo(2)

go

--4. Create a scalar function that takes Student ID and returns a message to
--user
		--a. If first name and Last name are null then display 'First name &
		--last name are null'
		--b. If First name is null then display 'first name is null'
		--c. If Last name is null then display 'last name is null'
		--d. Else display 'First name & last name are not null'

		/* Great summary on If statements
		
		https://www.sqlshack.com/sql-if-statement-introduction-and-overview/ 
		
		*/


		create function previewStdInfo(@stdID int) 
		returns nvarchar(100)
			begin

			/*declare @stdID int = 5

			Declare @stdInfo table(St_Fname nvarchar(100),St_Lname nvarchar(100))  ----> 2D array 
			insert into @stdInfo
			select St_Fname,St_Lname from student where St_Id = @stdID
			select * from @stdInfo

			declare @stdFname nvarchar(100)
			select @stdFname = St_Fname  from @stdInfo

			print @stdFname*/


			--select * from Student -- for testing 


			declare @stdFname nvarchar(100) ,@stdLname nvarchar(100) 
			select @stdFname = ISNULL(St_Fname,'0'), @stdLname = ISNULL(St_Lname,'0') from student where St_Id = @stdID
			--print @stdFname
			--print @stdLname

			-- I used (0) as a string to be able to compare it to the (name)... without needing a conversion

			if (@stdFname = '0' and @stdLname = '0' )
				return 'First name & last name are null'
			else if ( @stdFname = '0')
				return 'first name is null'
			else if ( @stdLname = '0') 
				return 'last name is null'
			
			-- this is the last statement written with else, because else can't have a return statment
				return 'First name & last name are not null'
			
			end

			--Also *NOTE* => we couldn't use (print) inside a function, but we could have used (select) 
			-- we could have also tried the -- (case-when) statements instead of (if)

go

--calling 

select dbo.previewStdInfo(14)  --first null
select dbo.previewStdInfo(13)  --last null
select dbo.previewStdInfo(5)  --nothing null

go
--5. Create inline function that takes integer which represents manager ID
--and displays department name, Manager Name and hiring date


select * from Student
select * from Department
select * from Instructor

select * from Course
select * from Stud_Course
select * from Ins_Course

go
		create function mangerInfo(@mangerID int)
		returns table
		as
		return (
			-- We must use (as) after CONCAT to define the result
			select Dept_Name,Ins_Name as MangerName,Manager_hiredate
			from Department inner join Instructor
			on Department.Dept_Id = Instructor.Dept_Id
			where Ins_Id = @mangerID

			)

go


-- calling 

select * from mangerInfo(4)
select * from mangerInfo(15)

go


--6. Create multi-statements table-valued function that takes a string
		--If string='first name' returns student first name
		--If string='last name' returns student last name
		--If string='full name' returns Full Name from student table
		--Note: Use “ISNULL” function

alter function getStuds(@format varchar(20))
returns @t table
			(
			 name varchar(50)
			)
as
	begin
		if @format='first'
			insert into @t
			select ISNULL(St_Fname,'') from Student
		else if @format='Last'
			insert into @t
			select ISNULL(St_Lname,'') from Student
		else if @format='fullname'
			insert into @t
			select concat(ISNULL(St_Fname,''),' ',ISNULL(St_Lname,'')) from Student
		return
			
	end

--calling
select * from getStuds('fullname')

select * from getStuds('first')

select * from getStuds('Last')



--7. Write a query that returns the Student No and Student first name
--without the last char

select * from Student -- testing
select * from Department -- testing
select * from Stud_Course -- testing

select St_Id, SUBSTRING(St_Fname,1,LEN(St_Fname)-1) as firstNameWithoutTheLastChar 
FROM Student;



--8. Wirte query to delete all grades for the students Located in SD

delete from Stud_Course
from Department D inner join Student S
	on D.Dept_Id = S.Dept_Id inner join Stud_Course C
	on C.St_Id = S.St_Id
	where D.Dept_Name = 'SD'








--DepartmentBonus:
--1. Give an example for hierarchyid Data type
--2. Create a batch that inserts 3000 rows in the student table(ITI database).
--The values of the st_id column should be unique and between 3000 and
--6000. All values of the columns st_fname, st_lname, should be set to 'Jane',
--' Smith' respectively.