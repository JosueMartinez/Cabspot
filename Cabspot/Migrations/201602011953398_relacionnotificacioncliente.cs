namespace Cabspot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relacionnotificacioncliente : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.notificacionCliente", "idCliente");
            AddForeignKey("dbo.notificacionCliente", "idCliente", "clientes", "idCliente", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.notificacionCliente", "idCliente", "clientes");
            DropIndex("dbo.notificacionCliente", new[] { "idCliente" });
        }
    }
}
