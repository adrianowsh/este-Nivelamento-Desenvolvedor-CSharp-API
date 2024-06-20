using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Application.Handlers;
using Questao5.Application.Queries.Requests;
using Questao5.Application.Queries.Responses;
using System.ComponentModel;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("Conta-Corrente")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class AccountController : ControllerBase
    {
        private readonly IConsultHandler _consultHandlerhandler;
        private readonly IMovimentHandler _movimentHandler;
        public AccountController(IConsultHandler consultHandlerhandler, IMovimentHandler movimentHandler)
        {
            _consultHandlerhandler = consultHandlerhandler;
            _movimentHandler = movimentHandler;
        }
        /// <summary>
        /// Obtém saldo da conta corrente
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Saldo")]
        [Description("Obtém saldo da conta corrente")]
        [ProducesResponseType(typeof(ConsultBalanceResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ConsultBalanceResponse>> GetBalance([FromQuery] ConsultBalanceRequest request)
        {
            var response = await _consultHandlerhandler.Handle(new ConsultRequest() { Number = request.Numero });
            if (response.ErrorMessage is not null)
                return BadRequest(response.ErrorMessage);

            return Ok(response);
        }

        /// <summary>
        /// Gera Movimentação da Conta Corrente
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Movimento")]
        [Description("Gera Movimentação da Conta Corrente")]
        [ProducesResponseType(typeof(MovimentResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MovimentResponse>> PostMoviment([FromBody] MovimentRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var response = await _movimentHandler.Handle(request);
            if (response.ErrorMessage is not null)
                return BadRequest(response.ErrorMessage);
            return Ok(response);
        }
    }
}
