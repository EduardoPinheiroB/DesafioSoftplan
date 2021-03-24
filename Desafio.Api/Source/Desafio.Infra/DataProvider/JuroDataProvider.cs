using CSharpFunctionalExtensions;
using Desafio.Domain.Gateways;
using Desafio.Domain.ValueObjects;
using Desafio.Infra.Adapters.Interfaces;
using System.Threading.Tasks;

namespace Desafio.Infra.DataProvider
{
    public class JuroDataProvider : IJuroGateway
    {
        private readonly IApiBuscarTaxaJuroAdapter apiBuscarTaxaJuroAdapter;

        public JuroDataProvider(IApiBuscarTaxaJuroAdapter apiBuscarTaxaJuroAdapter)
        {
            this.apiBuscarTaxaJuroAdapter = apiBuscarTaxaJuroAdapter;
        }

        public Result<decimal> BuscarTaxaJuro()
        {
            return Result.Success<decimal>(0.1M);
        }

        public async Task<Result<Taxa>> ConsultarApiTaxaJuro()
        {
            var valorTaxa = await apiBuscarTaxaJuroAdapter.BuscarTaxaJuro();

            if (valorTaxa.IsSuccess)
                return Result.Success<Taxa>(new Taxa(valorTaxa.Value));
            else
                return Result.Failure<Taxa>(valorTaxa.Error);
        }
    }
}
