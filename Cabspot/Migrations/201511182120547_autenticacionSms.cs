namespace Cabspot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class autenticacionSms : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "autenticacionsms",
                c => new
                    {
                        idSms = c.Int(nullable: false, identity: true),
                        idCliente = c.Int(nullable: false),
                        codigo = c.String(maxLength: 15, storeType: "nvarchar"),
                        verificado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idSms)
                //.ForeignKey("clientes", t => t.idCliente, cascadeDelete: true)
                .Index(t => t.idCliente);

            AddForeignKey("autenticacionsms", "idCliente", "clientes", "idCliente");
            
        }
        
        public override void Down()
        {
            DropForeignKey("autenticacionsms", "idCliente", "clientes");
            DropIndex("autenticacionsms", new[] { "idCliente" });
            DropTable("autenticacionsms");
        }
    }
}