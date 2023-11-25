using _3.Application.DTOs;
using _3.Application.Persistence;
using _4.Domain;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Application.Features.Usuarios.Queries.ObtenerListaUsuarios
{
    public class ObtenerListaUsuariosQueryHandler : IRequestHandler<ObtenerListaUsuariosQuery, IReadOnlyList<UsuarioDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ObtenerListaUsuariosQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<UsuarioDTO>> Handle(ObtenerListaUsuariosQuery request, CancellationToken cancellationToken)
        {
            var todosUsuarios = await _unitOfWork.Repository<Usuario>().GetAllAsync();

            return _mapper.Map<IReadOnlyList<UsuarioDTO>>(todosUsuarios);
        }
    }

}
