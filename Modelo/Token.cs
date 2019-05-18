using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Token
    {
        public Token()
        {
            Expiress = 5;
            Issuer = "Emprestei";
            Audience = "Emprestei";
            SecurityKey = "oj11cy5k5sznune7yico2pfwtupt7xyl6od9d9k8r9mdmrbb0d";
        }
        public string SecurityKey { get; set; }
        public int Expiress { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
