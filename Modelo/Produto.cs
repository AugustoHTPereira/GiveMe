﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Produto
    {
        public enum status
        {
            Indisponivel = 0,
            Disponivel = 1,
            Alugado = 2
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public DateTime DataCadastro { get; set; }
        public int LimiteDiasEmprestimo { get; set; }
        public Usuario UsuarioCriacao { get; set; }
        public Usuario UsuarioLocatario { get; set; }
        public status Status { get; set; }
        public bool Situacao { get; set; }
    }
}
