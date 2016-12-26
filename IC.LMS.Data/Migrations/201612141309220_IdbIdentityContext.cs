namespace IC.LMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdbIdentityContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompanyContactInfoes",
                c => new
                    {
                        CompanyContactId = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        CompanyAddress = c.String(),
                        EmailId = c.String(),
                        ContactNo = c.String(),
                        FaxNo = c.Int(),
                        PostalCode = c.String(),
                    })
                .PrimaryKey(t => t.CompanyContactId)
                .ForeignKey("dbo.CompanyInfoes", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.CompanyInfoes",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        ComapnyTinNo = c.Int(),
                        CompanyRegistration = c.String(),
                        ComapnyWebsite = c.String(),
                        SourceName = c.String(),
                        RegistrationDate = c.DateTime(),
                        SuccessScore = c.Int(),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.CompanyPersonContacts",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        PersonName = c.String(),
                        Gender = c.Int(nullable: false),
                        EmailId = c.String(),
                        ContactNo = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.CompanyInfoes", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.ProjectRequirements",
                c => new
                    {
                        ProjectReqId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        CompanyId = c.Int(nullable: false),
                        Description = c.String(),
                        RequirementDate = c.DateTime(nullable: false),
                        Technology = c.String(),
                    })
                .PrimaryKey(t => t.ProjectReqId)
                .ForeignKey("dbo.CompanyInfoes", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        DocumentId = c.Int(nullable: false, identity: true),
                        DocumentTypeId = c.Int(nullable: false),
                        DocumentName = c.String(),
                        DocumentType = c.String(),
                        DocumentPath = c.String(),
                        ProjectRequirement_ProjectReqId = c.Int(),
                    })
                .PrimaryKey(t => t.DocumentId)
                .ForeignKey("dbo.ProjectRequirements", t => t.ProjectRequirement_ProjectReqId)
                .Index(t => t.ProjectRequirement_ProjectReqId);
            
            CreateTable(
                "dbo.ProjectReqComments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        ProjectReqId = c.Int(nullable: false),
                        Comment = c.String(),
                        CommentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.ProjectRequirements", t => t.ProjectReqId, cascadeDelete: true)
                .Index(t => t.ProjectReqId);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        LoginId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.LoginId)
                .ForeignKey("dbo.SignUps", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
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
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectReqId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        StartDate = c.DateTime(),
                        CompletionDate = c.DateTime(),
                        DeadLine = c.DateTime(),
                        Estimation = c.String(),
                        ResourceWorking = c.String(),
                        ProjectStatus = c.Int(),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.ProjectRequirements", t => t.ProjectReqId, cascadeDelete: true)
                .Index(t => t.ProjectReqId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Projects", "ProjectReqId", "dbo.ProjectRequirements");
            DropForeignKey("dbo.Logins", "UserId", "dbo.SignUps");
            DropForeignKey("dbo.ProjectReqComments", "ProjectReqId", "dbo.ProjectRequirements");
            DropForeignKey("dbo.Documents", "ProjectRequirement_ProjectReqId", "dbo.ProjectRequirements");
            DropForeignKey("dbo.ProjectRequirements", "CompanyId", "dbo.CompanyInfoes");
            DropForeignKey("dbo.CompanyPersonContacts", "CompanyId", "dbo.CompanyInfoes");
            DropForeignKey("dbo.CompanyContactInfoes", "CompanyId", "dbo.CompanyInfoes");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Projects", new[] { "ProjectReqId" });
            DropIndex("dbo.Logins", new[] { "UserId" });
            DropIndex("dbo.ProjectReqComments", new[] { "ProjectReqId" });
            DropIndex("dbo.Documents", new[] { "ProjectRequirement_ProjectReqId" });
            DropIndex("dbo.ProjectRequirements", new[] { "CompanyId" });
            DropIndex("dbo.CompanyPersonContacts", new[] { "CompanyId" });
            DropIndex("dbo.CompanyContactInfoes", new[] { "CompanyId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Projects");
            DropTable("dbo.SignUps");
            DropTable("dbo.Logins");
            DropTable("dbo.ProjectReqComments");
            DropTable("dbo.Documents");
            DropTable("dbo.ProjectRequirements");
            DropTable("dbo.CompanyPersonContacts");
            DropTable("dbo.CompanyInfoes");
            DropTable("dbo.CompanyContactInfoes");
        }
    }
}
