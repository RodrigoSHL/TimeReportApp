using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Identity;

namespace Persistencia
{
    public class DataPrueba
    {
        public static async Task InsertarData(TimeReportContext context, UserManager<Usuario> usuarioManager){
            if(!usuarioManager.Users.Any()){
                var usuario = new Usuario{NombreCompleto = "Rodrigo Catalan", UserName="shl.catalan", Email="shl.catalan@gmail.com"};
                await usuarioManager.CreateAsync(usuario, "Password123$$");
            }
        }
    }
}