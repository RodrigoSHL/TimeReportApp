using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using MediatR;
using Persistencia;

namespace Aplicacion.TimeReports
{
    public class Eliminar
    {
        public class Ejecuta : IRequest {
            public Guid Id {get;set;}            
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly TimeReportContext _context;
            public Manejador(TimeReportContext context){
                _context = context;
            }
            
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var timeReport = await _context.TimeReport.FindAsync(request.Id);
                if(timeReport==null){
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {mensaje="No se encontró el reporte"});
                }
                _context.Remove(timeReport);

                var resultado = await _context.SaveChangesAsync();
                if(resultado>0){
                    return Unit.Value;
                }
                throw new Exception("No se pudo eliminar el reporte");
            }
        }
    }
}