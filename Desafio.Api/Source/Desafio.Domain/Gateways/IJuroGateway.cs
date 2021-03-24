using CSharpFunctionalExtensions;
using Desafio.Domain.ValueObjects;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Desafio.Domain.Gateways
{
    public interface IJuroGateway
    {
        [ExcludeFromCodeCoverage]
        Result<decimal> BuscarTaxaJuro();

        [ExcludeFromCodeCoverage]
        Task<Result<Taxa>> ConsultarApiTaxaJuro();
    }
}
