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
    public class D_Pessoa : IDAL<Pessoa>
    {
        IConexao _conexao;
        public D_Pessoa(IConexao conexao)
        {
            _conexao = conexao;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #region CRUD
        public void Insert(Pessoa Model)
        {
            try
            {
                using (SqlCommand cmd = _conexao.Open().CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO PESSOA (NOME, SOBRENOME, INSCRICAO, NASCIMENTO) VALUES (@NOME, @SOBRENOME, @INSCRICAO, @NASCIMENTO);";
                    cmd.Parameters.AddWithValue("@NOME", Model.Nome);
                    cmd.Parameters.AddWithValue("@SOBRENOME", Model.Sobrenome);
                    cmd.Parameters.AddWithValue("@INSCRICAO", Model.Inscricao);
                    cmd.Parameters.AddWithValue("@NASCIMENTO", Model.Nascimento);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Pessoa: " + ex.Message); 
            }
        }

        public int SelectIdentity()
        {
            try
            {
                int Id;
                using (SqlCommand cmd = _conexao.Open().CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "SELECT TOP 1 ID FROM PESSOA ORDER BY ID DESC";
                    Id = (int)cmd.ExecuteScalar();
                }
                return Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Pessoa SelectOneLine(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Pessoa Model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pessoa> SelectAll()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region CRUD_ASYNC
        public Task InsertAsync(Pessoa Model)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Pessoa>> SelectAllAsync()
        {
            throw new NotImplementedException();
        }
        public Task<int> SelectIdentityAsync()
        {
            throw new NotImplementedException();
        }
        public Task<Pessoa> SelectOneLineAsync(int Id)
        {
            throw new NotImplementedException();
        }
        public Task UpdateAsync(Pessoa Model)
        {
            throw new NotImplementedException();
        }
        #endregion

        
    }
}
