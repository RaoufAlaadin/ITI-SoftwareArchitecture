<Query Kind="SQL">
  <Connection>
    <ID>6df531c6-29fa-430d-8eba-cc940aa76916</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Database>Northwind</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
  <Output>DataGrids</Output>
</Query>

select * from products
select * from suppliers
select * from categories

ALTER TABLE [Order Details] DROP CONSTRAINT [FK_Order_Details_Products];
ALTER TABLE [Order Details] ADD CONSTRAINT [FK_Order_Details_Products]
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID) ON DELETE CASCADE;



s