namespace Cabspot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clientesMovil : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("autenticacionsms", "idCliente", "clientes");
            //DropIndex("autenticacionsms", new[] { "idCliente" });
            //CreateTable(
            //    "clientesMovil",
            //    c => new
            //        {
            //            idClienteMovil = c.Int(nullable: false, identity: true),
            //            telefonoMovil = c.String(nullable: false, maxLength: 12, storeType: "nvarchar"),
            //            nombreUsuario = c.String(maxLength: 15, storeType: "nvarchar"),
            //            apikey = c.String(maxLength: 32, storeType: "nvarchar"),
            //            fechaRegistro = c.DateTime(nullable: false, storeType: "date"),
            //        })
            //    .PrimaryKey(t => t.idClienteMovil);
            
            //AddColumn("autenticacionsms", "idClienteMovil", c => c.Int(nullable: false));
            //CreateIndex("autenticacionsms", "idClienteMovil");
            //AddForeignKey("autenticacionsms", "idClienteMovil", "clientesMovil", "idClienteMovil", cascadeDelete: true);
            //DropColumn("autenticacionsms", "idCliente");
        }
        
        public override void Down()
        {
            //AddColumn("autenticacionsms", "idCliente", c => c.Int(nullable: false));
            //DropForeignKey("autenticacionsms", "idClienteMovil", "clientesMovil");
            //DropIndex("autenticacionsms", new[] { "idClienteMovil" });
            //DropColumn("autenticacionsms", "idClienteMovil");
            //DropTable("clientesMovil");
            //CreateIndex("autenticacionsms", "idCliente");
            //AddForeignKey("autenticacionsms", "idCliente", "clientes", "idCliente", cascadeDelete: true);
        }
    }
}
