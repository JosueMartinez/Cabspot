namespace Cabspot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class taxistasVehiculo : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("cabspotdb.vehiculos", "idTaxista", "cabspotdb.taxistas");
            //DropIndex("cabspotdb.vehiculos", new[] { "idTaxista" });
            //AddColumn("cabspotdb.taxistas", "vehiculo_idVehiculo", c => c.Int());
            //AddColumn("cabspotdb.vehiculos", "taxistas_idTaxista", c => c.Int());
            //AddColumn("cabspotdb.vehiculos", "taxistas_idTaxista1", c => c.Int());
            //CreateIndex("cabspotdb.taxistas", "vehiculo_idVehiculo");
            //CreateIndex("cabspotdb.vehiculos", "taxistas_idTaxista");
            //CreateIndex("cabspotdb.vehiculos", "taxistas_idTaxista1");
            //AddForeignKey("cabspotdb.taxistas", "vehiculo_idVehiculo", "cabspotdb.vehiculos", "idVehiculo");
            //AddForeignKey("cabspotdb.vehiculos", "taxistas_idTaxista1", "cabspotdb.taxistas", "idTaxista");
            //AddForeignKey("cabspotdb.vehiculos", "taxistas_idTaxista", "cabspotdb.taxistas", "idTaxista");
        }
        
        public override void Down()
        {
            //DropForeignKey("cabspotdb.vehiculos", "taxistas_idTaxista", "cabspotdb.taxistas");
            //DropForeignKey("cabspotdb.vehiculos", "taxistas_idTaxista1", "cabspotdb.taxistas");
            //DropForeignKey("cabspotdb.taxistas", "vehiculo_idVehiculo", "cabspotdb.vehiculos");
            //DropIndex("cabspotdb.vehiculos", new[] { "taxistas_idTaxista1" });
            //DropIndex("cabspotdb.vehiculos", new[] { "taxistas_idTaxista" });
            //DropIndex("cabspotdb.taxistas", new[] { "vehiculo_idVehiculo" });
            //DropColumn("cabspotdb.vehiculos", "taxistas_idTaxista1");
            //DropColumn("cabspotdb.vehiculos", "taxistas_idTaxista");
            //DropColumn("cabspotdb.taxistas", "vehiculo_idVehiculo");
            //CreateIndex("cabspotdb.vehiculos", "idTaxista");
            //AddForeignKey("cabspotdb.vehiculos", "idTaxista", "cabspotdb.taxistas", "idTaxista");
        }
    }
}
