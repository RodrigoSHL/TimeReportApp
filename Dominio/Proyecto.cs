using System.Collections.Generic;
using System;

namespace Dominio
{
    public class Proyecto
    {
        public Guid ProyectoId {get;set;}
        public string NombreProyecto {get;set;}
        public Guid? ClienteId {get;set;}
        public Cliente Cliente {get;set;}
        public float TotalHorasDuracion {get;set;}
        public int TotalDiasDuracion {get;set;}
        public DateTime? FechaCreacion {get;set;}
        public ICollection<TimeReport> TimeReportLista {get;set;}
        public ICollection<ProyectoEtapa> EtapaLink {get;set;}
    }
}