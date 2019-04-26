﻿using Dados;
using Dados.Conexao;
using Dados.Conexao.Interface;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class N_Usuario
    {
        /// <summary>
        ///     Verifica se o usuário existe na base de dados. Se não existir insere a pessoa e depois o usuário
        /// </summary>
        /// <param name="Model"></param>
        /// <returns name="Warning">Retorna vazio caso haja tudo bem, senão preenchida.</returns>
        public static string Insert(Usuario Model)
        {
            try
            {
                string Warning = string.Empty;
                using (IConexao conexao = new ConexaoSqlServer())
                {
                    D_Usuario usuario = new D_Usuario(conexao);
                    if (usuario.HasUser(Model.Login, Model.Senha))
                    {
                        Warning = "Já existe um usuário com essas credenciais cadastrado no sistema.";
                    }
                    else
                    {
                        using (D_Pessoa Pessoa = new D_Pessoa(conexao))
                        {
                            Pessoa.Insert(Model.Pessoa);
                            Model.PessoaId = Pessoa.SelectIdentity();
                        }

                        usuario.Insert(Model);
                        usuario.Dispose();
                        Warning = string.Empty;
                    }
                }
                return Warning;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Usuario Logar(string Usuario, string Senha)
        {
            try
            {
                Usuario usuario = null;
                using (IConexao conexao = new ConexaoSqlServer())
                {
                    using(D_Usuario d_Usuario = new D_Usuario(conexao))
                    {
                        usuario = d_Usuario.Login(Usuario, Senha);
                    }
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
