namespace GUI
{
    partial class frmCadastroUnidade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroUnidade));
            this.lbNomeUnidade = new System.Windows.Forms.Label();
            this.txtNomeUnidade = new System.Windows.Forms.TextBox();
            this.gbUnidade = new System.Windows.Forms.GroupBox();
            this.txtIdUnidade = new System.Windows.Forms.TextBox();
            this.gbObs = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbObs = new System.Windows.Forms.Label();
            this.lbLogoUnidade = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.txtCodUnidade = new System.Windows.Forms.TextBox();
            this.lbCodUnidade = new System.Windows.Forms.Label();
            this.BtDeleta = new System.Windows.Forms.Button();
            this.btCarrega = new System.Windows.Forms.Button();
            this.pnDados.SuspendLayout();
            this.pnBotoes.SuspendLayout();
            this.gbUnidade.SuspendLayout();
            this.gbObs.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnDados
            // 
            this.pnDados.Controls.Add(this.gbUnidade);
            this.pnDados.Controls.Add(this.btCarrega);
            this.pnDados.Controls.Add(this.BtDeleta);
            this.pnDados.Size = new System.Drawing.Size(491, 485);
            // 
            // pnBotoes
            // 
            this.pnBotoes.Location = new System.Drawing.Point(13, 503);
            this.pnBotoes.Size = new System.Drawing.Size(491, 77);
            // 
            // btCancelar
            // 
            this.btCancelar.TabIndex = 10;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btSalvar
            // 
            this.btSalvar.TabIndex = 9;
            this.btSalvar.Click += new System.EventHandler(this.btSalvar_Click);
            // 
            // btExcluir
            // 
            this.btExcluir.TabIndex = 8;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // btAlterar
            // 
            this.btAlterar.TabIndex = 7;
            this.btAlterar.Click += new System.EventHandler(this.btAlterar_Click);
            // 
            // btLocalizar
            // 
            this.btLocalizar.Click += new System.EventHandler(this.btLocalizar_Click);
            // 
            // btInserir
            // 
            this.btInserir.TabIndex = 5;
            this.btInserir.Click += new System.EventHandler(this.btInserir_Click);
            // 
            // lbNomeUnidade
            // 
            this.lbNomeUnidade.AutoSize = true;
            this.lbNomeUnidade.Location = new System.Drawing.Point(6, 26);
            this.lbNomeUnidade.Name = "lbNomeUnidade";
            this.lbNomeUnidade.Size = new System.Drawing.Size(94, 13);
            this.lbNomeUnidade.TabIndex = 0;
            this.lbNomeUnidade.Text = "Nome da unidade:";
            // 
            // txtNomeUnidade
            // 
            this.txtNomeUnidade.Location = new System.Drawing.Point(111, 19);
            this.txtNomeUnidade.Name = "txtNomeUnidade";
            this.txtNomeUnidade.Size = new System.Drawing.Size(354, 20);
            this.txtNomeUnidade.TabIndex = 1;
            // 
            // gbUnidade
            // 
            this.gbUnidade.Controls.Add(this.txtIdUnidade);
            this.gbUnidade.Controls.Add(this.gbObs);
            this.gbUnidade.Controls.Add(this.lbLogoUnidade);
            this.gbUnidade.Controls.Add(this.panel1);
            this.gbUnidade.Controls.Add(this.txtCodUnidade);
            this.gbUnidade.Controls.Add(this.txtNomeUnidade);
            this.gbUnidade.Controls.Add(this.lbCodUnidade);
            this.gbUnidade.Controls.Add(this.lbNomeUnidade);
            this.gbUnidade.Location = new System.Drawing.Point(3, 3);
            this.gbUnidade.Name = "gbUnidade";
            this.gbUnidade.Size = new System.Drawing.Size(481, 380);
            this.gbUnidade.TabIndex = 2;
            this.gbUnidade.TabStop = false;
            this.gbUnidade.Text = "Dados da Unidade";
            // 
            // txtIdUnidade
            // 
            this.txtIdUnidade.Enabled = false;
            this.txtIdUnidade.Location = new System.Drawing.Point(176, 45);
            this.txtIdUnidade.Name = "txtIdUnidade";
            this.txtIdUnidade.Size = new System.Drawing.Size(100, 20);
            this.txtIdUnidade.TabIndex = 7;
            this.txtIdUnidade.Visible = false;
            // 
            // gbObs
            // 
            this.gbObs.Controls.Add(this.label2);
            this.gbObs.Controls.Add(this.label1);
            this.gbObs.Controls.Add(this.lbObs);
            this.gbObs.Location = new System.Drawing.Point(3, 106);
            this.gbObs.Name = "gbObs";
            this.gbObs.Size = new System.Drawing.Size(156, 113);
            this.gbObs.TabIndex = 6;
            this.gbObs.TabStop = false;
            this.gbObs.Text = "OBS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "300x300 pixels.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "proporções de 1:1 e medir";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbObs
            // 
            this.lbObs.AutoSize = true;
            this.lbObs.Location = new System.Drawing.Point(7, 20);
            this.lbObs.Name = "lbObs";
            this.lbObs.Size = new System.Drawing.Size(148, 13);
            this.lbObs.TabIndex = 0;
            this.lbObs.Text = "A imagem  grande deve ter as";
            this.lbObs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLogoUnidade
            // 
            this.lbLogoUnidade.AutoSize = true;
            this.lbLogoUnidade.Location = new System.Drawing.Point(6, 75);
            this.lbLogoUnidade.Name = "lbLogoUnidade";
            this.lbLogoUnidade.Size = new System.Drawing.Size(90, 13);
            this.lbLogoUnidade.TabIndex = 5;
            this.lbLogoUnidade.Text = "Logo da unidade:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pbLogo);
            this.panel1.Location = new System.Drawing.Point(165, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 302);
            this.panel1.TabIndex = 2;
            // 
            // pbLogo
            // 
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbLogo.InitialImage = global::GUI.Properties.Resources.no_thumb;
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(300, 300);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // txtCodUnidade
            // 
            this.txtCodUnidade.Location = new System.Drawing.Point(111, 45);
            this.txtCodUnidade.MaxLength = 2;
            this.txtCodUnidade.Name = "txtCodUnidade";
            this.txtCodUnidade.Size = new System.Drawing.Size(58, 20);
            this.txtCodUnidade.TabIndex = 2;
            // 
            // lbCodUnidade
            // 
            this.lbCodUnidade.AutoSize = true;
            this.lbCodUnidade.Location = new System.Drawing.Point(6, 52);
            this.lbCodUnidade.Name = "lbCodUnidade";
            this.lbCodUnidade.Size = new System.Drawing.Size(99, 13);
            this.lbCodUnidade.TabIndex = 0;
            this.lbCodUnidade.Text = "Código da unidade:";
            // 
            // BtDeleta
            // 
            this.BtDeleta.Image = global::GUI.Properties.Resources.fire_8x;
            this.BtDeleta.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtDeleta.Location = new System.Drawing.Point(319, 384);
            this.BtDeleta.Name = "BtDeleta";
            this.BtDeleta.Size = new System.Drawing.Size(75, 90);
            this.BtDeleta.TabIndex = 4;
            this.BtDeleta.Text = "Deleta";
            this.BtDeleta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtDeleta.UseVisualStyleBackColor = true;
            this.BtDeleta.Click += new System.EventHandler(this.BtDeleta_Click);
            // 
            // btCarrega
            // 
            this.btCarrega.Image = global::GUI.Properties.Resources.camera_slr_8x;
            this.btCarrega.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btCarrega.Location = new System.Drawing.Point(238, 384);
            this.btCarrega.Name = "btCarrega";
            this.btCarrega.Size = new System.Drawing.Size(75, 90);
            this.btCarrega.TabIndex = 3;
            this.btCarrega.Text = "Carrega";
            this.btCarrega.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btCarrega.UseVisualStyleBackColor = true;
            this.btCarrega.Click += new System.EventHandler(this.btCarrega_Click);
            // 
            // frmCadastroUnidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(509, 592);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCadastroUnidade";
            this.Text = "Cadastro de Unidade";
            this.Load += new System.EventHandler(this.frmCadastroUnidade_Load);
            this.pnDados.ResumeLayout(false);
            this.pnBotoes.ResumeLayout(false);
            this.gbUnidade.ResumeLayout(false);
            this.gbUnidade.PerformLayout();
            this.gbObs.ResumeLayout(false);
            this.gbObs.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtNomeUnidade;
        private System.Windows.Forms.Label lbNomeUnidade;
        private System.Windows.Forms.GroupBox gbUnidade;
        private System.Windows.Forms.TextBox txtCodUnidade;
        private System.Windows.Forms.Label lbCodUnidade;
        private System.Windows.Forms.Label lbLogoUnidade;
        private System.Windows.Forms.Button BtDeleta;
        private System.Windows.Forms.Button btCarrega;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbObs;
        private System.Windows.Forms.Label lbObs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.TextBox txtIdUnidade;
    }
}
