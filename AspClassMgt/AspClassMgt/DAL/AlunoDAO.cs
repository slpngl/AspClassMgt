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
        private  Context ctx = Singleton.Instance.Context;

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

        public Aluno EditarAluno(Aluno aluno)
        {
            ctx.Entry(aluno).State = EntityState.Modified;
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