namespace TwiTche.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usuarioseguidores : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Seguidores",
                c => new
                    {
                        IdSeguidores = c.Int(nullable: false, identity: true),
                        IdSeguidor = c.Int(nullable: false),
                        IdSeguindo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdSeguidores)
                .ForeignKey("dbo.Usuario", t => t.IdSeguidor)
                .ForeignKey("dbo.Usuario", t => t.IdSeguindo)
                .Index(t => t.IdSeguidor)
                .Index(t => t.IdSeguindo);

            CreateIndex("dbo.Seguidores", new string[2] { "IdSeguidor", "IdSeguindo" },
                true, "UK_Seguidores_IdSeguidor_IdSeguindo");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seguidores", "IdSeguindo", "dbo.Usuario");
            DropForeignKey("dbo.Seguidores", "IdSeguidor", "dbo.Usuario");
            DropIndex("dbo.Seguidores", new string[2] { "IdSeguidor", "IdSeguindo" });
            DropIndex("dbo.Seguidores", new[] { "IdSeguindo" });
            DropIndex("dbo.Seguidores", new[] { "IdSeguidor" });
            DropTable("dbo.Seguidores");
        }
    }
}
