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
