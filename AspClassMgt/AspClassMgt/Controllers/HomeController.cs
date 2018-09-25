using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspClassMgt.Models;
using AspClassMgt.DAL;
using AspClassMgt.Util;

namespace AspClassMgt.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // GET: LOGIN
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // POST : LOGIN 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Instituicao i)
        {
            if (ModelState.IsValid) //verifica se é válido
            {
                Instituicao logada = new Instituicao();
                logada = InstituicaoDAO.AutenticarLogin(i.lgnInstituicao, i.snhInstituicao);
                if (logada != null)
                {
                    string id = logada.IdInstituicao.ToString();
                    string nome = logada.nomeInstituicao.ToString();

                    Sessao.IniciarSessao(id,nome);
                    return RedirectToAction("Index");
                }
                if (logada == null)
                {
                    ModelState.AddModelError("", "Login ou senha inválidos!!");
                }

            }
            return View(i);
        }

        public ActionResult Logout(int id) {
            Sessao.EncerrarSessao();
            return RedirectToAction("Login");
        }
    


    }
    }
