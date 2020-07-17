using System.Collections.Generic;
using System;

namespace Dominio
{
    public class Etapa
    {
        public Guid EtapaId {get;set;}
        public string NombreEtapa{get;set;}
        public DateTime? FechaCreacion {get;set;}

        public ICollection<ProyectoEtapa> ProyectoLink {get;set;}
    }
}