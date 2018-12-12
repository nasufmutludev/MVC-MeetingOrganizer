namespace MeetingOrganizerDATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0104001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Meetings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MeetingSubject = c.String(nullable: false),
                        RoomID = c.Int(nullable: false),
                        StartingTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Subscribers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(nullable: false, maxLength: 50),
                        MeetingID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Meetings", t => t.MeetingID)
                .Index(t => t.MeetingID);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoomName = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Mail = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subscribers", "MeetingID", "dbo.Meetings");
            DropIndex("dbo.Subscribers", new[] { "MeetingID" });
            DropTable("dbo.Users");
            DropTable("dbo.Rooms");
            DropTable("dbo.Subscribers");
            DropTable("dbo.Meetings");
        }
    }
}
