namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_added_newtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                        Password = c.String(maxLength: 50),
                        Role = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.AdminID);
            
            CreateTable(
                "dbo.ImageFiles",
                c => new
                    {
                        ImageFileID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.ImageFileID);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        SenderMail = c.String(),
                        ReceiverMail = c.String(),
                        Subject = c.String(),
                        MessageContent = c.String(),
                        MessageDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MessageID);
            
            AddColumn("dbo.Abouts", "AboutStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Abouts", "AboutStatus");
            DropTable("dbo.Messages");
            DropTable("dbo.ImageFiles");
            DropTable("dbo.Admins");
        }
    }
}
