using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Pessoa
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Inscricao { get; set; }
        public DateTime Nascimento { get; set; }
        public Imagem Foto { get; set; }
        public bool Situacao { get; set; }
    }
}
