using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacion.Proyectos;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    //localhost:5000/api/[controller]
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectosController : MiControllerBase
    {
        [Authorize(Roles = "Operador")]
        [HttpGet]
        public async Task<ActionResult<List<ProyectoDto>>> Get(){
            return await Mediator.Send(new Consulta.ListaProyectos());
        }
        //localhost:5000/api/[controller]/{id}

        [HttpGet("{id}")]
        public async Task<ActionResult<ProyectoDto>> Detalle(Guid id){
            return await Mediator.Send(new ConsultaId.ProyectoUnico{Id=id});
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data){
            return await Mediator.Send(data);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, Editar.Ejecuta data){
            data.ProyectoId = id;
            return await Mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id){
            return await Mediator.Send(new Eliminar.Ejecuta{Id=id});
        }
    }
}