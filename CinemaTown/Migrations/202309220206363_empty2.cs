namespace CinemaTown.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class empty2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String(nullable: false));
        }
    }
}
