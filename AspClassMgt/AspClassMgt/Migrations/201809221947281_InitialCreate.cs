namespace AspClassMgt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aluno",
                c => new
                    {
                        IdAluno = c.Int(nullable: false, identity: true),
                        instituicaoAluno = c.Int(nullable: false),
                        Nome = c.String(),
                        Endereco = c.String(),
                    })
                .PrimaryKey(t => t.IdAluno);
            
            CreateTable(
                "dbo.Curso",
                c => new
                    {
                        IdCurso = c.Int(nullable: false, identity: true),
                        instituicaoCurso = c.Int(nullable: false),
                        NomeCurso = c.String(),
                        CargaHoraria = c.String(),
                        CursoProfessor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCurso);
            
            CreateTable(
                "dbo.Instituicao",
                c => new
                    {
                        IdInstituicao = c.Int(nullable: false, identity: true),
                        nomeInstituicao = c.String(),
                        lgnInstituicao = c.String(),
                        snhInstituicao = c.String(),
                    })
                .PrimaryKey(t => t.IdInstituicao);
            
            CreateTable(
                "dbo.Professor",
                c => new
                    {
                        IdProfessor = c.Int(nullable: false, identity: true),
                        instituicaoProfessor = c.Int(nullable: false),
                        NomeProfessor = c.String(),
                        Formacao = c.String(),
                    })
                .PrimaryKey(t => t.IdProfessor);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Professor");
            DropTable("dbo.Instituicao");
            DropTable("dbo.Curso");
            DropTable("dbo.Aluno");
        }
    }
}
