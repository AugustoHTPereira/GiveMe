using Dados.Conexao.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Dados.Conexao
{
    public class ConexaoSqlServer : IConexao
    {
        SqlConnection _conexao;
        public ConexaoSqlServer()
        {
            _conexao = new SqlConnection(@"Server=localhost\SQLEXPRESS; Initial Catalog=EMPRESTEI; Integrated Security=true;");
        }
        public void Close()
        {
            try
            {
                if (_conexao.State == System.Data.ConnectionState.Open || _conexao.State == System.Data.ConnectionState.Broken)
                    _conexao.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (_conexao.State == System.Data.ConnectionState.Open || _conexao.State == System.Data.ConnectionState.Broken)
                    _conexao.Close();
            }
        }

        public void Dispose()
        {
            try
            {
                Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _conexao = null;
                GC.SuppressFinalize(this);
            }
        }

        public SqlConnection Open()
        {
            try
            {
                if (_conexao.State.Equals(System.Data.ConnectionState.Closed))
                    _conexao.Open();
                return _conexao;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
