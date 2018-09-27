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
using AspClassMgt.Util;

namespace AspClassMgt.Controllers
{
    public class ProfessoresController : Controller

    {
        private Context db = new Context();
        ProfessorService professorService = new ProfessorService();
        Sessao sessao = new Sessao();

        // GET: Professores
        public ActionResult Index()
        {
            int id = sessao.RetornarID();
            IList<Professor> professores = professorService.ListarProfessorInstituicao(id);
            return View(professores);
        }

        // GET: Professores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = professorService.BuscarProfessorId(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        // GET: Professores/Create
        public ActionResult Create()
        {
            Professor professor = new Professor();
            return View(professor);
        }

        // POST: Professores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProfessor,NomeProfessor,Formacao,,Nome,Rua,Bairro,Cidade,UF")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                int inst = sessao.RetornarID();
                professor.instituicaoProfessor = inst;
                professorService.CadastrarProfessor(professor);
                return RedirectToAction("Index");
            }

            return View(professor);
        }

        // GET: Professores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = professorService.BuscarProfessorId(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        // POST: Professores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProfessor,NomeProfessor,Formacao,,Nome,Rua,Bairro,Cidade,UF")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                int inst = sessao.RetornarID();
                professor.instituicaoProfessor = inst;
                professorService.EditarProfessor(professor);
                return RedirectToAction("Index");
            }
            return View(professor);
        }

        // GET: Professores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = professorService.BuscarProfessorId(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        // POST: Professores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Professor professor = professorService.BuscarProfessorId(id);
            professorService.RemoverProfessor(professor);
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
