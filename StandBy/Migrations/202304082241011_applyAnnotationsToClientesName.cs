namespace StandBy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class applyAnnotationsToClientesName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "Nome", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clientes", "Nome", c => c.String());
        }
    }
}
