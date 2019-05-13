namespace ReceiptWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideConventionsReceipt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Receipts", "CurrencyType_Id", "dbo.CurrencyTypes");
            DropForeignKey("dbo.Receipts", "Provider_Id", "dbo.Providers");
            DropForeignKey("dbo.Receipts", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Receipts", new[] { "CurrencyType_Id" });
            DropIndex("dbo.Receipts", new[] { "Provider_Id" });
            DropIndex("dbo.Receipts", new[] { "User_Id" });
            AlterColumn("dbo.CurrencyTypes", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Providers", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Receipts", "Comments", c => c.String(maxLength: 255));
            AlterColumn("dbo.Receipts", "CurrencyType_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Receipts", "Provider_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Receipts", "User_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Receipts", "CurrencyType_Id");
            CreateIndex("dbo.Receipts", "Provider_Id");
            CreateIndex("dbo.Receipts", "User_Id");
            AddForeignKey("dbo.Receipts", "CurrencyType_Id", "dbo.CurrencyTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Receipts", "Provider_Id", "dbo.Providers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Receipts", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Receipts", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Receipts", "Provider_Id", "dbo.Providers");
            DropForeignKey("dbo.Receipts", "CurrencyType_Id", "dbo.CurrencyTypes");
            DropIndex("dbo.Receipts", new[] { "User_Id" });
            DropIndex("dbo.Receipts", new[] { "Provider_Id" });
            DropIndex("dbo.Receipts", new[] { "CurrencyType_Id" });
            AlterColumn("dbo.Receipts", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Receipts", "Provider_Id", c => c.Int());
            AlterColumn("dbo.Receipts", "CurrencyType_Id", c => c.Int());
            AlterColumn("dbo.Receipts", "Comments", c => c.String());
            AlterColumn("dbo.Providers", "Name", c => c.String());
            AlterColumn("dbo.CurrencyTypes", "Name", c => c.String());
            CreateIndex("dbo.Receipts", "User_Id");
            CreateIndex("dbo.Receipts", "Provider_Id");
            CreateIndex("dbo.Receipts", "CurrencyType_Id");
            AddForeignKey("dbo.Receipts", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Receipts", "Provider_Id", "dbo.Providers", "Id");
            AddForeignKey("dbo.Receipts", "CurrencyType_Id", "dbo.CurrencyTypes", "Id");
        }
    }
}
