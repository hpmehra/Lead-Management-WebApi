namespace IC.LMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserDetail : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Logins", "UserId", "dbo.SignUps");
            DropIndex("dbo.Logins", new[] { "UserId" });
            CreateTable(
                "dbo.UserDetails",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        fk_UserId = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        ContactNo = c.String(),
                        Gender = c.Int(nullable: false),
                        CountryId = c.Int(),
                        Dob = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserId);
            
            DropTable("dbo.Logins");
            DropTable("dbo.SignUps");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SignUps",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Email = c.String(),
                        ContactNo = c.String(),
                        Gender = c.Int(nullable: false),
                        CountryId = c.Int(),
                        Dob = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        LoginId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.LoginId);
            
            DropTable("dbo.UserDetails");
            CreateIndex("dbo.Logins", "UserId");
            AddForeignKey("dbo.Logins", "UserId", "dbo.SignUps", "UserId", cascadeDelete: true);
        }
    }
}
