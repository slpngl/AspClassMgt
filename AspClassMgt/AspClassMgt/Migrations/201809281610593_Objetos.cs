namespace AspClassMgt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Objetos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Curso", "CursoProfessorO_IdProfessor", c => c.Int());
            AddColumn("dbo.Matricula", "AlunoMatricula_IdAluno", c => c.Int());
            AddColumn("dbo.Matricula", "InstituicaoMatricula_IdInstituicao", c => c.Int());
            CreateIndex("dbo.Curso", "CursoProfessorO_IdProfessor");
            CreateIndex("dbo.Matricula", "AlunoMatricula_IdAluno");
            CreateIndex("dbo.Matricula", "InstituicaoMatricula_IdInstituicao");
            AddForeignKey("dbo.Curso", "CursoProfessorO_IdProfessor", "dbo.Professor", "IdProfessor");
            AddForeignKey("dbo.Matricula", "AlunoMatricula_IdAluno", "dbo.Aluno", "IdAluno");
            AddForeignKey("dbo.Matricula", "InstituicaoMatricula_IdInstituicao", "dbo.Instituicao", "IdInstituicao");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matricula", "InstituicaoMatricula_IdInstituicao", "dbo.Instituicao");
            DropForeignKey("dbo.Matricula", "AlunoMatricula_IdAluno", "dbo.Aluno");
            DropForeignKey("dbo.Curso", "CursoProfessorO_IdProfessor", "dbo.Professor");
            DropIndex("dbo.Matricula", new[] { "InstituicaoMatricula_IdInstituicao" });
            DropIndex("dbo.Matricula", new[] { "AlunoMatricula_IdAluno" });
            DropIndex("dbo.Curso", new[] { "CursoProfessorO_IdProfessor" });
            DropColumn("dbo.Matricula", "InstituicaoMatricula_IdInstituicao");
            DropColumn("dbo.Matricula", "AlunoMatricula_IdAluno");
            DropColumn("dbo.Curso", "CursoProfessorO_IdProfessor");
        }
    }
}
