namespace VideoRentingStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvailableCountColumnInMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "AvailableCount", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movies", "Stock", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Stock", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "AvailableCount");
        }
    }
}
