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
    public class InsituicaoApiController : ApiController
    {
        InstituicaoService instituicaoService = new InstituicaoService();

        // GET: api/Instituicao
        [HttpGet]
        public IList<Instituicao> GetInstituicaos()
        {
            return instituicaoService.ListarInstituicao();
        }

        //GET: api/Instituicao/5
        [HttpGet]
        [ResponseType(typeof(Instituicao))]
        public IHttpActionResult GetInstituicao(int id)
        {
            Instituicao instituicao = instituicaoService.BuscarInstituicaoPorId(id);
            if (instituicao == null)
            {
                return NotFound();
            }
            return Ok(instituicao);
        }

        //PUT : api/Instituicao/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInstituicao(int id, Instituicao instituicao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != instituicao.IdInstituicao)
            {
                return BadRequest();
            }
            try
            {
                instituicao.IdInstituicao = id;
                instituicaoService.EditarInstituicao(instituicao);
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;

            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Usuario
        [ResponseType(typeof(Instituicao))]
        public IHttpActionResult PostInstituicao(Instituicao instituicao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            instituicaoService.CadastrarInstituicao(instituicao);

            return CreatedAtRoute("DefaultApi", new { id = instituicao.IdInstituicao }, instituicao);
        }

    }
}

