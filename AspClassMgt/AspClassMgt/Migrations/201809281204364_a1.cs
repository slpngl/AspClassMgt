namespace AspClassMgt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Matricula",
                c => new
                    {
                        IdMatricula = c.Int(nullable: false, identity: true),
                        InstituicaoIDMatricula = c.Int(nullable: false),
                        AlunoIDMatricula = c.Int(nullable: false),
                        CursoIDMatricula = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdMatricula);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Matricula");
        }
    }
}
