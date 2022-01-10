namespace VideoRentingStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'cd0ca539-fd4f-431b-aed0-4c79b50bc78a', N'guest@vidly.com', 0, N'ANsVKZJqiZaPMwaJC5FB3IpLoRPLXDPi0tnzkLxvXf1QhTFffZchShJ8ETTiBNc9gA==', N'078df499-2de9-4930-b968-50df6464113a', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fe83d63b-39e2-454a-9879-83f96465f732', N'admin@vidly.com', 0, N'AJ1+TMwgSJT2cyKhPIHjs+7KHIsnOvt/O8ZQgMQIpwvtKO5Z34GioqX05xLvx9f0Eg==', N'bcbccf4d-2abd-45cc-92b7-dd032a44d840', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ce8b7811-9d9a-49ff-80ff-8261d6bd8941', N'CanManageMovies')
                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fe83d63b-39e2-454a-9879-83f96465f732', N'ce8b7811-9d9a-49ff-80ff-8261d6bd8941')
                ");

        }
        
        public override void Down()
        {
        }
    }
}
