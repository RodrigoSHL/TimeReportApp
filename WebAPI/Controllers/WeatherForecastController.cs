using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Persistencia;

namespace WebAPI.Controllers
{
    //localhost:5000/[controller]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly TimeReportContext context;

        //Servicio para arrancar el contexto inmediatamente
        public WeatherForecastController(TimeReportContext _context){
            this.context = _context;
        }

        [HttpGet]
        public IEnumerable<Proyecto> Get(){
            return context.Proyecto.ToList();
        }
    }
}
