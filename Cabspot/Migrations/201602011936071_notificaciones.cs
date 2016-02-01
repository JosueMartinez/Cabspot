namespace Cabspot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notificaciones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.notificacionCliente",
                c => new
                    {
                        idNotificacion = c.Int(nullable: false, identity: true),
                        idCliente = c.Int(nullable: false),
                        tramaJson = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.idNotificacion);
            
            CreateTable(
                "dbo.notificacionTaxista",
                c => new
                    {
                        idNotificacion = c.Int(nullable: false, identity: true),
                        idTaxista = c.Int(nullable: false),
                        tramaJson = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.idNotificacion);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.notificacionTaxista");
            DropTable("dbo.notificacionCliente");
        }
    }
}
