namespace VidllyApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedrole2 : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd484eb05-1c14-40d7-84ea-906b361927de', N'hoda@gmail.com', 0, N'AEehCsQjL6Yu7+XhsewIDC/ywXUJWv7V0ffxH0CzVqhh1bVKILyYy49Ajyq+FyZ2RA==', N'991a20cb-3a47-4b11-b8d2-e94bd40cd96d', NULL, 0, 0, NULL, 1, 0, N'hoda@gmail.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0a600089-f59e-4068-ab57-d0590e7fe768', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd484eb05-1c14-40d7-84ea-906b361927de', N'0a600089-f59e-4068-ab57-d0590e7fe768')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
