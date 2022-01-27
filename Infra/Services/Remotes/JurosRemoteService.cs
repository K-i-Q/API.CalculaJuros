using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Services.Remotes
{
    public class JurosRemoteService : IJurosRemoteService
    {
        private readonly IHttpClientFactory _clientFactory;

        private HttpClient client;

        /// <summary>
        /// Corpo do request ao autorizador
        /// </summary>
        public dynamic Body { get; set; }
        /// <summary>
        /// request ao autoruzador
        /// </summary>
        public HttpRequestMessage Request { get; set; }
        /// <summary>
        /// EsppRef example=680d2b892-5ead-4d83-a8db-ffc3244bad3f
        /// </summary>
        public string Api { get; set; }
        public string Metodo { get; set; }
        public HttpMethod HttpMethod { get; set; }

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="clientFactory"></param>
        public JurosRemoteService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            client = _clientFactory.CreateClient("API-Juros");
        }

        public async Task<JObject> Executar()
        {
            Request = new HttpRequestMessage(HttpMethod, Api + Metodo)
            {
                Content = new StringContent(JsonConvert.SerializeObject(Body), Encoding.UTF8, "application/json")
            };

            var response = await client.SendAsync(Request);

            var jsonString = await response.Content.ReadAsStringAsync();

            var resultContent = (JObject)JsonConvert.DeserializeObject(jsonString);

            if (response.IsSuccessStatusCode)
                return resultContent;
            else
            {
                return JObject.FromObject(new { mensagem = "Erro" });
            }
        }

    }
}