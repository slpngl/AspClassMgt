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
using AspClassMgt.Util;

namespace AspClassMgt.Controllers
{
    public class AlunosController : Controller
    {
        private Context db = new Context();

        // GET: Alunos
        public ActionResult Index()
        {
            int id = Sessao.RetornarID();
            return View(AlunoDAO.ListaAlunoInstituicao(id));
        }

        // GET: Alunos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = AlunoDAO.BuscarAlunoPorId(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // GET: Alunos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alunos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAluno,Nome,Endereco")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                int inst = Sessao.RetornarID();
                aluno.instituicaoAluno = inst;
                AlunoDAO.CadastrarAluno(aluno);
                return RedirectToAction("Index");
            }

            return View(aluno);
        }

        // GET: Alunos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = AlunoDAO.BuscarAlunoPorId(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }
        // POST: Alunos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAluno,Nome,Endereco")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                AlunoDAO.EditarAluno(aluno);
                return RedirectToAction("Index");
            }
            return View(aluno);
        }

        // GET: Alunos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = AlunoDAO.BuscarAlunoPorId(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aluno aluno = AlunoDAO.BuscarAlunoPorId(id);
            AlunoDAO.RemoverAluno(aluno);
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
