using AutoMapper;
using Domain.Dtos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace API.CalculaJuros.CommandHandlers.Handlers
{
    public class CalculoCommandHandler : ICalculoCommandHandler
    {

        public CalculoCommandHandler()
        {
        }

        public Task<CalculoDtoResponse> HandlerAsync(CalculoDtoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
