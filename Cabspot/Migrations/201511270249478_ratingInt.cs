namespace Cabspot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ratingInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("taxistas", "rating", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("taxistas", "rating", c => c.Double());
        }
    }
}
