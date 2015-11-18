namespace Cabspot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class taxistasVehiculo : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("vehiculos", "idTaxista", "taxistas");
            //DropIndex("vehiculos", new[] { "idTaxista" });
            //AddColumn("taxistas", "vehiculo_idVehiculo", c => c.Int());
            //AddColumn("vehiculos", "taxistas_idTaxista", c => c.Int());
            //AddColumn("vehiculos", "taxistas_idTaxista1", c => c.Int());
            //CreateIndex("taxistas", "vehiculo_idVehiculo");
            //CreateIndex("vehiculos", "taxistas_idTaxista");
            //CreateIndex("vehiculos", "taxistas_idTaxista1");
            //AddForeignKey("taxistas", "vehiculo_idVehiculo", "vehiculos", "idVehiculo");
            //AddForeignKey("vehiculos", "taxistas_idTaxista1", "taxistas", "idTaxista");
            //AddForeignKey("vehiculos", "taxistas_idTaxista", "taxistas", "idTaxista");
        }
        
        public override void Down()
        {
            //DropForeignKey("vehiculos", "taxistas_idTaxista", "taxistas");
            //DropForeignKey("vehiculos", "taxistas_idTaxista1", "taxistas");
            //DropForeignKey("taxistas", "vehiculo_idVehiculo", "vehiculos");
            //DropIndex("vehiculos", new[] { "taxistas_idTaxista1" });
            //DropIndex("vehiculos", new[] { "taxistas_idTaxista" });
            //DropIndex("taxistas", new[] { "vehiculo_idVehiculo" });
            //DropColumn("vehiculos", "taxistas_idTaxista1");
            //DropColumn("vehiculos", "taxistas_idTaxista");
            //DropColumn("taxistas", "vehiculo_idVehiculo");
            //CreateIndex("vehiculos", "idTaxista");
            //AddForeignKey("vehiculos", "idTaxista", "taxistas", "idTaxista");
        }
    }
}
