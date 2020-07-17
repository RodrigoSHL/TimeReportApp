using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Aplicacion.Contratos;
using Dominio;
using Microsoft.IdentityModel.Tokens;

namespace Seguridad
{
    public class JwtGenerador : IJwtGenerador
    {
        string IJwtGenerador.CrearToken(Usuario usuario, List<string> roles)
        {
            //Lista de claims
            var claims = new List<Claim>{
                new Claim(JwtRegisteredClaimNames.NameId, usuario.UserName)
            };

            if(roles!=null){
                foreach(var rol in roles){
                    claims.Add(new Claim(ClaimTypes.Role, rol));
                }
            }

            //key para jwt
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Mi palabra secret"));
            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescripcion = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(30),
                SigningCredentials = credenciales
            };
            //Token handler para crear el token
            var tokenManejador = new JwtSecurityTokenHandler();
            var token = tokenManejador.CreateToken(tokenDescripcion);

            return tokenManejador.WriteToken(token);

        }
    }
}