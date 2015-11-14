namespace Cabspot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("cabspotdb.taxistas", "idPersona", "cabspotdb.personas");
            //DropIndex("cabspotdb.taxistas", new[] { "idPersona" });
            //AlterColumn("cabspotdb.taxistas", "idPersona", c => c.Int(nullable: false));
            //CreateIndex("cabspotdb.taxistas", "idPersona");
            //AddForeignKey("cabspotdb.taxistas", "idPersona", "cabspotdb.personas", "idPersona", cascadeDelete: true);
        }
        
        public override void Down()
        {
            //DropForeignKey("cabspotdb.taxistas", "idPersona", "cabspotdb.personas");
            //DropIndex("cabspotdb.taxistas", new[] { "idPersona" });
            //AlterColumn("cabspotdb.taxistas", "idPersona", c => c.Int());
            //CreateIndex("cabspotdb.taxistas", "idPersona");
            //AddForeignKey("cabspotdb.taxistas", "idPersona", "cabspotdb.personas", "idPersona");
        }
    }
}
