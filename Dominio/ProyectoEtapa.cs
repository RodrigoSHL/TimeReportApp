using System;

namespace Dominio
{
    public class ProyectoEtapa
    {
        public Guid ProyectoId {get;set;}
        public Guid EtapaId {get;set;}
        public float HorasDisponibles{get;set;}
        public int DiasDisponibles {get;set;}
        public Proyecto Proyecto{get;set;}
        public Etapa Etapa{get;set;}        
    }
}