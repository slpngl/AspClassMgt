using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspClassMgt.Models;
using AspClassMgt.DAL;

namespace AspClassMgt.BLL
{
    public class MatriculaService
    {
        MatriculaDAO matriculaDAO = new MatriculaDAO();

        public IList<Matricula> ListarMatriculas()
        {
            return matriculaDAO.ListarMatricula();
        }

        public IList<Matricula> ListaMatriculaInstituicao(int? idInstituicao)
        {
            return matriculaDAO.ListaMatriculaInstituicao(idInstituicao);
        }

        public Boolean CadastrarMatricula(Matricula matricula)
        {
            return matriculaDAO.CadastrarMatricula(matricula);
        }

        public Matricula BuscarMatriculaPorIdInstituicao(int? idMatricula, int? idInstituicao)
        {
            return matriculaDAO.BuscarMatriculaPorIdInstituicao(idMatricula, idInstituicao);
        }

        public Matricula BuscarMatriculaPorId(int? idMatricula) {
            return matriculaDAO.BuscarMatriculaPorId(idMatricula);
        }

        public Boolean RemoverMatricula(Matricula matricula)
        {
            return matriculaDAO.RemoverMatricula(matricula);
        }
    }
}