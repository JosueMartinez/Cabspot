namespace Cabspot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("taxistas", "idPersona", "personas");
            //DropIndex("taxistas", new[] { "idPersona" });
            //AlterColumn("taxistas", "idPersona", c => c.Int(nullable: false));
            //CreateIndex("taxistas", "idPersona");
            //AddForeignKey("taxistas", "idPersona", "personas", "idPersona", cascadeDelete: true);
        }
        
        public override void Down()
        {
            //DropForeignKey("taxistas", "idPersona", "personas");
            //DropIndex("taxistas", new[] { "idPersona" });
            //AlterColumn("taxistas", "idPersona", c => c.Int());
            //CreateIndex("taxistas", "idPersona");
            //AddForeignKey("taxistas", "idPersona", "personas", "idPersona");
        }
    }
}
