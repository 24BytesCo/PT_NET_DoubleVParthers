using _4.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Application.Features.Personas.Queries.ConsultarTodasPersonas
{
    public class ObtenerTodasPersonasQuery: IRequest<IReadOnlyList<Persona>>
    {
    }
}
