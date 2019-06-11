using GiveMe.Utils;
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
    public partial class RegistrarUsuario : Form
    {
        public RegistrarUsuario()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (
                string.IsNullOrEmpty(txtUsuario.Text)   ||
                string.IsNullOrEmpty(txtSenha.Text)     ||
                string.IsNullOrEmpty(txtEmail.Text)     ||
                string.IsNullOrEmpty(txtNome.Text)      ||
                string.IsNullOrEmpty(txtSobrenome.Text) ||
                string.IsNullOrEmpty(txtInscricao.Text) ||
                string.IsNullOrEmpty(txtNascimento.Text)
                )
            {
                MessageBox.Show("Preencha todos os campos.", "Atenção!");
                return;
            }

            try
            {
                Usuario usuario = new Usuario
                {
                    Login = txtUsuario.Text,
                    Senha = txtSenha.Text,
                    Email = txtEmail.Text,
                    Situacao = true,
                    Pessoa = new Pessoa
                    {
                        Nome = txtNome.Text,
                        Sobrenome = txtSobrenome.Text,
                        Inscricao = txtInscricao.Text,
                        Nascimento = DateTime.Parse(txtNascimento.Text),
                        Foto = null,
                        Situacao = true
                    }
                };
                //INSERE USUARIO E PESSOA NO BANCO DE DADOS
                string str_RetornoCadastro = N_Usuario.Insert(usuario);
                if(str_RetornoCadastro != string.Empty)
                {
                    MessageBox.Show(str_RetornoCadastro, "Ops !");
                    return;
                }
                // ENVIA EMAIL DE CONFIRMACAO
                Email.Send(usuario.Email, "Olá, acabamos de verificar que você cadastrou esse e-mail em nossa rede GIVE-ME, para acessar a rede você precisa confirmar seu cadastro, para isso basta clicar <a href='#'>aqui</a>", "Confirmação de cadastro");
                // FIM ENVIA EMAIL DE CONFIRMACAO
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ops !");
                return;
            }

            MessageBox.Show("Seu cadastro foi realizado com sucesso. Verifique sua caixa de entrada de e-mail para confirmar seu registro.", "Sucesso!");
            this.Hide();
        }

        private void RegistrarUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}
