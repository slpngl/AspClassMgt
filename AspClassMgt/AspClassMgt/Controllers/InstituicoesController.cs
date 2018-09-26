using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AspClassMgt.Models;
using AspClassMgt.BLL;
     

namespace AspClassMgt.Controllers
{
    public class InstituicoesController : Controller
    {
        private Context db = new Context();
        InstituicaoService instituicaoService = new InstituicaoService();

        // GET: Instituicoes
        public ActionResult Index()
        {
            IList<Instituicao> instituicaos = instituicaoService.ListarInstituicao();
            return View(instituicaos);
        }

        // GET: Instituicoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instituicao instituicao = instituicaoService.BuscarInstituicaoPorId(id);
            if (instituicao == null)
            {
                return HttpNotFound();
            }
            return View(instituicao);
        }

        // GET: Instituicoes/Create
        public ActionResult Create()
        {
            Instituicao instituicao = new Instituicao();
            return View(instituicao);
        }

        // POST: Instituicoes/Create
         [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdInstituicao,nomeInstituicao,lgnInstituicao,snhInstituicao")] Instituicao instituicao)
        {
            if (ModelState.IsValid)
            {
                instituicaoService.CadastrarInstituicao(instituicao);
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
            Instituicao instituicao = instituicaoService.BuscarInstituicaoPorId(id);
            if (instituicao == null)
            {
                return HttpNotFound();
            }
            return View(instituicao);
        }

        // POST: Instituicoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdInstituicao,nomeInstituicao,lgnInstituicao,snhInstituicao")] Instituicao instituicao)
        {
            if (ModelState.IsValid)
            {
                instituicaoService.EditarInstituicao(instituicao);
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
            Instituicao instituicao = instituicaoService.BuscarInstituicaoPorId(id);
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
            Instituicao instituicao = instituicaoService.BuscarInstituicaoPorId(id);
            instituicaoService.RemoverInstituicao(instituicao);
            return RedirectToAction("Index");
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
