namespace CustomerOrder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Gender = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        PhoneNum = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustID, cascadeDelete: true)
                .Index(t => t.CustID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CustID", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "CustID" });
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
        }
    }
}
