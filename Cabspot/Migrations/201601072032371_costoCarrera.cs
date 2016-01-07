namespace Cabspot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class costoCarrera : DbMigration
    {
        public override void Up()
        {
            AddColumn("carreras", "costo", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("carreras", "costo");
        }
    }
}
