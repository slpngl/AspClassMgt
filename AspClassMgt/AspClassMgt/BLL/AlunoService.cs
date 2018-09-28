using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspClassMgt.DAL;
using AspClassMgt.Models;

namespace AspClassMgt.BLL
{
    public class AlunoService
    {
        AlunoDAO alunoDAO = new AlunoDAO();

        public  IList<Aluno> ListarAlunos() {
            return alunoDAO.ListarAlunos(); 
        }

        public IList<Aluno> ListarAlunosInstituicao(int? id) {
            return alunoDAO.ListaAlunoInstituicao(id);
        }

        public Boolean CadastrarAluno(Aluno aluno) {
            return alunoDAO.CadastrarAluno(aluno);
        }

        public Aluno BuscarAlunoPorId(int? id) {
            return alunoDAO.BuscarAlunoPorId(id);
        }

        public Aluno EditarAluno(Aluno aluno) {
            return alunoDAO.EditarAluno(aluno);
        }

        public Boolean RemoverAluno(Aluno aluno) {
            return alunoDAO.RemoverAluno(aluno);
        }

        public Aluno BuscarAlunoPorIdInstituicao(int idAluno, int idInstituicao) {
            return alunoDAO.BuscarAlunoPorIdInstituicao(idAluno, idInstituicao);
        }
    }
}