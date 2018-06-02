namespace ProjetLogoV1._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEntityAdressePatientV2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rue = c.String(),
                        NumeroRue = c.Int(nullable: false),
                        BoitePostal = c.Int(nullable: false),
                        CodePostal = c.Int(nullable: false),
                        Ville = c.String(),
                        Pays = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        DateNaissance = c.DateTime(nullable: false),
                        Email = c.String(),
                        TelFixe = c.Int(nullable: false),
                        Gsm = c.Int(nullable: false),
                        PersonneContact = c.String(),
                        TelContact = c.Int(nullable: false),
                        Anamnèse = c.String(),
                        Commentaire = c.String(),
                        AdresseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Adresses", t => t.AdresseId, cascadeDelete: true)
                .Index(t => t.AdresseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "AdresseId", "dbo.Adresses");
            DropIndex("dbo.Patients", new[] { "AdresseId" });
            DropTable("dbo.Patients");
            DropTable("dbo.Adresses");
        }
    }
}
