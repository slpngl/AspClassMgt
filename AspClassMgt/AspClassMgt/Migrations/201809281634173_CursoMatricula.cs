namespace AspClassMgt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CursoMatricula : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matricula", "CursoMatricula_IdCurso", c => c.Int());
            CreateIndex("dbo.Matricula", "CursoMatricula_IdCurso");
            AddForeignKey("dbo.Matricula", "CursoMatricula_IdCurso", "dbo.Curso", "IdCurso");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matricula", "CursoMatricula_IdCurso", "dbo.Curso");
            DropIndex("dbo.Matricula", new[] { "CursoMatricula_IdCurso" });
            DropColumn("dbo.Matricula", "CursoMatricula_IdCurso");
        }
    }
}
