using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Infra.Services
{
    public interface IJurosRemoteService
    {
        public dynamic Body { get; set; }
        public HttpRequestMessage Request { get; set; }
        public string Api { get; set; }
        public string Metodo { get; set; }
        HttpMethod HttpMethod { get; set; }

        Task<JObject> Executar();
    }
}
