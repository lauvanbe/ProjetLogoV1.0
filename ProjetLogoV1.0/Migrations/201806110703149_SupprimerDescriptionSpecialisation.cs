namespace ProjetLogoV1._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SupprimerDescriptionSpecialisation : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Specialisations", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Specialisations", "Description", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
