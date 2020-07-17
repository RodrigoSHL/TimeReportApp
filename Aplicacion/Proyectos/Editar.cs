using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using Dominio;
using FluentValidation;
using MediatR;
using Persistencia;

namespace Aplicacion.Proyectos
{
    public class Editar
    {
            public class Ejecuta : IRequest {

            public Guid ProyectoId {get;set;}  
            public string NombreProyecto {get;set;}
            public Guid? ClienteId {get;set;}

            public List<Guid> ListaEtapa {get;set;}

            }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly TimeReportContext _context;
            public Manejador(TimeReportContext context){
                _context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var proyecto = await _context.Proyecto.FindAsync(request.ProyectoId);
                if(proyecto==null){
                    //throw new Exception("No se puede eliminar el curso");
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new{mensaje = "No se encontró el proyecto"});
                }

                proyecto.NombreProyecto = request.NombreProyecto ?? proyecto.NombreProyecto;
                proyecto.ClienteId = request.ClienteId ?? proyecto.ClienteId;
                proyecto.FechaCreacion = DateTime.UtcNow;

                if(request.ListaEtapa!=null){
                    if(request.ListaEtapa.Count>0){
                        //Eliminar las etapas actuales
                        var etapasBD = _context.ProyectoEtapa.Where(x => x.ProyectoId == request.ProyectoId).ToList();
                        foreach(var etapaEliminar in etapasBD){
                            _context.ProyectoEtapa.Remove(etapaEliminar);
                        }
                        //Fin Eliminar

                        //Procedimiento para agregar nuevas etapas
                        foreach( var id in request.ListaEtapa){
                            var nuevaEtapa = new ProyectoEtapa {
                                ProyectoId = request.ProyectoId,
                                EtapaId = id
                            };
                            _context.ProyectoEtapa.Add(nuevaEtapa);
                        }
                        //Fin procedimiento
                    }
                }


                //if(request.ClienteId < 0){
                //    proyecto.ClienteId = proyecto.ClienteId;
                //}

                var resultado = await _context.SaveChangesAsync();
                if(resultado>0){
                    return Unit.Value;
                }
                throw new Exception("No se guardaron los cambios en el proyecto");
            }
        }
    }
}