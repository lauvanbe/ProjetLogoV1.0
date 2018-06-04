namespace ProjetLogoV1._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedsUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1b3adc29-f388-4c61-ba78-98cefdc05136', N'lauvanbe@gmail.com', 0, N'ACI+nqSFlbcznWErllgDw08/L1YlzLrhZhVEoRJNjnBTh0Fxiq26ggXxsqxG95hxHQ==', N'92ab1228-d7a4-4820-aa04-074006a4d10f', NULL, 0, 0, NULL, 1, 0, N'lauvanbe@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b2b72950-91ab-44b6-bfc4-bf39c2de1430', N'admin@logotech.com', 0, N'ALjYZXezWLP7Mi/WFPiJ08cf1A3QDVA0th6v5FpGag5tnmLfyq0nYBTmSY0f3Er8aQ==', N'52f8c21a-6558-44a5-bd1c-561e3219d357', NULL, 0, 0, NULL, 1, 0, N'admin@logotech.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'cae8a19c-6df2-4914-bb25-6cd6f0d2f68e', N'guest@logotech.com', 0, N'ANVjCFdGgLNBdXsQzna1tj5byH6Eho+FESo5zOZuHLuav1C/eD+Gj7THZ5zVdPInJw==', N'cf4e1bb7-6baa-4dd6-a01d-107d316f8d71', NULL, 0, 0, NULL, 1, 0, N'guest@logotech.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'de1f010d-3770-40cc-aad8-b1631f19ccad', N'CanManagePatients')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b2b72950-91ab-44b6-bfc4-bf39c2de1430', N'de1f010d-3770-40cc-aad8-b1631f19ccad')

");
        }
        
        public override void Down()
        {
        }
    }
}
