using AutoMapper;
using Domain.Dtos;
using Infra.Services;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.CalculaJuros.CommandHandlers.Handlers
{
    public class CalculoCommandHandler : ICalculoCommandHandler
    {
        private readonly IJurosRemoteService _jurosRemoteService;
        public CalculoCommandHandler(IJurosRemoteService jurosRemoteService)
        {
            _jurosRemoteService = jurosRemoteService;
        }

        public async Task<CalculoDtoResponse> HandlerAsync(CalculoDtoRequest request)
        {
            var response = new CalculoDtoResponse();
            try
            {
                _jurosRemoteService.Api = "api/Juros/";
                _jurosRemoteService.Metodo = "consultar";
                _jurosRemoteService.HttpMethod = HttpMethod.Get;

                var jObjectResult = await _jurosRemoteService.Executar();

                if (jObjectResult["successResult"] != null)
                {
                    var taxaJuros = jObjectResult["successResult"]["taxaJuros"].ToObject<decimal>();

                    var potenciaResult = Math.Pow(Convert.ToDouble((1 + taxaJuros)), Convert.ToDouble(request.Meses));

                    response.ValorFinal = request.ValorInicial * Convert.ToDecimal(potenciaResult);

                    response.ValorFinal = Math.Truncate(100 * response.ValorFinal) / 100;

                    response.Mensagem = "Sucesso";
                }

                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;

                return response;
            }
        }
    }
}
