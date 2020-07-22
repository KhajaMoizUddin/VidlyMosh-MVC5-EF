namespace VidlyMain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenresRecords : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into dbo.Genres(Id,Name)Values(1,'Action')");
            Sql("Insert into dbo.Genres(Id,Name)Values(2,'Romance')");
            Sql("Insert into dbo.Genres(Id,Name)Values(3,'Thriller')");
        }
        
        public override void Down()
        {
        }
    }
}
