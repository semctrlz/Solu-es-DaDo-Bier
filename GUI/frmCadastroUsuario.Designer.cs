namespace GUI
{
    partial class frmCadastroUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbUnidade = new System.Windows.Forms.ComboBox();
            this.lbUnidade = new System.Windows.Forms.Label();
            this.txtIdUsuario = new System.Windows.Forms.TextBox();
            this.txtIniciais = new System.Windows.Forms.TextBox();
            this.lbIniciais = new System.Windows.Forms.Label();
            this.CbNivel = new System.Windows.Forms.ComboBox();
            this.lbNivel = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.lbLogin = new System.Windows.Forms.Label();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lbEmail = new System.Windows.Forms.Label();
            this.lbNome = new System.Windows.Forms.Label();
            this.pnDados.SuspendLayout();
            this.pnBotoes.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnDados
            // 
            this.pnDados.Controls.Add(this.groupBox1);
            this.pnDados.Size = new System.Drawing.Size(489, 123);
            // 
            // pnBotoes
            // 
            this.pnBotoes.Location = new System.Drawing.Point(9, 141);
            // 
            // btCancelar
            // 
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btSalvar
            // 
            this.btSalvar.Click += new System.EventHandler(this.btSalvar_Click);
            // 
            // btExcluir
            // 
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // btAlterar
            // 
            this.btAlterar.Click += new System.EventHandler(this.btAlterar_Click);
            // 
            // btLocalizar
            // 
            this.btLocalizar.Click += new System.EventHandler(this.btLocalizar_Click);
            // 
            // btInserir
            // 
            this.btInserir.Click += new System.EventHandler(this.btInserir_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbUnidade);
            this.groupBox1.Controls.Add(this.lbUnidade);
            this.groupBox1.Controls.Add(this.txtIdUsuario);
            this.groupBox1.Controls.Add(this.txtIniciais);
            this.groupBox1.Controls.Add(this.lbIniciais);
            this.groupBox1.Controls.Add(this.CbNivel);
            this.groupBox1.Controls.Add(this.lbNivel);
            this.groupBox1.Controls.Add(this.txtLogin);
            this.groupBox1.Controls.Add(this.lbLogin);
            this.groupBox1.Controls.Add(this.txtemail);
            this.groupBox1.Controls.Add(this.txtNome);
            this.groupBox1.Controls.Add(this.lbEmail);
            this.groupBox1.Controls.Add(this.lbNome);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(482, 110);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados do Usuário";
            // 
            // cbUnidade
            // 
            this.cbUnidade.FormattingEnabled = true;
            this.cbUnidade.Location = new System.Drawing.Point(336, 72);
            this.cbUnidade.Name = "cbUnidade";
            this.cbUnidade.Size = new System.Drawing.Size(55, 21);
            this.cbUnidade.TabIndex = 5;
            // 
            // lbUnidade
            // 
            this.lbUnidade.AutoSize = true;
            this.lbUnidade.Location = new System.Drawing.Point(283, 78);
            this.lbUnidade.Name = "lbUnidade";
            this.lbUnidade.Size = new System.Drawing.Size(47, 13);
            this.lbUnidade.TabIndex = 9;
            this.lbUnidade.Text = "Unidade";
            // 
            // txtIdUsuario
            // 
            this.txtIdUsuario.Location = new System.Drawing.Point(409, 19);
            this.txtIdUsuario.Name = "txtIdUsuario";
            this.txtIdUsuario.Size = new System.Drawing.Size(67, 20);
            this.txtIdUsuario.TabIndex = 8;
            this.txtIdUsuario.Visible = false;
            // 
            // txtIniciais
            // 
            this.txtIniciais.Location = new System.Drawing.Point(218, 72);
            this.txtIniciais.Name = "txtIniciais";
            this.txtIniciais.Size = new System.Drawing.Size(58, 20);
            this.txtIniciais.TabIndex = 4;
            // 
            // lbIniciais
            // 
            this.lbIniciais.AutoSize = true;
            this.lbIniciais.Location = new System.Drawing.Point(173, 78);
            this.lbIniciais.Name = "lbIniciais";
            this.lbIniciais.Size = new System.Drawing.Size(39, 13);
            this.lbIniciais.TabIndex = 6;
            this.lbIniciais.Text = "Iniciais";
            // 
            // CbNivel
            // 
            this.CbNivel.FormattingEnabled = true;
            this.CbNivel.Location = new System.Drawing.Point(98, 72);
            this.CbNivel.Name = "CbNivel";
            this.CbNivel.Size = new System.Drawing.Size(67, 21);
            this.CbNivel.TabIndex = 3;
            // 
            // lbNivel
            // 
            this.lbNivel.AutoSize = true;
            this.lbNivel.Location = new System.Drawing.Point(7, 75);
            this.lbNivel.Name = "lbNivel";
            this.lbNivel.Size = new System.Drawing.Size(85, 13);
            this.lbNivel.TabIndex = 4;
            this.lbNivel.Text = "Nível de acesso";
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(300, 20);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(100, 20);
            this.txtLogin.TabIndex = 1;
            // 
            // lbLogin
            // 
            this.lbLogin.AutoSize = true;
            this.lbLogin.Location = new System.Drawing.Point(261, 27);
            this.lbLogin.Name = "lbLogin";
            this.lbLogin.Size = new System.Drawing.Size(33, 13);
            this.lbLogin.TabIndex = 2;
            this.lbLogin.Text = "Login";
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(49, 46);
            this.txtemail.MaxLength = 60;
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(206, 20);
            this.txtemail.TabIndex = 2;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(49, 20);
            this.txtNome.MaxLength = 50;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(206, 20);
            this.txtNome.TabIndex = 0;
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Location = new System.Drawing.Point(7, 46);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(32, 13);
            this.lbEmail.TabIndex = 0;
            this.lbEmail.Text = "Email";
            // 
            // lbNome
            // 
            this.lbNome.AutoSize = true;
            this.lbNome.Location = new System.Drawing.Point(7, 20);
            this.lbNome.Name = "lbNome";
            this.lbNome.Size = new System.Drawing.Size(35, 13);
            this.lbNome.TabIndex = 0;
            this.lbNome.Text = "Nome";
            // 
            // frmCadastroUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(506, 227);
            this.Name = "frmCadastroUsuario";
            this.Text = "Cadastro de usuário";
            this.Load += new System.EventHandler(this.frmCadastroUsuario_Load);
            this.pnDados.ResumeLayout(false);
            this.pnBotoes.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbIniciais;
        private System.Windows.Forms.ComboBox CbNivel;
        private System.Windows.Forms.Label lbNivel;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label lbLogin;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lbNome;
        private System.Windows.Forms.TextBox txtIniciais;
        private System.Windows.Forms.TextBox txtIdUsuario;
        private System.Windows.Forms.ComboBox cbUnidade;
        private System.Windows.Forms.Label lbUnidade;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.Label lbEmail;
    }
}
