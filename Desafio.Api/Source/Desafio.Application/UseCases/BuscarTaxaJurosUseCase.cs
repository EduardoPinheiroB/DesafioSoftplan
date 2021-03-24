using Desafio.Application.Interfaces;
using Desafio.Application.Models;
using Microsoft.Extensions.Logging;
using Desafio.Domain.Gateways;
using CSharpFunctionalExtensions;

namespace Desafio.Application.UseCases
{
    class BuscarTaxaJurosUseCase : IBuscarTaxaJurosUseCase
    {
        private readonly ILogger<BuscarTaxaJurosUseCase> logger;
        private readonly IJuroGateway juroGateway;

        public BuscarTaxaJurosUseCase(ILogger<BuscarTaxaJurosUseCase> logger, IJuroGateway juroGateway)
        {
            this.logger = logger;
            this.juroGateway = juroGateway;
        }

        public Result<JuroResult> BuscarTaxaJuro()
        {
            logger.LogDebug("Requisição recebida {0}", GetType().Name);
            var taxa = juroGateway.BuscarTaxaJuro();

            if (taxa.IsSuccess)
                return Result.Success<JuroResult>(new JuroResult { Taxa = taxa.Value });
            else
                return Result.Failure<JuroResult>(taxa.Error);
        }
    }
}
