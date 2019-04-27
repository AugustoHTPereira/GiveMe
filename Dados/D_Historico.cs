using Dados.Conexao.Interface;
using Dados.Interface;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class D_Historico : IDAL<Historico>
    {
        IConexao _conexao;
        public D_Historico(IConexao conexao)
        {
            _conexao = conexao;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Insert(Historico Model)
        {
            try
            {
                using(SqlCommand cmd = _conexao.Open().CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO HISTORICO (TABELA, REGISTROID, TIPOID, USUARIOID) " +
                        " VALUES (@TABELA, @REGISTROID, @TIPOID, @USUARIOID)";
                    cmd.Parameters.AddWithValue("@TABELA", Model.Tabela);
                    cmd.Parameters.AddWithValue("@REGISTROID", Model.RegistroId);
                    cmd.Parameters.AddWithValue("@TIPOID", Model.TipoId);
                    cmd.Parameters.AddWithValue("@USUARIOID", Model.UsuarioId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Historico: " + ex.Message);
            }
        }

        public Task InsertAsync(Historico Model)
        {
            throw new NotImplementedException();
        }

        public IList<Historico> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Historico>> SelectAllAsync()
        {
            throw new NotImplementedException();
        }

        public int SelectIdentity()
        {
            throw new NotImplementedException();
        }

        public Task<int> SelectIdentityAsync()
        {
            throw new NotImplementedException();
        }

        public Historico SelectOneLine(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Historico> SelectOneLineAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Historico Model)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Historico Model)
        {
            throw new NotImplementedException();
        }
    }
}
