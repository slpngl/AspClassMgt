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
        private static Context ctx = Singleton.Instance.Context;

        public static List<Instituicao> ListarInstituicao()
        {
            return ctx.Instituicao.ToList();
        }

        public static void CadastrarInstituicao(Instituicao instituicao)
        {
            ctx.Instituicao.Add(instituicao);
            ctx.SaveChanges();
        }

        public static Instituicao BuscarInstituicaoPorId(int? id)
        {
            return ctx.Instituicao.Find(id);
        }

        public static void EditarInstituicao(Instituicao instituicao)
        {
            ctx.Entry(instituicao).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public static void RemoverInstituicao(Instituicao instituicao)
        {
            ctx.Instituicao.Remove(instituicao);
            ctx.SaveChanges();
        }

        public static Instituicao AutenticarLogin(string lgn, string snh) {
            Instituicao instituicaoLogada = new Instituicao();
    
            List < Instituicao > lista = ListarInstituicao();
            foreach (Instituicao i in lista)
            {
                if (i.lgnInstituicao.Equals(lgn)) {
                    if (i.snhInstituicao.Equals(snh)) {
                        instituicaoLogada = i;
                    }
                }                                   

            }
            return instituicaoLogada;
        }
    }
}