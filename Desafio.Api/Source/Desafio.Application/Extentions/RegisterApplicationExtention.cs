using Desafio.Application.Interfaces;
using Desafio.Application.UseCases;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Desafio.Application.Extentions
{
    [ExcludeFromCodeCoverage]
    public static class RegisterApplicationExtention
    {
        public static void RegisterService(this IServiceCollection services)
        {
            services.AddTransient<IBuscarTaxaJurosUseCase, BuscarTaxaJurosUseCase>();
            services.AddTransient<ICalcularTaxaJurosUseCase, CalcularTaxaJurosUseCase>();
        }
    }
}
