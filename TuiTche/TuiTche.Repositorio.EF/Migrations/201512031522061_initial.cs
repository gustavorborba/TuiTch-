namespace TwiTche.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sexo",
                c => new
                {
                    Id = c.Int(nullable: false, identity: false),
                    Sexo = c.String(nullable: false)
                })
                .PrimaryKey(t => t.Id);
            Sql("INSERT INTO Sexo (Id, Sexo) values (1, 'MASCULINO')");
            Sql("INSERT INTO Sexo (Id, Sexo) values (2, 'FEMININO')");

            CreateTable(
                "dbo.Usuario",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Username = c.String(nullable: false, maxLength: 50),
                    NomeCompleto = c.String(nullable: false, maxLength: 128),
                    Email = c.String(nullable: false, maxLength: 128),
                    Senha = c.String(nullable: false, maxLength: 64),
                    IdSexoUsuario = c.Int(nullable: false),
                    Foto = c.String(maxLength: 128),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sexo", t => t.IdSexoUsuario)
                .Index(t => t.Username, "UK_Usuario_Username", true)
                .Index(t => t.Email, "UK_Usuario_Email", true)
                .Index(t => t.NomeCompleto, "UK_Usuario_NomeCompleto");

            CreateTable(
                "dbo.Seguidores",
                c => new
                {
                    IdSeguidores = c.Int(nullable: false, identity: true),
                    IdSeguidor = c.Int(nullable: false),
                    IdSeguindo = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.IdSeguidores })
                .ForeignKey("dbo.Usuario", t => t.IdSeguidor)
                .ForeignKey("dbo.Usuario", t => t.IdSeguindo)
                .Index(t => t.IdSeguidor)
                .Index(t => t.IdSeguindo);
            CreateIndex("dbo.Seguidores", new string[2] { "IdSeguidor", "IdSeguindo" },
              true, "UK_Seguidores_IdSeguidor_IdSeguindo");

            CreateTable(
                "dbo.Compartilhar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataCompartilhamento = c.DateTime(nullable: false),
                        IdPublicacao = c.Int(nullable: false),
                        IdUsuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Publicacao", t => t.IdPublicacao, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.IdUsuario)
                .Index(t => t.IdPublicacao)
                .Index(t => t.IdUsuario);
            
            CreateTable(
                "dbo.Publicacao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 288),
                        DataPublicacao = c.DateTime(nullable: false),
                        IdUsuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.IdUsuario)
                .Index(t => t.IdUsuario);

            
            CreateTable(
                "dbo.Pontuacao",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        PontuacaoTotal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Curtir",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IDPublicacao = c.Int(nullable: false),
                        IDUsuario = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Publicacao", t => t.IDPublicacao, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.IDUsuario, cascadeDelete: true)
                .Index(t => t.IDPublicacao)
                .Index(t => t.IDUsuario);
            
            CreateTable(
                "dbo.Hashtag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Palavra = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            DropForeignKey("dbo.Curtir", "IDUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Curtir", "IDPublicacao", "dbo.Publicacao");
            DropForeignKey("dbo.Compartilhar", "IdUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Compartilhar", "IdPublicacao", "dbo.Publicacao");
            DropForeignKey("dbo.Publicacao", "IdUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Seguidores", "IdSeguindo", "dbo.Usuario");
            DropForeignKey("dbo.Seguidores", "IdSeguidor", "dbo.Usuario");
            DropForeignKey("dbo.Pontuacao", "Id", "dbo.Usuario");
            DropIndex("dbo.Seguidores", new[] { "IdSeguindo" });
            DropIndex("dbo.Seguidores", new[] { "IdSeguidor" });
            DropIndex("dbo.PalavraGauderia", new[] { "IDHashtag" });
            DropIndex("dbo.Curtir", new[] { "IDUsuario" });
            DropIndex("dbo.Curtir", new[] { "IDPublicacao" });
            DropIndex("dbo.Pontuacao", new[] { "Id" });
            DropIndex("dbo.Publicacao", new[] { "IdUsuario" });
            DropIndex("dbo.Compartilhar", new[] { "IdUsuario" });
            DropIndex("dbo.Compartilhar", new[] { "IdPublicacao" });
            DropTable("dbo.Seguidores");
            DropTable("dbo.PalavraGauderia");
            DropTable("dbo.Hashtag");
            DropTable("dbo.Curtir");
            DropTable("dbo.Pontuacao");
            DropTable("dbo.Usuario");
            DropTable("dbo.Publicacao");
            DropTable("dbo.Compartilhar");
        }
    }
}
