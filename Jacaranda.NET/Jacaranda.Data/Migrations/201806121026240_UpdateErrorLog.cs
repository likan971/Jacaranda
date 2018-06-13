namespace Jacaranda.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateErrorLog : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ErrorLogs", "Message", c => c.String());
            AlterColumn("dbo.ErrorLogs", "StackTrace", c => c.String(nullable: false));
            AlterColumn("dbo.ErrorLogs", "RequestUrl", c => c.String(maxLength: 200));
            AlterColumn("dbo.ErrorLogs", "RequestBody", c => c.String());
            CreateIndex("dbo.ErrorLogs", "RequestUrl", name: "IX_ErrorLog_RequestUrl");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ErrorLogs", "IX_ErrorLog_RequestUrl");
            AlterColumn("dbo.ErrorLogs", "RequestBody", c => c.String(maxLength: 500));
            AlterColumn("dbo.ErrorLogs", "RequestUrl", c => c.String(maxLength: 100));
            AlterColumn("dbo.ErrorLogs", "StackTrace", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.ErrorLogs", "Message", c => c.String(nullable: false, maxLength: 500));
        }
    }
}
