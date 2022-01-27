using Domain.Dtos;
using Swashbuckle.AspNetCore.Filters;

namespace API.CalculaJuros.Controllers.ResponseExamples
{
    public class CalculoSucesso : IExamplesProvider<CalculoDtoResponse>
    {
        public CalculoDtoResponse GetExamples()
        {
            return new CalculoDtoResponse
            {
                ValorFinal = 105.10m
            };
        }
    }
}
