namespace TwiTche.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Publicacao", "IdUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Compartilhar", "IdUsuario", "dbo.Usuario");
            AddForeignKey("dbo.Publicacao", "IdUsuario", "dbo.Usuario", "Id");
            AddForeignKey("dbo.Compartilhar", "IdUsuario", "dbo.Usuario", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Compartilhar", "IdUsuario", "dbo.Usuario");
            DropForeignKey("dbo.Publicacao", "IdUsuario", "dbo.Usuario");
            AddForeignKey("dbo.Compartilhar", "IdUsuario", "dbo.Usuario", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Publicacao", "IdUsuario", "dbo.Usuario", "Id", cascadeDelete: true);
        }
    }
}
