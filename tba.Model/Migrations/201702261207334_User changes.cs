namespace tba.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Userchanges : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Users");
            AddColumn("dbo.Users", "PasswordHash", c => c.String());
            AddColumn("dbo.Users", "Email", c => c.String());
            AddColumn("dbo.Users", "EmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "PhoneNumber", c => c.String());
            AddColumn("dbo.Users", "PhoneConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "DateRegistration", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "AccessFailedCount", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Users", "UserName", c => c.String(maxLength: 14));
            AddPrimaryKey("dbo.Users", "Id");
            DropColumn("dbo.Users", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Password", c => c.String());
            DropPrimaryKey("dbo.Users");
            AlterColumn("dbo.Users", "UserName", c => c.String());
            AlterColumn("dbo.Users", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Users", "AccessFailedCount");
            DropColumn("dbo.Users", "DateRegistration");
            DropColumn("dbo.Users", "PhoneConfirmed");
            DropColumn("dbo.Users", "PhoneNumber");
            DropColumn("dbo.Users", "EmailConfirmed");
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.Users", "PasswordHash");
            AddPrimaryKey("dbo.Users", "Id");
        }
    }
}
