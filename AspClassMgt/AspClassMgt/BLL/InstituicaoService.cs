using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspClassMgt.DAL;
using AspClassMgt.Models;

namespace AspClassMgt.BLL
{
    public class InstituicaoService
    {
        InstituicaoDAO instituicaoDAO = new InstituicaoDAO();

        public IList<Instituicao> ListarInstituicao() {
            return instituicaoDAO.ListarInstituicao();
        }

        public Boolean CadastrarInstituicao(Instituicao instituicao) {
            return instituicaoDAO.CadastrarInstituicao(instituicao);
        }

        public Instituicao BuscarInstituicaoPorId(int? id) {
            return instituicaoDAO.BuscarInstituicaoPorId(id);
        }

        public Instituicao EditarInstituicao(Instituicao instituicao) {
            return instituicaoDAO.EditarInstituicao(instituicao);
        }

        public Boolean RemoverInstituicao(Instituicao instituicao) {
            return instituicaoDAO.RemoverInstituicao(instituicao);
        }

    }

}