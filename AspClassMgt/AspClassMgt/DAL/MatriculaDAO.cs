using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AspClassMgt.Models;

namespace AspClassMgt.DAL
{
    public class MatriculaDAO
    {
        private Context ctx = Singleton.Instance;

        public IList<Matricula> ListarMatricula()
        {
            return ctx.Matricula.ToList();

        }

        public IList<Matricula> ListaMatriculaInstituicao(int? idInstituicao)
        {
            IList<Matricula> matriculas = ListarMatricula();
            IList<Matricula> listaFiltrada = new List<Matricula>();
            foreach (Matricula a in matriculas)
            {
                if (a.InstituicaoIDMatricula == idInstituicao)
                {
                    listaFiltrada.Add(a);
                }
            }
            return listaFiltrada;
        }

        public Boolean CadastrarMatricula(Matricula matricula)
        {
            ctx.Matricula.Add(matricula);
            ctx.SaveChanges();
            return true;
        }

        public Matricula BuscarMatriculaPorId(int? id)
        {
            return ctx.Matricula.Find(id);
        }

        public Matricula BuscarMatriculaPorIdInstituicao(int? idMatricula, int? idInstituicao)
        {
            IList<Matricula> matriculas = ListarMatricula();
            Matricula matriculaFiltrado = new Matricula();
            foreach (Matricula a in matriculas)
            {
                if (a.InstituicaoIDMatricula == idInstituicao)
                {
                    if (a.IdMatricula == idMatricula)
                    {
                        matriculaFiltrado = a;
                    }
                }
            }
            return matriculaFiltrado;
        }

        public Matricula EditarMatricula(Matricula matricula)
        {
            Matricula a = ctx.Matricula.Find(matricula.IdMatricula);
            a.AlunoIDMatricula = matricula.AlunoIDMatricula;
            a.AlunoMatricula = matricula.AlunoMatricula;
            a.CursoIDMatricula = matricula.CursoIDMatricula;
            a.CursoMatricula = matricula.CursoMatricula;
            a.InstituicaoMatricula = matricula.InstituicaoMatricula;
            a.InstituicaoIDMatricula = matricula.InstituicaoIDMatricula;
            ctx.Entry(a).State = EntityState.Modified;
            ctx.SaveChanges();
            return matricula;
        }

        public Boolean RemoverMatricula(Matricula matricula)
        {
            ctx.Matricula.Remove(matricula);
            ctx.SaveChanges();
            return true;
        }

    }
}

        