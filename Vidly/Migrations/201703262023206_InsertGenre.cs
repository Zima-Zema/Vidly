namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertGenre : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Genres (Name) values('Comedy'),('Family'),('Drama'),('Action'),('Romace')");
        }
        
        public override void Down()
        {
        }
    }
}
