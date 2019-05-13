namespace ReceiptWebApp.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateProvidersAndCurrencyTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Providers (Name) VALUES ('Axtel')");
            Sql("INSERT INTO Providers (Name) VALUES ('Coca-Cola')");
            Sql("INSERT INTO Providers (Name) VALUES ('Movistar')");
            Sql("INSERT INTO Providers (Name) VALUES ('Nintendo')");

            Sql("INSERT INTO CurrencyTypes (Name) VALUES ('USD')");
            Sql("INSERT INTO CurrencyTypes (Name) VALUES ('MXN')");
            Sql("INSERT INTO CurrencyTypes (Name) VALUES ('GBP')");
            Sql("INSERT INTO CurrencyTypes (Name) VALUES ('EUR')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Providers WHERE Id IN (1, 2, 3, 4)");

            Sql("DELETE FROM CurrencyTypes WHERE Id IN (1, 2, 3, 4)");
        }
    }
}
