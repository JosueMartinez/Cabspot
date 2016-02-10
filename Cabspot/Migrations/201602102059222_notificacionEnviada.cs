namespace Cabspot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notificacionEnviada : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.notificacionCliente", "enviada", c => c.Boolean(nullable: false));
            AddColumn("dbo.notificacionTaxista", "enviada", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.notificacionTaxista", "enviada");
            DropColumn("dbo.notificacionCliente", "enviada");
        }
    }
}
