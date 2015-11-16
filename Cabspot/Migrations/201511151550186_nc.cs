namespace Cabspot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nc : DbMigration
    {
        public override void Up()
        {
            //RenameTable(name: "cabspotdb.vehiculos", newName: "vehiculo");
        }
        
        public override void Down()
        {
            //RenameTable(name: "cabspotdb.vehiculo", newName: "vehiculos");
        }
    }
}
