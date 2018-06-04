namespace ProjetLogoV1._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutPraticienModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Praticiens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Inami = c.Int(nullable: false),
                        Nom = c.String(nullable: false, maxLength: 55),
                        Prenom = c.String(nullable: false, maxLength: 55),
                        Email = c.String(nullable: false),
                        TelFixe = c.Int(nullable: false),
                        Gsm = c.Int(nullable: false),
                        Deplacement = c.Boolean(nullable: false),
                        AdresseId = c.Int(nullable: false),
                        SpecialisationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Adresses", t => t.AdresseId, cascadeDelete: true)
                .ForeignKey("dbo.Specialisations", t => t.SpecialisationId, cascadeDelete: true)
                .Index(t => t.AdresseId)
                .Index(t => t.SpecialisationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Praticiens", "SpecialisationId", "dbo.Specialisations");
            DropForeignKey("dbo.Praticiens", "AdresseId", "dbo.Adresses");
            DropIndex("dbo.Praticiens", new[] { "SpecialisationId" });
            DropIndex("dbo.Praticiens", new[] { "AdresseId" });
            DropTable("dbo.Praticiens");
        }
    }
}
