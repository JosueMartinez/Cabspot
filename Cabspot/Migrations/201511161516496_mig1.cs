namespace Cabspot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("taxistas", "vehiculo_idVehiculo", "vehiculo");
            //DropIndex("taxistas", new[] { "vehiculo_idVehiculo" });
            //DropIndex("vehiculo", new[] { "taxistas_idTaxista1" });
            //DropColumn("vehiculo", "idTaxista");
            //DropColumn("vehiculo", "idTaxista");
            //RenameColumn(table: "vehiculo", name: "taxistas_idTaxista1", newName: "idTaxista");
            //RenameColumn(table: "vehiculo", name: "taxistas_idTaxista", newName: "idTaxista");
            //RenameIndex(table: "vehiculo", name: "IX_taxistas_idTaxista", newName: "IX_idTaxista");
            //DropColumn("taxistas", "vehiculo_idVehiculo");
        }
        
        public override void Down()
        {
            //AddColumn("taxistas", "vehiculo_idVehiculo", c => c.Int());
            //RenameIndex(table: "vehiculo", name: "IX_idTaxista", newName: "IX_taxistas_idTaxista");
            //RenameColumn(table: "vehiculo", name: "idTaxista", newName: "taxistas_idTaxista");
            //RenameColumn(table: "vehiculo", name: "idTaxista", newName: "taxistas_idTaxista1");
            //AddColumn("vehiculo", "idTaxista", c => c.Int());
            //AddColumn("vehiculo", "idTaxista", c => c.Int());
            //CreateIndex("vehiculo", "taxistas_idTaxista1");
            //CreateIndex("taxistas", "vehiculo_idVehiculo");
            //AddForeignKey("taxistas", "vehiculo_idVehiculo", "vehiculo", "idVehiculo");
        }
    }
}
