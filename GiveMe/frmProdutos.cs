using Modelo;
using Negocio;
using System;
using System.Collections.Generic;
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
            _Produtos = N_Produto.SelectAllByCriator(_Usuario.Id);
            gvProdutos.DataSource = _Produtos;
        }
        public frmProdutos()
        {
            InitializeComponent();
            tabPage2.Focus();
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

    }
}
