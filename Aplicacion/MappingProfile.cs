using System.Linq;
using Aplicacion.Proyectos;
using AutoMapper;
using Dominio;

namespace Aplicacion
{
    public class MappingProfile : Profile
    {
        public MappingProfile(){
            CreateMap<Proyecto, ProyectoDto>()
            .ForMember(x => x.Etapas, y => y.MapFrom(z => z.EtapaLink.Select(a => a.Etapa).ToList()) )
            .ForMember(x => x.Reportes, y => y.MapFrom(z => z.TimeReportLista));
            CreateMap<ProyectoEtapa, ProyectoEtapaDto>();
            CreateMap<Etapa, EtapaDto>();
            CreateMap<Cliente, ClienteDto>();
            CreateMap<TimeReport, TimeReportDto>();
        }
    }
}