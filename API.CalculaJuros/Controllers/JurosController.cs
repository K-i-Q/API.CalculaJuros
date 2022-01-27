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
    public class JurosController : Controller
    {
        private readonly ICalculoCommandHandler _calculoCommandHandler;
        public JurosController(ICalculoCommandHandler calculoCommandHandler)
        {
            _calculoCommandHandler = calculoCommandHandler;
        }

        [ProducesResponseType(typeof(CalculoDtoResponse), 200)]
        [SwaggerRequestExample(typeof(CalculoDtoRequest), typeof(CalculoRequestExample))]
        [HttpPost("calculaJuros")]
        public async Task<IActionResult> CalculaJuros([FromBody] CalculoDtoRequest request)
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
