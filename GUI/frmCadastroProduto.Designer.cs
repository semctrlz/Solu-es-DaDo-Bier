namespace GUI
{
    partial class frmCadastroProduto
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
            this.gbCadastro = new System.Windows.Forms.GroupBox();
            this.lbcodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.cbAtivo = new System.Windows.Forms.CheckBox();
            this.lbAtivo = new System.Windows.Forms.Label();
            this.btDeleta = new System.Windows.Forms.Button();
            this.btCarrega = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbFotoProduto = new System.Windows.Forms.PictureBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.lbDesc = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.lbModelo = new System.Windows.Forms.Label();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.lbMarca = new System.Windows.Forms.Label();
            this.cbGrupo = new System.Windows.Forms.ComboBox();
            this.lbGrupo = new System.Windows.Forms.Label();
            this.txtNomeProduto = new System.Windows.Forms.TextBox();
            this.lbNomeProduto = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.pnDados.SuspendLayout();
            this.pnBotoes.SuspendLayout();
            this.gbCadastro.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoProduto)).BeginInit();
            this.SuspendLayout();
            // 
            // pnDados
            // 
            this.pnDados.Controls.Add(this.gbCadastro);
            this.pnDados.Controls.Add(this.txtId);
            // 
            // btCancelar
            // 
            this.btCancelar.Text = "&Cancelar";
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btSalvar
            // 
            this.btSalvar.Text = "&Salvar";
            this.btSalvar.Click += new System.EventHandler(this.btSalvar_Click);
            // 
            // btExcluir
            // 
            this.btExcluir.Text = "&Excluir";
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // btAlterar
            // 
            this.btAlterar.Text = "&Alterar";
            this.btAlterar.Click += new System.EventHandler(this.btAlterar_Click);
            // 
            // btLocalizar
            // 
            this.btLocalizar.Text = "&Localizar";
            this.btLocalizar.Click += new System.EventHandler(this.btLocalizar_Click);
            // 
            // btInserir
            // 
            this.btInserir.Text = "&Inserir";
            this.btInserir.Click += new System.EventHandler(this.btInserir_Click);
            // 
            // gbCadastro
            // 
            this.gbCadastro.Controls.Add(this.lbcodigo);
            this.gbCadastro.Controls.Add(this.txtCodigo);
            this.gbCadastro.Controls.Add(this.cbAtivo);
            this.gbCadastro.Controls.Add(this.lbAtivo);
            this.gbCadastro.Controls.Add(this.btDeleta);
            this.gbCadastro.Controls.Add(this.btCarrega);
            this.gbCadastro.Controls.Add(this.panel1);
            this.gbCadastro.Controls.Add(this.txtDesc);
            this.gbCadastro.Controls.Add(this.lbDesc);
            this.gbCadastro.Controls.Add(this.txtModelo);
            this.gbCadastro.Controls.Add(this.lbModelo);
            this.gbCadastro.Controls.Add(this.txtMarca);
            this.gbCadastro.Controls.Add(this.lbMarca);
            this.gbCadastro.Controls.Add(this.cbGrupo);
            this.gbCadastro.Controls.Add(this.lbGrupo);
            this.gbCadastro.Controls.Add(this.txtNomeProduto);
            this.gbCadastro.Controls.Add(this.lbNomeProduto);
            this.gbCadastro.Location = new System.Drawing.Point(3, 3);
            this.gbCadastro.Name = "gbCadastro";
            this.gbCadastro.Size = new System.Drawing.Size(483, 386);
            this.gbCadastro.TabIndex = 0;
            this.gbCadastro.TabStop = false;
            this.gbCadastro.Text = "Dados do produto";
            // 
            // lbcodigo
            // 
            this.lbcodigo.AutoSize = true;
            this.lbcodigo.Location = new System.Drawing.Point(325, 23);
            this.lbcodigo.Name = "lbcodigo";
            this.lbcodigo.Size = new System.Drawing.Size(40, 13);
            this.lbcodigo.TabIndex = 19;
            this.lbcodigo.Text = "Código";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(371, 20);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(105, 20);
            this.txtCodigo.TabIndex = 18;
            // 
            // cbAtivo
            // 
            this.cbAtivo.AutoSize = true;
            this.cbAtivo.Location = new System.Drawing.Point(257, 79);
            this.cbAtivo.Name = "cbAtivo";
            this.cbAtivo.Size = new System.Drawing.Size(15, 14);
            this.cbAtivo.TabIndex = 17;
            this.cbAtivo.UseVisualStyleBackColor = true;
            // 
            // lbAtivo
            // 
            this.lbAtivo.AutoSize = true;
            this.lbAtivo.Location = new System.Drawing.Point(220, 79);
            this.lbAtivo.Name = "lbAtivo";
            this.lbAtivo.Size = new System.Drawing.Size(31, 13);
            this.lbAtivo.TabIndex = 16;
            this.lbAtivo.Text = "Ativo";
            // 
            // btDeleta
            // 
            this.btDeleta.Image = global::GUI.Properties.Resources.fire_8x;
            this.btDeleta.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btDeleta.Location = new System.Drawing.Point(27, 286);
            this.btDeleta.Name = "btDeleta";
            this.btDeleta.Size = new System.Drawing.Size(75, 90);
            this.btDeleta.TabIndex = 15;
            this.btDeleta.Text = "&Deleta";
            this.btDeleta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btDeleta.UseVisualStyleBackColor = true;
            this.btDeleta.Click += new System.EventHandler(this.btDeleta_Click);
            // 
            // btCarrega
            // 
            this.btCarrega.Image = global::GUI.Properties.Resources.camera_slr_8x;
            this.btCarrega.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btCarrega.Location = new System.Drawing.Point(27, 187);
            this.btCarrega.Name = "btCarrega";
            this.btCarrega.Size = new System.Drawing.Size(75, 90);
            this.btCarrega.TabIndex = 14;
            this.btCarrega.Text = "Ca&rrega";
            this.btCarrega.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btCarrega.UseVisualStyleBackColor = true;
            this.btCarrega.Click += new System.EventHandler(this.btCarrega_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pbFotoProduto);
            this.panel1.Location = new System.Drawing.Point(138, 176);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(339, 204);
            this.panel1.TabIndex = 13;
            // 
            // pbFotoProduto
            // 
            this.pbFotoProduto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbFotoProduto.Location = new System.Drawing.Point(0, 0);
            this.pbFotoProduto.Name = "pbFotoProduto";
            this.pbFotoProduto.Size = new System.Drawing.Size(337, 202);
            this.pbFotoProduto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFotoProduto.TabIndex = 0;
            this.pbFotoProduto.TabStop = false;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(72, 100);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(405, 69);
            this.txtDesc.TabIndex = 12;
            // 
            // lbDesc
            // 
            this.lbDesc.AutoSize = true;
            this.lbDesc.Location = new System.Drawing.Point(10, 105);
            this.lbDesc.Name = "lbDesc";
            this.lbDesc.Size = new System.Drawing.Size(55, 13);
            this.lbDesc.TabIndex = 11;
            this.lbDesc.Text = "Descrição";
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(49, 73);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(162, 20);
            this.txtModelo.TabIndex = 10;
            // 
            // lbModelo
            // 
            this.lbModelo.AutoSize = true;
            this.lbModelo.Location = new System.Drawing.Point(7, 76);
            this.lbModelo.Name = "lbModelo";
            this.lbModelo.Size = new System.Drawing.Size(42, 13);
            this.lbModelo.TabIndex = 9;
            this.lbModelo.Text = "Modelo";
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(261, 46);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(216, 20);
            this.txtMarca.TabIndex = 8;
            // 
            // lbMarca
            // 
            this.lbMarca.AutoSize = true;
            this.lbMarca.Location = new System.Drawing.Point(217, 53);
            this.lbMarca.Name = "lbMarca";
            this.lbMarca.Size = new System.Drawing.Size(37, 13);
            this.lbMarca.TabIndex = 7;
            this.lbMarca.Text = "Marca";
            // 
            // cbGrupo
            // 
            this.cbGrupo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbGrupo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbGrupo.FormattingEnabled = true;
            this.cbGrupo.Location = new System.Drawing.Point(49, 46);
            this.cbGrupo.Name = "cbGrupo";
            this.cbGrupo.Size = new System.Drawing.Size(162, 21);
            this.cbGrupo.TabIndex = 6;
            this.cbGrupo.SelectedIndexChanged += new System.EventHandler(this.cbGrupo_SelectedIndexChanged);
            this.cbGrupo.Leave += new System.EventHandler(this.cbGrupo_Leave);
            // 
            // lbGrupo
            // 
            this.lbGrupo.AutoSize = true;
            this.lbGrupo.Location = new System.Drawing.Point(7, 49);
            this.lbGrupo.Name = "lbGrupo";
            this.lbGrupo.Size = new System.Drawing.Size(36, 13);
            this.lbGrupo.TabIndex = 5;
            this.lbGrupo.Text = "Grupo";
            // 
            // txtNomeProduto
            // 
            this.txtNomeProduto.Location = new System.Drawing.Point(49, 20);
            this.txtNomeProduto.Name = "txtNomeProduto";
            this.txtNomeProduto.Size = new System.Drawing.Size(244, 20);
            this.txtNomeProduto.TabIndex = 1;
            // 
            // lbNomeProduto
            // 
            this.lbNomeProduto.AutoSize = true;
            this.lbNomeProduto.Location = new System.Drawing.Point(7, 23);
            this.lbNomeProduto.Name = "lbNomeProduto";
            this.lbNomeProduto.Size = new System.Drawing.Size(35, 13);
            this.lbNomeProduto.TabIndex = 0;
            this.lbNomeProduto.Text = "Nome";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(434, 411);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(26, 20);
            this.txtId.TabIndex = 2;
            this.txtId.Visible = false;
            // 
            // frmCadastroProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(506, 561);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCadastroProduto";
            this.Text = "Cadastro de Produtos";
            this.Load += new System.EventHandler(this.frmCadastroProduto_Load);
            this.pnDados.ResumeLayout(false);
            this.pnDados.PerformLayout();
            this.pnBotoes.ResumeLayout(false);
            this.gbCadastro.ResumeLayout(false);
            this.gbCadastro.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbFotoProduto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCadastro;
        private System.Windows.Forms.Label lbNomeProduto;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtNomeProduto;
        private System.Windows.Forms.ComboBox cbGrupo;
        private System.Windows.Forms.Label lbGrupo;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label lbModelo;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Label lbMarca;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label lbDesc;
        private System.Windows.Forms.Button btCarrega;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbFotoProduto;
        private System.Windows.Forms.Button btDeleta;
        private System.Windows.Forms.CheckBox cbAtivo;
        private System.Windows.Forms.Label lbAtivo;
        private System.Windows.Forms.Label lbcodigo;
        private System.Windows.Forms.TextBox txtCodigo;
    }
}
