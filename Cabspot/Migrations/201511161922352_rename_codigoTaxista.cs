namespace Cabspot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rename_codigoTaxista : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("cabspotdb.vehiculo", "empleados1_idEmpleado", "cabspotdb.empleados");
            //DropIndex("cabspotdb.vehiculo", new[] { "empleados1_idEmpleado" });
            AddColumn("taxistas", "codigoTaxista", c => c.String(nullable: false, maxLength: 10, unicode: false));
            DropColumn("taxistas", "codigoTaxita");
            //DropColumn("cabspotdb.vehiculo", "empleados1_idEmpleado");
        }
        
        public override void Down()
        {
            //AddColumn("cabspotdb.vehiculo", "empleados1_idEmpleado", c => c.Int());
            AddColumn("taxistas", "codigoTaxita", c => c.String(nullable: false, maxLength: 10, unicode: false));
            DropColumn("taxistas", "codigoTaxista");
            //CreateIndex("cabspotdb.vehiculo", "empleados1_idEmpleado");
            //AddForeignKey("cabspotdb.vehiculo", "empleados1_idEmpleado", "cabspotdb.empleados", "idEmpleado");
        }
    }
}
