using _3.Application.DTOs;
using _3.Application.Features.Auth.Commands.Login;
using _3.Application.Features.Personas.Commands.CrearPersona;
using _3.Application.Features.Personas.Queries.ConsultarTodasPersonas;
using _3.Application.Features.Usuarios.Commands.CrearUsuario;
using _3.Application.Features.Usuarios.Queries.ObtenerListaUsuarios;
using _4.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace _1.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list", Name = "ObtenerListaPersonas")]
        [ProducesResponseType(typeof(IReadOnlyList<Persona>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IReadOnlyList<Persona>>> ObtenerListaPersonas() 
        {
            var query = new ObtenerTodasPersonasQuery();

            var todosUsuarios = await _mediator.Send(query);

            return Ok(todosUsuarios);
        }

        [HttpPost("crearPersona", Name = "CrearPersona")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<Persona>> CrearPersona([FromBody] CrearPersonaCommand request)
        {
            return await _mediator.Send(request);
        }

    }
}
