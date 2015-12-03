namespace TwiTche.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rename_columns : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Publicacao", new[] { "IDUsuario" });
            CreateIndex("dbo.Publicacao", "IdUsuario");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Publicacao", new[] { "IdUsuario" });
            CreateIndex("dbo.Publicacao", "IDUsuario");
        }
    }
}
