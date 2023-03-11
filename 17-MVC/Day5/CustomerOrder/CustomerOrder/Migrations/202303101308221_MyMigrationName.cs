namespace CustomerOrder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyMigrationName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Gender", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Gender", c => c.String(nullable: false));
        }
    }
}
