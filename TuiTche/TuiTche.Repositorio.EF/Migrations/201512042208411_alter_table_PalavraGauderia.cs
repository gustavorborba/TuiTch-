namespace TwiTche.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alter_table_PalavraGauderia : DbMigration
    {
        public override void Up()
        {

            AlterColumn("dbo.PalavraGauderia", "QtdUtilizacao", c => c.Int(nullable: true, defaultValue: 0));
        }
        
        public override void Down()
        {
        }
    }
}
