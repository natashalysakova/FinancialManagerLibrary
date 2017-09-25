namespace FinancialManagerDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addWallet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WalletEntities", "IsCreditCard", c => c.Boolean(nullable: false));
            AddColumn("dbo.WalletEntities", "OverdraftLimit", c => c.Double(nullable: false));
            AddColumn("dbo.WalletEntities", "Name", c => c.String());
            AddColumn("dbo.WalletEntities", "Currency", c => c.Int(nullable: false));
            AddColumn("dbo.WalletEntities", "Balance", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WalletEntities", "Balance");
            DropColumn("dbo.WalletEntities", "Currency");
            DropColumn("dbo.WalletEntities", "Name");
            DropColumn("dbo.WalletEntities", "OverdraftLimit");
            DropColumn("dbo.WalletEntities", "IsCreditCard");
        }
    }
}
