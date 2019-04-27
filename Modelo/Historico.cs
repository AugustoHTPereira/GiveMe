using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Historico
    {
        public int Id { get; set; }
        public int RegistroId { get; set; }
        public int TipoId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Data { get; set; }
        public string Tabela { get { return tabela; } set { tabela = value.ToUpper().Trim(); } }
        private string tabela;
    }
}
