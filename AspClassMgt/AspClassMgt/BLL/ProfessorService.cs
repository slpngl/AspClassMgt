using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspClassMgt.DAL;
using AspClassMgt.Models;

namespace AspClassMgt.BLL
{
    public class ProfessorService
    {
        ProfessorDAO professorDAO = new ProfessorDAO();

        public IList<Professor> ListarProfessor()
        {
            return professorDAO.ListarProfessors();
        }

        public IList<Professor> ListarProfessorInstituicao(int id)
        {
            return professorDAO.ListarProfessorInstituicao(id);
        }

        public Boolean CadastrarProfessor(Professor professor) {
            //Aqui vão as regras de negocio (não cadastrar com mesmo nome...etc);
            return professorDAO.CadastrarProfessor(professor);
        }

        public Professor EditarProfessor(Professor professor)
        {
            return professorDAO.EditarProfessor(professor);
        }

        public Boolean RemoverProfessor(Professor professor)
        {
            //Aqui vão as regras de negocio (não cadastrar com mesmo nome...etc);
            return professorDAO.RemoverProfessor(professor);
        }

        public Professor BuscarProfessorId(int? id) {
            return professorDAO.BuscarProfessorPorId(id);
        }

    }
}


