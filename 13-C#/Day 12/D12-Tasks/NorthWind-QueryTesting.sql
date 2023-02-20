-- checks how many connection is made by the data base
-- even if we close our program and remove object , the connection will be still there
-- due to something called `Resource pulling` 
sp_who

--1 

select count(*) from Products

--2

select * from Products


--3 creating a detailed view using a stored procedure. 
-- We would use the name of the stored procedure. 

[dbo].[SelectAllProducts]


--4 
UPDATE Products SET  UnitPrice = @UnitePrice WHERE(ProductID = @ProductID)


--5 testing the following tables ==> Products , categories, suppliers

select * from Products
select * from Categories
select * from Suppliers