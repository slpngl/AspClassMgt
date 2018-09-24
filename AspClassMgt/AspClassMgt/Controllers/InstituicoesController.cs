using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AspClassMgt.Models;
using AspClassMgt.DAL;
     

namespace AspClassMgt.Controllers
{
    public class InstituicoesController : Controller
    {
        private Context db = new Context();

        // GET: Instituicoes
        public ActionResult Index()
        {
            return View(InstituicaoDAO.ListarInstituicao());
        }

        // GET: Instituicoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instituicao instituicao = InstituicaoDAO.BuscarInstituicaoPorId(id);
            if (instituicao == null)
            {
                return HttpNotFound();
            }
            return View(instituicao);
        }

        // GET: Instituicoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Instituicoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdInstituicao,nomeInstituicao,lgnInstituicao,snhInstituicao")] Instituicao instituicao)
        {
            if (ModelState.IsValid)
            {
                InstituicaoDAO.CadastrarInstituicao(instituicao);
                return RedirectToAction("Index");
            }

            return View(instituicao);
        }

        // GET: Instituicoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instituicao instituicao = InstituicaoDAO.BuscarInstituicaoPorId(id);
            if (instituicao == null)
            {
                return HttpNotFound();
            }
            return View(instituicao);
        }

        // POST: Instituicoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdInstituicao,nomeInstituicao,lgnInstituicao,snhInstituicao")] Instituicao instituicao)
        {
            if (ModelState.IsValid)
            {
                InstituicaoDAO.EditarInstituicao(instituicao);
                return RedirectToAction("Index");
            }
            return View(instituicao);
        }

        // GET: Instituicoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instituicao instituicao = InstituicaoDAO.BuscarInstituicaoPorId(id);
            if (instituicao == null)
            {
                return HttpNotFound();
            }
            return View(instituicao);
        }

        // POST: Instituicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instituicao instituicao = InstituicaoDAO.BuscarInstituicaoPorId(id);
            InstituicaoDAO.RemoverInstituicao(instituicao);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Login(Instituicao i)
        {
            if (ModelState.IsValid)
            {
                Instituicao logada = new Instituicao();
                logada = InstituicaoDAO.AutenticarLogin(i.nomeInstituicao, i.snhInstituicao);
                if (logada != null)
                {
                    Session["instituicaoID"] = logada.IdInstituicao;
                    Session["instituicaoNome"] = logada.nomeInstituicao;
                    return RedirectToAction("Index");
                }

            }
            return View(i);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
