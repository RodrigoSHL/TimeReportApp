using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using Dominio;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Persistencia;

namespace Aplicacion.Seguridad
{
    public class UsuarioRolAgregar
    {
        public class Ejecuta : IRequest {
            public string Username {get;set;}
            public string RolNombre {get;set;}
        }

        public class EjecutaValidador : AbstractValidator<Ejecuta>{
            public EjecutaValidador(){
                RuleFor(x=> x.Username).NotEmpty();
                RuleFor(x=> x.RolNombre).NotEmpty();
            }
        }

        public class Manjeador : IRequestHandler<Ejecuta>
        {

            private readonly UserManager<Usuario> _userManager;
            private readonly RoleManager<IdentityRole> _roleManager;

            public Manjeador(UserManager<Usuario> userManager, RoleManager<IdentityRole> roleManager){
                _userManager = userManager;
                _roleManager = roleManager;

            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var role = await _roleManager.FindByNameAsync(request.RolNombre);
                if(role == null){
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {mensaje = "El rol no existe"});
                }

                var usuarioIden = await _userManager.FindByNameAsync(request.Username);
                if(usuarioIden == null){
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {mensaje = "El usuario no existe"});
                }

                var resultado = await _userManager.AddToRoleAsync(usuarioIden, request.RolNombre);
                if(resultado.Succeeded){
                    return Unit.Value;
                }
                
                throw new System.Exception("No se pudo agregar el rol al usuario");


            }
        }

    }
}