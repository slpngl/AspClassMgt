using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AspClassMgt.Models;

namespace AspClassMgt.DAL
{
    public class CursoDAO
    {
        private  Context ctx = Singleton.Instance.Context;

        public  IList<Curso> ListarCursos()
        {
            return ctx.Curso.ToList();
        }

        public  IList<Curso> ListaCursoInstituicao(int idInstituicao)
        {
            IList<Curso> cursos = ListarCursos();
            List<Curso> listaFiltrada = new List<Curso>();
            foreach (Curso a in cursos)
            {
                if (a.instituicaoCurso == idInstituicao)
                {
                    listaFiltrada.Add(a);
                }
            }
            return listaFiltrada;
        }

        public  Boolean CadastrarCurso(Curso curso)
        {
            ctx.Curso.Add(curso);
            ctx.SaveChanges();
            return true;
        }

        public  Curso BuscarCursoPorId(int? id)
        {
            return ctx.Curso.Find(id);
        }

        public  Curso EditarCurso(Curso curso)
        {
            ctx.Entry(curso).State = EntityState.Modified;
            ctx.SaveChanges();
            return curso;
        }

        public  Boolean RemoverCurso(Curso curso)
        {
            ctx.Curso.Remove(curso);
            ctx.SaveChanges();
            return true;
        }
    }
}