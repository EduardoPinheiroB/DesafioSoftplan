using CSharpFunctionalExtensions;
using Desafio.Application.Models;

namespace Desafio.Application.Interfaces
{
    public interface IBuscarTaxaJurosUseCase
    {
        Result<JuroResult> BuscarTaxaJuro();
    }
}
