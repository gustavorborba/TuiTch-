namespace TwiTche.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Compartilhar", "IdPublicacao", "dbo.Publicacao");
            DropForeignKey("dbo.Compartilhar", "IdUsuario", "dbo.Usuario");
            AddColumn("dbo.Compartilhar", "Publicacao_Id", c => c.Int());
            AddColumn("dbo.Compartilhar", "Usuario_Id", c => c.Int());
            CreateIndex("dbo.Compartilhar", "Publicacao_Id");
            CreateIndex("dbo.Compartilhar", "Usuario_Id");
            AddForeignKey("dbo.Compartilhar", "Publicacao_Id", "dbo.Publicacao", "Id");
            AddForeignKey("dbo.Compartilhar", "Usuario_Id", "dbo.Usuario", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Compartilhar", "Usuario_Id", "dbo.Usuario");
            DropForeignKey("dbo.Compartilhar", "Publicacao_Id", "dbo.Publicacao");
            DropIndex("dbo.Compartilhar", new[] { "Usuario_Id" });
            DropIndex("dbo.Compartilhar", new[] { "Publicacao_Id" });
            DropColumn("dbo.Compartilhar", "Usuario_Id");
            DropColumn("dbo.Compartilhar", "Publicacao_Id");
            AddForeignKey("dbo.Compartilhar", "IdUsuario", "dbo.Usuario", "Id");
            AddForeignKey("dbo.Compartilhar", "IdPublicacao", "dbo.Publicacao", "Id", cascadeDelete: true);
        }
    }
}
