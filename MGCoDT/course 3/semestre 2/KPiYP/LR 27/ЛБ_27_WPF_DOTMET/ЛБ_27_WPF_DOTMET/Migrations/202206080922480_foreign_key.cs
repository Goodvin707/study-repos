namespace ЛБ_27_WPF_DOTMET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreign_key : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sessions", "StudentId", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "SessionId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "SessionId");
            DropColumn("dbo.Sessions", "StudentId");
        }
    }
}
