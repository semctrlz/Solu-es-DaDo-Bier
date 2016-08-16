namespace GUI
{
    partial class frmCadastroMixUnidade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroMixUnidade));
            this.btCancelar = new System.Windows.Forms.Button();
            this.pnConsulta = new System.Windows.Forms.Panel();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.btSalvar = new System.Windows.Forms.Button();
            this.pnCadastro = new System.Windows.Forms.Panel();
            this.gbProduto = new System.Windows.Forms.GroupBox();
            this.txtEstoqueMinimo = new System.Windows.Forms.TextBox();
            this.lbProduto = new System.Windows.Forms.Label();
            this.lbEstoqueMin = new System.Windows.Forms.Label();
            this.cbProduto = new System.Windows.Forms.ComboBox();
            this.cbSetor = new System.Windows.Forms.ComboBox();
            this.cbUnidade = new System.Windows.Forms.ComboBox();
            this.lbUnidade = new System.Windows.Forms.Label();
            this.lbSetor = new System.Windows.Forms.Label();
            this.btExcluir = new System.Windows.Forms.Button();
            this.gbInformacoesSetor = new System.Windows.Forms.GroupBox();
            this.btEditar = new System.Windows.Forms.Button();
            this.pnConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.pnCadastro.SuspendLayout();
            this.gbProduto.SuspendLayout();
            this.gbInformacoesSetor.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCancelar
            // 
            this.btCancelar.Image = global::GUI.Properties.Resources.x_4x;
            this.btCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btCancelar.Location = new System.Drawing.Point(469, 80);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(58, 58);
            this.btCancelar.TabIndex = 15;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // pnConsulta
            // 
            this.pnConsulta.Controls.Add(this.dgvDados);
            this.pnConsulta.Location = new System.Drawing.Point(12, 141);
            this.pnConsulta.Name = "pnConsulta";
            this.pnConsulta.Size = new System.Drawing.Size(510, 407);
            this.pnConsulta.TabIndex = 13;
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.AllowUserToDeleteRows = false;
            this.dgvDados.AllowUserToResizeColumns = false;
            this.dgvDados.AllowUserToResizeRows = false;
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDados.Location = new System.Drawing.Point(0, 0);
            this.dgvDados.MultiSelect = false;
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.ReadOnly = true;
            this.dgvDados.RowHeadersVisible = false;
            this.dgvDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDados.Size = new System.Drawing.Size(510, 407);
            this.dgvDados.TabIndex = 0;
            this.dgvDados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDados_CellClick);
            this.dgvDados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDados_CellDoubleClick);
            // 
            // btSalvar
            // 
            this.btSalvar.Image = global::GUI.Properties.Resources.circle_check_4x;
            this.btSalvar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btSalvar.Location = new System.Drawing.Point(469, 15);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(58, 58);
            this.btSalvar.TabIndex = 14;
            this.btSalvar.Text = "Salvar";
            this.btSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btSalvar.UseVisualStyleBackColor = true;
            this.btSalvar.Click += new System.EventHandler(this.btSalvar_Click);
            // 
            // pnCadastro
            // 
            this.pnCadastro.Controls.Add(this.gbProduto);
            this.pnCadastro.Location = new System.Drawing.Point(12, 12);
            this.pnCadastro.Name = "pnCadastro";
            this.pnCadastro.Size = new System.Drawing.Size(387, 122);
            this.pnCadastro.TabIndex = 10;
            // 
            // gbProduto
            // 
            this.gbProduto.Controls.Add(this.txtEstoqueMinimo);
            this.gbProduto.Controls.Add(this.lbProduto);
            this.gbProduto.Controls.Add(this.lbEstoqueMin);
            this.gbProduto.Controls.Add(this.cbProduto);
            this.gbProduto.Location = new System.Drawing.Point(0, 82);
            this.gbProduto.Name = "gbProduto";
            this.gbProduto.Size = new System.Drawing.Size(387, 41);
            this.gbProduto.TabIndex = 10;
            this.gbProduto.TabStop = false;
            // 
            // txtEstoqueMinimo
            // 
            this.txtEstoqueMinimo.Location = new System.Drawing.Point(338, 13);
            this.txtEstoqueMinimo.MaxLength = 3;
            this.txtEstoqueMinimo.Name = "txtEstoqueMinimo";
            this.txtEstoqueMinimo.Size = new System.Drawing.Size(43, 20);
            this.txtEstoqueMinimo.TabIndex = 9;
            this.txtEstoqueMinimo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEstoqueMinimo_KeyDown);
            // 
            // lbProduto
            // 
            this.lbProduto.AutoSize = true;
            this.lbProduto.Location = new System.Drawing.Point(6, 16);
            this.lbProduto.Name = "lbProduto";
            this.lbProduto.Size = new System.Drawing.Size(44, 13);
            this.lbProduto.TabIndex = 6;
            this.lbProduto.Text = "Produto";
            // 
            // lbEstoqueMin
            // 
            this.lbEstoqueMin.AutoSize = true;
            this.lbEstoqueMin.Location = new System.Drawing.Point(248, 16);
            this.lbEstoqueMin.Name = "lbEstoqueMin";
            this.lbEstoqueMin.Size = new System.Drawing.Size(84, 13);
            this.lbEstoqueMin.TabIndex = 8;
            this.lbEstoqueMin.Text = "Estoque Mínimo";
            // 
            // cbProduto
            // 
            this.cbProduto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbProduto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbProduto.FormattingEnabled = true;
            this.cbProduto.Location = new System.Drawing.Point(60, 13);
            this.cbProduto.Name = "cbProduto";
            this.cbProduto.Size = new System.Drawing.Size(182, 21);
            this.cbProduto.TabIndex = 7;
            this.cbProduto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbProduto_KeyDown);
            // 
            // cbSetor
            // 
            this.cbSetor.FormattingEnabled = true;
            this.cbSetor.Location = new System.Drawing.Point(59, 51);
            this.cbSetor.Name = "cbSetor";
            this.cbSetor.Size = new System.Drawing.Size(121, 21);
            this.cbSetor.TabIndex = 5;
            this.cbSetor.SelectedIndexChanged += new System.EventHandler(this.cbSetor_SelectedIndexChanged);
            // 
            // cbUnidade
            // 
            this.cbUnidade.FormattingEnabled = true;
            this.cbUnidade.Location = new System.Drawing.Point(59, 24);
            this.cbUnidade.Name = "cbUnidade";
            this.cbUnidade.Size = new System.Drawing.Size(55, 21);
            this.cbUnidade.TabIndex = 3;
            this.cbUnidade.SelectedIndexChanged += new System.EventHandler(this.cbUnidade_SelectedIndexChanged);
            // 
            // lbUnidade
            // 
            this.lbUnidade.AutoSize = true;
            this.lbUnidade.Location = new System.Drawing.Point(6, 27);
            this.lbUnidade.Name = "lbUnidade";
            this.lbUnidade.Size = new System.Drawing.Size(47, 13);
            this.lbUnidade.TabIndex = 2;
            this.lbUnidade.Text = "Unidade";
            // 
            // lbSetor
            // 
            this.lbSetor.AutoSize = true;
            this.lbSetor.Location = new System.Drawing.Point(6, 54);
            this.lbSetor.Name = "lbSetor";
            this.lbSetor.Size = new System.Drawing.Size(32, 13);
            this.lbSetor.TabIndex = 0;
            this.lbSetor.Text = "Setor";
            // 
            // btExcluir
            // 
            this.btExcluir.Image = global::GUI.Properties.Resources.trash_4x;
            this.btExcluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btExcluir.Location = new System.Drawing.Point(405, 79);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(58, 58);
            this.btExcluir.TabIndex = 12;
            this.btExcluir.Text = "Excluir";
            this.btExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // gbInformacoesSetor
            // 
            this.gbInformacoesSetor.Controls.Add(this.lbUnidade);
            this.gbInformacoesSetor.Controls.Add(this.lbSetor);
            this.gbInformacoesSetor.Controls.Add(this.cbUnidade);
            this.gbInformacoesSetor.Controls.Add(this.cbSetor);
            this.gbInformacoesSetor.Location = new System.Drawing.Point(12, 12);
            this.gbInformacoesSetor.Name = "gbInformacoesSetor";
            this.gbInformacoesSetor.Size = new System.Drawing.Size(387, 79);
            this.gbInformacoesSetor.TabIndex = 10;
            this.gbInformacoesSetor.TabStop = false;
            this.gbInformacoesSetor.Text = "Informações do setor";
            // 
            // btEditar
            // 
            this.btEditar.Image = global::GUI.Properties.Resources.pencil_4x;
            this.btEditar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btEditar.Location = new System.Drawing.Point(405, 15);
            this.btEditar.Name = "btEditar";
            this.btEditar.Size = new System.Drawing.Size(58, 58);
            this.btEditar.TabIndex = 11;
            this.btEditar.Text = "Editar";
            this.btEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btEditar.UseVisualStyleBackColor = true;
            this.btEditar.Click += new System.EventHandler(this.btEditar_Click);
            // 
            // frmCadastroMixUnidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 558);
            this.Controls.Add(this.gbInformacoesSetor);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.pnConsulta);
            this.Controls.Add(this.btSalvar);
            this.Controls.Add(this.pnCadastro);
            this.Controls.Add(this.btExcluir);
            this.Controls.Add(this.btEditar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCadastroMixUnidade";
            this.Text = "Cadastro de Mix";
            this.Load += new System.EventHandler(this.frmCadastroMixUnidade_Load);
            this.pnConsulta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.pnCadastro.ResumeLayout(false);
            this.gbProduto.ResumeLayout(false);
            this.gbProduto.PerformLayout();
            this.gbInformacoesSetor.ResumeLayout(false);
            this.gbInformacoesSetor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Panel pnConsulta;
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.Button btSalvar;
        private System.Windows.Forms.Panel pnCadastro;
        private System.Windows.Forms.ComboBox cbUnidade;
        private System.Windows.Forms.Label lbUnidade;
        private System.Windows.Forms.Label lbSetor;
        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.TextBox txtEstoqueMinimo;
        private System.Windows.Forms.Label lbEstoqueMin;
        private System.Windows.Forms.ComboBox cbProduto;
        private System.Windows.Forms.Label lbProduto;
        private System.Windows.Forms.ComboBox cbSetor;
        private System.Windows.Forms.GroupBox gbInformacoesSetor;
        private System.Windows.Forms.Button btEditar;
        private System.Windows.Forms.GroupBox gbProduto;
    }
}