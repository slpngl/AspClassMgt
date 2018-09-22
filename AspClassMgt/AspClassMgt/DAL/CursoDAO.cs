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
        private static Context ctx = Singleton.Instance.Context;

        public static List<Curso> ListarCursos()
        {
            return ctx.Curso.ToList();
        }

        public static void CadastrarCurso(Curso curso)
        {
            ctx.Curso.Add(curso);
            ctx.SaveChanges();
        }

        public static Curso BuscarCursoPorId(int? id)
        {
            return ctx.Curso.Find(id);
        }

        public static void EditarCurso(Curso curso)
        {
            ctx.Entry(curso).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public static void RemoverCurso(Curso curso)
        {
            ctx.Curso.Remove(curso);
            ctx.SaveChanges();
        }
    }
}