namespace Cabspot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("cabspotdb.empleados", "registradoPor", "cabspotdb.empleados");
            //DropForeignKey("cabspotdb.personas", "idContacto", "cabspotdb.contactos");
            //DropForeignKey("cabspotdb.personas", "idDireccion", "cabspotdb.direcciones");
            //DropForeignKey("cabspotdb.vehiculos", "registradoPor", "cabspotdb.empleados");
            //DropForeignKey("cabspotdb.vehiculos", "modificadoPor", "cabspotdb.empleados");
            //DropIndex("cabspotdb.personas", new[] { "idDireccion" });
            //DropIndex("cabspotdb.personas", new[] { "idContacto" });
            //DropIndex("cabspotdb.vehiculos", new[] { "registradoPor" });
            //DropIndex("cabspotdb.vehiculos", new[] { "modificadoPor" });
            //DropIndex("cabspotdb.empleados", new[] { "registradoPor" });
            //AddColumn("cabspotdb.vehiculos", "empleados_idEmpleado", c => c.Int());
            //AddColumn("cabspotdb.vehiculos", "empleados1_idEmpleado", c => c.Int());
            //AddColumn("cabspotdb.empleados", "personas_idPersona", c => c.Int());
            //AlterColumn("cabspotdb.personas", "idDireccion", c => c.Int(nullable: false));
            //AlterColumn("cabspotdb.personas", "idContacto", c => c.Int(nullable: false));
            //CreateIndex("cabspotdb.personas", "idDireccion");
            //CreateIndex("cabspotdb.personas", "idContacto");
            //CreateIndex("cabspotdb.taxistas", "idPersona");
            //CreateIndex("cabspotdb.vehiculos", "empleados_idEmpleado");
            //CreateIndex("cabspotdb.vehiculos", "empleados1_idEmpleado");
            //CreateIndex("cabspotdb.empleados", "personas_idPersona");
            //AddForeignKey("cabspotdb.empleados", "personas_idPersona", "cabspotdb.personas", "idPersona");
            //AddForeignKey("cabspotdb.taxistas", "idPersona", "cabspotdb.personas", "idPersona");
            //AddForeignKey("cabspotdb.personas", "idContacto", "cabspotdb.contactos", "idContacto", cascadeDelete: true);
            //AddForeignKey("cabspotdb.personas", "idDireccion", "cabspotdb.direcciones", "idDireccion", cascadeDelete: true);
            //AddForeignKey("cabspotdb.vehiculos", "empleados_idEmpleado", "cabspotdb.empleados", "idEmpleado");
            //AddForeignKey("cabspotdb.vehiculos", "empleados1_idEmpleado", "cabspotdb.empleados", "idEmpleado");
        }
        
        public override void Down()
        {
            //DropForeignKey("cabspotdb.vehiculos", "empleados1_idEmpleado", "cabspotdb.empleados");
            //DropForeignKey("cabspotdb.vehiculos", "empleados_idEmpleado", "cabspotdb.empleados");
            //DropForeignKey("cabspotdb.personas", "idDireccion", "cabspotdb.direcciones");
            //DropForeignKey("cabspotdb.personas", "idContacto", "cabspotdb.contactos");
            //DropForeignKey("cabspotdb.taxistas", "idPersona", "cabspotdb.personas");
            //DropForeignKey("cabspotdb.empleados", "personas_idPersona", "cabspotdb.personas");
            //DropIndex("cabspotdb.empleados", new[] { "personas_idPersona" });
            //DropIndex("cabspotdb.vehiculos", new[] { "empleados1_idEmpleado" });
            //DropIndex("cabspotdb.vehiculos", new[] { "empleados_idEmpleado" });
            //DropIndex("cabspotdb.taxistas", new[] { "idPersona" });
            //DropIndex("cabspotdb.personas", new[] { "idContacto" });
            //DropIndex("cabspotdb.personas", new[] { "idDireccion" });
            //AlterColumn("cabspotdb.personas", "idContacto", c => c.Int());
            //AlterColumn("cabspotdb.personas", "idDireccion", c => c.Int());
            //DropColumn("cabspotdb.empleados", "personas_idPersona");
            //DropColumn("cabspotdb.vehiculos", "empleados1_idEmpleado");
            //DropColumn("cabspotdb.vehiculos", "empleados_idEmpleado");
            //CreateIndex("cabspotdb.empleados", "registradoPor");
            //CreateIndex("cabspotdb.vehiculos", "modificadoPor");
            //CreateIndex("cabspotdb.vehiculos", "registradoPor");
            //CreateIndex("cabspotdb.personas", "idContacto");
            //CreateIndex("cabspotdb.personas", "idDireccion");
            //AddForeignKey("cabspotdb.vehiculos", "modificadoPor", "cabspotdb.empleados", "idEmpleado");
            //AddForeignKey("cabspotdb.vehiculos", "registradoPor", "cabspotdb.empleados", "idEmpleado");
            //AddForeignKey("cabspotdb.personas", "idDireccion", "cabspotdb.direcciones", "idDireccion");
            //AddForeignKey("cabspotdb.personas", "idContacto", "cabspotdb.contactos", "idContacto");
            //AddForeignKey("cabspotdb.empleados", "registradoPor", "cabspotdb.empleados", "idEmpleado");
        }
    }
}
