namespace Cabspot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migCarrera : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.carreras", "fechaInicioCarrera", c => c.DateTime(precision: 0));
            AlterColumn("dbo.carreras", "costo", c => c.Single());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.carreras", "costo", c => c.Single(nullable: false));
            AlterColumn("dbo.carreras", "fechaInicioCarrera", c => c.DateTime(nullable: false, precision: 0));
        }
    }
}
