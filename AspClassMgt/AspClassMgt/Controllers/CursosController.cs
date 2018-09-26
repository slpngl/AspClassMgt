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
    public class CursosController : Controller
    {
        private Context db = new Context();
        CursoService cursoService = new CursoService();
        ProfessorService professorService = new ProfessorService();
        Sessao sessao = new Sessao();

        // GET: Cursos
        public ActionResult Index()
        {
            int id = sessao.RetornarID();
            IList<Curso> cursosInstituicao = cursoService.ListaCursoInstituicao(id);
            return View(cursosInstituicao);
        }

        // GET: Cursos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = cursoService.BuscarCursoPorId(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // GET: Cursos/Create
        public ActionResult Create()
        {
            Curso curso = new Curso();
            int idInstituição = sessao.RetornarID();
            var professores = professorService.ListarProfessorInstituicao(idInstituição);
            List<SelectListItem> professoresList = new List<SelectListItem>();
            //Para adicionar os elementos na selectlist downdrop
            foreach (Professor item in professores)
            {
                professoresList.Add(new SelectListItem
                {
                    Text = item.NomeProfessor,
                    Value = item.IdProfessor.ToString()
                });
            }

            ViewBag.Listaprofessores = professoresList;
            return View(curso);
        }

        // POST: Cursos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCurso,NomeCurso,CargaHoraria")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                int inst = sessao.RetornarID();
                curso.instituicaoCurso = inst;
                cursoService.CadastrarCurso(curso);
                return RedirectToAction("Index");
            }

            return View(curso);
        }

        // GET: Cursos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = cursoService.BuscarCursoPorId(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // POST: Cursos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCurso,NomeCurso,CargaHoraria")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                int inst = sessao.RetornarID();
                curso.instituicaoCurso = inst;
                cursoService.EditarCurso(curso);
                return RedirectToAction("Index");
            }
            return View(curso);
        }

        // GET: Cursos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = cursoService.BuscarCursoPorId(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // POST: Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Curso curso = cursoService.BuscarCursoPorId(id);
            cursoService.RemoverCurso(curso);
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
