namespace ProjetLogoV1._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeplacementFonctionDansPraticien : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Specialisations", "FonctionId", "dbo.Fonctions");
            DropIndex("dbo.Specialisations", new[] { "FonctionId" });
            DropColumn("dbo.Specialisations", "FonctionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Specialisations", "FonctionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Specialisations", "FonctionId");
            AddForeignKey("dbo.Specialisations", "FonctionId", "dbo.Fonctions", "Id", cascadeDelete: true);
        }
    }
}
