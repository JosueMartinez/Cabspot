namespace Cabspot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mi : DbMigration
    {
        public override void Up()
        {
            //DropColumn("vehiculo", "registradoPor");
            //RenameColumn(table: "vehiculo", name: "empleados_idEmpleado", newName: "registradoPor");
            //RenameIndex(table: "vehiculo", name: "IX_empleados_idEmpleado", newName: "IX_registradoPor");
        }
        
        public override void Down()
        {
            //RenameIndex(table: "vehiculo", name: "IX_registradoPor", newName: "IX_empleados_idEmpleado");
            //RenameColumn(table: "vehiculo", name: "registradoPor", newName: "empleados_idEmpleado");
            //AddColumn("vehiculo", "registradoPor", c => c.Int());
        }
    }
}
