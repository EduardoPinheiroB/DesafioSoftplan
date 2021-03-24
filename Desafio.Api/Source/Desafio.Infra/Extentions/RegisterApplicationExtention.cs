using Desafio.Domain.Gateways;
using Desafio.Infra.Adapters;
using Desafio.Infra.Adapters.Interfaces;
using Desafio.Infra.DataProvider;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Desafio.Infra.Extentions
{
    [ExcludeFromCodeCoverage]
    public static class RegisterInfraExtention
    {
        public static void RegisterService(this IServiceCollection services)
        {
            services.AddScoped<IJuroGateway, JuroDataProvider>();

            services.AddScoped<IApiBuscarTaxaJuroAdapter, ApiBuscarTaxaJuroAdapter>();
        }
    }
}
