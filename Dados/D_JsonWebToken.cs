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
    public class D_JsonWebToken : IDAL<JsonWebToken>
    {
        IConexao _conexao;
        public D_JsonWebToken(Conexao.ConexaoSqlServer conexao)
        {
            _conexao = conexao;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Insert(JsonWebToken Model)
        {
            throw new NotImplementedException();
        }

        public async Task InsertAsync(JsonWebToken Model)
        {
            try
            {
                using (SqlCommand cmd = _conexao.Open().CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO JSONWEBTOKEN (TOKEN, USUARIOID) VALUES (@TOKEN, @USUARIOID);";
                    cmd.Parameters.AddWithValue("@TOKEN", Model.Token);
                    cmd.Parameters.AddWithValue("@USUARIOID", Model.UsuarioId);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<JsonWebToken> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Task<IList<JsonWebToken>> SelectAllAsync()
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

        public JsonWebToken SelectOneLine(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<JsonWebToken> SelectOneLineAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(JsonWebToken Model)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(JsonWebToken Model)
        {
            throw new NotImplementedException();
        }
    }
}
