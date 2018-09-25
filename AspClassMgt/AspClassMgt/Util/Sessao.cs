using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspClassMgt.Util
{
    public class Sessao
    {
        public static bool EncerrarSessao() {
            HttpContext.Current.Session.Remove("instituicaoLogadaID");
            HttpContext.Current.Session.Remove("instituicaoLogadaNome");
            return true;
        }

        public static bool IniciarSessao(string id, string nome)
        {
            HttpContext.Current.Session.Add("instituicaoLogadaID", id);
            HttpContext.Current.Session.Add("instituicaoLogadaNome", nome);
            return true;
        }

        public static int RetornarID() {
            string id = HttpContext.Current.Session["instituicaoLogadaID"].ToString();
            return Convert.ToInt32(id);
        }

        public static string RetornarIntituicaoNome() {
            string nome =  HttpContext.Current.Session["instituicaoLogadaNome"].ToString();
            return nome;
        }


    }
}