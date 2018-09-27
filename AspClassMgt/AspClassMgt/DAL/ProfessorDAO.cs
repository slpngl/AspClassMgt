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
        private  Context ctx = Singleton.Instance;

        public  List<Professor> ListarProfessors()
        {
            return ctx.Professor.ToList();
        }

        public IList<Professor> ListarProfessorInstituicao(int id)
        {
            IList<Professor> professores = ListarProfessors();
            IList<Professor> listaFiltrada = new List<Professor>();
            foreach (Professor a in professores)
            {
                if (a.instituicaoProfessor == id)
                {
                    listaFiltrada.Add(a);
                }
            }
            return listaFiltrada;
        }

        public  Boolean CadastrarProfessor(Professor professor)
        {
            ctx.Professor.Add(professor);
            ctx.SaveChanges();
            return true;
        }

        public Professor EditarProfessor(Professor professor)
        {
            ctx.Entry(professor).CurrentValues.SetValues(professor);
            ctx.Entry(professor).State = EntityState.Modified;
            ctx.SaveChanges();
            return professor;
        }

        public Boolean RemoverProfessor(Professor professor)
        {
            ctx.Professor.Remove(professor);
            ctx.SaveChanges();
            return true;
        }

        public Professor BuscarProfessorPorId(int? id)
        {
            return ctx.Professor.Find(id);
        }

   
     
        }
    }
