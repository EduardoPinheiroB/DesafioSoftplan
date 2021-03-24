using CSharpFunctionalExtensions;
using System.Threading.Tasks;

namespace Desafio.Application.Interfaces
{
    public interface ICalcularTaxaJurosUseCase
    {
        Task<Result<decimal>> CalcularTaxaJuros(int tempo, decimal valorInicial);
    }
}
