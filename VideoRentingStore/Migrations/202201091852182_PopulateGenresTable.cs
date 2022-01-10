namespace VideoRentingStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Comedy'), (2, 'Sci-Fi'), (3, 'Horror'), " +
                "(4, 'Romance'), (5, 'Action'), (6, 'Thriller'), (7, 'Drama'), (8, 'Mystery')," +
                "(9, 'Crime')");
        }
        
        public override void Down()
        {
        }
    }
}
