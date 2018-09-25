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
     

    }
}