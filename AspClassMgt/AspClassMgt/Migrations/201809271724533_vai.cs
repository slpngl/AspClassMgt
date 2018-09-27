namespace AspClassMgt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vai : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aluno", "Rua", c => c.String());
            AddColumn("dbo.Aluno", "Bairro", c => c.String());
            AddColumn("dbo.Aluno", "Cidade", c => c.String());
            AddColumn("dbo.Aluno", "UF", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Aluno", "UF");
            DropColumn("dbo.Aluno", "Cidade");
            DropColumn("dbo.Aluno", "Bairro");
            DropColumn("dbo.Aluno", "Rua");
        }
    }
}
