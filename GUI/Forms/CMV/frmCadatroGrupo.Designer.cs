namespace GUI.CMV
{
    partial class frmCadatroGrupo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadatroGrupo));
            this.lbUnidade = new System.Windows.Forms.Label();
            this.cbUnidade = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gbConta = new System.Windows.Forms.GroupBox();
            this.dgvContas = new System.Windows.Forms.DataGridView();
            this.id_config_custo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idconfig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conta_nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.del = new System.Windows.Forms.DataGridViewImageColumn();
            this.gbAdmin = new System.Windows.Forms.GroupBox();
            this.dgvAdmin = new System.Windows.Forms.DataGridView();
            this.id_config_receita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod_admin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.cbGrupos = new System.Windows.Forms.ComboBox();
            this.lbGrupo = new System.Windows.Forms.Label();
            this.cbConta = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAdmin = new System.Windows.Forms.TextBox();
            this.btAddConta = new System.Windows.Forms.Button();
            this.btAddAdmin = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pnCadastroGrupo = new System.Windows.Forms.Panel();
            this.txtMetaPercent = new System.Windows.Forms.TextBox();
            this.txtMetaValor = new System.Windows.Forms.TextBox();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAdicionarGrupo = new System.Windows.Forms.Button();
            this.txtNomeGrupo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btExcluirGrupo = new System.Windows.Forms.Button();
            this.txtmetaValor1 = new System.Windows.Forms.TextBox();
            this.txtMEtaPercentual1 = new System.Windows.Forms.TextBox();
            this.btEditar = new System.Windows.Forms.Button();
            this.btSalvar = new System.Windows.Forms.Button();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.gbConta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContas)).BeginInit();
            this.gbAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdmin)).BeginInit();
            this.pnCadastroGrupo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbUnidade
            // 
            this.lbUnidade.AutoSize = true;
            this.lbUnidade.Location = new System.Drawing.Point(6, 16);
            this.lbUnidade.Name = "lbUnidade";
            this.lbUnidade.Size = new System.Drawing.Size(47, 13);
            this.lbUnidade.TabIndex = 0;
            this.lbUnidade.Text = "Unidade";
            // 
            // cbUnidade
            // 
            this.cbUnidade.FormattingEnabled = true;
            this.cbUnidade.Location = new System.Drawing.Point(6, 33);
            this.cbUnidade.Name = "cbUnidade";
            this.cbUnidade.Size = new System.Drawing.Size(75, 21);
            this.cbUnidade.TabIndex = 0;
            this.cbUnidade.TabStop = false;
            this.cbUnidade.SelectedIndexChanged += new System.EventHandler(this.cbUnidade_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.lbUnidade);
            this.groupBox1.Controls.Add(this.cbUnidade);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(523, 63);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(323, 106);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 100);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox2";
            // 
            // gbConta
            // 
            this.gbConta.Controls.Add(this.dgvContas);
            this.gbConta.Enabled = false;
            this.gbConta.Location = new System.Drawing.Point(12, 169);
            this.gbConta.Name = "gbConta";
            this.gbConta.Size = new System.Drawing.Size(398, 263);
            this.gbConta.TabIndex = 3;
            this.gbConta.TabStop = false;
            // 
            // dgvContas
            // 
            this.dgvContas.AllowUserToAddRows = false;
            this.dgvContas.AllowUserToDeleteRows = false;
            this.dgvContas.AllowUserToResizeColumns = false;
            this.dgvContas.AllowUserToResizeRows = false;
            this.dgvContas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_config_custo,
            this.idconfig,
            this.conta_nome,
            this.del});
            this.dgvContas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvContas.Location = new System.Drawing.Point(3, 16);
            this.dgvContas.Name = "dgvContas";
            this.dgvContas.ReadOnly = true;
            this.dgvContas.RowHeadersVisible = false;
            this.dgvContas.Size = new System.Drawing.Size(392, 244);
            this.dgvContas.TabIndex = 0;
            this.dgvContas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContas_CellContentClick);
            this.dgvContas.SelectionChanged += new System.EventHandler(this.dgvContas_SelectionChanged);
            // 
            // id_config_custo
            // 
            this.id_config_custo.HeaderText = "Id";
            this.id_config_custo.Name = "id_config_custo";
            this.id_config_custo.ReadOnly = true;
            this.id_config_custo.Visible = false;
            // 
            // idconfig
            // 
            this.idconfig.HeaderText = "IdConfig";
            this.idconfig.Name = "idconfig";
            this.idconfig.ReadOnly = true;
            this.idconfig.Visible = false;
            // 
            // conta_nome
            // 
            this.conta_nome.HeaderText = "Conta gerencial e nome";
            this.conta_nome.Name = "conta_nome";
            this.conta_nome.ReadOnly = true;
            this.conta_nome.Width = 362;
            // 
            // del
            // 
            this.del.HeaderText = "";
            this.del.Image = global::GUI.Properties.Resources.trash_2x;
            this.del.Name = "del";
            this.del.ReadOnly = true;
            this.del.Width = 26;
            // 
            // gbAdmin
            // 
            this.gbAdmin.Controls.Add(this.dgvAdmin);
            this.gbAdmin.Enabled = false;
            this.gbAdmin.Location = new System.Drawing.Point(416, 169);
            this.gbAdmin.Name = "gbAdmin";
            this.gbAdmin.Size = new System.Drawing.Size(119, 263);
            this.gbAdmin.TabIndex = 3;
            this.gbAdmin.TabStop = false;
            // 
            // dgvAdmin
            // 
            this.dgvAdmin.AllowUserToAddRows = false;
            this.dgvAdmin.AllowUserToDeleteRows = false;
            this.dgvAdmin.AllowUserToResizeColumns = false;
            this.dgvAdmin.AllowUserToResizeRows = false;
            this.dgvAdmin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdmin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_config_receita,
            this.cod_admin,
            this.delete});
            this.dgvAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAdmin.Location = new System.Drawing.Point(3, 16);
            this.dgvAdmin.Name = "dgvAdmin";
            this.dgvAdmin.ReadOnly = true;
            this.dgvAdmin.RowHeadersVisible = false;
            this.dgvAdmin.Size = new System.Drawing.Size(113, 244);
            this.dgvAdmin.TabIndex = 0;
            this.dgvAdmin.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAdmin_CellContentClick);
            this.dgvAdmin.SelectionChanged += new System.EventHandler(this.dgvAdmin_SelectionChanged);
            // 
            // id_config_receita
            // 
            this.id_config_receita.HeaderText = "id";
            this.id_config_receita.Name = "id_config_receita";
            this.id_config_receita.ReadOnly = true;
            this.id_config_receita.Visible = false;
            // 
            // cod_admin
            // 
            this.cod_admin.HeaderText = "Grupo Adm";
            this.cod_admin.Name = "cod_admin";
            this.cod_admin.ReadOnly = true;
            this.cod_admin.Width = 83;
            // 
            // delete
            // 
            this.delete.HeaderText = "";
            this.delete.Image = global::GUI.Properties.Resources.trash_2x;
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Width = 26;
            // 
            // cbGrupos
            // 
            this.cbGrupos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGrupos.FormattingEnabled = true;
            this.cbGrupos.Location = new System.Drawing.Point(15, 94);
            this.cbGrupos.Name = "cbGrupos";
            this.cbGrupos.Size = new System.Drawing.Size(262, 21);
            this.cbGrupos.TabIndex = 1;
            this.cbGrupos.SelectedIndexChanged += new System.EventHandler(this.cbGrupos_SelectedIndexChanged);
            // 
            // lbGrupo
            // 
            this.lbGrupo.AutoSize = true;
            this.lbGrupo.Location = new System.Drawing.Point(15, 78);
            this.lbGrupo.Name = "lbGrupo";
            this.lbGrupo.Size = new System.Drawing.Size(36, 13);
            this.lbGrupo.TabIndex = 0;
            this.lbGrupo.Text = "Grupo";
            // 
            // cbConta
            // 
            this.cbConta.Enabled = false;
            this.cbConta.FormattingEnabled = true;
            this.cbConta.Location = new System.Drawing.Point(15, 142);
            this.cbConta.Name = "cbConta";
            this.cbConta.Size = new System.Drawing.Size(362, 21);
            this.cbConta.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Conta gerencial";
            // 
            // txtAdmin
            // 
            this.txtAdmin.Enabled = false;
            this.txtAdmin.Location = new System.Drawing.Point(416, 142);
            this.txtAdmin.Name = "txtAdmin";
            this.txtAdmin.Size = new System.Drawing.Size(89, 20);
            this.txtAdmin.TabIndex = 5;
            // 
            // btAddConta
            // 
            this.btAddConta.Enabled = false;
            this.btAddConta.Image = global::GUI.Properties.Resources.arrow_circle_bottom_2x;
            this.btAddConta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAddConta.Location = new System.Drawing.Point(383, 140);
            this.btAddConta.Name = "btAddConta";
            this.btAddConta.Size = new System.Drawing.Size(24, 24);
            this.btAddConta.TabIndex = 7;
            this.btAddConta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAddConta.UseVisualStyleBackColor = true;
            this.btAddConta.Click += new System.EventHandler(this.btAddConta_Click);
            // 
            // btAddAdmin
            // 
            this.btAddAdmin.Enabled = false;
            this.btAddAdmin.Image = global::GUI.Properties.Resources.arrow_circle_bottom_2x;
            this.btAddAdmin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAddAdmin.Location = new System.Drawing.Point(507, 139);
            this.btAddAdmin.Name = "btAddAdmin";
            this.btAddAdmin.Size = new System.Drawing.Size(24, 24);
            this.btAddAdmin.TabIndex = 8;
            this.btAddAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAddAdmin.UseVisualStyleBackColor = true;
            this.btAddAdmin.Click += new System.EventHandler(this.btAddAdmin_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(413, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Grupo admin";
            // 
            // pnCadastroGrupo
            // 
            this.pnCadastroGrupo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnCadastroGrupo.Controls.Add(this.txtMetaPercent);
            this.pnCadastroGrupo.Controls.Add(this.txtMetaValor);
            this.pnCadastroGrupo.Controls.Add(this.btCancelar);
            this.pnCadastroGrupo.Controls.Add(this.btAdicionarGrupo);
            this.pnCadastroGrupo.Controls.Add(this.txtNomeGrupo);
            this.pnCadastroGrupo.Controls.Add(this.label3);
            this.pnCadastroGrupo.Location = new System.Drawing.Point(541, 96);
            this.pnCadastroGrupo.Name = "pnCadastroGrupo";
            this.pnCadastroGrupo.Size = new System.Drawing.Size(517, 107);
            this.pnCadastroGrupo.TabIndex = 9;
            this.pnCadastroGrupo.Visible = false;
            // 
            // txtMetaPercent
            // 
            this.txtMetaPercent.Location = new System.Drawing.Point(91, 70);
            this.txtMetaPercent.Name = "txtMetaPercent";
            this.txtMetaPercent.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMetaPercent.Size = new System.Drawing.Size(64, 20);
            this.txtMetaPercent.TabIndex = 2;
            this.txtMetaPercent.Validating += new System.ComponentModel.CancelEventHandler(this.txtMetaPercent_Validating);
            // 
            // txtMetaValor
            // 
            this.txtMetaValor.Location = new System.Drawing.Point(21, 69);
            this.txtMetaValor.Name = "txtMetaValor";
            this.txtMetaValor.Size = new System.Drawing.Size(64, 20);
            this.txtMetaValor.TabIndex = 1;
            this.txtMetaValor.Validating += new System.ComponentModel.CancelEventHandler(this.txtMetaValor_Validating);
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(241, 66);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 4;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btAdicionarGrupo
            // 
            this.btAdicionarGrupo.Location = new System.Drawing.Point(241, 28);
            this.btAdicionarGrupo.Name = "btAdicionarGrupo";
            this.btAdicionarGrupo.Size = new System.Drawing.Size(75, 23);
            this.btAdicionarGrupo.TabIndex = 3;
            this.btAdicionarGrupo.Text = "Adicionar";
            this.btAdicionarGrupo.UseVisualStyleBackColor = true;
            this.btAdicionarGrupo.Click += new System.EventHandler(this.btAdicionarGrupo_Click);
            // 
            // txtNomeGrupo
            // 
            this.txtNomeGrupo.Location = new System.Drawing.Point(21, 28);
            this.txtNomeGrupo.MaxLength = 50;
            this.txtNomeGrupo.Name = "txtNomeGrupo";
            this.txtNomeGrupo.Size = new System.Drawing.Size(212, 20);
            this.txtNomeGrupo.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nome do Grupo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(350, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Meta %";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(280, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Meta $";
            // 
            // btExcluirGrupo
            // 
            this.btExcluirGrupo.Enabled = false;
            this.btExcluirGrupo.Image = global::GUI.Properties.Resources.trash_2x;
            this.btExcluirGrupo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExcluirGrupo.Location = new System.Drawing.Point(483, 93);
            this.btExcluirGrupo.Name = "btExcluirGrupo";
            this.btExcluirGrupo.Size = new System.Drawing.Size(24, 24);
            this.btExcluirGrupo.TabIndex = 7;
            this.btExcluirGrupo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btExcluirGrupo.UseVisualStyleBackColor = true;
            this.btExcluirGrupo.Click += new System.EventHandler(this.btExcluirGrupo_Click);
            // 
            // txtmetaValor1
            // 
            this.txtmetaValor1.Enabled = false;
            this.txtmetaValor1.Location = new System.Drawing.Point(283, 95);
            this.txtmetaValor1.Name = "txtmetaValor1";
            this.txtmetaValor1.Size = new System.Drawing.Size(64, 20);
            this.txtmetaValor1.TabIndex = 2;
            this.txtmetaValor1.Validating += new System.ComponentModel.CancelEventHandler(this.txtmetaValor1_Validating);
            // 
            // txtMEtaPercentual1
            // 
            this.txtMEtaPercentual1.Enabled = false;
            this.txtMEtaPercentual1.Location = new System.Drawing.Point(353, 96);
            this.txtMEtaPercentual1.Name = "txtMEtaPercentual1";
            this.txtMEtaPercentual1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMEtaPercentual1.Size = new System.Drawing.Size(64, 20);
            this.txtMEtaPercentual1.TabIndex = 3;
            this.txtMEtaPercentual1.Validating += new System.ComponentModel.CancelEventHandler(this.txtMEtaPercentual1_Validating);
            // 
            // btEditar
            // 
            this.btEditar.Enabled = false;
            this.btEditar.Image = global::GUI.Properties.Resources.pencil_2x;
            this.btEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEditar.Location = new System.Drawing.Point(423, 93);
            this.btEditar.Name = "btEditar";
            this.btEditar.Size = new System.Drawing.Size(24, 24);
            this.btEditar.TabIndex = 7;
            this.btEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btEditar.UseVisualStyleBackColor = true;
            this.btEditar.Click += new System.EventHandler(this.btEditar_Click);
            // 
            // btSalvar
            // 
            this.btSalvar.Enabled = false;
            this.btSalvar.Image = global::GUI.Properties.Resources.circle_check_2x;
            this.btSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSalvar.Location = new System.Drawing.Point(453, 93);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(24, 24);
            this.btSalvar.TabIndex = 7;
            this.btSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btSalvar.UseVisualStyleBackColor = true;
            this.btSalvar.Click += new System.EventHandler(this.btSalvar_Click);
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(15, 94);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(262, 20);
            this.txtNome.TabIndex = 10;
            this.txtNome.Visible = false;
            // 
            // frmCadatroGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 444);
            this.Controls.Add(this.pnCadastroGrupo);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtMEtaPercentual1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btAddAdmin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtmetaValor1);
            this.Controls.Add(this.btSalvar);
            this.Controls.Add(this.btEditar);
            this.Controls.Add(this.btExcluirGrupo);
            this.Controls.Add(this.btAddConta);
            this.Controls.Add(this.txtAdmin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbAdmin);
            this.Controls.Add(this.lbGrupo);
            this.Controls.Add(this.gbConta);
            this.Controls.Add(this.cbConta);
            this.Controls.Add(this.cbGrupos);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCadatroGrupo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de grupos";
            this.Load += new System.EventHandler(this.frmCadatroGrupo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbConta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContas)).EndInit();
            this.gbAdmin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdmin)).EndInit();
            this.pnCadastroGrupo.ResumeLayout(false);
            this.pnCadastroGrupo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbUnidade;
        private System.Windows.Forms.ComboBox cbUnidade;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox gbConta;
        private System.Windows.Forms.GroupBox gbAdmin;
        private System.Windows.Forms.ComboBox cbGrupos;
        private System.Windows.Forms.Label lbGrupo;
        private System.Windows.Forms.ComboBox cbConta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAdmin;
        private System.Windows.Forms.DataGridView dgvContas;
        private System.Windows.Forms.DataGridView dgvAdmin;
        private System.Windows.Forms.Button btAddConta;
        private System.Windows.Forms.Button btAddAdmin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnCadastroGrupo;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btAdicionarGrupo;
        private System.Windows.Forms.TextBox txtNomeGrupo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btExcluirGrupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_config_custo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idconfig;
        private System.Windows.Forms.DataGridViewTextBoxColumn conta_nome;
        private System.Windows.Forms.DataGridViewImageColumn del;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_config_receita;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_admin;
        private System.Windows.Forms.DataGridViewImageColumn delete;
        private System.Windows.Forms.TextBox txtMetaPercent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMetaValor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtmetaValor1;
        private System.Windows.Forms.TextBox txtMEtaPercentual1;
        private System.Windows.Forms.Button btEditar;
        private System.Windows.Forms.Button btSalvar;
        private System.Windows.Forms.TextBox txtNome;
    }
}