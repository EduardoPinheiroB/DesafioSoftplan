using Desafio.Application.Interfaces;
using Microsoft.Extensions.Logging;
using Desafio.Domain.Gateways;
using Desafio.Domain.ValueObjects;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace Desafio.Application.UseCases
{
    public class CalcularTaxaJurosUseCase : ICalcularTaxaJurosUseCase
    {
        private readonly ILogger<CalcularTaxaJurosUseCase> logger;
        private readonly IJuroGateway juroGateway;

        public CalcularTaxaJurosUseCase(ILogger<CalcularTaxaJurosUseCase> logger, IJuroGateway juroGateway)
        {
            this.logger = logger;
            this.juroGateway = juroGateway;
        }

        public async Task<Result<decimal>> CalcularTaxaJuros(int tempo, decimal valorInicial)
        {
            logger.LogDebug("Requisição recebida no usecase {0}", GetType().Name);

            var taxa = await juroGateway.ConsultarApiTaxaJuro();

            if (taxa.IsSuccess)
            {
                var juro = new Juro(taxa.Value.Valor, tempo, valorInicial);

                if(!juro.IsValid)
                    return Result.Failure<decimal>(juro.Notifications.TryFirst().Value.Message);

                juro.CalcularTaxaJuros();

                return Result.Success<decimal>(juro.ValorFinal);
            }
            else
            {
                return Result.Failure<decimal>(taxa.Error);
            }
        }
    }
}
