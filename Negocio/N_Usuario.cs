using Dados;
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
        /// <returns></returns>
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
    }
}
