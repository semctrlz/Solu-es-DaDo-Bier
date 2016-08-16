namespace GUI
{
    partial class frmAlteraSenha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAlteraSenha));
            this.lbUsuario = new System.Windows.Forms.Label();
            this.lbSenhaAtual = new System.Windows.Forms.Label();
            this.txtSenhaAtual = new System.Windows.Forms.TextBox();
            this.lbNovaSenha1 = new System.Windows.Forms.Label();
            this.txtNovaSenha1 = new System.Windows.Forms.TextBox();
            this.lbNovaSenha2 = new System.Windows.Forms.Label();
            this.txtNovaSenha2 = new System.Windows.Forms.TextBox();
            this.btAltera = new System.Windows.Forms.Button();
            this.btCancela = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbUsuario
            // 
            this.lbUsuario.AutoSize = true;
            this.lbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsuario.Location = new System.Drawing.Point(13, 13);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(75, 16);
            this.lbUsuario.TabIndex = 0;
            this.lbUsuario.Text = "lbUsuario";
            // 
            // lbSenhaAtual
            // 
            this.lbSenhaAtual.AutoSize = true;
            this.lbSenhaAtual.Location = new System.Drawing.Point(13, 53);
            this.lbSenhaAtual.Name = "lbSenhaAtual";
            this.lbSenhaAtual.Size = new System.Drawing.Size(64, 13);
            this.lbSenhaAtual.TabIndex = 1;
            this.lbSenhaAtual.Text = "Senha atual";
            // 
            // txtSenhaAtual
            // 
            this.txtSenhaAtual.Location = new System.Drawing.Point(16, 69);
            this.txtSenhaAtual.Name = "txtSenhaAtual";
            this.txtSenhaAtual.PasswordChar = '●';
            this.txtSenhaAtual.Size = new System.Drawing.Size(100, 20);
            this.txtSenhaAtual.TabIndex = 2;
            this.txtSenhaAtual.TextChanged += new System.EventHandler(this.txtSenhaAtual_TextChanged);
            this.txtSenhaAtual.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSenhaAtual_KeyDown);
            // 
            // lbNovaSenha1
            // 
            this.lbNovaSenha1.AutoSize = true;
            this.lbNovaSenha1.Location = new System.Drawing.Point(16, 121);
            this.lbNovaSenha1.Name = "lbNovaSenha1";
            this.lbNovaSenha1.Size = new System.Drawing.Size(65, 13);
            this.lbNovaSenha1.TabIndex = 3;
            this.lbNovaSenha1.Text = "Nova senha";
            // 
            // txtNovaSenha1
            // 
            this.txtNovaSenha1.Location = new System.Drawing.Point(16, 138);
            this.txtNovaSenha1.Name = "txtNovaSenha1";
            this.txtNovaSenha1.PasswordChar = '●';
            this.txtNovaSenha1.Size = new System.Drawing.Size(100, 20);
            this.txtNovaSenha1.TabIndex = 4;
            this.txtNovaSenha1.TextChanged += new System.EventHandler(this.txtNovaSenha1_TextChanged);
            this.txtNovaSenha1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNovaSenha1_KeyDown);
            // 
            // lbNovaSenha2
            // 
            this.lbNovaSenha2.AutoSize = true;
            this.lbNovaSenha2.Location = new System.Drawing.Point(16, 165);
            this.lbNovaSenha2.Name = "lbNovaSenha2";
            this.lbNovaSenha2.Size = new System.Drawing.Size(73, 13);
            this.lbNovaSenha2.TabIndex = 5;
            this.lbNovaSenha2.Text = "Repetir senha";
            // 
            // txtNovaSenha2
            // 
            this.txtNovaSenha2.Location = new System.Drawing.Point(16, 182);
            this.txtNovaSenha2.Name = "txtNovaSenha2";
            this.txtNovaSenha2.PasswordChar = '●';
            this.txtNovaSenha2.Size = new System.Drawing.Size(100, 20);
            this.txtNovaSenha2.TabIndex = 6;
            this.txtNovaSenha2.TextChanged += new System.EventHandler(this.txtNovaSenha2_TextChanged);
            this.txtNovaSenha2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNovaSenha2_KeyDown);
            // 
            // btAltera
            // 
            this.btAltera.Image = global::GUI.Properties.Resources.circle_check_6x;
            this.btAltera.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btAltera.Location = new System.Drawing.Point(140, 53);
            this.btAltera.Name = "btAltera";
            this.btAltera.Size = new System.Drawing.Size(75, 71);
            this.btAltera.TabIndex = 7;
            this.btAltera.Text = "Alterar";
            this.btAltera.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btAltera.UseVisualStyleBackColor = true;
            this.btAltera.Click += new System.EventHandler(this.btAltera_Click);
            // 
            // btCancela
            // 
            this.btCancela.Image = global::GUI.Properties.Resources.x_6x;
            this.btCancela.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btCancela.Location = new System.Drawing.Point(140, 131);
            this.btCancela.Name = "btCancela";
            this.btCancela.Size = new System.Drawing.Size(75, 71);
            this.btCancela.TabIndex = 8;
            this.btCancela.Text = "Cancelar";
            this.btCancela.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btCancela.UseVisualStyleBackColor = true;
            this.btCancela.Click += new System.EventHandler(this.btCancela_Click);
            // 
            // frmAlteraSenha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 224);
            this.Controls.Add(this.btCancela);
            this.Controls.Add(this.btAltera);
            this.Controls.Add(this.txtNovaSenha2);
            this.Controls.Add(this.lbNovaSenha2);
            this.Controls.Add(this.txtNovaSenha1);
            this.Controls.Add(this.lbNovaSenha1);
            this.Controls.Add(this.txtSenhaAtual);
            this.Controls.Add(this.lbSenhaAtual);
            this.Controls.Add(this.lbUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAlteraSenha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alterar a senha";
            this.Load += new System.EventHandler(this.frmAlteraSenha_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbUsuario;
        private System.Windows.Forms.Label lbSenhaAtual;
        private System.Windows.Forms.TextBox txtSenhaAtual;
        private System.Windows.Forms.Label lbNovaSenha1;
        private System.Windows.Forms.TextBox txtNovaSenha1;
        private System.Windows.Forms.Label lbNovaSenha2;
        private System.Windows.Forms.TextBox txtNovaSenha2;
        private System.Windows.Forms.Button btAltera;
        private System.Windows.Forms.Button btCancela;
    }
}