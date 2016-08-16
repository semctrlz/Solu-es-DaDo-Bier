namespace GUI
{
    partial class frmEntrada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEntrada));
            this.gbNf = new System.Windows.Forms.GroupBox();
            this.lbUnidade = new System.Windows.Forms.Label();
            this.cbUnidade = new System.Windows.Forms.ComboBox();
            this.txtNf = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDataEntrada = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDataEmissao = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbForn = new System.Windows.Forms.Label();
            this.txtLancamento = new System.Windows.Forms.TextBox();
            this.txtFornecedor = new System.Windows.Forms.TextBox();
            this.gbItens = new System.Windows.Forms.GroupBox();
            this.txtProdId = new System.Windows.Forms.TextBox();
            this.lbTotalLancamento = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btAdd = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCustoTotal = new System.Windows.Forms.TextBox();
            this.txtCustoUnit = new System.Windows.Forms.TextBox();
            this.txtQuant = new System.Windows.Forms.TextBox();
            this.txtProdutoNome = new System.Windows.Forms.TextBox();
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.custo_u = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.custo_t = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_lancamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btNf = new System.Windows.Forms.Button();
            this.btProdutos = new System.Windows.Forms.Button();
            this.btLocalizar = new System.Windows.Forms.Button();
            this.btExcluir = new System.Windows.Forms.Button();
            this.btEditar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btSalvar = new System.Windows.Forms.Button();
            this.txtCodProduto = new System.Windows.Forms.MaskedTextBox();
            this.gbNf.SuspendLayout();
            this.gbItens.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.SuspendLayout();
            // 
            // gbNf
            // 
            this.gbNf.Controls.Add(this.lbUnidade);
            this.gbNf.Controls.Add(this.cbUnidade);
            this.gbNf.Controls.Add(this.txtNf);
            this.gbNf.Controls.Add(this.label6);
            this.gbNf.Controls.Add(this.label5);
            this.gbNf.Controls.Add(this.label4);
            this.gbNf.Controls.Add(this.txtDataEntrada);
            this.gbNf.Controls.Add(this.label3);
            this.gbNf.Controls.Add(this.txtDataEmissao);
            this.gbNf.Controls.Add(this.label2);
            this.gbNf.Controls.Add(this.lbForn);
            this.gbNf.Controls.Add(this.txtLancamento);
            this.gbNf.Controls.Add(this.txtFornecedor);
            this.gbNf.Location = new System.Drawing.Point(13, 13);
            this.gbNf.Name = "gbNf";
            this.gbNf.Size = new System.Drawing.Size(290, 144);
            this.gbNf.TabIndex = 0;
            this.gbNf.TabStop = false;
            this.gbNf.Text = "Dados da nota";
            // 
            // lbUnidade
            // 
            this.lbUnidade.AutoSize = true;
            this.lbUnidade.Location = new System.Drawing.Point(207, 13);
            this.lbUnidade.Name = "lbUnidade";
            this.lbUnidade.Size = new System.Drawing.Size(47, 13);
            this.lbUnidade.TabIndex = 15;
            this.lbUnidade.Text = "Unidade";
            // 
            // cbUnidade
            // 
            this.cbUnidade.FormattingEnabled = true;
            this.cbUnidade.Location = new System.Drawing.Point(210, 32);
            this.cbUnidade.Name = "cbUnidade";
            this.cbUnidade.Size = new System.Drawing.Size(69, 21);
            this.cbUnidade.TabIndex = 0;
            this.cbUnidade.TabStop = false;
            this.cbUnidade.Enter += new System.EventHandler(this.cbUnidade_Enter);
            // 
            // txtNf
            // 
            this.txtNf.Location = new System.Drawing.Point(73, 77);
            this.txtNf.MaxLength = 10;
            this.txtNf.Name = "txtNf";
            this.txtNf.Size = new System.Drawing.Size(55, 20);
            this.txtNf.TabIndex = 1;
            this.txtNf.Enter += new System.EventHandler(this.txtNf_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Fornecedor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(70, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "NF";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(207, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Entrada";
            // 
            // txtDataEntrada
            // 
            this.txtDataEntrada.Location = new System.Drawing.Point(210, 77);
            this.txtDataEntrada.Mask = "00/00/0000";
            this.txtDataEntrada.Name = "txtDataEntrada";
            this.txtDataEntrada.PromptChar = ' ';
            this.txtDataEntrada.Size = new System.Drawing.Size(70, 20);
            this.txtDataEntrada.TabIndex = 3;
            this.txtDataEntrada.ValidatingType = typeof(System.DateTime);
            this.txtDataEntrada.Enter += new System.EventHandler(this.txtDataEntrada_Enter);
            this.txtDataEntrada.Leave += new System.EventHandler(this.txtDataEntrada_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(131, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Emissão";
            // 
            // txtDataEmissao
            // 
            this.txtDataEmissao.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert;
            this.txtDataEmissao.Location = new System.Drawing.Point(134, 77);
            this.txtDataEmissao.Mask = "00/00/0000";
            this.txtDataEmissao.Name = "txtDataEmissao";
            this.txtDataEmissao.PromptChar = ' ';
            this.txtDataEmissao.Size = new System.Drawing.Size(70, 20);
            this.txtDataEmissao.TabIndex = 2;
            this.txtDataEmissao.ValidatingType = typeof(System.DateTime);
            this.txtDataEmissao.Enter += new System.EventHandler(this.txtDataEmissao_Enter);
            this.txtDataEmissao.Leave += new System.EventHandler(this.txtDataEmissao_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lançamento";
            // 
            // lbForn
            // 
            this.lbForn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbForn.Location = new System.Drawing.Point(6, 100);
            this.lbForn.Name = "lbForn";
            this.lbForn.Size = new System.Drawing.Size(274, 41);
            this.lbForn.TabIndex = 1;
            this.lbForn.Text = "Fornecedor";
            // 
            // txtLancamento
            // 
            this.txtLancamento.Enabled = false;
            this.txtLancamento.Location = new System.Drawing.Point(9, 32);
            this.txtLancamento.MaxLength = 8;
            this.txtLancamento.Name = "txtLancamento";
            this.txtLancamento.Size = new System.Drawing.Size(83, 20);
            this.txtLancamento.TabIndex = 0;
            this.txtLancamento.TabStop = false;
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.Location = new System.Drawing.Point(9, 77);
            this.txtFornecedor.MaxLength = 6;
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.Size = new System.Drawing.Size(58, 20);
            this.txtFornecedor.TabIndex = 0;
            this.txtFornecedor.Enter += new System.EventHandler(this.txtFornecedor_Enter);
            this.txtFornecedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFornecedor_KeyDown);
            this.txtFornecedor.Leave += new System.EventHandler(this.txtFornecedor_Leave);
            // 
            // gbItens
            // 
            this.gbItens.Controls.Add(this.txtCodProduto);
            this.gbItens.Controls.Add(this.txtProdId);
            this.gbItens.Controls.Add(this.lbTotalLancamento);
            this.gbItens.Controls.Add(this.label11);
            this.gbItens.Controls.Add(this.btAdd);
            this.gbItens.Controls.Add(this.label10);
            this.gbItens.Controls.Add(this.label9);
            this.gbItens.Controls.Add(this.label8);
            this.gbItens.Controls.Add(this.label7);
            this.gbItens.Controls.Add(this.txtCustoTotal);
            this.gbItens.Controls.Add(this.txtCustoUnit);
            this.gbItens.Controls.Add(this.txtQuant);
            this.gbItens.Controls.Add(this.txtProdutoNome);
            this.gbItens.Controls.Add(this.dgvProdutos);
            this.gbItens.Location = new System.Drawing.Point(13, 164);
            this.gbItens.Name = "gbItens";
            this.gbItens.Size = new System.Drawing.Size(481, 385);
            this.gbItens.TabIndex = 1;
            this.gbItens.TabStop = false;
            this.gbItens.Text = "Produtos";
            // 
            // txtProdId
            // 
            this.txtProdId.Location = new System.Drawing.Point(60, 34);
            this.txtProdId.Name = "txtProdId";
            this.txtProdId.Size = new System.Drawing.Size(20, 20);
            this.txtProdId.TabIndex = 7;
            this.txtProdId.Visible = false;
            // 
            // lbTotalLancamento
            // 
            this.lbTotalLancamento.AutoSize = true;
            this.lbTotalLancamento.Location = new System.Drawing.Point(427, 364);
            this.lbTotalLancamento.Name = "lbTotalLancamento";
            this.lbTotalLancamento.Size = new System.Drawing.Size(34, 13);
            this.lbTotalLancamento.TabIndex = 6;
            this.lbTotalLancamento.Text = "00,00";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(303, 364);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(118, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Total dos produtos: R$ ";
            // 
            // btAdd
            // 
            this.btAdd.Image = global::GUI.Properties.Resources.plus_3x;
            this.btAdd.Location = new System.Drawing.Point(449, 22);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(32, 32);
            this.btAdd.TabIndex = 5;
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(372, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Custo total";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(299, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Custo unit.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(251, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Quant.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Produto";
            // 
            // txtCustoTotal
            // 
            this.txtCustoTotal.Location = new System.Drawing.Point(375, 35);
            this.txtCustoTotal.Name = "txtCustoTotal";
            this.txtCustoTotal.Size = new System.Drawing.Size(67, 20);
            this.txtCustoTotal.TabIndex = 4;
            this.txtCustoTotal.Enter += new System.EventHandler(this.txtCustoTotal_Enter);
            this.txtCustoTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustoTotal_KeyPress);
            this.txtCustoTotal.Leave += new System.EventHandler(this.txtCustoTotal_Leave);
            // 
            // txtCustoUnit
            // 
            this.txtCustoUnit.Location = new System.Drawing.Point(302, 35);
            this.txtCustoUnit.Name = "txtCustoUnit";
            this.txtCustoUnit.Size = new System.Drawing.Size(67, 20);
            this.txtCustoUnit.TabIndex = 3;
            this.txtCustoUnit.Enter += new System.EventHandler(this.txtCustoUnit_Enter);
            this.txtCustoUnit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustoUnit_KeyPress);
            this.txtCustoUnit.Leave += new System.EventHandler(this.txtCustoUnit_Leave);
            // 
            // txtQuant
            // 
            this.txtQuant.Location = new System.Drawing.Point(254, 35);
            this.txtQuant.Name = "txtQuant";
            this.txtQuant.Size = new System.Drawing.Size(42, 20);
            this.txtQuant.TabIndex = 2;
            this.txtQuant.Enter += new System.EventHandler(this.txtQuant_Enter);
            this.txtQuant.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuant_KeyPress);
            this.txtQuant.Leave += new System.EventHandler(this.txtQuant_Leave);
            // 
            // txtProdutoNome
            // 
            this.txtProdutoNome.Location = new System.Drawing.Point(60, 35);
            this.txtProdutoNome.Name = "txtProdutoNome";
            this.txtProdutoNome.ReadOnly = true;
            this.txtProdutoNome.Size = new System.Drawing.Size(188, 20);
            this.txtProdutoNome.TabIndex = 1;
            this.txtProdutoNome.TabStop = false;
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.AllowUserToAddRows = false;
            this.dgvProdutos.AllowUserToDeleteRows = false;
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.seq,
            this.id,
            this.produto,
            this.qtd,
            this.custo_u,
            this.custo_t,
            this.id_lancamento});
            this.dgvProdutos.Location = new System.Drawing.Point(0, 61);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.ReadOnly = true;
            this.dgvProdutos.RowHeadersVisible = false;
            this.dgvProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdutos.Size = new System.Drawing.Size(481, 296);
            this.dgvProdutos.TabIndex = 0;
            this.dgvProdutos.TabStop = false;
            this.dgvProdutos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdutos_CellContentClick);
            // 
            // seq
            // 
            this.seq.HeaderText = "Seq.";
            this.seq.Name = "seq";
            this.seq.ReadOnly = true;
            this.seq.Width = 30;
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // produto
            // 
            this.produto.HeaderText = "Produto";
            this.produto.Name = "produto";
            this.produto.ReadOnly = true;
            this.produto.Width = 248;
            // 
            // qtd
            // 
            this.qtd.HeaderText = "Quant.";
            this.qtd.Name = "qtd";
            this.qtd.ReadOnly = true;
            this.qtd.Width = 50;
            // 
            // custo_u
            // 
            this.custo_u.HeaderText = "Custo Unit.";
            this.custo_u.Name = "custo_u";
            this.custo_u.ReadOnly = true;
            this.custo_u.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.custo_u.Width = 63;
            // 
            // custo_t
            // 
            this.custo_t.HeaderText = "Custo Total";
            this.custo_t.Name = "custo_t";
            this.custo_t.ReadOnly = true;
            this.custo_t.Width = 63;
            // 
            // id_lancamento
            // 
            this.id_lancamento.HeaderText = "lancamento";
            this.id_lancamento.Name = "id_lancamento";
            this.id_lancamento.ReadOnly = true;
            this.id_lancamento.Visible = false;
            // 
            // btNf
            // 
            this.btNf.Image = global::GUI.Properties.Resources.arrow_circle_top_4x;
            this.btNf.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btNf.Location = new System.Drawing.Point(309, 97);
            this.btNf.Name = "btNf";
            this.btNf.Size = new System.Drawing.Size(58, 58);
            this.btNf.TabIndex = 16;
            this.btNf.Text = "Nf";
            this.btNf.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btNf.UseVisualStyleBackColor = true;
            this.btNf.Click += new System.EventHandler(this.btNf_Click);
            // 
            // btProdutos
            // 
            this.btProdutos.Image = global::GUI.Properties.Resources.arrow_circle_bottom_4x;
            this.btProdutos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btProdutos.Location = new System.Drawing.Point(309, 97);
            this.btProdutos.Name = "btProdutos";
            this.btProdutos.Size = new System.Drawing.Size(58, 58);
            this.btProdutos.TabIndex = 4;
            this.btProdutos.Text = "Produtos";
            this.btProdutos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btProdutos.UseVisualStyleBackColor = true;
            this.btProdutos.Click += new System.EventHandler(this.btProdutos_Click);
            // 
            // btLocalizar
            // 
            this.btLocalizar.Image = global::GUI.Properties.Resources.magnifying_glass_4x;
            this.btLocalizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btLocalizar.Location = new System.Drawing.Point(309, 33);
            this.btLocalizar.Name = "btLocalizar";
            this.btLocalizar.Size = new System.Drawing.Size(58, 58);
            this.btLocalizar.TabIndex = 6;
            this.btLocalizar.TabStop = false;
            this.btLocalizar.Text = "Localizar";
            this.btLocalizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btLocalizar.UseVisualStyleBackColor = true;
            this.btLocalizar.Click += new System.EventHandler(this.btLocalizar_Click);
            // 
            // btExcluir
            // 
            this.btExcluir.Image = global::GUI.Properties.Resources.trash_4x;
            this.btExcluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btExcluir.Location = new System.Drawing.Point(373, 97);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(58, 58);
            this.btExcluir.TabIndex = 12;
            this.btExcluir.TabStop = false;
            this.btExcluir.Text = "Excluir";
            this.btExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // btEditar
            // 
            this.btEditar.Image = global::GUI.Properties.Resources.pencil_4x;
            this.btEditar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btEditar.Location = new System.Drawing.Point(373, 33);
            this.btEditar.Name = "btEditar";
            this.btEditar.Size = new System.Drawing.Size(58, 58);
            this.btEditar.TabIndex = 9;
            this.btEditar.TabStop = false;
            this.btEditar.Text = "Editar";
            this.btEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btEditar.UseVisualStyleBackColor = true;
            this.btEditar.Click += new System.EventHandler(this.btEditar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancelar.Image = global::GUI.Properties.Resources.x_4x;
            this.btCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btCancelar.Location = new System.Drawing.Point(437, 97);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(58, 58);
            this.btCancelar.TabIndex = 5;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btSalvar
            // 
            this.btSalvar.Image = global::GUI.Properties.Resources.circle_check_4x;
            this.btSalvar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btSalvar.Location = new System.Drawing.Point(437, 33);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(58, 58);
            this.btSalvar.TabIndex = 11;
            this.btSalvar.TabStop = false;
            this.btSalvar.Text = "Salvar";
            this.btSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btSalvar.UseVisualStyleBackColor = true;
            this.btSalvar.Click += new System.EventHandler(this.btSalvar_Click);
            // 
            // txtCodProduto
            // 
            this.txtCodProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodProduto.Location = new System.Drawing.Point(0, 35);
            this.txtCodProduto.Mask = "00,0000";
            this.txtCodProduto.Name = "txtCodProduto";
            this.txtCodProduto.PromptChar = ' ';
            this.txtCodProduto.Size = new System.Drawing.Size(54, 20);
            this.txtCodProduto.TabIndex = 0;
            this.txtCodProduto.Enter += new System.EventHandler(this.txtCodProduto_Enter);
            this.txtCodProduto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodProduto_KeyDown);
            this.txtCodProduto.Leave += new System.EventHandler(this.txtCodProduto_Leave);
            // 
            // frmEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 561);
            this.Controls.Add(this.btNf);
            this.Controls.Add(this.gbItens);
            this.Controls.Add(this.gbNf);
            this.Controls.Add(this.btProdutos);
            this.Controls.Add(this.btSalvar);
            this.Controls.Add(this.btLocalizar);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btExcluir);
            this.Controls.Add(this.btEditar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEntrada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lançamento";
            this.Load += new System.EventHandler(this.frmEntrada_Load);
            this.gbNf.ResumeLayout(false);
            this.gbNf.PerformLayout();
            this.gbItens.ResumeLayout(false);
            this.gbItens.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbNf;
        private System.Windows.Forms.TextBox txtNf;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtDataEntrada;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtDataEmissao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbForn;
        private System.Windows.Forms.TextBox txtLancamento;
        private System.Windows.Forms.TextBox txtFornecedor;
        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.Button btEditar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btSalvar;
        private System.Windows.Forms.GroupBox gbItens;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCustoTotal;
        private System.Windows.Forms.TextBox txtCustoUnit;
        private System.Windows.Forms.TextBox txtQuant;
        private System.Windows.Forms.TextBox txtProdutoNome;
        private System.Windows.Forms.DataGridView dgvProdutos;
        private System.Windows.Forms.Label lbTotalLancamento;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btProdutos;
        private System.Windows.Forms.Button btLocalizar;
        private System.Windows.Forms.TextBox txtProdId;
        private System.Windows.Forms.Label lbUnidade;
        private System.Windows.Forms.ComboBox cbUnidade;
        private System.Windows.Forms.Button btNf;
        private System.Windows.Forms.DataGridViewTextBoxColumn seq;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtd;
        private System.Windows.Forms.DataGridViewTextBoxColumn custo_u;
        private System.Windows.Forms.DataGridViewTextBoxColumn custo_t;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_lancamento;
        private System.Windows.Forms.MaskedTextBox txtCodProduto;
    }
}