namespace Cabspot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("empleados", "registradoPor", "empleados");
            //DropForeignKey("personas", "idContacto", "contactos");
            //DropForeignKey("personas", "idDireccion", "direcciones");
            //DropForeignKey("vehiculos", "registradoPor", "empleados");
            //DropForeignKey("vehiculos", "modificadoPor", "empleados");
            //DropIndex("personas", new[] { "idDireccion" });
            //DropIndex("personas", new[] { "idContacto" });
            //DropIndex("vehiculos", new[] { "registradoPor" });
            //DropIndex("vehiculos", new[] { "modificadoPor" });
            //DropIndex("empleados", new[] { "registradoPor" });
            //AddColumn("vehiculos", "empleados_idEmpleado", c => c.Int());
            //AddColumn("vehiculos", "empleados1_idEmpleado", c => c.Int());
            //AddColumn("empleados", "personas_idPersona", c => c.Int());
            //AlterColumn("personas", "idDireccion", c => c.Int(nullable: false));
            //AlterColumn("personas", "idContacto", c => c.Int(nullable: false));
            //CreateIndex("personas", "idDireccion");
            //CreateIndex("personas", "idContacto");
            //CreateIndex("taxistas", "idPersona");
            //CreateIndex("vehiculos", "empleados_idEmpleado");
            //CreateIndex("vehiculos", "empleados1_idEmpleado");
            //CreateIndex("empleados", "personas_idPersona");
            //AddForeignKey("empleados", "personas_idPersona", "personas", "idPersona");
            //AddForeignKey("taxistas", "idPersona", "personas", "idPersona");
            //AddForeignKey("personas", "idContacto", "contactos", "idContacto", cascadeDelete: true);
            //AddForeignKey("personas", "idDireccion", "direcciones", "idDireccion", cascadeDelete: true);
            //AddForeignKey("vehiculos", "empleados_idEmpleado", "empleados", "idEmpleado");
            //AddForeignKey("vehiculos", "empleados1_idEmpleado", "empleados", "idEmpleado");
        }
        
        public override void Down()
        {
            //DropForeignKey("vehiculos", "empleados1_idEmpleado", "empleados");
            //DropForeignKey("vehiculos", "empleados_idEmpleado", "empleados");
            //DropForeignKey("personas", "idDireccion", "direcciones");
            //DropForeignKey("personas", "idContacto", "contactos");
            //DropForeignKey("taxistas", "idPersona", "personas");
            //DropForeignKey("empleados", "personas_idPersona", "personas");
            //DropIndex("empleados", new[] { "personas_idPersona" });
            //DropIndex("vehiculos", new[] { "empleados1_idEmpleado" });
            //DropIndex("vehiculos", new[] { "empleados_idEmpleado" });
            //DropIndex("taxistas", new[] { "idPersona" });
            //DropIndex("personas", new[] { "idContacto" });
            //DropIndex("personas", new[] { "idDireccion" });
            //AlterColumn("personas", "idContacto", c => c.Int());
            //AlterColumn("personas", "idDireccion", c => c.Int());
            //DropColumn("empleados", "personas_idPersona");
            //DropColumn("vehiculos", "empleados1_idEmpleado");
            //DropColumn("vehiculos", "empleados_idEmpleado");
            //CreateIndex("empleados", "registradoPor");
            //CreateIndex("vehiculos", "modificadoPor");
            //CreateIndex("vehiculos", "registradoPor");
            //CreateIndex("personas", "idContacto");
            //CreateIndex("personas", "idDireccion");
            //AddForeignKey("vehiculos", "modificadoPor", "empleados", "idEmpleado");
            //AddForeignKey("vehiculos", "registradoPor", "empleados", "idEmpleado");
            //AddForeignKey("personas", "idDireccion", "direcciones", "idDireccion");
            //AddForeignKey("personas", "idContacto", "contactos", "idContacto");
            //AddForeignKey("empleados", "registradoPor", "empleados", "idEmpleado");
        }
    }
}
