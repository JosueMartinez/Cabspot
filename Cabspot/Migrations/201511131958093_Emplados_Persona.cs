namespace Cabspot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Emplados_Persona : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("empleados", "personas_idPersona", "personas");
            //DropIndex("empleados", new[] { "personas_idPersona" });
            //RenameColumn(table: "empleados", name: "personas_idPersona", newName: "idPersona");
            //AlterColumn("empleados", "idPersona", c => c.Int(nullable: false));
            //CreateIndex("empleados", "idPersona");
            //AddForeignKey("empleados", "idPersona", "personas", "idPersona", cascadeDelete: true);
        }
        
        public override void Down()
        {
            //DropForeignKey("empleados", "idPersona", "personas");
            //DropIndex("empleados", new[] { "idPersona" });
            //AlterColumn("empleados", "idPersona", c => c.Int());
            //RenameColumn(table: "empleados", name: "idPersona", newName: "personas_idPersona");
            //CreateIndex("empleados", "personas_idPersona");
            //AddForeignKey("empleados", "personas_idPersona", "personas", "idPersona");
        }
    }
}
