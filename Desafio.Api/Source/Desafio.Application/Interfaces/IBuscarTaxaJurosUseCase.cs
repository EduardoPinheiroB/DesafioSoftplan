using CSharpFunctionalExtensions;
using Desafio.Application.Models;
using System.Diagnostics.CodeAnalysis;

namespace Desafio.Application.Interfaces
{
    public interface IBuscarTaxaJurosUseCase
    {
        [ExcludeFromCodeCoverage]
        Result<JuroResult> BuscarTaxaJuro();
    }
}
