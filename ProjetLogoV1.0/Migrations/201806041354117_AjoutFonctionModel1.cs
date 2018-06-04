namespace ProjetLogoV1._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutFonctionModel1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fonctions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nom = c.String(nullable: false, maxLength: 55),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Fonctions");
        }
    }
}
