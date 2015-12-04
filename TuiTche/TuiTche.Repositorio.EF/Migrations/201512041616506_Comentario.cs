namespace TwiTche.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Comentario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cometario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Texto = c.String(nullable: false, maxLength: 288),
                        IdPublicacao = c.Int(nullable: false),
                        IdUsuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Publicacao", t => t.IdPublicacao, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.IdUsuario, cascadeDelete: false)
                .Index(t => t.IdPublicacao)
                .Index(t => t.IdUsuario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cometario", "IdUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Cometario", "IdPublicacao", "dbo.Publicacao");
            DropIndex("dbo.Cometario", new[] { "IdUsuario" });
            DropIndex("dbo.Cometario", new[] { "IdPublicacao" });
            DropTable("dbo.Cometario");
        }
    }
}
