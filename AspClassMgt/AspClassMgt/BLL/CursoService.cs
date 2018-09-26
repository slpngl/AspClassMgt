using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspClassMgt.DAL;
using AspClassMgt.Models;

namespace AspClassMgt.BLL
{
    public class CursoService
    {
        CursoDAO cursoDAO = new CursoDAO();

        public IList<Curso> ListarCursos() {
            return cursoDAO.ListarCursos();
        }

        public IList<Curso> ListaCursoInstituicao(int idInstituicao) {
            return cursoDAO.ListaCursoInstituicao(idInstituicao);
        }

        public Curso BuscarCursoPorId(int? id)
        {
            return cursoDAO.BuscarCursoPorId(id);
        }

        public Boolean CadastrarCurso(Curso curso) {
            return cursoDAO.CadastrarCurso(curso);
        }

        public Curso EditarCurso(Curso curso)
        {
            return cursoDAO.EditarCurso(curso);
        }

        public Boolean RemoverCurso(Curso curso) {
            return cursoDAO.RemoverCurso(curso);
        } 



    }
}