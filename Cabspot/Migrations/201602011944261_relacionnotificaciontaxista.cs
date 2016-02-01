namespace Cabspot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relacionnotificaciontaxista : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.notificacionTaxista", "idTaxista");
            AddForeignKey("dbo.notificacionTaxista", "idTaxista", "dbo.taxistas", "idTaxista", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.notificacionTaxista", "idTaxista", "dbo.taxistas");
            DropIndex("dbo.notificacionTaxista", new[] { "idTaxista" });
        }
    }
}
