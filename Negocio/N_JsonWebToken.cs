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
    public static class N_JsonWebToken
    {
        public static async Task Insert(JsonWebToken Modelo)
        {
            using(ConexaoSqlServer conexao = new ConexaoSqlServer())
            {
                using(D_JsonWebToken dal = new D_JsonWebToken(conexao))
                {
                    await dal.InsertAsync(Modelo);
                }
            }
        }
    }
}
