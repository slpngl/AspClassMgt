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
        Sessao sessao = new Sessao();

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
        public ActionResult Login(string login, string senha){
            if (sessao.AutenticarLogin(login, senha) == true)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Login");
        }

        public ActionResult Logout(int id) {
            sessao.EncerrarSessao();
            return RedirectToAction("Login");
        }
    


    }
    }
