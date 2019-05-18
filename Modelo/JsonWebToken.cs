using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class JsonWebToken
    {
        public bool autenticated { get; set; }
        public string acesstoken { get; set; }
        public int userid { get; set; }
        public DateTime created { get; set; }
        public DateTime expire { get; set; }
        public string message { get; set; }
        public bool mailconfirm { get; set; }
        public Usuario user { get; set; }

        //autenticated = true,
        //acesstoken = strToken,
        //userid = User.Id,
        //created = issuedAt,
        //expire = expires,
        //message = "Ok",
        //mailconfirm = User.ConfirmacaoEmail,
        //user = User
    }
}
