//using _4.Domain;
//using FluentValidation;
//using MediatR;
//using Microsoft.EntityFrameworkCore;

//namespace _3.Application.Features.Usuarios.Commands
//{
//    public class CrearUsuarioCommand
//    {
//        public class CrearUsuarioCommandRequest : IRequest
//        {
//            public string? NombreUsuario { get; set; }

//            public string? Pass { get; set; }

//        }

//        public class CrearUsuarioCommandRequestValidator : AbstractValidator<CrearUsuarioCommandRequest>
//        {
//            public CrearUsuarioCommandRequestValidator()
//            {
//                RuleFor(x => x.NombreUsuario).NotEmpty().NotNull();
//                RuleFor(x => x.Pass).NotEmpty().NotNull();
//            }

//        }

//        public class CrearUsuarioCommandRequestHandler : IRequestHandler<CrearUsuarioCommandRequest>
//        {
//            private readonly PTDbContext _context;

//            public CrearUsuarioCommandRequestHandler(DbContext context)
//            {
//                _context = context;
//            }

//            public async Task<Unit> Handle(CrearUsuarioCommandRequest request, CancellationToken cancellationToken)
//            {
//                var nuevoUsuario = new Usuario
//                {
//                    Identificador = Guid.NewGuid(),
//                    UserName = request.NombreUsuario,
//                    PasswordHash = request.Pass,
//                };

//                _context.Add(nuevoUsuario);


//                if (await _context.SaveChangesAsync() > 0)
//                {
//                    return Unit.Value;
//                }

//                throw new Exception("No se pudo crear el usuario");
//            }

//        }





//    }
//}
