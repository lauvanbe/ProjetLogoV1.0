namespace ProjetLogoV1._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemplirLateralite : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Lateralites ON");
            Sql("INSERT INTO Lateralites (Id, Nom) VALUES (1, 'Gauche')");
            Sql("INSERT INTO Lateralites (Id, Nom) VALUES (2, 'Droitier')");
            Sql("INSERT INTO Lateralites (Id, Nom) VALUES (3, 'Ambidextre')");
        }
        
        public override void Down()
        {
        }
    }
}
