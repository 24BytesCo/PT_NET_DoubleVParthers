using _3.Application.Persistence;
using _4.Domain;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Application.Features.Personas.Queries.ConsultarTodasPersonas
{
    public class ObtenerTodasPersonasQueryHandler : IRequestHandler<ObtenerTodasPersonasQuery, IReadOnlyList<Persona>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ObtenerTodasPersonasQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public Task<IReadOnlyList<Persona>> Handle(ObtenerTodasPersonasQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.Repository<Persona>().ObtenerTodasPersonas();
        }
    }
}
