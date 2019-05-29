using Modelo;
using Negocio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace GiveMe
{
    public partial class frmProdutos : Form
    {
        const string _BaseURL = "https://localhost:44384/api/";

        Usuario _Usuario;
        IList<Produto> _Produtos;
        public frmProdutos(Usuario Usuario)
        {
            InitializeComponent();
            _Usuario = Usuario;
            CarregaProdutos();
            btnPegar.Visible = false;
        }

        void CarregaProdutos()
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(_BaseURL + "Produto/?usuarioid=" + _Usuario.Id);
                request.Method = "Get";
                request.Headers["Authorization"] = _Usuario.Token;
                request.ContentType = "application/json";
                var response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                        string result = reader.ReadToEnd();

                        _Produtos = JsonConvert.DeserializeObject<List<Produto>>(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Token request: " + ex.Message, "Ops !");
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
            // le a linha que foi clicada
            var row = this.gvProdutos.Rows[gvProdutos.SelectedCells[0].RowIndex];

            //passa os valores para os respectivos textboxs
            txtId.Text = row.Cells[0].Value.ToString();
            txtNome.Text = row.Cells[1].Value.ToString();
            txtDescricao.Text = row.Cells[2].Value.ToString();
            txtObs.Text = row.Cells[3].Value.ToString();
            txtDataCadastro.Text = row.Cells[4].Value.ToString();
            txtStatus.Text = row.Cells[5].Value.ToString();
            txtValor.Text = row.Cells[7].Value.ToString();
            txtLimiteEmprestimo.Text = row.Cells[8].Value.ToString();
            txtUsuarioCriacao.Text = row.Cells[9].Value.ToString();
            txtUsuarioLocador.Text = row.Cells[10].Value.ToString();

            //desabilita o formulario
            txtNome.ReadOnly = true;
            txtDescricao.ReadOnly = true;
            txtObs.ReadOnly = true;
            txtDataCadastro.ReadOnly = true;
            txtStatus.ReadOnly = true;
            txtValor.ReadOnly = true;
            txtLimiteEmprestimo.ReadOnly = true;
            txtUsuarioCriacao.ReadOnly = true;
            txtUsuarioLocador.ReadOnly = true;

            //troca a tab
            tabPage2.Text = "Datalhes " + txtNome.Text;
            tabProdutos.SelectedTab = tabPage2;

            //se o usuario logado for diferente do dono do produto
            if (txtUsuarioCriacao.Text != _Usuario.Pessoa.Nome)
            {
                btnPegar.Visible = true;
            }
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
            txtDataCadastro.Text = string.Empty;
            txtStatus.Text = string.Empty;
            txtValor.Text = string.Empty;
            txtLimiteEmprestimo.Text = string.Empty;
            txtUsuarioCriacao.Text = string.Empty;
            txtUsuarioLocador.Text = string.Empty;
        }

        private void BtnPegar_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto
            {
                Id = int.Parse(txtId.Text),
                UsuarioLocatario = new Usuario
                {
                    Id = _Usuario.Id
                }
            };
            N_Produto.Give(produto, new Historico { RegistroId = produto.Id, Tabela = "Produto", TipoId = 2, UsuarioId = _Usuario.Id });
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            ClimbForm();
            txtNome.ReadOnly = false;
            txtDescricao.ReadOnly = false;
            txtObs.ReadOnly = false;
            txtDataCadastro.ReadOnly = false;
            txtStatus.ReadOnly = false;
            txtValor.ReadOnly = false;
            txtLimiteEmprestimo.ReadOnly = false;
            txtUsuarioCriacao.ReadOnly = false;
            txtUsuarioLocador.ReadOnly = false;
        }
    }
}
