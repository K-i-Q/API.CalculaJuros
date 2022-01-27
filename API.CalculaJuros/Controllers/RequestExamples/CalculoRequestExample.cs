using Domain.Dtos;
using Swashbuckle.AspNetCore.Filters;

namespace API.CalculaJuros.Controllers.RequestExamples
{
    public class CalculoRequestExample : IExamplesProvider<CalculoDtoRequest>
    {
        public CalculoDtoRequest GetExamples()
        {
            return new CalculoDtoRequest
            {
                Meses = 5,
                ValorInicial = 100
            };
        }
    }
}
