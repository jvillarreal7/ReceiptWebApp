namespace ReceiptWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeysForReceipt : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Receipts", name: "CurrencyType_Id", newName: "CurrencyTypeId");
            RenameColumn(table: "dbo.Receipts", name: "Provider_Id", newName: "ProviderId");
            RenameColumn(table: "dbo.Receipts", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.Receipts", name: "IX_User_Id", newName: "IX_UserId");
            RenameIndex(table: "dbo.Receipts", name: "IX_Provider_Id", newName: "IX_ProviderId");
            RenameIndex(table: "dbo.Receipts", name: "IX_CurrencyType_Id", newName: "IX_CurrencyTypeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Receipts", name: "IX_CurrencyTypeId", newName: "IX_CurrencyType_Id");
            RenameIndex(table: "dbo.Receipts", name: "IX_ProviderId", newName: "IX_Provider_Id");
            RenameIndex(table: "dbo.Receipts", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Receipts", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.Receipts", name: "ProviderId", newName: "Provider_Id");
            RenameColumn(table: "dbo.Receipts", name: "CurrencyTypeId", newName: "CurrencyType_Id");
        }
    }
}
