namespace Cabspot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notificacionTaxista : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.notificacionTaxista", "ubicacionOrigen", c => c.String(unicode: false));
            AddColumn("dbo.notificacionTaxista", "ubicacionDestino", c => c.String(unicode: false));
            AddColumn("dbo.notificacionTaxista", "metodoPago", c => c.String(unicode: false));
            DropColumn("dbo.notificacionTaxista", "tramaJson");
        }
        
        public override void Down()
        {
            AddColumn("dbo.notificacionTaxista", "tramaJson", c => c.String(unicode: false));
            DropColumn("dbo.notificacionTaxista", "metodoPago");
            DropColumn("dbo.notificacionTaxista", "ubicacionDestino");
            DropColumn("dbo.notificacionTaxista", "ubicacionOrigen");
        }
    }
}
