namespace Cabspot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notificacionCliente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.notificacionCliente", "nombreTaxista", c => c.String(unicode: false));
            AddColumn("dbo.notificacionCliente", "codigoTaxista", c => c.String(unicode: false));
            AddColumn("dbo.notificacionCliente", "vehiculo", c => c.String(unicode: false));
            AddColumn("dbo.notificacionCliente", "ubicacionTaxista", c => c.String(unicode: false));
            AddColumn("dbo.notificacionCliente", "tiempoAproximadoRecogida", c => c.Int(nullable: false));
            DropColumn("dbo.notificacionCliente", "tramaJson");
        }
        
        public override void Down()
        {
            AddColumn("dbo.notificacionCliente", "tramaJson", c => c.String(unicode: false));
            DropColumn("dbo.notificacionCliente", "tiempoAproximadoRecogida");
            DropColumn("dbo.notificacionCliente", "ubicacionTaxista");
            DropColumn("dbo.notificacionCliente", "vehiculo");
            DropColumn("dbo.notificacionCliente", "codigoTaxista");
            DropColumn("dbo.notificacionCliente", "nombreTaxista");
        }
    }
}
