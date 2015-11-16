namespace Cabspot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("cabspotdb.taxistas", "vehiculo_idVehiculo", "cabspotdb.vehiculo");
            //DropIndex("cabspotdb.taxistas", new[] { "vehiculo_idVehiculo" });
            //DropIndex("cabspotdb.vehiculo", new[] { "taxistas_idTaxista1" });
            //DropColumn("cabspotdb.vehiculo", "idTaxista");
            //DropColumn("cabspotdb.vehiculo", "idTaxista");
            //RenameColumn(table: "cabspotdb.vehiculo", name: "taxistas_idTaxista1", newName: "idTaxista");
            //RenameColumn(table: "cabspotdb.vehiculo", name: "taxistas_idTaxista", newName: "idTaxista");
            //RenameIndex(table: "cabspotdb.vehiculo", name: "IX_taxistas_idTaxista", newName: "IX_idTaxista");
            //DropColumn("cabspotdb.taxistas", "vehiculo_idVehiculo");
        }
        
        public override void Down()
        {
            //AddColumn("cabspotdb.taxistas", "vehiculo_idVehiculo", c => c.Int());
            //RenameIndex(table: "cabspotdb.vehiculo", name: "IX_idTaxista", newName: "IX_taxistas_idTaxista");
            //RenameColumn(table: "cabspotdb.vehiculo", name: "idTaxista", newName: "taxistas_idTaxista");
            //RenameColumn(table: "cabspotdb.vehiculo", name: "idTaxista", newName: "taxistas_idTaxista1");
            //AddColumn("cabspotdb.vehiculo", "idTaxista", c => c.Int());
            //AddColumn("cabspotdb.vehiculo", "idTaxista", c => c.Int());
            //CreateIndex("cabspotdb.vehiculo", "taxistas_idTaxista1");
            //CreateIndex("cabspotdb.taxistas", "vehiculo_idVehiculo");
            //AddForeignKey("cabspotdb.taxistas", "vehiculo_idVehiculo", "cabspotdb.vehiculo", "idVehiculo");
        }
    }
}
