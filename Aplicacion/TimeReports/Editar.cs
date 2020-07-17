using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using MediatR;
using Persistencia;

namespace Aplicacion.TimeReports
{
    public class Editar
    {
        public class Ejecuta : IRequest {
            public Guid TimeReportId {get;set;}
            public DateTime? FechaInicio {get;set;}
            public TimeSpan? HoraInicio {get;set;}
            public TimeSpan? HoraFin {get;set;}
            public string Titulo {get;set;}
            public string Descripcion {get;set;}
            public Guid? ProyectoId {get;set;}            
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly TimeReportContext _context;
            public Manejador(TimeReportContext context){
                _context = context;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var timeReport = await _context.TimeReport.FindAsync(request.TimeReportId);
                if(timeReport==null){
                        throw new ManejadorExcepcion(HttpStatusCode.NotFound, new{mensaje = "No se encontró el reporte"});
                }
                timeReport.FechaInicio = request.FechaInicio ?? timeReport.FechaInicio;
                timeReport.Titulo = request.Titulo ?? timeReport.Titulo;
                timeReport.Descripcion = request.Descripcion ?? timeReport.Descripcion;
                timeReport.ProyectoId = request.ProyectoId ?? timeReport.ProyectoId;
                timeReport.FechaCreacion = DateTime.UtcNow;
               
               var resultado = await _context.SaveChangesAsync();
                if(resultado>0){
                    return Unit.Value;
                }
                throw new Exception("No se guardaron los cambios en el reporte");         
            }
        }




    }
}