namespace AspClassMgt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enderecoProfessor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Professor", "Rua", c => c.String());
            AddColumn("dbo.Professor", "Bairro", c => c.String());
            AddColumn("dbo.Professor", "Cidade", c => c.String());
            AddColumn("dbo.Professor", "UF", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Professor", "UF");
            DropColumn("dbo.Professor", "Cidade");
            DropColumn("dbo.Professor", "Bairro");
            DropColumn("dbo.Professor", "Rua");
        }
    }
}
