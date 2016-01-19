namespace Cabspot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullablePersonas : DbMigration
    {
        public override void Up()
        {
            AlterColumn("personas", "foto", c => c.String(maxLength: 255, unicode: false));
            AlterColumn("personas", "nacionalidad", c => c.String(maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("personas", "nacionalidad", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("personas", "foto", c => c.String(nullable: false, maxLength: 255, unicode: false));
        }
    }
}
