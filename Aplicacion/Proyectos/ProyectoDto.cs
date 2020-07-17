using System;
using System.Collections.Generic;
using Dominio;

namespace Aplicacion.Proyectos
{
    public class ProyectoDto
    {
        public Guid ProyectoId {get;set;}
        public string NombreProyecto {get;set;}
        public Guid? ClienteId {get;set;}
        public DateTime FechaCreacion {get;set;}
        public ICollection<EtapaDto> Etapas {get;set;}
        public ICollection<TimeReportDto> Reportes {get;set;}
    }
}