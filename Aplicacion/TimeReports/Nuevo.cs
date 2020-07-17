using System;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using FluentValidation;
using MediatR;
using Persistencia;

namespace Aplicacion.TimeReports
{
    public class Nuevo
    {
        public class Ejecuta : IRequest {
            public Guid TimeReportId {get;set;}
            public DateTime FechaInicio {get;set;}
            public TimeSpan? HoraInicio {get;set;}
            public TimeSpan? HoraFin {get;set;}
            public string Titulo {get;set;}
            public string Descripcion {get;set;}
            public Guid ProyectoId {get;set;}
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>{
            public EjecutaValidacion(){
                RuleFor(x => x.FechaInicio).NotEmpty();
                RuleFor(x => x.Titulo).NotEmpty();
                RuleFor(x => x.Descripcion).NotEmpty();
                RuleFor(x => x.ProyectoId).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>{
            private readonly TimeReportContext _context;
            public Manejador(TimeReportContext context){
                _context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken){
                var timeReport = new TimeReport{
                    TimeReportId = Guid.NewGuid(),
                    FechaInicio = request.FechaInicio,
                    Titulo = request.Titulo,
                    Descripcion = request.Descripcion,
                    ProyectoId = request.ProyectoId,
                    FechaCreacion = DateTime.UtcNow
                };

                _context.TimeReport.Add(timeReport);

                var resultado = await _context.SaveChangesAsync();
                if(resultado>0){
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar el reporte");

            }
        }

    }
}