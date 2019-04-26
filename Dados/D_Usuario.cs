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
    public class D_Usuario : IDAL<Usuario>
    {
        IConexao _conexao;
        public D_Usuario(IConexao conexao)
        {
            _conexao = conexao;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Insert(Usuario Model)
        {
            try
            {
                using (SqlCommand cmd = _conexao.Open().CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO USUARIO (LOGIN, SENHA, EMAIL, PESSOAID) VALUES (@LOGIN, @SENHA, @EMAIL, @PESSOAID);";
                    cmd.Parameters.AddWithValue("@LOGIN", Model.Login);
                    cmd.Parameters.AddWithValue("@SENHA", Model.Senha);
                    cmd.Parameters.AddWithValue("@EMAIL", Model.Email);
                    cmd.Parameters.AddWithValue("@PESSOAID", Model.PessoaId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Usuario: " + ex.Message);
            }
        }

        public Task InsertAsync(Usuario Model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> SelectAllAsync()
        {
            throw new NotImplementedException();
        }

        public int SelectIdentity()
        {
            try
            {
                int Id;
                using (SqlCommand cmd = _conexao.Open().CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "SELECT TOP 1 ID FROM USUARIO ORDER BY ID DESC";
                    Id = (int)cmd.ExecuteScalar();
                }
                return Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<int> SelectIdentityAsync()
        {
            throw new NotImplementedException();
        }

        public Usuario SelectOneLine(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> SelectOneLineAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario Model)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Usuario Model)
        {
            throw new NotImplementedException();
        }

        #region Others
        public bool HasUser(string Login, string Senha)
        {
            try
            {
                bool Has;
                using (SqlCommand cmd = _conexao.Open().CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "SELECT ID FROM USUARIO WHERE LOGIN = @LOGIN AND SENHA = @SENHA";
                    cmd.Parameters.AddWithValue("@LOGIN", Login);
                    cmd.Parameters.AddWithValue("@SENHA", Senha);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Has = reader.HasRows ? true : false;
                    }
                }
                return Has;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
