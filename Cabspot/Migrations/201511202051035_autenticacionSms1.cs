namespace Cabspot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class autenticacionSms1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("clientes", "apikey", c => c.String(maxLength: 32, storeType: "nvarchar"));
            //AlterColumn("dbo.contactos", "telefonoMovil", c => c.String(maxLength: 10, unicode: false));
        }
        
        public override void Down()
        {
            //AlterColumn("dbo.contactos", "telefonoMovil", c => c.String(nullable: false, maxLength: 10, unicode: false));
            DropColumn("cabspotdb.clientes", "apikey");
        }
    }
}
