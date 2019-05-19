using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
        public bool Situacao { get; set; }
        public bool ConfirmacaoEmail { get; set; }
        public string Token { get; set; }
    }
}
