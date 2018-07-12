using ConsultaAereo.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;

namespace ConsultaAereo.Api.Controllers
{
    public class PassagemAereaController : ODataController
    {
        private PassagemAereaRepositorio _repositorio;

        public PassagemAereaController()
        {
            this._repositorio = new PassagemAereaRepositorio();
        }

        [Queryable]
        public IQueryable<PassagemAerea> GetPassagemAerea()
        {
            return this._repositorio.ObterTodas();
        }

        [Queryable]
        public SingleResult<PassagemAerea> GetPassagemAerea([FromODataUri] int key)
        {
            return SingleResult.Create(this._repositorio
                .ObterTodas().Where(passagem => passagem.Id == key));
        }

        [Queryable]
        public Aeroporto GetOrigem([FromODataUri] int key)
        {
            return this._repositorio.Obter(key).Origem;
        }

        [Queryable]
        public Aeroporto GetDestino([FromODataUri] int key)
        {
            return this._repositorio.Obter(key).Destino;
        }

        public IHttpActionResult Post(PassagemAerea passagemAerea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this._repositorio.Adicionar(passagemAerea);

            return Created(passagemAerea);
        }

        public IHttpActionResult Put([FromODataUri] int key, PassagemAerea passagemAerea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != passagemAerea.Id)
            {
                return BadRequest();
            }

            this._repositorio.Atualizar(passagemAerea);

            return Updated(passagemAerea);
        }

        public IHttpActionResult Delete([FromODataUri] int key)
        {
            PassagemAerea passagemAerea = this._repositorio.Obter(key);
            if (passagemAerea == null)
            {
                return NotFound();
            }

            this._repositorio.Remover(passagemAerea);

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
