using Modelo;
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
    public partial class frm_Master : Form
    {
        public frm_Master()
        {
            InitializeComponent();
            lblVersao.Text = "V 1.00.0.0";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnResizeMenu_Click(object sender, EventArgs e)
        {
            if (pnlEsquerda.Width == 225)
                pnlEsquerda.Width = 64;
            else
                pnlEsquerda.Width = 225;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ShowInMaster(Form From, Panel To)
        {
            //EXIBE NO PANEL DE DESTINO O FORMULÁRIO DESEJADO
            if (To.Controls.Count > 0)
                To.Controls.RemoveAt(0);
            From.TopLevel = false;
            From.Dock = DockStyle.Fill;
            To.Controls.Add(From);
            To.Tag = From;
            From.Show();
        }

        private void btnMeusProdutos_Click(object sender, EventArgs e)
        {
            frmProdutos produtos = new frmProdutos();
            produtos.SetName("MEUS PRODUTOS");
            ShowInMaster(produtos, pnlConteudo);
        }
    }
}
