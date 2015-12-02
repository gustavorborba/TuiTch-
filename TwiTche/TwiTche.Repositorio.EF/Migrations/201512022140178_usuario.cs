namespace TwiTche.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usuario : DbMigration
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
                        Nome_Completo = c.String(nullable: false, maxLength: 128),
                        Email = c.String(nullable: false, maxLength: 128),
                        Senha = c.String(nullable: false, maxLength: 64),
                        IdSexoUsuario = c.Int(nullable: false),
                        Foto = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sexo", t => t.IdSexoUsuario)
                .Index(t => t.Username, "UK_Usuario_Username", true)
                .Index(t => t.Email, "UK_Usuario_Email", true)
                .Index(t => t.Nome_Completo, "UK_Usuario_Nome_Completo");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuario", "IdSexoUsuario", "dbo.Sexo");
            DropTable("dbo.Usuario");
            DropTable("dbo.Sexo");
        }
    }
}
