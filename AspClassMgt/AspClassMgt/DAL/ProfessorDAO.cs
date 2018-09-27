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
            Professor p = ctx.Professor.Find(professor.IdProfessor);

            p.NomeProfessor = professor.NomeProfessor;
            p.instituicaoProfessor = professor.instituicaoProfessor;
            p.Formacao = professor.Formacao;
            p.Rua = professor.Rua;
            p.Bairro = professor.Bairro;
            p.Cidade = professor.Cidade;
            p.UF = professor.UF;
           // ctx.Entry(professor).State = EntityState.Modified;
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
