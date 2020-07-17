using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using MediatR;
using Persistencia;

namespace Aplicacion.Proyectos
{
    public class Eliminar
    {
        public class Ejecuta : IRequest {
            public Guid Id{get;set;}
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly TimeReportContext _context;
            public Manejador(TimeReportContext context){
                _context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var etapasDB = _context.ProyectoEtapa.Where(x => x.ProyectoId == request.Id);
                foreach (var etapa in etapasDB){
                    _context.ProyectoEtapa.Remove(etapa);
                }

                var proyecto = await _context.Proyecto.FindAsync(request.Id);
                if(proyecto==null){
                    //throw new Exception("No se puede eliminar el curso");
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new{mensaje = "No se encontró el proyecto"});
                }
                _context.Remove(proyecto);

                var resultado = await _context.SaveChangesAsync();

                if(resultado>0){
                    return Unit.Value;
                }
                throw new Exception("No se pudieron guardar los cambios");
            }
        }
    }
}