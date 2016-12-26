namespace IC.LMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompanyInfoNewChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompanyInfoes", "EnggOwner", c => c.Int());
            AddColumn("dbo.CompanyInfoes", "SalesOwner", c => c.Int());
            AddColumn("dbo.CompanyInfoes", "Tags", c => c.String());
            AddColumn("dbo.CompanyInfoes", "Unavaible", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CompanyInfoes", "Unavaible");
            DropColumn("dbo.CompanyInfoes", "Tags");
            DropColumn("dbo.CompanyInfoes", "SalesOwner");
            DropColumn("dbo.CompanyInfoes", "EnggOwner");
        }
    }
}
