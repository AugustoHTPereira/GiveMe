using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiveMe
{
    public partial class frmProdutos : Form
    {
        public frmProdutos()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnPedirEmprestado_Click(object sender, EventArgs e)
        {

        }
        public void SetName(string Nome = null)
        {
            if (Nome != null)
                lblTitulo.Text = Nome;
        }
    }
}
