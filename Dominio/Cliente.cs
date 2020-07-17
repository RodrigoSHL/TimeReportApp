using System.Collections.Generic;
using System;

namespace Dominio
{
    public class Cliente
    {
        public Guid ClienteId {get;set;}
        public string NombreCliente {get;set;}
        public DateTime? FechaCreacion {get;set;}

        public ICollection<Proyecto> ProyectoLista {get;set;}
    }
}