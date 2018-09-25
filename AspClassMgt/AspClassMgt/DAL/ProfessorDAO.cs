using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AspClassMgt.Models;

namespace AspClassMgt.DAL
{
    public class ProfessorDAO
    {
        private static Context ctx = Singleton.Instance.Context;

        public static List<Professor> ListarProfessors()
        {
            return ctx.Professor.ToList();
        }

        public static List<Professor> ListaProfessorInstituicao(int idInstituicao)
        {
            List<Professor> professores = ListarProfessors();
            List<Professor> listaFiltrada = new List<Professor>();
            foreach (Professor a in professores)
            {
                if (a.instituicaoProfessor == idInstituicao)
                {
                    listaFiltrada.Add(a);
                }
            }
            return listaFiltrada;
        }



        public static void CadastrarProfessor(Professor professor)
        {
            ctx.Professor.Add(professor);
            ctx.SaveChanges();
        }

        public static Professor BuscarProfessorPorId(int? id)
        {
            return ctx.Professor.Find(id);
        }

        public static void EditarProfessor(Professor professor)
        {
            ctx.Entry(professor).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public static void RemoverProfessor(Professor professor)
        {
            ctx.Professor.Remove(professor);
            ctx.SaveChanges();
        }
    }
}