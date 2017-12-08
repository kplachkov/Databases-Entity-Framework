namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStudioModel : DbMigration
    {
        public override void Up()
        {
            // Update database to current model.
            CreateTable(
                "dbo.Studios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "Studio_Id", c => c.Int());
            CreateIndex("dbo.Movies", "Studio_Id");
            AddForeignKey("dbo.Movies", "Studio_Id", "dbo.Studios", "Id");
        }
        
        public override void Down()
        {
            // Go back to previous version.
            DropForeignKey("dbo.Movies", "Studio_Id", "dbo.Studios");
            DropIndex("dbo.Movies", new[] { "Studio_Id" });
            DropColumn("dbo.Movies", "Studio_Id");
            DropTable("dbo.Studios");
        }
    }
}
