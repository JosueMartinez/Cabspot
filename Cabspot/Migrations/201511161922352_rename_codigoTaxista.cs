namespace Cabspot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rename_codigoTaxista : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("vehiculo", "empleados1_idEmpleado", "empleados");
            //DropIndex("vehiculo", new[] { "empleados1_idEmpleado" });
            AddColumn("taxistas", "codigoTaxista", c => c.String(nullable: false, maxLength: 10, unicode: false));
            DropColumn("taxistas", "codigoTaxita");
            //DropColumn("vehiculo", "empleados1_idEmpleado");
        }
        
        public override void Down()
        {
            //AddColumn("vehiculo", "empleados1_idEmpleado", c => c.Int());
            AddColumn("taxistas", "codigoTaxita", c => c.String(nullable: false, maxLength: 10, unicode: false));
            DropColumn("taxistas", "codigoTaxista");
            //CreateIndex("vehiculo", "empleados1_idEmpleado");
            //AddForeignKey("vehiculo", "empleados1_idEmpleado", "empleados", "idEmpleado");
        }
    }
}
