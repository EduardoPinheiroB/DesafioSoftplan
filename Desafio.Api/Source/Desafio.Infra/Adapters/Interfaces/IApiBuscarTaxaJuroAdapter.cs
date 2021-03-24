using CSharpFunctionalExtensions;
using System.Threading.Tasks;

namespace Desafio.Infra.Adapters.Interfaces
{
    public interface IApiBuscarTaxaJuroAdapter
    {
        Task<Result<decimal>> BuscarTaxaJuro();
    }
}
