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
                "dbo.Hashtag",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Palavra = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);

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

        }

        public override void Down()
        {
            DropForeignKey("dbo.Usuario", "IdSexoUsuario", "dbo.Sexo");
            DropForeignKey("dbo.Seguidores", "IdSeguindo", "dbo.Usuario");
            DropForeignKey("dbo.Seguidores", "IdSeguidor", "dbo.Usuario");
            DropIndex("dbo.Seguidores", new[] { "IdSeguindo" });
            DropIndex("dbo.Seguidores", new[] { "IdSeguidor" });
            DropTable("dbo.Seguidores");
            DropTable("dbo.Usuario");
            DropTable("dbo.Hashtag");
        }
    }
}
