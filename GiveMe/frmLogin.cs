using Modelo;
using Negocio;
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
        Usuario _Usuario;
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

            try
            {
                _Usuario = N_Usuario.Logar(txtLogin.Text, txtSenha.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ops !");
                return;
            }
            // VALIDA O LOGIN DO USUÁRIO
            if(_Usuario == null)
            {
                MessageBox.Show("Não encontramos nenhum usuário com essas credenciais. Verifique seus dados ou se não for registrado ainda, registre-se!", "Ops !");
                return;
            }
            if (_Usuario.ConfirmacaoEmail.Equals(false))
            {
                MessageBox.Show("Você ainda não confirmou seu e-mail. Confirme-o antes de realizar o login.", "Ops !");
                return;
            }
            if (_Usuario.Situacao.Equals(false))
            {
                MessageBox.Show("Seu usuário foi desativado. Contate o suporte técnico.", "Ops !");
                return;
            }
            // FIM VALIDA O LOGIN DO USUÁRIO
            frm_Master master = new frm_Master(_Usuario);
            master.Show();
            this.Hide();
        }

        private void lkbRegistrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrarUsuario form = new RegistrarUsuario();
            form.Show();
        }
    }
}
