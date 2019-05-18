using Modelo;
using Negocio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;

namespace GiveMe
{
    public partial class frmLogin : Form
    {
        const string _BaseUrl = "https://localhost:44384/api/";

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
            if (txtLogin.Text == string.Empty || txtSenha.Text == string.Empty)
            {
                lblErro.Text = "Preencha os campos de usuário e senha";
                return;
            }

            //string Token = string.Empty;
            if (GetToken(out string Token))
            {
                JsonWebToken TokenData = JsonConvert.DeserializeObject<JsonWebToken>(Token);

                frm_Master master = new frm_Master(_Usuario);
                master.Show();
                this.Hide();
            }
        }

        private void lkbRegistrar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrarUsuario form = new RegistrarUsuario();
            form.Show();
        }

        private bool GetToken(out string Token)
        {
            HttpClient Client = new HttpClient();
            // Endereço para requisição
            Client.BaseAddress = new Uri(_BaseUrl + "Token");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var Pairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>( "Login", txtLogin.Text),
                new KeyValuePair<string, string> ( "Senha", txtSenha.Text)
            };

            var Content = new FormUrlEncodedContent(Pairs);

            HttpResponseMessage ResponseMessage = Client.PostAsync(Client.BaseAddress, Content).Result;
            Token = string.Empty;

            if (!ResponseMessage.StatusCode.Equals(HttpStatusCode.OK))
            {
                MessageBox.Show("Verifique seus dados", "Acesso negado");
                return false;
            }

            Token = ResponseMessage.Content.ReadAsStringAsync().Result;
            return true;
        }
    }
}
