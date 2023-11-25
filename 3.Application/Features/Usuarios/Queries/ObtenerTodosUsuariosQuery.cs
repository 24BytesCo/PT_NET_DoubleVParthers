//using _3.Application.DTOs;
//using AutoMapper;
//using MediatR;
//using Microsoft.EntityFrameworkCore;

//namespace _3.Application.Features.Usuarios.Queries
//{
//    public class ObtenerTodosUsuariosQuery
//    {

//        public class ObtenerTodosUsuariosQueryRequest : IRequest<List<UsuarioDTO>> { }

//        public class ObtenerTodosUsuariosQueryHandler : IRequestHandler<ObtenerTodosUsuariosQueryRequest, List<UsuarioDTO>>
//        {
//            private readonly DbContext _context;
//            private readonly IMapper _mapper;

//            public ObtenerTodosUsuariosQueryHandler(DbContext context, IMapper mapper)
//            {
//                _context = context;
//                _mapper = mapper;
//            }

//            public Task<List<UsuarioDTO>> Handle(ObtenerTodosUsuariosQueryRequest request, CancellationToken cancellationToken)
//            {
//                throw new NotImplementedException();
//            }
//        }


//    }
//}
