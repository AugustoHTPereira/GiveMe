using Microsoft.IdentityModel.Tokens;
using Modelo;
using Negocio;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web.Http;

namespace WSAPI.Controllers
{
    public class TokenController : ApiController
    {
        //CHAVE DE SEGURANÇA PODE SER QUALQUER VALOR
        readonly string Key = "1A2B3C4D#Ç789456123AFFF";

        [AllowAnonymous]
        // MÉTODO DE VALIDAÇÃO DO USUÁRIO, NELE É GERADO O TOKEN CASO SEJA UM USUÁRIO VÁLIDO
        public IHttpActionResult Post([FromBody] Usuario usuario)
        {
            Usuario autenticado;

            try
            {
                //REALIZA O LOGIN DO USUÁRIO COM OS DADOS DE LOGIN PASSADOS PELO CORPO DA REQUISIÇÃO
                autenticado = N_Usuario.Logar(usuario.Login, usuario.Senha);
            }
            catch (Exception ex)
            {
                return BadRequest("LOGIN ERROR " + ex.Message);
            }

            try
            {
                if (autenticado != null)
                {
                    //CRIA AS CLAIMS DO USUÁRIO, DADOS A SEREM PASSADOS VIA TOKEN
                    var Claims = new[]
                    {
                        new Claim(ClaimTypes.Name, autenticado.Id.ToString())
                    };

                    // GERA A CHAVE DE SEGURANÇA COM BASE NA CHAVE CRIADA 
                    SymmetricSecurityKey SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));

                    // DEFINE O ALGORÍTIMO DE CRIPTOGRAFIA E GERA AS CREDENCIAIS PARA A ASSINATURA
                    var Credencials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

                    // CRIA O TOKEN DO USUÁRIO
                    var Token = new JwtSecurityToken(issuer: "EMPRESTEI", audience: "EMPRESTEI", claims: Claims, expires: DateTime.Now.AddMinutes(5), signingCredentials: Credencials);

                    //RETORNA O TOKEN CRIADO
                    return Ok(new { Token = new JwtSecurityTokenHandler().WriteToken(Token) });
                }
                else
                    return BadRequest("LOGIN ERROR Incorrect credentials.");    // CASO NÃO SEJA AUTENTICADO O USUÁRIO
            }
            catch (Exception ex)
            {
                return BadRequest("GENERATE TOKEN ERROR " + ex.Message);
            }
        }
    }
}
