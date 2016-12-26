namespace IC.LMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompanyInfoChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompanyContactInfoes", "LinkedInUrl", c => c.String());
            AddColumn("dbo.CompanyContactInfoes", "CountryId", c => c.Int());
            AddColumn("dbo.CompanyInfoes", "Priority", c => c.Int());
            AddColumn("dbo.CompanyInfoes", "ContactChannel", c => c.Int());
            AddColumn("dbo.CompanyInfoes", "Stage", c => c.Int());
            AddColumn("dbo.CompanyInfoes", "DeadReason", c => c.String());
            AddColumn("dbo.CompanyInfoes", "Creator", c => c.String());
            AddColumn("dbo.CompanyInfoes", "CreateOn", c => c.DateTime());
            AddColumn("dbo.CompanyInfoes", "TimeZone", c => c.String());
            AddColumn("dbo.CompanyPersonContacts", "SkypeId", c => c.String());
            AddColumn("dbo.CompanyPersonContacts", "IsPrimary", c => c.Boolean(nullable: false));
            DropColumn("dbo.CompanyInfoes", "CompanyRegistration");
            DropColumn("dbo.CompanyInfoes", "RegistrationDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CompanyInfoes", "RegistrationDate", c => c.DateTime());
            AddColumn("dbo.CompanyInfoes", "CompanyRegistration", c => c.String());
            DropColumn("dbo.CompanyPersonContacts", "IsPrimary");
            DropColumn("dbo.CompanyPersonContacts", "SkypeId");
            DropColumn("dbo.CompanyInfoes", "TimeZone");
            DropColumn("dbo.CompanyInfoes", "CreateOn");
            DropColumn("dbo.CompanyInfoes", "Creator");
            DropColumn("dbo.CompanyInfoes", "DeadReason");
            DropColumn("dbo.CompanyInfoes", "Stage");
            DropColumn("dbo.CompanyInfoes", "ContactChannel");
            DropColumn("dbo.CompanyInfoes", "Priority");
            DropColumn("dbo.CompanyContactInfoes", "CountryId");
            DropColumn("dbo.CompanyContactInfoes", "LinkedInUrl");
        }
    }
}
