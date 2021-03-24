using Desafio.Application.Interfaces;
using Desafio.Application.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace Desafio.Application.Extentions
{
    public static class RegisterApplicationExtention
    {
        public static void RegisterService(this IServiceCollection services)
        {
            services.AddTransient<IBuscarTaxaJurosUseCase, BuscarTaxaJurosUseCase>();
            services.AddTransient<ICalcularTaxaJurosUseCase, CalcularTaxaJurosUseCase>();
        }
    }
}
