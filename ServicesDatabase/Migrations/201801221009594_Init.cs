namespace ServicesDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RecordEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Month = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        PayDate = c.DateTime(nullable: false),
                        Value = c.Double(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tarif_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TarifEntities", t => t.Tarif_Id)
                .Index(t => t.Tarif_Id);
            
            CreateTable(
                "dbo.TarifEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Started = c.DateTime(nullable: false),
                        Finished = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecordEntities", "Tarif_Id", "dbo.TarifEntities");
            DropIndex("dbo.RecordEntities", new[] { "Tarif_Id" });
            DropTable("dbo.TarifEntities");
            DropTable("dbo.RecordEntities");
        }
    }
}
