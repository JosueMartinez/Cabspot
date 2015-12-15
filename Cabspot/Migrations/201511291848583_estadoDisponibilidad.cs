namespace Cabspot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class estadoDisponibilidad : DbMigration
    {
        public override void Up()
        {
            CreateIndex("taxistas", "idEstadoDisponibilidad");
            AddForeignKey("taxistas", "idEstadoDisponibilidad", "estadodisponibilidad", "idEstadoDisponibilidad");
        }
        
        public override void Down()
        {
            DropForeignKey("taxistas", "idEstadoDisponibilidad", "estadodisponibilidad");
            DropIndex("taxistas", new[] { "idEstadoDisponibilidad" });
        }
    }
}
