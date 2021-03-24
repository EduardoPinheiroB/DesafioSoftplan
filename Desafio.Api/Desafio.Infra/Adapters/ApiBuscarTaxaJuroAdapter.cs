using CSharpFunctionalExtensions;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Threading.Tasks;

namespace Desafio.Infra.Adapters
{
    public class ApiBuscarTaxaJuroAdapter
    {
        public async Task<Result<decimal>> BuscarTaxaJuro()
        {
            var client = new RestClient("https://localhost:5001/juros/taxaJuros");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var taxaJuro = JsonConvert.DeserializeObject<decimal>(response.Content);
                return Result.Success<decimal>(taxaJuro);
            }
            else
                return Result.Failure<decimal>("Falha na consulta da API de taxa de juros");
        }
    }
}
