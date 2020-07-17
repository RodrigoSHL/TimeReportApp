using System;

namespace Aplicacion.Proyectos
{
    public class ProyectoEtapaDto
    {
        public Guid ProyectoId {get;set;}
        public Guid EtapaId {get;set;}
        public float HorasDisponibles{get;set;}
    }
}