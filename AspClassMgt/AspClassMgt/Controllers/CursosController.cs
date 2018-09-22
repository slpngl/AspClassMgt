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
    public class CursosController : Controller
    {
        private Context db = new Context();

        // GET: Cursos
        public ActionResult Index()
        {
            return View(CursoDAO.ListarCursos());
        }

        // GET: Cursos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = CursoDAO.BuscarCursoPorId(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // GET: Cursos/Create
        public ActionResult Create()
        {
            var professores = db.Professor.ToList();
            //   var professores = ProfessorDAO.ListarProfessors();
            List<SelectListItem> professoresList = new List<SelectListItem>();
            foreach (Professor item in professores)
            {
                professoresList.Add(new SelectListItem
                {
                    Text = item.NomeProfessor,
                    Value = item.IdProfessor.ToString()
                });
            }
            ViewBag.Listaprofessores = professoresList;
            return View();
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
                CursoDAO.CadastrarCurso(curso);
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
            Curso curso = CursoDAO.BuscarCursoPorId(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // POST: Cursos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCurso,NomeCurso,CargaHoraria")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                CursoDAO.EditarCurso(curso);
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
            Curso curso = db.Curso.Find(id);
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
            Curso curso = CursoDAO.BuscarCursoPorId(id);
            CursoDAO.RemoverCurso(curso);
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
