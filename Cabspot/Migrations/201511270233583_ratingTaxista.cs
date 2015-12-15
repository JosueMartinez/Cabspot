namespace Cabspot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ratingTaxista : DbMigration
    {
        public override void Up()
        {
            AddColumn("taxistas", "rating", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("taxistas", "rating");
        }
    }
}
