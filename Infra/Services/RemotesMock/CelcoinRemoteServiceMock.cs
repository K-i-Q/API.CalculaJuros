//using iHUB.Banking.CelCoin.Domain.Queries;
//using iHUB.Banking.Domain;
//using iHUB.Banking.Domain.Dtos;
//using iHUB.Banking.Domain.Queries;
//using iHUB.Banking.Infra.Services.Request.Celcoin;
//using iHUB.Banking.Infra.Services.Response.Celcoin;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using Newtonsoft.Json.Serialization;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace iHUB.Banking.Infra.Services.RemotesMock
//{
//    public class CelcoinRemoteServiceMock : ICelcoinRemoteService
//    {
//        private ParceiroDtoResponse _parceiroResult;
//        private ParceiroDtoResponse _parceiroResult_Erro;
//        private ConsultaLocalizacaoTerminaisTecbanResult _pontoAtendimentoResult;
//        private HttpClient Client;
//        public dynamic Body { get; set; }
//        public HttpRequestMessage Request { get; set; }
//        public string EsppRef { get; set; }
//        public string Api { get; set; }
//        public string Metodo { get; set; }
//        public EnumMensagemReposta Mensagem { get; set; }
//        public HttpMethod HttpMethod { get; set; }

//        private List<ParceirosCelCoin> _parceiros;
//        private List<ConsultaTerminaisTecbanStores> _pontos;
//        private List<ProvedorResult> _provedores;
//        private ValorConsultarQueryResponse _valores;
//        public CelcoinRemoteServiceMock()
//        {
//            #region Parceiros
//            _parceiros = new List<ParceirosCelCoin>();
//            _parceiros.Add(new ParceirosCelCoin
//            {
//                CodeParceiro = "0001",
//                NamePartner = "BRINKSPAY"
//            });
//            _parceiros.Add(new ParceirosCelCoin
//            {
//                CodeParceiro = "30911820",
//                NamePartner = "HUGPAY"
//            });
//            #endregion Parceiros

//            #region PontosAtendimento
//            _pontos = new List<ConsultaTerminaisTecbanStores>();

//            _pontos.Add(new ConsultaTerminaisTecbanStores
//            {
//                Address = new CelCoin.Domain.Queries.ConsultaTerminaisTecbanAddress
//                {
//                    City = "CAMPINAS",
//                    District = "JARDIM NOVA EUROPA",
//                    Number = "247",
//                    Rua = "RUA RICARDO MORO",
//                    State = "SP"
//                },
//                AllowedTransactions = true,
//                Description = "Casa lotérica",
//                Location = new CelCoin.Domain.Queries.ConsultaTerminaisTecbanLocation
//                {
//                    Latitude = -22.926383f,
//                    Longitude = -47.081025f
//                },
//                Name = "LOTERICA SHIMOZONO LTDA ME",
//                StoreId = "1234"
//            });

//            _pontoAtendimentoResult = new ConsultaLocalizacaoTerminaisTecbanResult(_pontos);
//            #endregion PontosAtendimento

//            #region Provedores
//            _provedores = new List<ProvedorResult>();
//            _provedores.Add(new ProvedorResult
//            {

//                Category = 1,
//                Name = "Tim",
//                ProviderId = 2029,
//                TipoRecarganameProvider = 3,
//                MaxValue = 0,
//                MinValue = 0
//            });
//            _provedores.Add(new ProvedorResult
//            {
//                Category = 2,
//                Name = "Google Play",
//                ProviderId = 2028,
//                TipoRecarganameProvider = 3,
//                MaxValue = 0,
//                MinValue = 0
//            });
//            _provedores.Add(new ProvedorResult
//            {
//                Category = 3,
//                Name = "SKY TV",
//                ProviderId = 2027,
//                TipoRecarganameProvider = 3,
//                MaxValue = 0,
//                MinValue = 0
//            });
//            #endregion Provedores
//            #region Valores
//            _valores = new ValorConsultarQueryResponse { EsppRef = Guid.NewGuid(), CodigoErro = string.Empty, Mensagem = string.Empty };
//            _valores.Dados = new List<DadoValorRecargaDto>
//            {
//                new DadoValorRecargaDto
//                {
//                    PermiteRangeValor = false,
//                    RangeValorMaximo = 10,
//                    RangeValorMinimo = 10,
//                    ValorFixo = 10
//                },
//                new DadoValorRecargaDto
//                {
//                    ValorFixo = 15,
//                    RangeValorMinimo = 15,
//                    RangeValorMaximo = 15,
//                    PermiteRangeValor  = false
//                },
//                new DadoValorRecargaDto
//                {
//                    PermiteRangeValor = false,
//                    RangeValorMaximo = 20,
//                    RangeValorMinimo = 20,
//                    ValorFixo = 20
//                }
//            };

//            #endregion Valores
//        }


//        public async Task<JObject> Executar()
//        {
//            var serializerSettings = new JsonSerializerSettings();
//            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
//            var jsonResult = new object();
//            switch (Metodo)
//            {
//                case "PontosAtendimento":
//                    var pontos = new { pontos = _pontos };
//                    jsonResult = new { isSuccess = "true", successResult = pontos };
//                    break;
//                case "Parceiros":
//                    var parceiros = new { parceiros = _parceiros };
//                    jsonResult = new { isSuccess = "true", successResult = parceiros };
//                    break;
//                case "Provedor":
//                    var categoria = Body.GetType().GetProperty("categoria").GetValue(Body, null);
//                    var provedores = new { provedores = _provedores.ToList().Where(x => x.Category == categoria) };
//                    jsonResult = new { isSuccess = "true", successResult = provedores };
//                    break;
//                case "Valor":
//                    var valores = new { valores = _valores };
//                    jsonResult = new { isSuccess = "true", successResult = valores };
//                    break;
//                default:
//                    break;
//            }
//            string jsonString = "";
//            jsonString = JsonConvert.SerializeObject(jsonResult, serializerSettings);

//            return await Task.Run(() => (JObject)JsonConvert.DeserializeObject(jsonString));
//        }

//        private class ProvedorRequestMock
//        {
//            public int categoria { get; set; }
//            public int codigoEstado { get; set; }
//            public int tipoRecarga { get; set; }
//        }

//        public async Task<AtualizarRecargaCelCoinResponse> AtualizarRecarga(AtualizarRecargaCelCoinRequest reqObj, CancellationToken cancellationToken = default)
//        {
//            return new AtualizarRecargaCelCoinResponse();
//        }
//    }
//}
