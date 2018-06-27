using Hands.Dominio.Entidade;
using Hands.Dominio.Servicos;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Hands.API.Controllers
{
    [RoutePrefix("produto")]
    public class ProdutoController : ApiController
    {
        IProdutoServico _servico;

        public ProdutoController(IProdutoServico servico)
        {
            _servico = servico;
        }

        [Route("listar")]
        [HttpGet]
        public IHttpActionResult Listar()
        {
            try
            {
                return Ok(_servico.Listar());
            }
            catch (System.Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        [Route("obter/{id}")]
        [HttpGet]
        public IHttpActionResult ObterId([FromUri] int id)
        {
            try
            {
                return Ok(_servico.ObterId(id));
            }
            catch (System.Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        [Route("adicionar")]
        [HttpPost]
        public IHttpActionResult Incluir([FromBody] Produto model)
        {
            try
            {
                _servico.Adicionar(model);

                return Ok("Dados salvos!");
            }
            catch (System.Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        [Route("alterar")]
        [HttpPut]
        public IHttpActionResult Alterar([FromBody] Produto model)
        {
            try
            {
                _servico.Alterar(model);

                return Ok("Dados alterados!");
            }
            catch (System.Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }

        [Route("deletar/{id}")]
        [HttpDelete]
        public IHttpActionResult Deletar([FromUri] int id)
        {
            try
            {
                _servico.Remover(id);

                return Ok("Dados removidos!");
            }
            catch (System.Exception ex)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message));
            }
        }
    }
}
