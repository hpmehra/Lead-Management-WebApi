namespace IC.LMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCompanyWebsitename : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompanyInfoes", "CompanyTinNo", c => c.Int());
            AddColumn("dbo.CompanyInfoes", "CompanyWebsite", c => c.String());
            DropColumn("dbo.CompanyInfoes", "ComapnyTinNo");
            DropColumn("dbo.CompanyInfoes", "ComapnyWebsite");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CompanyInfoes", "ComapnyWebsite", c => c.String());
            AddColumn("dbo.CompanyInfoes", "ComapnyTinNo", c => c.Int());
            DropColumn("dbo.CompanyInfoes", "CompanyWebsite");
            DropColumn("dbo.CompanyInfoes", "CompanyTinNo");
        }
    }
}
