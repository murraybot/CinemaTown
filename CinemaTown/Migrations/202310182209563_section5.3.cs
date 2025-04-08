namespace CinemaTown.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class section53 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Movies", "ReleaseYear", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Description", c => c.String());
            AlterColumn("dbo.Movies", "ReleaseYear", c => c.Int(nullable: false));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
