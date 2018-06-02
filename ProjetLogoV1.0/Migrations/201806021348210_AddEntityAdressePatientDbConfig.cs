namespace ProjetLogoV1._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEntityAdressePatientDbConfig : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Adresses", "Rue", c => c.String(nullable: false, maxLength: 55));
            AlterColumn("dbo.Adresses", "BoitePostal", c => c.Int());
            AlterColumn("dbo.Adresses", "Ville", c => c.String(nullable: false, maxLength: 55));
            AlterColumn("dbo.Adresses", "Pays", c => c.String(nullable: false, maxLength: 55));
            AlterColumn("dbo.Patients", "Nom", c => c.String(nullable: false, maxLength: 55));
            AlterColumn("dbo.Patients", "Prenom", c => c.String(nullable: false, maxLength: 55));
            AlterColumn("dbo.Patients", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "TelFixe", c => c.Int());
            AlterColumn("dbo.Patients", "Gsm", c => c.Int());
            AlterColumn("dbo.Patients", "PersonneContact", c => c.String(maxLength: 55));
            AlterColumn("dbo.Patients", "TelContact", c => c.Int());
            AlterColumn("dbo.Patients", "Anamnèse", c => c.String(nullable: false, maxLength: 2000));
            AlterColumn("dbo.Patients", "Commentaire", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "Commentaire", c => c.String());
            AlterColumn("dbo.Patients", "Anamnèse", c => c.String());
            AlterColumn("dbo.Patients", "TelContact", c => c.Int(nullable: false));
            AlterColumn("dbo.Patients", "PersonneContact", c => c.String());
            AlterColumn("dbo.Patients", "Gsm", c => c.Int(nullable: false));
            AlterColumn("dbo.Patients", "TelFixe", c => c.Int(nullable: false));
            AlterColumn("dbo.Patients", "Email", c => c.String());
            AlterColumn("dbo.Patients", "Prenom", c => c.String());
            AlterColumn("dbo.Patients", "Nom", c => c.String());
            AlterColumn("dbo.Adresses", "Pays", c => c.String());
            AlterColumn("dbo.Adresses", "Ville", c => c.String());
            AlterColumn("dbo.Adresses", "BoitePostal", c => c.Int(nullable: false));
            AlterColumn("dbo.Adresses", "Rue", c => c.String());
        }
    }
}
