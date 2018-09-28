using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AspClassMgt.Models;

namespace AspClassMgt.DAL
{
    public class AlunoDAO
    {
        private  Context ctx = Singleton.Instance;

        public  IList<Aluno> ListarAlunos()
        {
            return ctx.Aluno.ToList();
        }

        public  IList<Aluno> ListaAlunoInstituicao(int? idInstituicao) {
            IList<Aluno> alunos = ListarAlunos();
            IList<Aluno> listaFiltrada = new List<Aluno>();
            foreach (Aluno a in alunos)
            {
                if (a.instituicaoAluno == idInstituicao) {
                    listaFiltrada.Add(a);
                }
            }
            return listaFiltrada;
        }

        public Boolean CadastrarAluno(Aluno aluno)
        {
            ctx.Aluno.Add(aluno);
            ctx.SaveChanges();
            return true;
        }

        public Aluno BuscarAlunoPorId(int? id)
        {
            return ctx.Aluno.Find(id);
        }

        public Aluno BuscarAlunoPorIdInstituicao(int? idAluno, int? idInstituicao)
        {
            IList<Aluno> alunos = ListarAlunos();
            Aluno alunoFiltrado = new Aluno();
            foreach (Aluno a in alunos)
            {
                if (a.instituicaoAluno == idInstituicao)
                {
                    if (a.IdAluno == idAluno) {
                        alunoFiltrado = a;
                    }
                }
            }
            return alunoFiltrado;
        }

        public Aluno EditarAluno(Aluno aluno)
        {
            Aluno a = ctx.Aluno.Find(aluno.IdAluno);
            a.Nome = aluno.Nome;
            a.Rua = aluno.Rua;
            a.Bairro = aluno.Bairro;
            a.Cidade = aluno.Cidade;
            a.UF = aluno.UF;  
            
            //ctx.Entry(aluno).CurrentValues.SetValues(aluno);
            ctx.Entry(a).State = EntityState.Modified;
            ctx.SaveChanges();
            return aluno;
        }

        public  Boolean RemoverAluno(Aluno aluno)
        {
            ctx.Aluno.Remove(aluno);
            ctx.SaveChanges();
            return true;
        }



    }
}