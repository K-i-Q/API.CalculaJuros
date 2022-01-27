using API.CalculaJuros.CommandHandlers;
using API.CalculaJuros.Controllers.RequestExamples;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.CalculaJuros.Controllers
{
    [ApiController]
    [Route("v1/Calcula")]
    public class CalculaController : Controller
    {
        private readonly ICalculoCommandHandler _calculoCommandHandler;
        public CalculaController(ICalculoCommandHandler calculoCommandHandler)
        {
            _calculoCommandHandler = calculoCommandHandler;
        }

        [ProducesResponseType(typeof(CalculoDtoResponse), 200)]
        [SwaggerRequestExample(typeof(CalculoDtoRequest), typeof(CalculoRequestExample))]
        [HttpGet("calculaJuros")]
        public async Task<IActionResult> CalculaJuros([FromQuery] CalculoDtoRequest request)
        {
            try
            {
                var response = await _calculoCommandHandler.HandlerAsync(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new CalculoDtoResponse { Mensagem = ex.Message });
            }
        }
    }
}
