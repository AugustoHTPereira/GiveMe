namespace GiveMe
{
    partial class frm_Master
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlEsquerda = new System.Windows.Forms.Panel();
            this.lblVersao = new System.Windows.Forms.Label();
            this.btnMeusProdutos = new System.Windows.Forms.Button();
            this.btnMyAccount = new System.Windows.Forms.Button();
            this.pnlTopo = new System.Windows.Forms.Panel();
            this.btnResizeMenu = new System.Windows.Forms.PictureBox();
            this.btnMinimize = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.pnlConteudo = new System.Windows.Forms.Panel();
            this.pnlEsquerda.SuspendLayout();
            this.pnlTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnResizeMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlEsquerda
            // 
            this.pnlEsquerda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(52)))), ((int)(((byte)(77)))));
            this.pnlEsquerda.Controls.Add(this.lblVersao);
            this.pnlEsquerda.Controls.Add(this.btnMeusProdutos);
            this.pnlEsquerda.Controls.Add(this.btnMyAccount);
            this.pnlEsquerda.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlEsquerda.Location = new System.Drawing.Point(0, 0);
            this.pnlEsquerda.Name = "pnlEsquerda";
            this.pnlEsquerda.Size = new System.Drawing.Size(300, 673);
            this.pnlEsquerda.TabIndex = 0;
            // 
            // lblVersao
            // 
            this.lblVersao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVersao.AutoSize = true;
            this.lblVersao.ForeColor = System.Drawing.SystemColors.Control;
            this.lblVersao.Location = new System.Drawing.Point(12, 647);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(53, 17);
            this.lblVersao.TabIndex = 2;
            this.lblVersao.Text = "Versão";
            // 
            // btnMeusProdutos
            // 
            this.btnMeusProdutos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMeusProdutos.FlatAppearance.BorderSize = 0;
            this.btnMeusProdutos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMeusProdutos.Font = new System.Drawing.Font("Malgun Gothic Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMeusProdutos.ForeColor = System.Drawing.Color.White;
            this.btnMeusProdutos.Image = global::GiveMe.Properties.Resources.icons8_box_50;
            this.btnMeusProdutos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMeusProdutos.Location = new System.Drawing.Point(3, 229);
            this.btnMeusProdutos.Margin = new System.Windows.Forms.Padding(0);
            this.btnMeusProdutos.Name = "btnMeusProdutos";
            this.btnMeusProdutos.Size = new System.Drawing.Size(300, 87);
            this.btnMeusProdutos.TabIndex = 1;
            this.btnMeusProdutos.Text = "   MEUS PRODUTOS";
            this.btnMeusProdutos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMeusProdutos.UseVisualStyleBackColor = true;
            this.btnMeusProdutos.Click += new System.EventHandler(this.btnMeusProdutos_Click);
            // 
            // btnMyAccount
            // 
            this.btnMyAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMyAccount.FlatAppearance.BorderSize = 0;
            this.btnMyAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyAccount.Font = new System.Drawing.Font("Malgun Gothic Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMyAccount.ForeColor = System.Drawing.Color.White;
            this.btnMyAccount.Image = global::GiveMe.Properties.Resources.icons8_user_50;
            this.btnMyAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMyAccount.Location = new System.Drawing.Point(3, 123);
            this.btnMyAccount.Margin = new System.Windows.Forms.Padding(0);
            this.btnMyAccount.Name = "btnMyAccount";
            this.btnMyAccount.Size = new System.Drawing.Size(300, 87);
            this.btnMyAccount.TabIndex = 0;
            this.btnMyAccount.Text = "   MINHA CONTA";
            this.btnMyAccount.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMyAccount.UseVisualStyleBackColor = true;
            // 
            // pnlTopo
            // 
            this.pnlTopo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(64)))), ((int)(((byte)(164)))));
            this.pnlTopo.Controls.Add(this.btnResizeMenu);
            this.pnlTopo.Controls.Add(this.btnMinimize);
            this.pnlTopo.Controls.Add(this.btnExit);
            this.pnlTopo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopo.Location = new System.Drawing.Point(300, 0);
            this.pnlTopo.Name = "pnlTopo";
            this.pnlTopo.Size = new System.Drawing.Size(1032, 50);
            this.pnlTopo.TabIndex = 0;
            // 
            // btnResizeMenu
            // 
            this.btnResizeMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResizeMenu.Image = global::GiveMe.Properties.Resources.icons8_menu_vertical_50__1_;
            this.btnResizeMenu.Location = new System.Drawing.Point(6, 9);
            this.btnResizeMenu.Name = "btnResizeMenu";
            this.btnResizeMenu.Size = new System.Drawing.Size(30, 30);
            this.btnResizeMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnResizeMenu.TabIndex = 2;
            this.btnResizeMenu.TabStop = false;
            this.btnResizeMenu.Click += new System.EventHandler(this.btnResizeMenu_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.Image = global::GiveMe.Properties.Resources.icons8_minus_50;
            this.btnMinimize.Location = new System.Drawing.Point(954, 9);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(30, 30);
            this.btnMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimize.TabIndex = 1;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Image = global::GiveMe.Properties.Resources.icons8_multiply_filled_50;
            this.btnExit.Location = new System.Drawing.Point(990, 9);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(30, 30);
            this.btnExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnExit.TabIndex = 0;
            this.btnExit.TabStop = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pnlConteudo
            // 
            this.pnlConteudo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConteudo.Location = new System.Drawing.Point(300, 50);
            this.pnlConteudo.Name = "pnlConteudo";
            this.pnlConteudo.Size = new System.Drawing.Size(1032, 623);
            this.pnlConteudo.TabIndex = 1;
            // 
            // frm_Master
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1332, 673);
            this.Controls.Add(this.pnlConteudo);
            this.Controls.Add(this.pnlTopo);
            this.Controls.Add(this.pnlEsquerda);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Master";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.pnlEsquerda.ResumeLayout(false);
            this.pnlEsquerda.PerformLayout();
            this.pnlTopo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnResizeMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlTopo;
        private System.Windows.Forms.PictureBox btnExit;
        private System.Windows.Forms.Panel pnlConteudo;
        private System.Windows.Forms.Panel pnlEsquerda;
        private System.Windows.Forms.PictureBox btnResizeMenu;
        private System.Windows.Forms.Button btnMyAccount;
        private System.Windows.Forms.Label lblVersao;
        private System.Windows.Forms.Button btnMeusProdutos;
        private System.Windows.Forms.PictureBox btnMinimize;
    }
}

