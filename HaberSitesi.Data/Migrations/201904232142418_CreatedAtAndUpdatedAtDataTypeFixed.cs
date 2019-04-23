namespace HaberSitesi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedAtAndUpdatedAtDataTypeFixed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Categories", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Posts", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Posts", "UpdatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "UpdatedAt", c => c.String());
            AlterColumn("dbo.Posts", "CreatedAt", c => c.String());
            AlterColumn("dbo.Categories", "UpdatedAt", c => c.String());
            AlterColumn("dbo.Categories", "CreatedAt", c => c.String());
        }
    }
}
