﻿using Dados.Conexao.Interface;
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

        #region CRUD
        public void Insert(Usuario Model)
        {
            try
            {
                using (SqlCommand cmd = _conexao.Open().CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO USUARIO (LOGIN, SENHA, EMAIL, PESSOAID, CONFIRMACAOEMAIL) VALUES (@LOGIN, @SENHA, @EMAIL, @PESSOAID, 1);"; // A FACILITAR, CONFIRMACAO DE EMAIL INSERIDA COMO VERDADEIRO
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
        public IList<Usuario> SelectAll()
        {
            try
            {
                IList<Usuario> Usuarios = null;
                using (SqlCommand cmd = _conexao.Open().CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "SELECT U.ID, U.EMAIL, U.[LOGIN], U.SITUACAO, U.CONFIRMACAOEMAIL, P.ID AS 'PESSOAID', P.NOME, P.SOBRENOME, P.NASCIMENTO, P.INSCRICAO, P.SITUACAO AS 'PESSOASITUACAO' FROM USUARIO U INNER JOIN PESSOA P ON P.ID = U.PESSOAID";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Usuarios = new List<Usuario>();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Usuario Usuario = new Usuario
                                {
                                    Id = (int)reader["ID"],
                                    Email = (string)reader["EMAIL"],
                                    Login = (string)reader["LOGIN"],
                                    Situacao = (bool)reader["SITUACAO"],
                                    ConfirmacaoEmail = (bool)reader["CONFIRMACAOEMAIL"],
                                    PessoaId = (int)reader["PESSOAID"],
                                    //Senha = "",
                                    Pessoa = new Pessoa
                                    {
                                        Id = (int)reader["PESSOAID"],
                                        Nome = (string)reader["NOME"],
                                        Sobrenome = (string)reader["SOBRENOME"],
                                        Nascimento = (DateTime)reader["NASCIMENTO"],
                                        Inscricao = (string)reader["INSCRICAO"],
                                        Situacao = (bool)reader["PESSOASITUACAO"]
                                    }
                                };
                                Usuarios.Add(Usuario);
                            }
                        }
                    }
                }
                return Usuarios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
        public Usuario SelectOneLine(int Id)
        {
            throw new NotImplementedException();
        }
        public void Update(Usuario Model)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region CRUD_ASYNC
        public Task InsertAsync(Usuario Model)
        {
            throw new NotImplementedException();
        }
        public async Task<IList<Usuario>> SelectAllAsync()
        {
            try
            {
                IList<Usuario> Usuarios = null;
                using (SqlCommand cmd = _conexao.Open().CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "SELECT U.ID FROM USUARIO";
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        Usuarios = new List<Usuario>();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Usuario Usuario = new Usuario
                                {
                                    Id = (int)reader["ID"]
                                };
                                Usuarios.Add(Usuario);
                            }
                        }
                    }
                }
                return Usuarios;
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
        public Task<Usuario> SelectOneLineAsync(int Id)
        {
            throw new NotImplementedException();
        }
        public Task UpdateAsync(Usuario Model)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region OTHERS
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
        public Usuario Login(string Usuario, string Senha)
        {
            try
            {
                Usuario usuario = null;
                using (SqlCommand cmd = _conexao.Open().CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText =
                        "SELECT " +
                        " P.ID AS 'PESSOAID'," +
                        " P.NOME," +
                        " P.SOBRENOME," +
                        " P.INSCRICAO," +
                        " P.NASCIMENTO," +
                        " U.ID AS 'USUARIOID', " +
                        " U.EMAIL, " +
                        " U.CONFIRMACAOEMAIL," +
                        " U.SITUACAO" +
                        " FROM USUARIO U" +
                        " INNER JOIN PESSOA P ON P.ID = U.PESSOAID" +
                        " WHERE (U.[LOGIN] = @LOGIN OR U.EMAIL = @LOGIN) AND U.SENHA = @SENHA AND U.SITUACAO = 1";
                    cmd.Parameters.AddWithValue("@LOGIN", Usuario);
                    cmd.Parameters.AddWithValue("@SENHA", Senha);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            usuario = new Usuario();
                            while (reader.Read())
                            {
                                usuario.Pessoa = new Pessoa
                                {
                                    Id = (int)reader["PESSOAID"],
                                    Nome = (string)reader["NOME"],
                                    Sobrenome = (string)reader["SOBRENOME"],
                                    Inscricao = (string)reader["INSCRICAO"],
                                    Nascimento = (DateTime)reader["NASCIMENTO"],
                                };
                                usuario.Id = (int)reader["USUARIOID"];
                                usuario.Email = (string)reader["EMAIL"];
                                usuario.ConfirmacaoEmail = (bool)reader["CONFIRMACAOEMAIL"];
                                usuario.Situacao = (bool)reader["SITUACAO"];
                                usuario.PessoaId = (int)reader["PESSOAID"];
                            }
                        }
                    }
                }
                return usuario;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
