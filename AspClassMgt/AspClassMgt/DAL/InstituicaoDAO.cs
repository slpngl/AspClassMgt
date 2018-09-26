using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AspClassMgt.Models;

namespace AspClassMgt.DAL
{
    public class InstituicaoDAO
    {
        private Context ctx = Singleton.Instance.Context;

        public  IList<Instituicao> ListarInstituicao()
        {
            return ctx.Instituicao.ToList();
        }

        public Boolean CadastrarInstituicao(Instituicao instituicao)
        {
            ctx.Instituicao.Add(instituicao);
            ctx.SaveChanges();
            return true;

        }

        public  Instituicao BuscarInstituicaoPorId(int? id)
        {
            return ctx.Instituicao.Find(id);
        }

        public Instituicao EditarInstituicao(Instituicao instituicao)
        {
            ctx.Entry(instituicao).State = EntityState.Modified;
            ctx.SaveChanges();
            return instituicao;
        }

        public  Boolean RemoverInstituicao(Instituicao instituicao)
        {
            ctx.Instituicao.Remove(instituicao);
            ctx.SaveChanges();
            return true;
        }

    }
}