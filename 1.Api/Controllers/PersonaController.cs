using _3.Application.DTOs;
using _3.Application.Features.Auth.Commands.Login;
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
        [ProducesResponseType(typeof(IReadOnlyList<UsuarioDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IReadOnlyList<UsuarioDTO>>> ObtenerListaPersonas() 
        {
            var query = new ObtenerListaUsuariosQuery();

            var todosUsuarios = await _mediator.Send(query);

            return Ok(todosUsuarios);
        }

        [HttpPost("crearPersona", Name = "CrearPersona")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<AuthDTO>> CrearPersona([FromBody] CrearUsuarioCommand request)
        {
            return await _mediator.Send(request);
        }

    }
}
