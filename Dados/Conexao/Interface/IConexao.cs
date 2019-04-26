using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados.Conexao.Interface
{
    public interface IConexao : IDisposable
    {
        SqlConnection Open();
        void Close();
    }
}
