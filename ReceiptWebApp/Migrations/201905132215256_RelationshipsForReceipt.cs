namespace ReceiptWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationshipsForReceipt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CurrencyTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Providers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Receipts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        Comments = c.String(),
                        CurrencyType_Id = c.Int(),
                        Provider_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CurrencyTypes", t => t.CurrencyType_Id)
                .ForeignKey("dbo.Providers", t => t.Provider_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.CurrencyType_Id)
                .Index(t => t.Provider_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Receipts", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Receipts", "Provider_Id", "dbo.Providers");
            DropForeignKey("dbo.Receipts", "CurrencyType_Id", "dbo.CurrencyTypes");
            DropIndex("dbo.Receipts", new[] { "User_Id" });
            DropIndex("dbo.Receipts", new[] { "Provider_Id" });
            DropIndex("dbo.Receipts", new[] { "CurrencyType_Id" });
            DropTable("dbo.Receipts");
            DropTable("dbo.Providers");
            DropTable("dbo.CurrencyTypes");
        }
    }
}
