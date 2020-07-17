using System;

namespace Aplicacion.Proyectos
{
    public class TimeReportDto
    {
        public Guid TimeReportId {get;set;}
        public DateTime FechaInicio {get;set;}
        public string Titulo {get;set;}
        public string Descripcion {get;set;}
        public Guid ProyectoId {get;set;}
        public DateTime FechaCreacion{get;set;}
    }
}