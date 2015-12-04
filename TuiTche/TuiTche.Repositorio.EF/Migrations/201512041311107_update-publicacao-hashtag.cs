namespace TwiTche.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatepublicacaohashtag : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PublicacaoHashtags",
                c => new
                    {
                        IdHashtag = c.Int(nullable: false),
                        IdPublicacao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdHashtag, t.IdPublicacao })
                .ForeignKey("dbo.Hashtag", t => t.IdHashtag, cascadeDelete: true)
                .ForeignKey("dbo.Publicacao", t => t.IdPublicacao, cascadeDelete: true)
                .Index(t => t.IdHashtag)
                .Index(t => t.IdPublicacao);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PublicacaoHashtags", "IdPublicacao", "dbo.Publicacao");
            DropForeignKey("dbo.PublicacaoHashtags", "IdHashtag", "dbo.Hashtag");
            DropIndex("dbo.PublicacaoHashtags", new[] { "IdPublicacao" });
            DropIndex("dbo.PublicacaoHashtags", new[] { "IdHashtag" });
            DropTable("dbo.PublicacaoHashtags");
        }
    }
}
