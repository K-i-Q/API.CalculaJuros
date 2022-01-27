using Domain.Commands;
using Domain.Dtos;
using System.Threading.Tasks;

namespace API.CalculaJuros.CommandHandlers
{
    public interface ICalculoCommandHandler
    {
        Task<CalculoDtoResponse> HandlerAsync(CalculoDtoRequest request);
    }
}
