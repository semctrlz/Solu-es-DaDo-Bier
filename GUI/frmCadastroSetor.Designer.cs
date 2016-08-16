namespace GUI
{
    partial class frmCadastroSetor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroSetor));
            this.btCancelar = new System.Windows.Forms.Button();
            this.pnConsulta = new System.Windows.Forms.Panel();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.btSalvar = new System.Windows.Forms.Button();
            this.pnCadastro = new System.Windows.Forms.Panel();
            this.txtId = new System.Windows.Forms.TextBox();
            this.cbUnidade = new System.Windows.Forms.ComboBox();
            this.lbUnidade = new System.Windows.Forms.Label();
            this.txtNomeSetor = new System.Windows.Forms.TextBox();
            this.lbNome = new System.Windows.Forms.Label();
            this.btExcluir = new System.Windows.Forms.Button();
            this.btEditar = new System.Windows.Forms.Button();
            this.pnConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.pnCadastro.SuspendLayout();
            this.SuspendLayout();
            // 
            // btCancelar
            // 
            this.btCancelar.Image = global::GUI.Properties.Resources.x_4x;
            this.btCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btCancelar.Location = new System.Drawing.Point(314, 77);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(58, 58);
            this.btCancelar.TabIndex = 9;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // pnConsulta
            // 
            this.pnConsulta.Controls.Add(this.dgvDados);
            this.pnConsulta.Location = new System.Drawing.Point(13, 141);
            this.pnConsulta.Name = "pnConsulta";
            this.pnConsulta.Size = new System.Drawing.Size(359, 407);
            this.pnConsulta.TabIndex = 7;
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
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.ReadOnly = true;
            this.dgvDados.RowHeadersVisible = false;
            this.dgvDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDados.Size = new System.Drawing.Size(359, 407);
            this.dgvDados.TabIndex = 0;
            this.dgvDados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDados_CellDoubleClick);
            // 
            // btSalvar
            // 
            this.btSalvar.Image = global::GUI.Properties.Resources.circle_check_4x;
            this.btSalvar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btSalvar.Location = new System.Drawing.Point(314, 12);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(58, 58);
            this.btSalvar.TabIndex = 8;
            this.btSalvar.Text = "Salvar";
            this.btSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btSalvar.UseVisualStyleBackColor = true;
            this.btSalvar.Click += new System.EventHandler(this.btSalvar_Click);
            // 
            // pnCadastro
            // 
            this.pnCadastro.Controls.Add(this.txtId);
            this.pnCadastro.Controls.Add(this.cbUnidade);
            this.pnCadastro.Controls.Add(this.lbUnidade);
            this.pnCadastro.Controls.Add(this.txtNomeSetor);
            this.pnCadastro.Controls.Add(this.lbNome);
            this.pnCadastro.Location = new System.Drawing.Point(13, 12);
            this.pnCadastro.Name = "pnCadastro";
            this.pnCadastro.Size = new System.Drawing.Size(231, 122);
            this.pnCadastro.TabIndex = 4;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(71, 99);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(44, 20);
            this.txtId.TabIndex = 4;
            this.txtId.Visible = false;
            // 
            // cbUnidade
            // 
            this.cbUnidade.FormattingEnabled = true;
            this.cbUnidade.Location = new System.Drawing.Point(86, 18);
            this.cbUnidade.Name = "cbUnidade";
            this.cbUnidade.Size = new System.Drawing.Size(142, 21);
            this.cbUnidade.TabIndex = 3;
            this.cbUnidade.SelectedIndexChanged += new System.EventHandler(this.cbUnidade_SelectedIndexChanged);
            // 
            // lbUnidade
            // 
            this.lbUnidade.AutoSize = true;
            this.lbUnidade.Location = new System.Drawing.Point(3, 21);
            this.lbUnidade.Name = "lbUnidade";
            this.lbUnidade.Size = new System.Drawing.Size(47, 13);
            this.lbUnidade.TabIndex = 2;
            this.lbUnidade.Text = "Unidade";
            // 
            // txtNomeSetor
            // 
            this.txtNomeSetor.Location = new System.Drawing.Point(86, 45);
            this.txtNomeSetor.Name = "txtNomeSetor";
            this.txtNomeSetor.Size = new System.Drawing.Size(142, 20);
            this.txtNomeSetor.TabIndex = 1;
            // 
            // lbNome
            // 
            this.lbNome.AutoSize = true;
            this.lbNome.Location = new System.Drawing.Point(3, 48);
            this.lbNome.Name = "lbNome";
            this.lbNome.Size = new System.Drawing.Size(76, 13);
            this.lbNome.TabIndex = 0;
            this.lbNome.Text = "Nome do setor";
            // 
            // btExcluir
            // 
            this.btExcluir.Image = global::GUI.Properties.Resources.trash_4x;
            this.btExcluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btExcluir.Location = new System.Drawing.Point(250, 76);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(58, 58);
            this.btExcluir.TabIndex = 6;
            this.btExcluir.Text = "Excluir";
            this.btExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // btEditar
            // 
            this.btEditar.Image = global::GUI.Properties.Resources.pencil_4x;
            this.btEditar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btEditar.Location = new System.Drawing.Point(250, 12);
            this.btEditar.Name = "btEditar";
            this.btEditar.Size = new System.Drawing.Size(58, 58);
            this.btEditar.TabIndex = 5;
            this.btEditar.Text = "Editar";
            this.btEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btEditar.UseVisualStyleBackColor = true;
            this.btEditar.Click += new System.EventHandler(this.btEditar_Click);
            // 
            // frmCadastroSetor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 561);
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
            this.Name = "frmCadastroSetor";
            this.Text = "Cadastro de setor";
            this.Load += new System.EventHandler(this.frmCadastroSetor_Load);
            this.pnConsulta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.pnCadastro.ResumeLayout(false);
            this.pnCadastro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Panel pnConsulta;
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.Button btSalvar;
        private System.Windows.Forms.Panel pnCadastro;
        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.Button btEditar;
        private System.Windows.Forms.ComboBox cbUnidade;
        private System.Windows.Forms.Label lbUnidade;
        private System.Windows.Forms.TextBox txtNomeSetor;
        private System.Windows.Forms.Label lbNome;
        private System.Windows.Forms.TextBox txtId;
    }
}