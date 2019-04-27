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
    public class D_Produto : IDAL<Produto>
    {
        IConexao _conexao;
        public D_Produto(IConexao conexao)
        {
            _conexao = conexao;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #region CRUD
        public void Insert(Produto Model)
        {
            try
            {
                using (SqlCommand cmd = _conexao.Open().CreateCommand())
                {   
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO PRODUTO (NOME, DESCRICAO, OBSERVACAO, LIMITEDIASEMPRESTIMO, VALOR, USUARIOCRIACAOID) " +
                        " VALUES(@NOME, @DESCRICAO, @OBSERVACAO, @LIMITEDIAS, @VALOR, @USUARIOCRIACAOID)";
                    cmd.Parameters.AddWithValue("@NOME", Model.Nome);
                    cmd.Parameters.AddWithValue("@DESCRICAO", Model.Descricao);
                    cmd.Parameters.AddWithValue("@OBSERVACAO", Model.Observacao);
                    cmd.Parameters.AddWithValue("@LIMITEDIAS", Model.LimiteDiasEmprestimo);
                    cmd.Parameters.AddWithValue("@USUARIOCRIACAOID", Model.UsuarioCriacao.Id);
                    cmd.Parameters.AddWithValue("@VALOR", Model.Valor);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Usuario: " + ex.Message);
            }
        }
        public IList<Produto> SelectAll()
        {
            throw new NotImplementedException();
        }
        public int SelectIdentity()
        {
            throw new NotImplementedException();
        }
        public Produto SelectOneLine(int Id)
        {
            throw new NotImplementedException();
        }
        public void Update(Produto Model)
        {
            throw new NotImplementedException();
        }
        public IList<Produto> SelectAllByCriator(int CreatorId)
        {
            try
            {
                IList<Produto> Produtos = null;
                using (SqlCommand cmd = _conexao.Open().CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = 
                        " SELECT " +
                        " P.ID, " +
                        " P.NOME, " +
                        " P.DESCRICAO, " +
                        " P.OBSERVACAO, " +
                        " P.CADASTRO, " +
                        " P.LIMITEDIASEMPRESTIMO, " +
                        " P.[STATUS]," +
                        " P.SITUACAO," +
                        " PC.ID AS 'USUARIOCRIACAO_ID'," +
                        " PC.NOME AS 'USUARIOCRIACAO_NOME'," +
                        " PL.ID AS 'USUARIOLOCATARIO_ID'," +
                        " PL.NOME AS 'USUARIOLOCATARIO_NOME'" +
                        " FROM PRODUTO P" +
                        " INNER JOIN USUARIO UC ON UC.ID = P.USUARIOCRIACAOID" +
                        " INNER JOIN PESSOA PC ON PC.ID = UC.PESSOAID" +
                        " LEFT JOIN USUARIO UL ON UL.ID = P.USUARIOLOCATARIOID" +
                        " LEFT JOIN PESSOA PL ON PL.ID = UL.PESSOAID" +
                        " WHERE UC.ID = @USUARIOCRIACAOID";

                    cmd.Parameters.AddWithValue("@USUARIOCRIACAOID", CreatorId);
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            Produtos = new List<Produto>();
                            while (reader.Read())
                            {
                                Produto Produto = new Produto
                                {
                                    Id = (int)reader["ID"],
                                    Nome = (string)reader["NOME"],
                                    Descricao = (string)reader["DESCRICAO"],
                                    Observacao = (string)reader["OBSERVACAO"],
                                    DataCadastro = (DateTime)reader["CADASTRO"],
                                    LimiteDiasEmprestimo = (int)reader["LIMITEDIAS"],
                                    Status = (int)reader["STATUS"],
                                    Situacao = (bool)reader["SITUACAO"],
                                    UsuarioCriacao = new Usuario
                                    {
                                        Id = (int)reader["USUARIOCRIACAO_ID"],
                                        Pessoa = new Pessoa
                                        {
                                            Nome = (string)reader["USUARIOCRIACAO_NOME"]
                                        }
                                    },
                                    UsuarioLocatario = new Usuario
                                    {
                                        Id = (int)reader["USUARIOLOCATARIO_ID"],
                                        Pessoa = new Pessoa
                                        {
                                            Nome = (string)reader["USUARIOLOCATARIO_NOME"]
                                        }
                                    }
                                };
                                Produtos.Add(Produto);
                            }
                        }
                    }
                }
                return Produtos;
            }
            catch (Exception ex)
            {
                throw new Exception("Usuario: " + ex.Message);
            }
        }
        #endregion

        #region CRUDASYNC

        public Task InsertAsync(Produto Model)
        {
            throw new NotImplementedException();
        }
        public Task<IList<Produto>> SelectAllAsync()
        {
            throw new NotImplementedException();
        }
        public Task<int> SelectIdentityAsync()
        {
            throw new NotImplementedException();
        }
        public Task<Produto> SelectOneLineAsync(int Id)
        {
            throw new NotImplementedException();
        }
        public Task UpdateAsync(Produto Model)
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}
