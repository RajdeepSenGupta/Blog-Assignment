namespace Blogging.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "OnCreated", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "OnCreated", c => c.DateTime(nullable: false));
        }
    }
}
