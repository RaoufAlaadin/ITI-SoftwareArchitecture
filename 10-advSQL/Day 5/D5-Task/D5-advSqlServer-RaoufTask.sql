--1. Create a cursor for Employee table that increases Employee
--salary by 10% if Salary <3000 and increases it by 20% if
--Salary >=3000. Use company DB

use SD

go 


Select * from HumanResources.Employee

go
--1- first we declare the main cursor ==> pointer
declare employeeSalaryCursor cursor
--2- we choose our targeted data and add (for) before the seelect statement
for select Salary  from HumanResources.Employee
--3- we decide what we want to do with the data --- Read only || update 
for update

--4- we declare a variable to store the results coming from the cursor fetching data. 
declare @sal int
--5- we open the cursor as in calling it 
open employeeSalaryCursor
--6- we ask the cursor to fetch the data it's currently pointing at, which is the first row
-- fetch also increase the counter to the next row
fetch employeeSalaryCursor into @sal
--7- fetch statues = 0 is going to be the return of the above fetch, so we will enter the while loop
while @@FETCH_STATUS=0
	begin  
		if @sal>=3000
			update HumanResources.Employee    
				set salary=@sal*1.20
-- this part make sure we only updating/deleting the current row only !! 
			where current of employeeSalaryCounter 
		else if @sal<3000
			update HumanResources.Employee
				set salary=@sal*1.10
			where current of employeeSalaryCounter
		else
		/* This part is for the case of finding NULL values I guess.
			We didn't use being and end for the statements as  this is --only one line acutally --
		*/
			delete from HumanResources.Employee
			where current of employeeSalaryCounter
	-- this line is outside the if statements , 
	-- it's purpose is moving us to the next row, without it will be pointing to the same row forever
		fetch employeeSalaryCursor into @sal

	-- when the rows end, the fetch will not return 0, and the while loop will end. 
	end
--8- We will close the pointer after it's job was done.
close employeeSalaryCursor
--9- We will deallocate it from the memory so the space could be used by another process. 
deallocate employeeSalaryCursor


----------------------------------------------------------------------------------------------------
--2. Display Department name with its manager name using
--cursor. Use ITI DB

use ITI


/* We will divide using the cursor into 3 parts 
	a - declaring the cursor and the query we will operate on 
	
	b-  declaring the necessary variables and making our first fetch 
	
	c- while loop and our core logic 
*/

--a
declare deptAndMangerNamesCursor cursor
for 
select Department.Dept_Name,Instructor.Ins_Name as [mangerName]
from Department inner join Instructor
on Department.Dept_Id = Instructor.Dept_Id
-- we will use read-only as we won't update anything, this is from a security prespective.
for read only 

--b
declare @deptName nvarchar(100),@mangerName nvarchar(100)
open deptAndMangerNamesCursor
fetch deptAndMangerNamesCursor into @deptName,@mangerName

--c
while @@FETCH_STATUS=0
	begin
		select @deptName as [deptName] ,@mangerName as [mangerName]
		fetch deptAndMangerNamesCursor into @deptName,@mangerName
	end
close deptAndMangerNamesCursor
deallocate deptAndMangerNamesCursor


------------------------------------------------------------------------------------------------------------------------------
--3. Try to display all students first name in one cell separated
--by comma. Using Cursor


declare studentsFirstNameJoinCursor cursor
for select distinct st_fname from student where st_fname is not null
for read only


declare @name varchar(20),@all_names varchar(300)=''
open studentsFirstNameJoinCursor

/*Important !!!!! 
the declared variables must equal the columns number returend by the fetch and the same order
*/
fetch studentsFirstNameJoinCursor into @name     --counter=0
while @@FETCH_STATUS=0
	begin
		set @all_names=CONCAT(@all_names,',',@name)
		fetch studentsFirstNameJoinCursor into @name   --counter++
	end
select @all_names
close studentsFirstNameJoinCursor
deallocate studentsFirstNameJoinCursor

--------------------------------------------------------------------------------------------------------

--4. Create full, differential Backup for SD DB.

--5. Use import export wizard to display students data (ITI DB)
--in excel sheet



--https://www.youtube.com/watch?v=-Tezsi5oYss&ab_channel=RighttoLearn%40BK




--6. Try to generate script from DB ITI that describes all tables
--and views in this DB



--7. Create a sequence object that allow values from 1 to 10
--without cycling in a specific column and test it.

--https://learn.microsoft.com/en-us/sql/t-sql/statements/create-sequence-transact-sql?view=sql-server-ver16

Create SEQUENCE MySequence
START WITH 1
INCREMENT BY 1
MinValue 1
MaxValue 10
NO CYCLE; --default

create TABLE person1
(ID int,
FullName nvarchar(100) NOT NULL);

create TABLE person2
(ID int,
FullName nvarchar(100) NOT NULL);

INSERT into person1
VALUES (NEXT VALUE FOR MySequence, 'ahmed')

INSERT into person2
VALUES (NEXT VALUE FOR MySequence, 'ahmed1')


select * from person1
select * from person2


/* for the case no cycle, to restart the sequence you have to use alter 
https://learn.microsoft.com/en-us/sql/t-sql/statements/alter-sequence-transact-sql?redirectedfrom=MSDN&view=sql-server-ver16
*/

-- IMPORTANT ==> 
--				This line is important and plays the role of the 'cycle' option when creating the sequence in the first place
ALTER SEQUENCE MySequence
RESTART WITH 1





--using a word document 

--Part2: 

--What is the difference between the following objects in
--SQL Server


--1. batch, script and transaction


--2. trigger and stored procedure


--3. stored procedure and functions


--4. drop, truncate and delete statement


--5. select and select into statement

--6. local and global variables


--7. convert and cast statements

--8. DDL,DML,DCL,DQL and TCL

--9. For xml raw and for xml auto
--10. Table valued and multi statemcent function

--11. Varchar(50) and varchar(max)

--12. Datetime, datetime2(7) and datetimeoffset(7)

--13. Default instance and named instance

--14. SQL and windows Authentication

--15. Clustered and non-clustered index

--16. Group by rollup and group by cube

--17. Sequence object and identity

--18. Inline function and view
--19. Table variable and temporary table

--20. Row_number() and dense_Rank() function