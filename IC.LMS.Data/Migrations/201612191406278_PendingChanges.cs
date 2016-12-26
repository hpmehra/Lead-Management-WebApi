namespace IC.LMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PendingChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documents", "FK_PrimaryID", c => c.Int(nullable: false));
            AlterColumn("dbo.CompanyInfoes", "TimeZone", c => c.Int(nullable: false));
            AlterColumn("dbo.Projects", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Projects", "CompletionDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Projects", "DeadLine", c => c.DateTime(nullable: false));
          //  DropColumn("dbo.Documents", "DocumentType");
        }
        
        public override void Down()
        {
          //  AddColumn("dbo.Documents", "DocumentType", c => c.String());
            AlterColumn("dbo.Projects", "DeadLine", c => c.DateTime());
            AlterColumn("dbo.Projects", "CompletionDate", c => c.DateTime());
            AlterColumn("dbo.Projects", "StartDate", c => c.DateTime());
            AlterColumn("dbo.CompanyInfoes", "TimeZone", c => c.String());
            DropColumn("dbo.Documents", "FK_PrimaryID");
        }
    }
}
