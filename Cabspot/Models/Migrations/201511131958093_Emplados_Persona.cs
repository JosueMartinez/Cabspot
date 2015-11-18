namespace Cabspot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Emplados_Persona : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("cabspotdb.empleados", "personas_idPersona", "cabspotdb.personas");
            //DropIndex("cabspotdb.empleados", new[] { "personas_idPersona" });
            //RenameColumn(table: "cabspotdb.empleados", name: "personas_idPersona", newName: "idPersona");
            //AlterColumn("cabspotdb.empleados", "idPersona", c => c.Int(nullable: false));
            //CreateIndex("cabspotdb.empleados", "idPersona");
            //AddForeignKey("cabspotdb.empleados", "idPersona", "cabspotdb.personas", "idPersona", cascadeDelete: true);
        }
        
        public override void Down()
        {
            //DropForeignKey("cabspotdb.empleados", "idPersona", "cabspotdb.personas");
            //DropIndex("cabspotdb.empleados", new[] { "idPersona" });
            //AlterColumn("cabspotdb.empleados", "idPersona", c => c.Int());
            //RenameColumn(table: "cabspotdb.empleados", name: "idPersona", newName: "personas_idPersona");
            //CreateIndex("cabspotdb.empleados", "personas_idPersona");
            //AddForeignKey("cabspotdb.empleados", "personas_idPersona", "cabspotdb.personas", "idPersona");
        }
    }
}
