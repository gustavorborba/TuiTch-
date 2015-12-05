namespace TwiTche.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefatoradoComentario : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Cometario", newName: "Comentario");
            AddColumn("dbo.Comentario", "DataComentario", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comentario", "DataComentario");
            RenameTable(name: "dbo.Comentario", newName: "Cometario");
        }
    }
}
