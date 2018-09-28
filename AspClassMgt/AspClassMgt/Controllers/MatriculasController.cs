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
    public class MatriculasController : Controller
    {
        private Context db = new Context();
        MatriculaService matriculaService = new MatriculaService();
        Sessao sessao = new Sessao();
        CursoService cursoService = new CursoService();
        InstituicaoService instituicaoService = new InstituicaoService();
        AlunoService alunoService = new AlunoService();


        // GET: Matriculas
        public ActionResult Index()
        {
            int id = sessao.RetornarID();
            IList<Matricula> matriculas = matriculaService.ListaMatriculaInstituicao(id);
            return View(matriculas);
        }

        // GET: Matriculas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = matriculaService.BuscarMatriculaPorId(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            return View(matricula);
        }

        // GET: Matriculas/Create
        public ActionResult Create()
        {
            Matricula matricula = new Matricula();
            int idInstituição = sessao.RetornarID();
            var cursos = cursoService.ListaCursoInstituicao(idInstituição);
            List<SelectListItem> cursosInstituicao = new List<SelectListItem>();
            foreach (Curso item in cursos)
            {
                cursosInstituicao.Add(new SelectListItem
                {
                    Text = item.NomeCurso,
                    Value = item.IdCurso.ToString()
                });

            }
            ViewBag.cursosInstituicao = cursosInstituicao;
            return View(matricula);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMatricula,InstituicaoIDMatricula,AlunoIDMatricula,CursoIDMatricula")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                Instituicao instituicaoMatricula = instituicaoService.BuscarInstituicaoPorId(matricula.InstituicaoIDMatricula);
                matricula.InstituicaoMatricula = instituicaoMatricula;
                Aluno alunoMatricula = alunoService.BuscarAlunoPorId(matricula.AlunoIDMatricula);
                matricula.AlunoMatricula = alunoMatricula;
                Curso cursoMatricula = cursoService.BuscarCursoPorId(matricula.CursoIDMatricula);
                matricula.CursoMatricula = cursoMatricula;
                matriculaService.CadastrarMatricula(matricula);
                return RedirectToAction("Index");
            }

            return View(matricula);
        }

        // GET: Matriculas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = matriculaService.BuscarMatriculaPorId(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            return View(matricula);
        }

        // POST: Matriculas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMatricula,InstituicaoIDMatricula,AlunoIDMatricula,CursoIDMatricula")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matricula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(matricula);
        }

        // GET: Matriculas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = matriculaService.BuscarMatriculaPorId(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            return View(matricula);
        }

        // POST: Matriculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Matricula matricula = matriculaService.BuscarMatriculaPorId(id);
            matriculaService.RemoverMatricula(matricula);
            return RedirectToAction("Index","Home");
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
