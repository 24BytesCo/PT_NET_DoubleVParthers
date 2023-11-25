using _3.Application.DTOs;
using _3.Application.Features.Usuarios.Queries.ObtenerListaUsuarios;
using _4.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace _1.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list", Name = "ObtenerListaUsuarios")]
        [ProducesResponseType(typeof(IReadOnlyList<UsuarioDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IReadOnlyList<UsuarioDTO>>> ObtenerListaUsuarios() 
        {
            var query = new ObtenerListaUsuariosQuery();

            var todosUsuarios = await _mediator.Send(query);

            return Ok(todosUsuarios);
        }
    }
}
