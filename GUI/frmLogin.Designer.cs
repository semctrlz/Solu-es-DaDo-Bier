namespace GUI
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.lbUsuario = new System.Windows.Forms.Label();
            this.lbSenha = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.lbCaps = new System.Windows.Forms.Label();
            this.pbCadeado = new System.Windows.Forms.PictureBox();
            this.btSair = new System.Windows.Forms.Button();
            this.btLogin = new System.Windows.Forms.Button();
            this.cbPermanecerLogado = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCadeado)).BeginInit();
            this.SuspendLayout();
            // 
            // lbUsuario
            // 
            this.lbUsuario.AutoSize = true;
            this.lbUsuario.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsuario.Location = new System.Drawing.Point(87, 11);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(65, 21);
            this.lbUsuario.TabIndex = 0;
            this.lbUsuario.Text = "Usuário";
            // 
            // lbSenha
            // 
            this.lbSenha.AutoSize = true;
            this.lbSenha.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSenha.Location = new System.Drawing.Point(98, 43);
            this.lbSenha.Name = "lbSenha";
            this.lbSenha.Size = new System.Drawing.Size(54, 21);
            this.lbSenha.TabIndex = 1;
            this.lbSenha.Text = "Senha";
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.SystemColors.Window;
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(158, 12);
            this.txtUsuario.MaxLength = 15;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(129, 22);
            this.txtUsuario.TabIndex = 1;
            // 
            // txtSenha
            // 
            this.txtSenha.BackColor = System.Drawing.SystemColors.Window;
            this.txtSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.Location = new System.Drawing.Point(158, 44);
            this.txtSenha.MaxLength = 14;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '●';
            this.txtSenha.Size = new System.Drawing.Size(129, 22);
            this.txtSenha.TabIndex = 2;
            this.txtSenha.Leave += new System.EventHandler(this.txtSenha_Leave);
            // 
            // lbCaps
            // 
            this.lbCaps.AutoSize = true;
            this.lbCaps.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCaps.ForeColor = System.Drawing.Color.Red;
            this.lbCaps.Location = new System.Drawing.Point(12, 136);
            this.lbCaps.Name = "lbCaps";
            this.lbCaps.Size = new System.Drawing.Size(0, 15);
            this.lbCaps.TabIndex = 5;
            // 
            // pbCadeado
            // 
            this.pbCadeado.Image = global::GUI.Properties.Resources.lock_unlocked_8x;
            this.pbCadeado.Location = new System.Drawing.Point(15, 12);
            this.pbCadeado.Name = "pbCadeado";
            this.pbCadeado.Size = new System.Drawing.Size(64, 64);
            this.pbCadeado.TabIndex = 6;
            this.pbCadeado.TabStop = false;
            // 
            // btSair
            // 
            this.btSair.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSair.Image = global::GUI.Properties.Resources.x_3x;
            this.btSair.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btSair.Location = new System.Drawing.Point(228, 97);
            this.btSair.Name = "btSair";
            this.btSair.Size = new System.Drawing.Size(59, 49);
            this.btSair.TabIndex = 5;
            this.btSair.Text = "Sair";
            this.btSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btSair.UseVisualStyleBackColor = true;
            this.btSair.Click += new System.EventHandler(this.btSair_Click);
            // 
            // btLogin
            // 
            this.btLogin.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLogin.Image = global::GUI.Properties.Resources.account_login_3x;
            this.btLogin.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btLogin.Location = new System.Drawing.Point(158, 97);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(59, 49);
            this.btLogin.TabIndex = 4;
            this.btLogin.Text = "Login";
            this.btLogin.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btLogin.UseVisualStyleBackColor = true;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // cbPermanecerLogado
            // 
            this.cbPermanecerLogado.AutoSize = true;
            this.cbPermanecerLogado.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPermanecerLogado.Location = new System.Drawing.Point(158, 73);
            this.cbPermanecerLogado.Name = "cbPermanecerLogado";
            this.cbPermanecerLogado.Size = new System.Drawing.Size(125, 17);
            this.cbPermanecerLogado.TabIndex = 3;
            this.cbPermanecerLogado.Text = "Permanecer logado";
            this.cbPermanecerLogado.UseVisualStyleBackColor = true;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 158);
            this.Controls.Add(this.cbPermanecerLogado);
            this.Controls.Add(this.pbCadeado);
            this.Controls.Add(this.lbCaps);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.btSair);
            this.Controls.Add(this.btLogin);
            this.Controls.Add(this.lbSenha);
            this.Controls.Add(this.lbUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLogin_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbCadeado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbUsuario;
        private System.Windows.Forms.Label lbSenha;
        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.Button btSair;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lbCaps;
        private System.Windows.Forms.PictureBox pbCadeado;
        private System.Windows.Forms.CheckBox cbPermanecerLogado;
    }
}