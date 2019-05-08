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
    public static class N_Produto
    {
        public static void Insert(Produto Model)
        {
            try
            {
                using(IConexao conexao = new ConexaoSqlServer())
                {
                    using(D_Produto Produto = new D_Produto(conexao))
                    {
                        Produto.Insert(Model);
                        Model.Id = Produto.SelectIdentity();
                    }
                    using(D_Historico D_Historico = new D_Historico(conexao))
                    {
                        Historico historico = new Historico
                        {
                            Tabela = "PRODUTO",
                            RegistroId = Model.Id,
                            TipoId = 1,
                            UsuarioId = Model.UsuarioCriacaoId
                        };
                        D_Historico.Insert(historico);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static IList<Produto> SelectAllByCriator(int CreatorId)
        {
            try
            {
                IList<Produto> Produtos;
                using (IConexao conexao = new ConexaoSqlServer())
                {
                    using (D_Produto Produto = new D_Produto(conexao))
                    {
                        Produtos = Produto.SelectAllByCriator(CreatorId);
                    }
                }
                return Produtos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
