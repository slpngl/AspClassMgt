using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AspClassMgt.BLL;
using AspClassMgt.Models;

namespace AspClassMgt.Controllers
{
    public class AlunosAPIController : ApiController
    {
        AlunoService alunoService = new AlunoService();

        // GET: api/Usuario
        [HttpGet]
        public IList<Aluno> GetAlunos()
        {
            return alunoService.ListarAlunos();
        }

        // GET: api/Usuario/5
        [HttpGet]
        [ResponseType(typeof(Aluno))]
        public IHttpActionResult GetAluno(int id)
        {
            Aluno aluno = alunoService.BuscarAlunoPorId(id);
            if (aluno == null)
            {
                return NotFound();
            }

            return Ok(aluno);
        }

        // PUT: api/Usuario/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAluno(int id, Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aluno.IdAluno)
            {
                return BadRequest();
            }

            try
            {
                aluno.IdAluno = id;
                alunoService.EditarAluno(aluno);
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;

            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Usuario
        [ResponseType(typeof(Aluno))]
        public IHttpActionResult PostUsuario(Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            alunoService.CadastrarAluno(aluno);

            return CreatedAtRoute("DefaultApi", new { id = aluno.IdAluno }, aluno);
        }

        // DELETE: api/Usuario/5
        [ResponseType(typeof(Aluno))]
        public IHttpActionResult DeleteUsuario(int? id)
        {
            Aluno aluno = alunoService.BuscarAlunoPorId(id);
            if (id == null)
            {
                return NotFound();
            }

            return Ok(alunoService.RemoverAluno(aluno));
        }
    }
}