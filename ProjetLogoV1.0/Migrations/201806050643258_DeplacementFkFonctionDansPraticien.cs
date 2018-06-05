namespace ProjetLogoV1._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeplacementFkFonctionDansPraticien : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Praticiens", "FonctionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Praticiens", "FonctionId");
            AddForeignKey("dbo.Praticiens", "FonctionId", "dbo.Fonctions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Praticiens", "FonctionId", "dbo.Fonctions");
            DropIndex("dbo.Praticiens", new[] { "FonctionId" });
            DropColumn("dbo.Praticiens", "FonctionId");
        }
    }
}
