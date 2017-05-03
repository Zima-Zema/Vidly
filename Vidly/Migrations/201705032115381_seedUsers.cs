namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'cf21def2-e52f-423c-a74f-e182ad2fc163', N'gest@vidly.com', 0, N'AONI/s9gvAP3HtXdb8gJ5dqrIfewWMiIYHzu+iO7ovtpONnShskp1hqeoLa043Tklg==', N'82407bcd-10ed-40f0-ab35-a4631450214f', NULL, 0, 0, NULL, 1, 0, N'gest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd93d735c-cbf5-4f96-a334-4c68d2f2f2a1', N'admin@vidly.com', 0, N'AKuSozleXZRXrkYYUErUhaLsESbDfj0RyctoWVAerr66W38qq1S/DY7PWOPAP8C/eA==', N'a5846251-a9a2-4793-bdae-1ee78eb6456c', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9955604c-626a-4739-86c4-492d2af5945b', N'CanManageMovie')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd93d735c-cbf5-4f96-a334-4c68d2f2f2a1', N'9955604c-626a-4739-86c4-492d2af5945b')

");
        }
        
        public override void Down()
        {
        }
    }
}
