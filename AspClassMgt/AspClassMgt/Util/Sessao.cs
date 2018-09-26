using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspClassMgt.BLL;
using AspClassMgt.Models;

namespace AspClassMgt.Util
{
    public class Sessao : HttpSessionStateBase
    {
        InstituicaoService instituicaoService = new InstituicaoService();

        public bool AutenticarLogin(string lgn, string snh) {
            IList<Instituicao> lista = instituicaoService.ListarInstituicao();
            foreach (Instituicao i in lista)
            {
                if (i.lgnInstituicao.Equals(lgn))
                {
                    if (i.snhInstituicao.Equals(snh))
                    {
                        int idint = i.IdInstituicao;
                        string nome = i.nomeInstituicao;
                        string id = Convert.ToString(idint);
                        HttpContext.Current.Session.Add("instituicaoLogadaID", id);
                        HttpContext.Current.Session.Add("instituicaoLogadaNome", nome);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool EncerrarSessao() {
            
            HttpContext.Current.Session.Remove("instituicaoLogadaID");
            HttpContext.Current.Session.Remove("instituicaoLogadaNome");
            HttpContext.Current.Session.Abandon();
            return true;
        }

        public int RetornarID() {
            string id = HttpContext.Current.Session["instituicaoLogadaID"].ToString();
            int idInt = Convert.ToInt32(id);
            return idInt;
        }

        public string RetornarIntituicaoNome() {
            string nome =  HttpContext.Current.Session["instituicaoLogadaNome"].ToString();
            return nome;
        }


    }
}