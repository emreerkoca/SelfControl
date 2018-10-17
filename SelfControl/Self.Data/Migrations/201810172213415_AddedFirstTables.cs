namespace Self.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFirstTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OriginalWord = c.String(),
                        TranslatedWord = c.String(),
                        Sentence = c.String(),
                        RegistrationDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(maxLength: 150),
                        RegistrationDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Sentence",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SentenceContent = c.String(maxLength: 140),
                        RegistrationDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 50),
                        RegistrationDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Role_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Role", t => t.Role_ID)
                .Index(t => t.Role_ID);
            
            CreateTable(
                "dbo.Word",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OriginalWord = c.String(nullable: false, maxLength: 50),
                        TranslatedWord = c.String(nullable: false, maxLength: 50),
                        ViewCount = c.Int(nullable: false),
                        RegistrationDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Sentence_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Sentence", t => t.Sentence_ID)
                .Index(t => t.Sentence_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Word", "Sentence_ID", "dbo.Sentence");
            DropForeignKey("dbo.User", "Role_ID", "dbo.Role");
            DropIndex("dbo.Word", new[] { "Sentence_ID" });
            DropIndex("dbo.User", new[] { "Role_ID" });
            DropTable("dbo.Word");
            DropTable("dbo.User");
            DropTable("dbo.Sentence");
            DropTable("dbo.Role");
            DropTable("dbo.Notifications");
        }
    }
}
