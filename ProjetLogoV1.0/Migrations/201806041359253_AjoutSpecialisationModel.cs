namespace ProjetLogoV1._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutSpecialisationModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Specialisations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 55),
                        Description = c.String(nullable: false, maxLength: 255),
                        FonctionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fonctions", t => t.FonctionId, cascadeDelete: true)
                .Index(t => t.FonctionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Specialisations", "FonctionId", "dbo.Fonctions");
            DropIndex("dbo.Specialisations", new[] { "FonctionId" });
            DropTable("dbo.Specialisations");
        }
    }
}
