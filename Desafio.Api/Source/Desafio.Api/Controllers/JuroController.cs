using Desafio.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Api.Controllers
{
    [Route("juros")]
    [ApiController]
    public class JuroController : ControllerBase
    {
        private readonly ILogger<JuroController> logger;
        private readonly IBuscarTaxaJurosUseCase taxaJurosUseCase;
        private readonly ICalcularTaxaJurosUseCase calcularTaxaJurosUseCase;

        public JuroController(ILogger<JuroController> logger,
            IBuscarTaxaJurosUseCase taxaJurosUseCase,
            ICalcularTaxaJurosUseCase calcularTaxaJurosUseCase)
        {
            this.logger = logger;
            this.taxaJurosUseCase = taxaJurosUseCase;
            this.calcularTaxaJurosUseCase = calcularTaxaJurosUseCase;
        }

        [HttpGet("taxaJuros")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult taxaJuro()
        {
            try
            {
                logger.LogDebug("Requisição recebida.");
                var juro = taxaJurosUseCase.BuscarTaxaJuro();

                if (juro.IsSuccess)
                {
                    logger.LogInformation("Requisição concluída com sucesso!");
                    return Ok(juro.Value.Taxa);
                }
                else
                {
                    logger.LogError("Ocorreu um erro ao processar a requisição. Erro: {@0}", juro.Error);
                    return BadRequest("Ocorreu uma falha ao processar a requisição");
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Ocorreu um erro generico ao processar a requisição. Erro: {@0}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao processar a requisição.");
            }
        }


        [HttpGet("calculajuros")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> calculajurosAsync(
            [FromQuery(Name = "valor_inicial")][BindRequired] decimal valorInicial,
            [FromQuery(Name = "tempo")][BindRequired] int tempo)
        {
            try
            {
                logger.LogDebug("Mensagem recebida calculajurosAsync, Valor Inicial: {valorInicial}, Tempo: {tempo}", valorInicial, tempo);

                var totalJuro = await calcularTaxaJurosUseCase.CalcularTaxaJuros(tempo, valorInicial);

                if (totalJuro.IsSuccess)
                {
                    logger.LogInformation("Requisição concluída com sucesso!");
                    return Ok(totalJuro.Value);
                }
                else
                {
                    logger.LogError("Ocorreu um erro ao processar a requisição. Erro: {@0}", totalJuro.Error);
                    return BadRequest("Ocorreu uma falha ao processar a requisição");
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Ocorreu um erro ao processar a requisição. Erro: {@0}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao processar a requisição.");
            }
        }

        [HttpGet("showmethecode")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult showmethecode()
        {
            return Ok("https://github.com/EduardoPinheiroB/DesafioSoftplan");
        }
    }
}
