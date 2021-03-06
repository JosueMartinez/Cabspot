namespace Cabspot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class telefonoMovil : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.contactos", "telefonoMovil", c => c.String(nullable: false, maxLength: 12, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.contactos", "telefonoMovil", c => c.String(maxLength: 12, unicode: false));
        }
    }
}
