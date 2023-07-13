using Microsoft.AspNetCore.Mvc;
using SpeedEat.Aplicacao.Clientes.Servicos.Interfaces;
using SpeedEat.DataTransfer.Clientes.Requests;
using SpeedEat.DataTransfer.Clientes.Responses;

namespace SpeedEat.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly IClientesAppServico _clientesAppServico;

        public ClienteController(IClientesAppServico clientesAppServico)
        {
            _clientesAppServico = clientesAppServico;
        }

        /// <summary> Insere um cliente </summary>
        /// <param name="request"> Objeto que compõe o corpo da requisição de inserção</param>
        /// <returns> Retorna o Cliente inserido </returns>
        [HttpPost]
        public ActionResult<ClienteResponse> Inserir([FromBody] ClienteRequest request)
        {
            return request.Nome == null ?
                BadRequest(request) :
                Ok(_clientesAppServico.Inserir(request));
        }

        /// <summary> Recupera um cliente pelo seu código </summary>
        /// <param name="id"> Código identificador do cliente </param>
        /// <returns> Retorna um objeto do tipo Cliente </returns>
        [HttpGet("{id}")]
        public ActionResult<ClienteResponse> Recuperar([FromRoute] int id)
        {
            ClienteResponse response = _clientesAppServico.Recuperar(id);

            return response == null ? NotFound() : Ok(response);
        }

        /// <summary> Edita um cliente </summary>
        /// <param name="id"> Código identificador do cliente </param>
        /// <param name="request"> Objeto que compõe o corpo da requisição de edição </param>
        /// <returns> Retorna o Cliente editado </returns>
        [HttpPut("{id}")]
        public ActionResult<ClienteResponse> Editar([FromRoute] int id, [FromBody] ClienteRequest request)
        {
            return (id == 0 || request.Nome == null) ?
                BadRequest(request) :
                Ok(_clientesAppServico.Editar(id, request));
        }

        /// <summary> Recupera uma lista de clientes por filtros </summary>
        /// <param name="request"> Objeto para filtrar clientes </param>
        /// <returns> Retorna uma lista de Clientes </returns>
        [HttpGet]
        public ActionResult<IEnumerable<ClienteResponse>> Listar([FromQuery] ClienteListarRequest request)
        {
            return Ok(_clientesAppServico.Listar(request));
        }
    }
}