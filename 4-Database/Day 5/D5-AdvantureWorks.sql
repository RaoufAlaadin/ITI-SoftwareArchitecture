

/*	Notes ---->    1- the full path was 
						ServerName.DBName.SchemaName.ObjectName
					our tables are objects... if we are using the default schema (dbo)
					(or class you could say) we don't write to mention the schema and just write  
					the table(object name)
https://www.sqlteam.com/articles/understanding-the-difference-between-owners-and-schemas-in-sql-server
			here we have different schemas, to Acces an object it's like OOP 
				ClassName.Object or( schemaName.Object) ==> Ex. Sales.SalesTaxRate

					Why Schemas? They are used to logically group your Tables. */


Use AdventureWorks2012


--1.	Display the SalesOrderID, ShipDate of the SalesOrderHeader table (Sales schema) 
--to show SalesOrders that occurred within the period ‘7/28/2002’ and ‘7/29/2014’


	select SalesOrderID,ShipDate from Sales.SalesOrderHeader
	where ShipDate between '7/28/2002' and '7/29/2014'

--2.	Display only Products(Production schema) with a StandardCost 
		--below $110.00 (show ProductID, Name only)

		select Production.Product.ProductID, Production.Product.Name
		from  Production.Product
		where Production.Product.StandardCost < 110

--3.	Display ProductID, Name if its weight is unknown

	select Production.Product.ProductID, Production.Product.Name
		from  Production.Product
		where Production.Product.Weight is null

--4.	 Display all Products with a Silver, Black, or Red Color

		select *
		from  Production.Product
		where Production.Product.Color in ('silver','Black','Red')

--5.	 Display any Product with a Name starting with the letter B

		select *
		from  Production.Product
		where Production.Product.Name like 'b%'


--6.	Run the following Query
--Then write a query that displays any Product description with underscore value in its description.

			UPDATE Production.ProductDescription
			SET Description = 'Chromoly steel_High of defects'
			WHERE ProductDescriptionID = 3

			/* I had to put _ between [] for it to mean underscore. 
				as it's also used to represent one letter.
			Also I had to put many cases for the [_]for different placement	
			*/
			select * from Production.ProductDescription
			where production.ProductDescription.Description like '[_]%' 
				or	 production.ProductDescription.Description like '%[_]' 
				or production.ProductDescription.Description like '%[_]%' 


--7.	Calculate sum of TotalDue for each OrderDate 
--in Sales.SalesOrderHeader table for the period between  '7/1/2001' and '7/31/2014'

select sum(TotalDue) As TotalDue_Sum, OrderDate from Sales.SalesOrderHeader
group by OrderDate

--8.	 Display the Employees HireDate (note no repeated values are allowed)
	
	select Distinct HireDate from HumanResources.Employee


--9.	 Calculate the average of the unique ListPrices in the Product table

	select avg(distinct ListPrice) As Avg_ListPrices from Production.Product

--10.	Display the Product Name and its ListPrice within 
--the values of 100 and 120 the list should has the 
--following format "The [product name] is only! [List price]" 
--(the list will be sorted according to its ListPrice value)

select Production.Product.Name AS [Product name] , Production.Product.ListPrice AS [List price]

from Production.Product
where ListPrice between 100 and 120 
order by [List price]




--11.	

--a)	 Transfer the rowguid ,Name, SalesPersonID, 
--Demographics from Sales.Store table  in a newly created table named [store_Archive]
--Note: Check your database to see the new table and how many rows in it?



select rowguid,Name,SalesPersonID,Demographics  into Sales.[store_Archive]
 from Sales.Store

 -- it has 701 row as the original table. also note it has the dbo. schema now
 -- because we didn't specify a schema when copying...
 -- but I made a version with the Sales schema and it worked.
 select * from sales.store_Archive

--b)	Try the previous query but without transferring the data? 

select rowguid,Name,SalesPersonID,Demographics  into Sales.[store_Archive_Empty]
 from Sales.Store
 where 1 = 2
  -- here you will find an empty table is created because of the (false where condtion we put) 
  -- the benfit of this that we now have a table with the same structure but it's empty and 
  -- ready to be filled with new data. 
 select * from sales.store_Archive_Empty

--12.	Using union statement, 
	--retrieve the today’s date in different styles using convert or format funtion.


		/*		https://www.sqlshack.com/sql-convert-date-functions-and-formats/

			SYSDATETIME(): To returns the server’s date and time
			SYSDATETIMEOffset(): It returns the server’s date and time, along with UTC offset
			GETUTCDATE(): It returns date and GMT (Greenwich Mean Time ) time
			GETDATE(): It returns server date and time 
			
		*/
		--note: not all the numbers from 1 has a format, the link above have all 
		--			the available codes and their format.

		select 'Trying Converts'
		select convert(varchar,getdate(),4)
		union
		select convert(varchar,getdate(),22)
		union
		select convert(varchar,getdate(),25)
		union
		select convert(varchar,getdate(),27)
		union
		select 'now the functions'
		union
		select SYSDATETIME()
		union
		select SYSDATETIMEOffset()
		union
		select GETUTCDATE()
		union
		select GETDATE()

		