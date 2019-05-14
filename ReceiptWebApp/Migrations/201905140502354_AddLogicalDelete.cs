namespace ReceiptWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLogicalDelete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Receipts", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Receipts", "IsActive");
        }
    }
}
