using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using AutoMapper;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Proyectos
{
    public class ConsultaId
    {
        public class ProyectoUnico : IRequest<ProyectoDto>{
            public Guid Id {get;set;}
        }

        public class Manejador : IRequestHandler<ProyectoUnico, ProyectoDto>
        {
            private readonly TimeReportContext _context;
            private readonly IMapper _mapper;
            public Manejador(TimeReportContext context, IMapper mapper){
                _context = context;
                _mapper = mapper;
            }
            public async Task<ProyectoDto> Handle(ProyectoUnico request, CancellationToken cancellationToken)
            {
                var proyecto = await _context.Proyecto
                                              .Include(x => x.TimeReportLista)
                                              .Include(x => x.EtapaLink)
                                              .ThenInclude(y => y.Etapa)
                                              .FirstOrDefaultAsync(a => a.ProyectoId == request.Id);
                if(proyecto==null){
                    //throw new Exception("No se puede eliminar el curso");
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new{mensaje = "No se encontró el proyecto"});
                }
                var proyectoDto = _mapper.Map<Proyecto, ProyectoDto>(proyecto);
                return proyectoDto;
            }
        }
    }
}