//using iHUB.Banking.CelCoin.Domain.Queries;
//using iHUB.Banking.Domain;
//using iHUB.Banking.Domain.Queries;
//using iHUB.Banking.Infra.Services.Request.Celcoin;
//using iHUB.Banking.Infra.Services.Response.Celcoin;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using Newtonsoft.Json.Serialization;
//using System.Collections.Generic;
//using System.Net.Http;
//using System.Threading;
//using System.Threading.Tasks;

//namespace iHUB.Banking.Infra.Services.RemotesMock
//{
//    public class CelcoinRemoteServiceMockErro : ICelcoinRemoteService
//    {
//        private ConsultaLocalizacaoTerminaisTecbanResult _pontoAtendimentoResult;
//        private ValorConsultarQueryResponse _valorConsultarQueryResponse;

//        private HttpClient Client;
//        public dynamic Body { get; set; }
//        public HttpRequestMessage Request { get; set; }
//        public string EsppRef { get; set; }
//        public string Api { get; set; }
//        public string Metodo { get; set; }
//        public EnumMensagemReposta Mensagem { get; set; }

//        public HttpMethod HttpMethod { get; set; }

//        private List<ConsultaTerminaisTecbanStores> _pontos;
//        public CelcoinRemoteServiceMockErro()
//        {
//            _pontos = null;
//            _pontoAtendimentoResult = new ConsultaLocalizacaoTerminaisTecbanResult(_pontos);
//            _pontoAtendimentoResult.ErrorCode = "01";
//            _pontoAtendimentoResult.Mensagem = "Erro";

//            _valorConsultarQueryResponse = new ValorConsultarQueryResponse 
//            {
//                CodigoErro = "Erro01",
//                Mensagem = "Erro",
//                Dados = null,
//                EsppRef = System.Guid.Empty
//            };
//        }

//        public async Task<JObject> Executar()
//        {
//            var serializerSettings = new JsonSerializerSettings();
//            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
//            var jsonResult = new object();
//            switch (Metodo)
//            {
//                case "PontoAtendimento":
//                    var pontos = new { pontos = _pontos };
//                    jsonResult = new { successResult = pontos };
//                    break;
//                case "Valor":
//                    var valores = new { valores = _valorConsultarQueryResponse };
//                    jsonResult = new { successResult = valores };
//                    break;
//                default:
//                    break;
//            }
//            string jsonString = "";
//            jsonString = JsonConvert.SerializeObject(jsonResult, serializerSettings);

//            return await Task.Run(() => (JObject)JsonConvert.DeserializeObject(jsonString));
//        }

//        public async Task<AtualizarRecargaCelCoinResponse> AtualizarRecarga(AtualizarRecargaCelCoinRequest reqObj, CancellationToken cancellationToken = default)
//        {
//            return new AtualizarRecargaCelCoinResponse();
//        }

//    }
//}
