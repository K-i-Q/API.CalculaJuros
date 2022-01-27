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
    public class JurosController : Controller
    {

        public JurosController()
        {

        }

        [ProducesResponseType(typeof(CalculoDtoResponse), 200)]
        [SwaggerRequestExample(typeof(CalculoDtoRequest), typeof(CalculoRequestExample))]
        [HttpPost("calculaJuros")]
        public async Task<IActionResult> CalculaJuros()
        {

            return Ok();
        }
    }
}
