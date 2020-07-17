using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using FluentValidation;
using MediatR;
using Persistencia;

namespace Aplicacion.Proyectos
{
    public class Nuevo
    {
        public class Ejecuta : IRequest {

            public string NombreProyecto {get;set;}
            public Guid? ClienteId {get;set;}

            public List<Guid> ListaEtapas {get;set;}
        }
        public class EjecutaValidacion : AbstractValidator<Ejecuta>{
            public EjecutaValidacion(){
                RuleFor(x => x.NombreProyecto).NotEmpty();
                RuleFor(x => x.ClienteId).NotEmpty();
            }
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly TimeReportContext _context;
            public Manejador(TimeReportContext context){
                _context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                Guid _proyectoId = Guid.NewGuid();
                var proyecto = new Proyecto{
                    ProyectoId = _proyectoId,
                    NombreProyecto = request.NombreProyecto,
                    ClienteId = request.ClienteId,
                    FechaCreacion = DateTime.UtcNow
                };

                _context.Proyecto.Add(proyecto);

                //Recorrer arreglo de etapas, y aser un save por cada etapa.
                if(request.ListaEtapas!=null){
                    foreach(var id in request.ListaEtapas){
                        var proyectoEtapa = new ProyectoEtapa{
                            ProyectoId = _proyectoId,
                            EtapaId = id
                        };
                        _context.ProyectoEtapa.Add(proyectoEtapa);
                    }
                }

                var valor = await _context.SaveChangesAsync();

                if(valor>0){
                    return Unit.Value;
                }

                throw new Exception("No se pudo insertar el proyecto");
            }
        }
    }
}