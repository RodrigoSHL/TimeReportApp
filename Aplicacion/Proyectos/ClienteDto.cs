using System;

namespace Aplicacion.Proyectos
{
    public class ClienteDto
    {
        public Guid ClienteId {get;set;}
        public string NombreCliente {get;set;}
        public DateTime FechaCreacion{get;set;}
    }
}