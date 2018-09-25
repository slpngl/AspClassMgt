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
        private static Context ctx = Singleton.Instance.Context;

        public static List<Aluno> ListarAlunos()
        {
            return ctx.Aluno.ToList();
        }

        public static List<Aluno> ListaAlunoInstituicao(int idInstituicao) {
            List<Aluno> alunos = ListarAlunos();
            List<Aluno> listaFiltrada = new List<Aluno>();
            foreach (Aluno a in alunos)
            {
                if (a.instituicaoAluno == idInstituicao) {
                    listaFiltrada.Add(a);
                }
            }
            return listaFiltrada;
        }

        public static void CadastrarAluno(Aluno aluno)
        {
            ctx.Aluno.Add(aluno);
            ctx.SaveChanges();
        }

        public static Aluno BuscarAlunoPorId(int? id)
        {
            return ctx.Aluno.Find(id);
        }

        public static void EditarAluno(Aluno aluno)
        {
            ctx.Entry(aluno).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public static void RemoverAluno(Aluno aluno)
        {
            ctx.Aluno.Remove(aluno);
            ctx.SaveChanges();
        }



    }
}