namespace CinemaTown.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers2 : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1b33acfa-ff88-47e4-bf0b-192dccbefcc6', N'random@crossroad.dev', 0, N'AJO8ldaJwb7W4iit61s1HYXTx0GADk/3glAbX3MTGuWG+HRbw6UcOWeWL+uZU3yUBw==', N'81862e34-216f-4bdf-adb5-ad9118841775', NULL, 0, 0, NULL, 1, 0, N'random@crossroad.dev')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'5c81f50f-0351-47fb-bdf5-511e7b5ea0df', N'john@crossroad.dev', 0, N'AM2kG/JvkNiGUpWm19hoi2ERyOHCJl+t5eaqxyXA7hI5EwnAbuYvL/FDlH078sqeIw==', N'5464b425-312c-4441-9109-e8d50f83aeda', NULL, 0, 0, NULL, 1, 0, N'john@crossroad.dev')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9db79161-0fa7-4213-9f9d-315ff5b83124', N'employee@crossroad.dev', 0, N'ACSZo7MG5FQIUn3RkRSrB684BoxQgFosV6iI6WQcetwQGDKn4b9O3qLqqOZhTY/lJA==', N'8dfec984-4c5d-42ec-8340-311cf9175280', NULL, 0, 0, NULL, 1, 0, N'employee@crossroad.dev')
            
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'446a20dd-34ff-4386-9a34-54d6a7fb4a5a', N'CanManageCustomers')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'608f75a0-3af5-4fa7-a122-4954e322cf0a', N'CanManageMovies');


            ");
        }
        
        public override void Down()
        {
        }
    }
}
