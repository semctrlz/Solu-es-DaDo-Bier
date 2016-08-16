namespace GUI
{
    partial class frmInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventario));
            this.dgvInventario = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod_produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nome_produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marca_produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelo_produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contagem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbDataInventario = new System.Windows.Forms.Label();
            this.txtDataInventario = new System.Windows.Forms.MaskedTextBox();
            this.txtDataMovimento = new System.Windows.Forms.MaskedTextBox();
            this.lbDataMovimento = new System.Windows.Forms.Label();
            this.lbUnidade = new System.Windows.Forms.Label();
            this.cbUnidade = new System.Windows.Forms.ComboBox();
            this.gbDadosInventario = new System.Windows.Forms.GroupBox();
            this.txtAberto = new System.Windows.Forms.TextBox();
            this.lbGrupo = new System.Windows.Forms.ListBox();
            this.lbTipoInv = new System.Windows.Forms.Label();
            this.lbItens = new System.Windows.Forms.Label();
            this.cbTipoInv = new System.Windows.Forms.ComboBox();
            this.cbItensAContar = new System.Windows.Forms.ComboBox();
            this.txtNumeroInventario = new System.Windows.Forms.TextBox();
            this.lbInventario = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.pnDados = new System.Windows.Forms.Panel();
            this.btAdd = new System.Windows.Forms.Button();
            this.txtQuantProdutoAdd = new System.Windows.Forms.TextBox();
            this.txtModeloProdutoAdd = new System.Windows.Forms.TextBox();
            this.txtMarcaProdutoAdd = new System.Windows.Forms.TextBox();
            this.txtNomeProdutoAdd = new System.Windows.Forms.TextBox();
            this.txtCodProdAdd = new System.Windows.Forms.MaskedTextBox();
            this.btRodar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btImprimir = new System.Windows.Forms.Button();
            this.btSalvar = new System.Windows.Forms.Button();
            this.btEditar = new System.Windows.Forms.Button();
            this.btLocalizar = new System.Windows.Forms.Button();
            this.btGerar = new System.Windows.Forms.Button();
            this.btExcluir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
            this.gbDadosInventario.SuspendLayout();
            this.pnDados.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvInventario
            // 
            this.dgvInventario.AllowUserToAddRows = false;
            this.dgvInventario.AllowUserToDeleteRows = false;
            this.dgvInventario.AllowUserToResizeColumns = false;
            this.dgvInventario.AllowUserToResizeRows = false;
            this.dgvInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.cod_produto,
            this.nome_produto,
            this.marca_produto,
            this.modelo_produto,
            this.contagem});
            this.dgvInventario.Location = new System.Drawing.Point(0, 29);
            this.dgvInventario.MultiSelect = false;
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.RowHeadersVisible = false;
            this.dgvInventario.Size = new System.Drawing.Size(605, 375);
            this.dgvInventario.TabIndex = 0;
            this.dgvInventario.TabStop = false;
            this.dgvInventario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventario_CellContentClick);
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // cod_produto
            // 
            this.cod_produto.HeaderText = "Código";
            this.cod_produto.Name = "cod_produto";
            this.cod_produto.ReadOnly = true;
            this.cod_produto.Width = 50;
            // 
            // nome_produto
            // 
            this.nome_produto.HeaderText = "Produto";
            this.nome_produto.Name = "nome_produto";
            this.nome_produto.ReadOnly = true;
            this.nome_produto.Width = 150;
            // 
            // marca_produto
            // 
            this.marca_produto.HeaderText = "Marca";
            this.marca_produto.Name = "marca_produto";
            this.marca_produto.ReadOnly = true;
            this.marca_produto.Width = 134;
            // 
            // modelo_produto
            // 
            this.modelo_produto.HeaderText = "Modelo";
            this.modelo_produto.Name = "modelo_produto";
            this.modelo_produto.ReadOnly = true;
            this.modelo_produto.Width = 150;
            // 
            // contagem
            // 
            this.contagem.HeaderText = "Contagem";
            this.contagem.Name = "contagem";
            this.contagem.Width = 76;
            // 
            // lbDataInventario
            // 
            this.lbDataInventario.AutoSize = true;
            this.lbDataInventario.Location = new System.Drawing.Point(176, 16);
            this.lbDataInventario.Name = "lbDataInventario";
            this.lbDataInventario.Size = new System.Drawing.Size(80, 13);
            this.lbDataInventario.TabIndex = 8;
            this.lbDataInventario.Text = "Data Inventário";
            // 
            // txtDataInventario
            // 
            this.txtDataInventario.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert;
            this.txtDataInventario.Location = new System.Drawing.Point(179, 32);
            this.txtDataInventario.Mask = "00/00/0000";
            this.txtDataInventario.Name = "txtDataInventario";
            this.txtDataInventario.PromptChar = ' ';
            this.txtDataInventario.Size = new System.Drawing.Size(70, 20);
            this.txtDataInventario.TabIndex = 9;
            this.txtDataInventario.ValidatingType = typeof(System.DateTime);
            this.txtDataInventario.Enter += new System.EventHandler(this.txtDataInventario_Enter);
            this.txtDataInventario.Leave += new System.EventHandler(this.txtDataInventario_Leave);
            // 
            // txtDataMovimento
            // 
            this.txtDataMovimento.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert;
            this.txtDataMovimento.Location = new System.Drawing.Point(255, 32);
            this.txtDataMovimento.Mask = "00/00/0000";
            this.txtDataMovimento.Name = "txtDataMovimento";
            this.txtDataMovimento.PromptChar = ' ';
            this.txtDataMovimento.Size = new System.Drawing.Size(78, 20);
            this.txtDataMovimento.TabIndex = 11;
            this.txtDataMovimento.ValidatingType = typeof(System.DateTime);
            this.txtDataMovimento.Enter += new System.EventHandler(this.txtDataMovimento_Enter);
            this.txtDataMovimento.Leave += new System.EventHandler(this.txtDataMovimento_Leave);
            // 
            // lbDataMovimento
            // 
            this.lbDataMovimento.AutoSize = true;
            this.lbDataMovimento.Location = new System.Drawing.Point(256, 13);
            this.lbDataMovimento.Name = "lbDataMovimento";
            this.lbDataMovimento.Size = new System.Drawing.Size(84, 13);
            this.lbDataMovimento.TabIndex = 10;
            this.lbDataMovimento.Text = "Data movimento";
            // 
            // lbUnidade
            // 
            this.lbUnidade.AutoSize = true;
            this.lbUnidade.Location = new System.Drawing.Point(101, 16);
            this.lbUnidade.Name = "lbUnidade";
            this.lbUnidade.Size = new System.Drawing.Size(47, 13);
            this.lbUnidade.TabIndex = 17;
            this.lbUnidade.Text = "Unidade";
            // 
            // cbUnidade
            // 
            this.cbUnidade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbUnidade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbUnidade.FormattingEnabled = true;
            this.cbUnidade.Location = new System.Drawing.Point(104, 32);
            this.cbUnidade.Name = "cbUnidade";
            this.cbUnidade.Size = new System.Drawing.Size(69, 21);
            this.cbUnidade.TabIndex = 16;
            this.cbUnidade.TabStop = false;
            this.cbUnidade.Leave += new System.EventHandler(this.cbUnidade_Leave);
            // 
            // gbDadosInventario
            // 
            this.gbDadosInventario.Controls.Add(this.txtAberto);
            this.gbDadosInventario.Controls.Add(this.lbGrupo);
            this.gbDadosInventario.Controls.Add(this.lbTipoInv);
            this.gbDadosInventario.Controls.Add(this.lbItens);
            this.gbDadosInventario.Controls.Add(this.cbTipoInv);
            this.gbDadosInventario.Controls.Add(this.cbItensAContar);
            this.gbDadosInventario.Controls.Add(this.txtNumeroInventario);
            this.gbDadosInventario.Controls.Add(this.lbInventario);
            this.gbDadosInventario.Controls.Add(this.lbUnidade);
            this.gbDadosInventario.Controls.Add(this.lbDataInventario);
            this.gbDadosInventario.Controls.Add(this.txtDataInventario);
            this.gbDadosInventario.Controls.Add(this.cbUnidade);
            this.gbDadosInventario.Controls.Add(this.lbDataMovimento);
            this.gbDadosInventario.Controls.Add(this.txtDataMovimento);
            this.gbDadosInventario.Location = new System.Drawing.Point(12, 423);
            this.gbDadosInventario.Name = "gbDadosInventario";
            this.gbDadosInventario.Size = new System.Drawing.Size(350, 144);
            this.gbDadosInventario.TabIndex = 19;
            this.gbDadosInventario.TabStop = false;
            this.gbDadosInventario.Text = "Parâmentros";
            // 
            // txtAberto
            // 
            this.txtAberto.Location = new System.Drawing.Point(5, 104);
            this.txtAberto.MaxLength = 1;
            this.txtAberto.Name = "txtAberto";
            this.txtAberto.Size = new System.Drawing.Size(99, 20);
            this.txtAberto.TabIndex = 28;
            this.txtAberto.Visible = false;
            // 
            // lbGrupo
            // 
            this.lbGrupo.FormattingEnabled = true;
            this.lbGrupo.Items.AddRange(new object[] {
            "TODOS"});
            this.lbGrupo.Location = new System.Drawing.Point(213, 58);
            this.lbGrupo.Name = "lbGrupo";
            this.lbGrupo.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbGrupo.Size = new System.Drawing.Size(120, 82);
            this.lbGrupo.TabIndex = 27;
            // 
            // lbTipoInv
            // 
            this.lbTipoInv.AutoSize = true;
            this.lbTipoInv.Location = new System.Drawing.Point(113, 58);
            this.lbTipoInv.Name = "lbTipoInv";
            this.lbTipoInv.Size = new System.Drawing.Size(92, 13);
            this.lbTipoInv.TabIndex = 25;
            this.lbTipoInv.Text = "Tipo de inventário";
            // 
            // lbItens
            // 
            this.lbItens.AutoSize = true;
            this.lbItens.Location = new System.Drawing.Point(6, 58);
            this.lbItens.Name = "lbItens";
            this.lbItens.Size = new System.Drawing.Size(72, 13);
            this.lbItens.TabIndex = 25;
            this.lbItens.Text = "Itens a contar";
            // 
            // cbTipoInv
            // 
            this.cbTipoInv.FormattingEnabled = true;
            this.cbTipoInv.Items.AddRange(new object[] {
            "Inventário",
            "Estoque Inicial"});
            this.cbTipoInv.Location = new System.Drawing.Point(112, 77);
            this.cbTipoInv.Name = "cbTipoInv";
            this.cbTipoInv.Size = new System.Drawing.Size(95, 21);
            this.cbTipoInv.TabIndex = 23;
            this.cbTipoInv.Leave += new System.EventHandler(this.cbTipoInv_Leave);
            // 
            // cbItensAContar
            // 
            this.cbItensAContar.FormattingEnabled = true;
            this.cbItensAContar.Items.AddRange(new object[] {
            "Total",
            "Somente Mix"});
            this.cbItensAContar.Location = new System.Drawing.Point(5, 77);
            this.cbItensAContar.Name = "cbItensAContar";
            this.cbItensAContar.Size = new System.Drawing.Size(99, 21);
            this.cbItensAContar.TabIndex = 23;
            // 
            // txtNumeroInventario
            // 
            this.txtNumeroInventario.Enabled = false;
            this.txtNumeroInventario.Location = new System.Drawing.Point(6, 32);
            this.txtNumeroInventario.Name = "txtNumeroInventario";
            this.txtNumeroInventario.Size = new System.Drawing.Size(92, 20);
            this.txtNumeroInventario.TabIndex = 22;
            // 
            // lbInventario
            // 
            this.lbInventario.AutoSize = true;
            this.lbInventario.Location = new System.Drawing.Point(6, 16);
            this.lbInventario.Name = "lbInventario";
            this.lbInventario.Size = new System.Drawing.Size(92, 13);
            this.lbInventario.TabIndex = 21;
            this.lbInventario.Text = "Inventário número";
            // 
            // printDocument1
            // 
            this.printDocument1.DocumentName = "Relatorio de inventário";
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage_1);
            // 
            // pnDados
            // 
            this.pnDados.Controls.Add(this.btAdd);
            this.pnDados.Controls.Add(this.txtQuantProdutoAdd);
            this.pnDados.Controls.Add(this.txtModeloProdutoAdd);
            this.pnDados.Controls.Add(this.txtMarcaProdutoAdd);
            this.pnDados.Controls.Add(this.txtNomeProdutoAdd);
            this.pnDados.Controls.Add(this.txtCodProdAdd);
            this.pnDados.Controls.Add(this.dgvInventario);
            this.pnDados.Location = new System.Drawing.Point(13, 13);
            this.pnDados.Name = "pnDados";
            this.pnDados.Size = new System.Drawing.Size(605, 404);
            this.pnDados.TabIndex = 21;
            // 
            // btAdd
            // 
            this.btAdd.Image = global::GUI.Properties.Resources.plus_2x;
            this.btAdd.Location = new System.Drawing.Point(572, 4);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(24, 24);
            this.btAdd.TabIndex = 5;
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // txtQuantProdutoAdd
            // 
            this.txtQuantProdutoAdd.Location = new System.Drawing.Point(485, 5);
            this.txtQuantProdutoAdd.Name = "txtQuantProdutoAdd";
            this.txtQuantProdutoAdd.Size = new System.Drawing.Size(78, 20);
            this.txtQuantProdutoAdd.TabIndex = 4;
            // 
            // txtModeloProdutoAdd
            // 
            this.txtModeloProdutoAdd.Enabled = false;
            this.txtModeloProdutoAdd.Location = new System.Drawing.Point(336, 5);
            this.txtModeloProdutoAdd.Name = "txtModeloProdutoAdd";
            this.txtModeloProdutoAdd.Size = new System.Drawing.Size(150, 20);
            this.txtModeloProdutoAdd.TabIndex = 3;
            // 
            // txtMarcaProdutoAdd
            // 
            this.txtMarcaProdutoAdd.Enabled = false;
            this.txtMarcaProdutoAdd.Location = new System.Drawing.Point(202, 5);
            this.txtMarcaProdutoAdd.Name = "txtMarcaProdutoAdd";
            this.txtMarcaProdutoAdd.Size = new System.Drawing.Size(135, 20);
            this.txtMarcaProdutoAdd.TabIndex = 2;
            // 
            // txtNomeProdutoAdd
            // 
            this.txtNomeProdutoAdd.Enabled = false;
            this.txtNomeProdutoAdd.Location = new System.Drawing.Point(53, 5);
            this.txtNomeProdutoAdd.Name = "txtNomeProdutoAdd";
            this.txtNomeProdutoAdd.Size = new System.Drawing.Size(150, 20);
            this.txtNomeProdutoAdd.TabIndex = 1;
            // 
            // txtCodProdAdd
            // 
            this.txtCodProdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodProdAdd.Location = new System.Drawing.Point(0, 5);
            this.txtCodProdAdd.Mask = "00,0000";
            this.txtCodProdAdd.Name = "txtCodProdAdd";
            this.txtCodProdAdd.PromptChar = ' ';
            this.txtCodProdAdd.Size = new System.Drawing.Size(54, 20);
            this.txtCodProdAdd.TabIndex = 0;
            this.txtCodProdAdd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodProdAdd_KeyDown);
            this.txtCodProdAdd.Leave += new System.EventHandler(this.txtCodProdAdd_Leave);
            // 
            // btRodar
            // 
            this.btRodar.Image = global::GUI.Properties.Resources.loop_circular_4x;
            this.btRodar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btRodar.Location = new System.Drawing.Point(496, 436);
            this.btRodar.Name = "btRodar";
            this.btRodar.Size = new System.Drawing.Size(58, 58);
            this.btRodar.TabIndex = 20;
            this.btRodar.TabStop = false;
            this.btRodar.Text = "&Rodar";
            this.btRodar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btRodar.UseVisualStyleBackColor = true;
            this.btRodar.Click += new System.EventHandler(this.btRodar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Image = global::GUI.Properties.Resources.x_4x;
            this.btCancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btCancelar.Location = new System.Drawing.Point(560, 500);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(58, 58);
            this.btCancelar.TabIndex = 7;
            this.btCancelar.TabStop = false;
            this.btCancelar.Text = "&Cancelar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btImprimir
            // 
            this.btImprimir.Image = global::GUI.Properties.Resources.print_4x;
            this.btImprimir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btImprimir.Location = new System.Drawing.Point(560, 436);
            this.btImprimir.Name = "btImprimir";
            this.btImprimir.Size = new System.Drawing.Size(58, 58);
            this.btImprimir.TabIndex = 7;
            this.btImprimir.TabStop = false;
            this.btImprimir.Text = "&Imprimir";
            this.btImprimir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btImprimir.UseVisualStyleBackColor = true;
            this.btImprimir.Click += new System.EventHandler(this.btImprimir_Click);
            // 
            // btSalvar
            // 
            this.btSalvar.Image = global::GUI.Properties.Resources.circle_check_4x;
            this.btSalvar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btSalvar.Location = new System.Drawing.Point(432, 436);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(58, 58);
            this.btSalvar.TabIndex = 20;
            this.btSalvar.TabStop = false;
            this.btSalvar.Text = "&Salvar";
            this.btSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btSalvar.UseVisualStyleBackColor = true;
            this.btSalvar.Click += new System.EventHandler(this.btSalvar_Click);
            // 
            // btEditar
            // 
            this.btEditar.Image = global::GUI.Properties.Resources.pencil_4x;
            this.btEditar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btEditar.Location = new System.Drawing.Point(432, 500);
            this.btEditar.Name = "btEditar";
            this.btEditar.Size = new System.Drawing.Size(58, 58);
            this.btEditar.TabIndex = 20;
            this.btEditar.TabStop = false;
            this.btEditar.Text = "E&ditar";
            this.btEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btEditar.UseVisualStyleBackColor = true;
            this.btEditar.Click += new System.EventHandler(this.btEditar_Click);
            // 
            // btLocalizar
            // 
            this.btLocalizar.Image = global::GUI.Properties.Resources.magnifying_glass_4x;
            this.btLocalizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btLocalizar.Location = new System.Drawing.Point(368, 500);
            this.btLocalizar.Name = "btLocalizar";
            this.btLocalizar.Size = new System.Drawing.Size(58, 58);
            this.btLocalizar.TabIndex = 20;
            this.btLocalizar.TabStop = false;
            this.btLocalizar.Text = "&Localizar";
            this.btLocalizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btLocalizar.UseVisualStyleBackColor = true;
            this.btLocalizar.Click += new System.EventHandler(this.btLocalizar_Click);
            // 
            // btGerar
            // 
            this.btGerar.Image = global::GUI.Properties.Resources.media_play_4x;
            this.btGerar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btGerar.Location = new System.Drawing.Point(368, 436);
            this.btGerar.Name = "btGerar";
            this.btGerar.Size = new System.Drawing.Size(58, 58);
            this.btGerar.TabIndex = 20;
            this.btGerar.TabStop = false;
            this.btGerar.Text = "&Gerar";
            this.btGerar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btGerar.UseVisualStyleBackColor = true;
            this.btGerar.Click += new System.EventHandler(this.btGerar_Click);
            // 
            // btExcluir
            // 
            this.btExcluir.Image = global::GUI.Properties.Resources.trash_4x;
            this.btExcluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btExcluir.Location = new System.Drawing.Point(496, 500);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(58, 58);
            this.btExcluir.TabIndex = 20;
            this.btExcluir.TabStop = false;
            this.btExcluir.Text = "&Excluir";
            this.btExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // frmInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 571);
            this.Controls.Add(this.pnDados);
            this.Controls.Add(this.gbDadosInventario);
            this.Controls.Add(this.btRodar);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btImprimir);
            this.Controls.Add(this.btSalvar);
            this.Controls.Add(this.btEditar);
            this.Controls.Add(this.btLocalizar);
            this.Controls.Add(this.btGerar);
            this.Controls.Add(this.btExcluir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventário";
            this.Load += new System.EventHandler(this.frmInventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            this.gbDadosInventario.ResumeLayout(false);
            this.gbDadosInventario.PerformLayout();
            this.pnDados.ResumeLayout(false);
            this.pnDados.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.Button btImprimir;
        private System.Windows.Forms.Label lbDataInventario;
        private System.Windows.Forms.MaskedTextBox txtDataInventario;
        private System.Windows.Forms.MaskedTextBox txtDataMovimento;
        private System.Windows.Forms.Label lbDataMovimento;
        private System.Windows.Forms.Label lbUnidade;
        private System.Windows.Forms.ComboBox cbUnidade;
        private System.Windows.Forms.GroupBox gbDadosInventario;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.TextBox txtNumeroInventario;
        private System.Windows.Forms.Label lbInventario;
        private System.Windows.Forms.Button btLocalizar;
        private System.Windows.Forms.Button btSalvar;
        private System.Windows.Forms.Button btRodar;
        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.Label lbItens;
        private System.Windows.Forms.ComboBox cbItensAContar;
        private System.Windows.Forms.ListBox lbGrupo;
        private System.Windows.Forms.Button btGerar;
        private System.Windows.Forms.Label lbTipoInv;
        private System.Windows.Forms.ComboBox cbTipoInv;
        private System.Windows.Forms.Button btEditar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.TextBox txtAberto;
        private System.Windows.Forms.Panel pnDados;
        private System.Windows.Forms.MaskedTextBox txtCodProdAdd;
        private System.Windows.Forms.TextBox txtQuantProdutoAdd;
        private System.Windows.Forms.TextBox txtModeloProdutoAdd;
        private System.Windows.Forms.TextBox txtMarcaProdutoAdd;
        private System.Windows.Forms.TextBox txtNomeProdutoAdd;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nome_produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn marca_produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelo_produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn contagem;
    }
}