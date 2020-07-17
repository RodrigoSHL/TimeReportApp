using System;

namespace Dominio
{
    public class TimeReport
    {
        public Guid TimeReportId {get;set;}
        public DateTime FechaInicio {get;set;}
        public TimeSpan HoraInicio {get;set;}
        public TimeSpan HoraFin {get;set;}
        public string Titulo {get;set;}
        public string Descripcion {get;set;}
        public DateTime? FechaCreacion {get;set;}

        public Guid ProyectoId {get;set;}
        public Proyecto Proyecto {get;set;}
    }
}