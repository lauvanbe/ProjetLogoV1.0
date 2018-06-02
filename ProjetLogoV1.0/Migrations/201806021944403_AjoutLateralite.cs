namespace ProjetLogoV1._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutLateralite : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lateralites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nom = c.String(nullable: false, maxLength: 55),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Patients", "LateraliteId", c => c.Int(nullable: false));
            CreateIndex("dbo.Patients", "LateraliteId");
            AddForeignKey("dbo.Patients", "LateraliteId", "dbo.Lateralites", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "LateraliteId", "dbo.Lateralites");
            DropIndex("dbo.Patients", new[] { "LateraliteId" });
            DropColumn("dbo.Patients", "LateraliteId");
            DropTable("dbo.Lateralites");
        }
    }
}
