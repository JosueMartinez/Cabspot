namespace Cabspot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class autenticacionSmsTaxistas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "cabspotdb.autenticacionsmstaxista",
                c => new
                    {
                        idSms = c.Int(nullable: false, identity: true),
                        idTaxista = c.Int(nullable: false),
                        codigo = c.String(maxLength: 15, storeType: "nvarchar"),
                        verificado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idSms)
                .ForeignKey("dbo.taxistas", t => t.idTaxista, cascadeDelete: true)
                .Index(t => t.idTaxista);
            
        }
        
        public override void Down()
        {
            DropForeignKey("cabspotdb.autenticacionsmstaxista", "idTaxista", "dbo.taxistas");
            DropIndex("cabspotdb.autenticacionsmstaxista", new[] { "idTaxista" });
            DropTable("cabspotdb.autenticacionsmstaxista");
        }
    }
}
