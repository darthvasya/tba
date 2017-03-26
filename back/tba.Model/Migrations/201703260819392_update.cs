namespace tba.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RefreshTokens", "Subject", c => c.String(maxLength: 50));
            AlterColumn("dbo.RefreshTokens", "ClientId", c => c.String(maxLength: 50));
            AlterColumn("dbo.RefreshTokens", "ProtectedTicket", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RefreshTokens", "ProtectedTicket", c => c.String(nullable: false));
            AlterColumn("dbo.RefreshTokens", "ClientId", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.RefreshTokens", "Subject", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
