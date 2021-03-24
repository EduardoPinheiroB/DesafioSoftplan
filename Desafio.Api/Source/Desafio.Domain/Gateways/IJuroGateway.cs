using CSharpFunctionalExtensions;
using Desafio.Domain.ValueObjects;
using System.Threading.Tasks;

namespace Desafio.Domain.Gateways
{
    public interface IJuroGateway
    {
        Result<decimal> BuscarTaxaJuro();
        Task<Result<Taxa>> ConsultarApiTaxaJuro();
    }
}
