using CSharpFunctionalExtensions;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Desafio.Application.Interfaces
{
    public interface ICalcularTaxaJurosUseCase
    {
        [ExcludeFromCodeCoverage]
        Task<Result<decimal>> CalcularTaxaJuros(int tempo, decimal valorInicial);
    }
}
