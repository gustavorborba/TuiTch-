namespace TwiTche.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class curtir : DbMigration
    {
        public override void Up()
        {
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
                .Index(t => t.IDPublicacao);


                CreateIndex("dbo.Curtir", new string[2] { "IDPublicacao", "IDUsuario" },
                true, "UK_Curtir_IDPublicacao_IDUsuario");

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Curtir", "IDUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Curtir", "IDPublicacao", "dbo.Publicacao");
            DropIndex("dbo.Curtir", new string[2] { "IDPublicacao", "IDUsuario" });
            DropIndex("dbo.Curtir", new[] { "IDUsuario" });
            DropIndex("dbo.Curtir", new[] { "IDPublicacao" });
            DropTable("dbo.Curtir");
        }
    }
}
