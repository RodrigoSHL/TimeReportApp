using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Proyectos
{
    public class Consulta
    {
        public class ListaProyectos : IRequest<List<ProyectoDto>> {}
        //Handler
        public class Manejador : IRequestHandler<ListaProyectos, List<ProyectoDto>>
        {
            private readonly TimeReportContext _context;
            private readonly IMapper _mapper;
            public Manejador(TimeReportContext context, IMapper mapper){
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<ProyectoDto>> Handle(ListaProyectos request, CancellationToken cancellationToken)
            {
                var proyectos = await _context.Proyecto
                                              .Include(x => x.TimeReportLista)
                                              .Include(x => x.EtapaLink)
                                              .ThenInclude(x => x.Etapa)
                                              .ToListAsync();

                var proyectosDto = _mapper.Map<List<Proyecto>, List<ProyectoDto>>(proyectos);
                return proyectosDto;
            }
        }

    }
}