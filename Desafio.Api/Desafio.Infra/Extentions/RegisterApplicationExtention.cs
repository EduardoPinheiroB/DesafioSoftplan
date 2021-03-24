using Desafio.Domain.Gateways;
using Desafio.Infra.Adapters;
using Desafio.Infra.DataProvider;
using Microsoft.Extensions.DependencyInjection;

namespace Desafio.Infra.Extentions
{
    public static class RegisterInfraExtention
    {
        public static void RegisterService(this IServiceCollection services)
        {
            services.AddScoped<IJuroGateway, JuroDataProvider>();

            services.AddScoped<ApiBuscarTaxaJuroAdapter>();
        }
    }
}
