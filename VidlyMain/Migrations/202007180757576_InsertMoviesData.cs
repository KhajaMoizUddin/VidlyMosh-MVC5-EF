namespace VidlyMain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertMoviesData : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into dbo.Movies(Name,ReleaseDate,NumberInStock,GenreId)Values('Fast And Furious',13/2/2012,12,1)");
            Sql("Insert into dbo.Movies(Name,ReleaseDate,NumberInStock,GenreId)Values('Singham',13/2/2015,7,2)");
            Sql("Insert into dbo.Movies(Name,ReleaseDate,NumberInStock,GenreId)Values('Agneepath',13/2/2013,5,3)");
        }
        
        public override void Down()
        {
        }
    }
}
