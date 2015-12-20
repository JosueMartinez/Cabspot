namespace Cabspot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vehiculoActivo : DbMigration
    {
        public override void Up()
        {
            AddColumn("vehiculo", "activo", c => c.Boolean(nullable: false,defaultValue:false));
        }
        
        public override void Down()
        {
            DropColumn("vehiculo", "activo");
        }
    }
}
