namespace IC.LMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompanyInfoConatctChanel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CompanyContactInfoes", "CountryId", c => c.Int(nullable: false));
            AlterColumn("dbo.CompanyInfoes", "ContactChannel", c => c.String());
            AlterColumn("dbo.CompanyInfoes", "CreateOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Projects", "ProjectStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "ProjectStatus", c => c.Int());
            AlterColumn("dbo.CompanyInfoes", "CreateOn", c => c.DateTime());
            AlterColumn("dbo.CompanyInfoes", "ContactChannel", c => c.Int());
            AlterColumn("dbo.CompanyContactInfoes", "CountryId", c => c.Int());
        }
    }
}
