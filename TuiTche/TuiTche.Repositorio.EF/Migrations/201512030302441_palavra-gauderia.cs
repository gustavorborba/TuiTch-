namespace TwiTche.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class palavragauderia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PalavraGauderia",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IDHashtag = c.Int(nullable: false),
                        QtdUtilizacao = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hashtag", t => t.IDHashtag, cascadeDelete: true)
                .Index(t => t.IDHashtag);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PalavraGauderia", "IDHashtag", "dbo.Hashtag");
            DropIndex("dbo.PalavraGauderia", new[] { "IDHashtag" });
            DropTable("dbo.PalavraGauderia");
        }
    }
}
