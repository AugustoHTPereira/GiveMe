using Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    public class TokenController : ApiController
    {
        public object Post([FromBody] Usuario RequestUser)
        {
            // Lock null users
            if (RequestUser == null)
                return Unauthorized();
            if (string.IsNullOrEmpty(RequestUser.Login) || string.IsNullOrEmpty(RequestUser.Senha))
                return Unauthorized();
            // End lock null users
            Usuario user = null;
            try
            {
                user = Negocio.N_Usuario.Logar(RequestUser.Login, RequestUser.Senha);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            if (user == null)
                return Unauthorized();

            return (GenerateTokenJwt(user));
        }

        object GenerateTokenJwt(Usuario User)
        {
            //Set issued at date
            DateTime issuedAt = DateTime.UtcNow;
            //set the time when it expires
            DateTime expires = DateTime.UtcNow.AddHours(1);

            var tokenHandler = new JwtSecurityTokenHandler();

            //create a identity and add claims to the user which we want to log in
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                new System.Security.Principal.GenericIdentity(User.Id.ToString(), "Login"),
                new[]
                {

                    new Claim(ClaimTypes.Name, User.Id.ToString())
                });

            const string sec = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
            var now = DateTime.UtcNow;
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));
            var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);


            //create the jwt
            var token =
                (JwtSecurityToken)
                    tokenHandler.CreateJwtSecurityToken(issuer: "Emprestei", audience: "Emprestei",
                        subject: claimsIdentity, notBefore: issuedAt, expires: expires, signingCredentials: signingCredentials);
            string strToken = tokenHandler.WriteToken(token);
            
            // insert into database async
            Task task = new Task(() => InsertToken(new JsonWebToken
            {
                acesstoken = strToken,
                userid = User.Id

            }));
            task.Wait(1000);
            task.Start();

            async void InsertToken(JsonWebToken Token)
            {
                await Negocio.N_JsonWebToken.Insert(Token);
            }
            // end insert into database async

            return new
            {
                autenticated = true,
                acesstoken = strToken,
                userid = User.Id,
                created = issuedAt,
                expire = expires,
                message = "Ok",
                mailconfirm = User.ConfirmacaoEmail,
                user = User
            };
        }
        
    }
}
