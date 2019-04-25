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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            lblErro.Text = string.Empty;
            txtSenha.PasswordChar = '-';
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if(txtLogin.Text == string.Empty || txtSenha.Text == string.Empty)
            {
                lblErro.Text = "Preencha os campos de usuário e senha";
                return;
            }

            if(txtLogin.Text == txtSenha.Text)
            {
                frm_Master master = new frm_Master();
                master.Show();
                this.Hide();
            }
            else
            {
                lblErro.Text = "Os dados não condizem";
                return;
            }
        }
    }
}
