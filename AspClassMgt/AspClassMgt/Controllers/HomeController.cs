using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspClassMgt.Models;
using AspClassMgt.DAL;

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
                if (logada != null) {
                    Session["instituicaoLogadaID"] = logada.IdInstituicao.ToString();
                    Session["instituicaoLogadaNome"] = logada.nomeInstituicao.ToString();
                    return RedirectToAction("Index");
                }
            }
                return View(i);
            
        }

    }
    }
