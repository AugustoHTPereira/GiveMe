using Modelo;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GiveMe
{
    public partial class frmProdutos : Form
    {
        Usuario _Usuario;
        IList<Produto> _Produtos;
        public frmProdutos(Usuario Usuario)
        {
            InitializeComponent();
            _Usuario = Usuario;
            CarregaProdutos();
        }

        void CarregaProdutos()
        {
            try
            {
                _Produtos = N_Produto.SelectAllByCriator(_Usuario.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ops !");
                return;
            }

            if (_Produtos != null)
            {
                var colection = from i in _Produtos
                                select new
                                {
                                    Id = i.Id,
                                    Produto = i.Nome,
                                    Descricao = i.Descricao,
                                    Observacao = i.Observacao == string.Empty ? "N/A" : i.Observacao,
                                    Cadastro = i.DataCadastro,
                                    Status = i.Status == 0 ? "Indisponível" : i.Status == 1 ? "Disponível" : i.Status == 2 ? "Alugado" : "NULL",
                                    Situacao = i.Situacao == true ? "Ativo" : "Inativo",
                                    ValorEstimado = i.Valor,
                                    LimiteDias = i.LimiteDiasEmprestimo,
                                    Dono = i.UsuarioCriacao.Pessoa.Nome,
                                    Locatario = i.UsuarioLocatario != null ? (i.UsuarioLocatario.Pessoa.Nome == null || i.UsuarioLocatario.Pessoa.Nome == string.Empty ? "N/A" : i.UsuarioLocatario.Pessoa.Nome) : "N/A"
                                };
                gvProdutos.DataSource = colection.ToList();
            }
        }
        private void GvProdutos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var row = this.gvProdutos.Rows[gvProdutos.SelectedCells[0].RowIndex];
            txtNome.Text = row.Cells[1].Value.ToString();
            txtDescricao.Text = row.Cells[2].Value.ToString();
            txtObs.Text = row.Cells[3].Value.ToString();
            txtDataCadastro.Text = row.Cells[4].Value.ToString();
            txtStatus.Text = row.Cells[5].Value.ToString();
            txtValor.Text = row.Cells[6].Value.ToString();
            txtLimiteEmprestimo.Text = row.Cells[7].Value.ToString();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void SetName(string Nome = null)
        {
            if (Nome != null)
                lblTitulo.Text = Nome;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Produto produto = new Produto
                {
                    Nome = txtNome.Text,
                    Descricao = txtDescricao.Text,
                    Observacao = txtObs.Text,
                    LimiteDiasEmprestimo = int.Parse(txtLimiteEmprestimo.Text),
                    UsuarioCriacaoId = _Usuario.Id,
                    Valor = decimal.Parse(txtValor.Text)
                };
                N_Produto.Insert(produto);
                CarregaProdutos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ops !");
                return;
            }
            if (MessageBox.Show("Seu produto foi criado, deseja criar um novo?", "Sucesso", MessageBoxButtons.YesNo) == DialogResult.No)
                tabPage1.Focus();
            ClimbForm();
        }
        void ClimbForm()
        {
            txtNome.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            txtObs.Text = string.Empty;
            txtLimiteEmprestimo.Text = string.Empty;
            txtValor.Text = string.Empty;
        }

        
    }
}
