namespace GUI.Forms.Fichas
{
    partial class CadastroFichas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastroFichas));
            this.cbUnidade = new System.Windows.Forms.ComboBox();
            this.lbUnidade = new System.Windows.Forms.Label();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.gbImagem = new System.Windows.Forms.GroupBox();
            this.btCarregaFoto = new System.Windows.Forms.Button();
            this.btDeletaFoto = new System.Windows.Forms.Button();
            this.pbFoto = new System.Windows.Forms.PictureBox();
            this.gbIngredientes = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btAddIngrediente = new System.Windows.Forms.Button();
            this.lbCustoTotal2 = new System.Windows.Forms.Label();
            this.lbCustoKg2 = new System.Windows.Forms.Label();
            this.lbCustoPorcao2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCodItem = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvFicha = new System.Windows.Forms.DataGridView();
            this.CODIGO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.um = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.custo_unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.custo_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.del = new System.Windows.Forms.DataGridViewImageColumn();
            this.label14 = new System.Windows.Forms.Label();
            this.lbUm = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtUm = new System.Windows.Forms.TextBox();
            this.txtPreparo = new System.Windows.Forms.TextBox();
            this.txtFc = new System.Windows.Forms.TextBox();
            this.txtNomeItem = new System.Windows.Forms.TextBox();
            this.txtQuant = new System.Windows.Forms.TextBox();
            this.btNovo = new System.Windows.Forms.Button();
            this.btExcluir = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.gbFicha = new System.Windows.Forms.GroupBox();
            this.lbNome = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCodigoPrato = new System.Windows.Forms.MaskedTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSetor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.cbSubCategoria = new System.Windows.Forms.ComboBox();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.txtRendimento = new System.Windows.Forms.TextBox();
            this.btEditar = new System.Windows.Forms.Button();
            this.btLocalizar = new System.Windows.Forms.Button();
            this.btSalvar = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.gb1.SuspendLayout();
            this.gbImagem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).BeginInit();
            this.gbIngredientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFicha)).BeginInit();
            this.gbFicha.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbUnidade
            // 
            this.cbUnidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUnidade.FormattingEnabled = true;
            this.cbUnidade.Location = new System.Drawing.Point(65, 12);
            this.cbUnidade.Name = "cbUnidade";
            this.cbUnidade.Size = new System.Drawing.Size(82, 21);
            this.cbUnidade.TabIndex = 3;
            // 
            // lbUnidade
            // 
            this.lbUnidade.AutoSize = true;
            this.lbUnidade.Location = new System.Drawing.Point(12, 15);
            this.lbUnidade.Name = "lbUnidade";
            this.lbUnidade.Size = new System.Drawing.Size(47, 13);
            this.lbUnidade.TabIndex = 2;
            this.lbUnidade.Text = "Unidade";
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.gbImagem);
            this.gb1.Controls.Add(this.gbIngredientes);
            this.gb1.Controls.Add(this.btNovo);
            this.gb1.Controls.Add(this.btExcluir);
            this.gb1.Controls.Add(this.btCancelar);
            this.gb1.Controls.Add(this.gbFicha);
            this.gb1.Controls.Add(this.btEditar);
            this.gb1.Controls.Add(this.btLocalizar);
            this.gb1.Controls.Add(this.btSalvar);
            this.gb1.Location = new System.Drawing.Point(15, 39);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(1323, 656);
            this.gb1.TabIndex = 4;
            this.gb1.TabStop = false;
            // 
            // gbImagem
            // 
            this.gbImagem.Controls.Add(this.btCarregaFoto);
            this.gbImagem.Controls.Add(this.btDeletaFoto);
            this.gbImagem.Controls.Add(this.pbFoto);
            this.gbImagem.Location = new System.Drawing.Point(711, 19);
            this.gbImagem.Name = "gbImagem";
            this.gbImagem.Size = new System.Drawing.Size(606, 573);
            this.gbImagem.TabIndex = 22;
            this.gbImagem.TabStop = false;
            this.gbImagem.Text = "Imagem";
            // 
            // btCarregaFoto
            // 
            this.btCarregaFoto.Image = global::GUI.Properties.Resources.camera_slr_2x;
            this.btCarregaFoto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCarregaFoto.Location = new System.Drawing.Point(362, 44);
            this.btCarregaFoto.Name = "btCarregaFoto";
            this.btCarregaFoto.Size = new System.Drawing.Size(116, 24);
            this.btCarregaFoto.TabIndex = 20;
            this.btCarregaFoto.Text = "Carregar Imagem";
            this.btCarregaFoto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCarregaFoto.UseVisualStyleBackColor = true;
            this.btCarregaFoto.Click += new System.EventHandler(this.btCarregaFoto_Click);
            // 
            // btDeletaFoto
            // 
            this.btDeletaFoto.Image = global::GUI.Properties.Resources.fire_2x;
            this.btDeletaFoto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDeletaFoto.Location = new System.Drawing.Point(484, 44);
            this.btDeletaFoto.Name = "btDeletaFoto";
            this.btDeletaFoto.Size = new System.Drawing.Size(116, 24);
            this.btDeletaFoto.TabIndex = 21;
            this.btDeletaFoto.Text = "Deletar Imagem";
            this.btDeletaFoto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btDeletaFoto.UseVisualStyleBackColor = true;
            this.btDeletaFoto.Click += new System.EventHandler(this.btDeletaFoto_Click);
            // 
            // pbFoto
            // 
            this.pbFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbFoto.Location = new System.Drawing.Point(15, 79);
            this.pbFoto.Name = "pbFoto";
            this.pbFoto.Size = new System.Drawing.Size(585, 394);
            this.pbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFoto.TabIndex = 9;
            this.pbFoto.TabStop = false;
            // 
            // gbIngredientes
            // 
            this.gbIngredientes.Controls.Add(this.label13);
            this.gbIngredientes.Controls.Add(this.txtDescricao);
            this.gbIngredientes.Controls.Add(this.label3);
            this.gbIngredientes.Controls.Add(this.label5);
            this.gbIngredientes.Controls.Add(this.label6);
            this.gbIngredientes.Controls.Add(this.label7);
            this.gbIngredientes.Controls.Add(this.btAddIngrediente);
            this.gbIngredientes.Controls.Add(this.lbCustoTotal2);
            this.gbIngredientes.Controls.Add(this.lbCustoKg2);
            this.gbIngredientes.Controls.Add(this.lbCustoPorcao2);
            this.gbIngredientes.Controls.Add(this.label8);
            this.gbIngredientes.Controls.Add(this.txtCodItem);
            this.gbIngredientes.Controls.Add(this.label4);
            this.gbIngredientes.Controls.Add(this.dgvFicha);
            this.gbIngredientes.Controls.Add(this.label14);
            this.gbIngredientes.Controls.Add(this.lbUm);
            this.gbIngredientes.Controls.Add(this.label15);
            this.gbIngredientes.Controls.Add(this.txtUm);
            this.gbIngredientes.Controls.Add(this.txtPreparo);
            this.gbIngredientes.Controls.Add(this.txtFc);
            this.gbIngredientes.Controls.Add(this.txtNomeItem);
            this.gbIngredientes.Controls.Add(this.txtQuant);
            this.gbIngredientes.Enabled = false;
            this.gbIngredientes.Location = new System.Drawing.Point(18, 130);
            this.gbIngredientes.Name = "gbIngredientes";
            this.gbIngredientes.Size = new System.Drawing.Size(687, 496);
            this.gbIngredientes.TabIndex = 12;
            this.gbIngredientes.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 474);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(97, 13);
            this.label13.TabIndex = 17;
            this.label13.Text = "Descrição do prato";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(109, 471);
            this.txtDescricao.MaxLength = 65;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(569, 20);
            this.txtDescricao.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ingrediente*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 327);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Modo de preparo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(534, 327);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Custo Total";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(393, 327);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Custo/Kg";
            // 
            // btAddIngrediente
            // 
            this.btAddIngrediente.Enabled = false;
            this.btAddIngrediente.Image = global::GUI.Properties.Resources.arrow_circle_bottom_2x;
            this.btAddIngrediente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAddIngrediente.Location = new System.Drawing.Point(615, 28);
            this.btAddIngrediente.Name = "btAddIngrediente";
            this.btAddIngrediente.Size = new System.Drawing.Size(24, 24);
            this.btAddIngrediente.TabIndex = 11;
            this.btAddIngrediente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAddIngrediente.UseVisualStyleBackColor = true;
            this.btAddIngrediente.Click += new System.EventHandler(this.btAddIngrediente_Click);
            // 
            // lbCustoTotal2
            // 
            this.lbCustoTotal2.AutoSize = true;
            this.lbCustoTotal2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCustoTotal2.Location = new System.Drawing.Point(601, 327);
            this.lbCustoTotal2.Name = "lbCustoTotal2";
            this.lbCustoTotal2.Size = new System.Drawing.Size(32, 13);
            this.lbCustoTotal2.TabIndex = 2;
            this.lbCustoTotal2.Text = "0,00";
            // 
            // lbCustoKg2
            // 
            this.lbCustoKg2.AutoSize = true;
            this.lbCustoKg2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCustoKg2.Location = new System.Drawing.Point(451, 327);
            this.lbCustoKg2.Name = "lbCustoKg2";
            this.lbCustoKg2.Size = new System.Drawing.Size(32, 13);
            this.lbCustoKg2.TabIndex = 2;
            this.lbCustoKg2.Text = "0,00";
            // 
            // lbCustoPorcao2
            // 
            this.lbCustoPorcao2.AutoSize = true;
            this.lbCustoPorcao2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCustoPorcao2.Location = new System.Drawing.Point(302, 327);
            this.lbCustoPorcao2.Name = "lbCustoPorcao2";
            this.lbCustoPorcao2.Size = new System.Drawing.Size(32, 13);
            this.lbCustoPorcao2.TabIndex = 2;
            this.lbCustoPorcao2.Text = "0,00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(231, 327);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Custo/Porção";
            // 
            // txtCodItem
            // 
            this.txtCodItem.Location = new System.Drawing.Point(9, 32);
            this.txtCodItem.Mask = "00\\.00\\.0000";
            this.txtCodItem.Name = "txtCodItem";
            this.txtCodItem.PromptChar = ' ';
            this.txtCodItem.Size = new System.Drawing.Size(68, 20);
            this.txtCodItem.TabIndex = 6;
            this.txtCodItem.Enter += new System.EventHandler(this.txtCodItem_Enter);
            this.txtCodItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodItem_KeyDown);
            this.txtCodItem.Leave += new System.EventHandler(this.txtCodItem_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(544, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Quantidade*";
            // 
            // dgvFicha
            // 
            this.dgvFicha.AllowUserToAddRows = false;
            this.dgvFicha.AllowUserToDeleteRows = false;
            this.dgvFicha.AllowUserToResizeColumns = false;
            this.dgvFicha.AllowUserToResizeRows = false;
            this.dgvFicha.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFicha.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CODIGO,
            this.name,
            this.quant,
            this.um,
            this.fc,
            this.custo_unit,
            this.custo_total,
            this.del});
            this.dgvFicha.Location = new System.Drawing.Point(9, 58);
            this.dgvFicha.Name = "dgvFicha";
            this.dgvFicha.ReadOnly = true;
            this.dgvFicha.RowHeadersVisible = false;
            this.dgvFicha.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFicha.Size = new System.Drawing.Size(669, 260);
            this.dgvFicha.TabIndex = 3;
            this.dgvFicha.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFicha_CellClick);
            this.dgvFicha.SelectionChanged += new System.EventHandler(this.dgvFicha_SelectionChanged);
            // 
            // CODIGO
            // 
            this.CODIGO.HeaderText = "CODIGO";
            this.CODIGO.Name = "CODIGO";
            this.CODIGO.ReadOnly = true;
            this.CODIGO.Width = 70;
            // 
            // name
            // 
            this.name.HeaderText = "NOME";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 250;
            // 
            // quant
            // 
            this.quant.HeaderText = "QUANT";
            this.quant.Name = "quant";
            this.quant.ReadOnly = true;
            this.quant.Width = 60;
            // 
            // um
            // 
            this.um.HeaderText = "U.M.";
            this.um.Name = "um";
            this.um.ReadOnly = true;
            this.um.Width = 50;
            // 
            // fc
            // 
            this.fc.HeaderText = "F.C.";
            this.fc.Name = "fc";
            this.fc.ReadOnly = true;
            this.fc.Width = 50;
            // 
            // custo_unit
            // 
            this.custo_unit.HeaderText = "$ UN";
            this.custo_unit.Name = "custo_unit";
            this.custo_unit.ReadOnly = true;
            this.custo_unit.Width = 60;
            // 
            // custo_total
            // 
            this.custo_total.HeaderText = "TOTAL";
            this.custo_total.Name = "custo_total";
            this.custo_total.ReadOnly = true;
            this.custo_total.Width = 80;
            // 
            // del
            // 
            this.del.HeaderText = "";
            this.del.Image = global::GUI.Properties.Resources.trash_2x;
            this.del.Name = "del";
            this.del.ReadOnly = true;
            this.del.Width = 26;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Enabled = false;
            this.label14.Location = new System.Drawing.Point(476, 15);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "F.C.";
            // 
            // lbUm
            // 
            this.lbUm.AutoSize = true;
            this.lbUm.Enabled = false;
            this.lbUm.Location = new System.Drawing.Point(437, 15);
            this.lbUm.Name = "lbUm";
            this.lbUm.Size = new System.Drawing.Size(30, 13);
            this.lbUm.TabIndex = 2;
            this.lbUm.Text = "U.M.";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Enabled = false;
            this.label15.Location = new System.Drawing.Point(80, 15);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 13);
            this.label15.TabIndex = 2;
            this.label15.Text = "Nome";
            // 
            // txtUm
            // 
            this.txtUm.Enabled = false;
            this.txtUm.Location = new System.Drawing.Point(440, 31);
            this.txtUm.Name = "txtUm";
            this.txtUm.Size = new System.Drawing.Size(33, 20);
            this.txtUm.TabIndex = 8;
            // 
            // txtPreparo
            // 
            this.txtPreparo.Location = new System.Drawing.Point(9, 355);
            this.txtPreparo.Multiline = true;
            this.txtPreparo.Name = "txtPreparo";
            this.txtPreparo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPreparo.Size = new System.Drawing.Size(669, 107);
            this.txtPreparo.TabIndex = 12;
            // 
            // txtFc
            // 
            this.txtFc.Enabled = false;
            this.txtFc.Location = new System.Drawing.Point(479, 31);
            this.txtFc.Name = "txtFc";
            this.txtFc.Size = new System.Drawing.Size(62, 20);
            this.txtFc.TabIndex = 9;
            // 
            // txtNomeItem
            // 
            this.txtNomeItem.Enabled = false;
            this.txtNomeItem.Location = new System.Drawing.Point(83, 32);
            this.txtNomeItem.Name = "txtNomeItem";
            this.txtNomeItem.Size = new System.Drawing.Size(351, 20);
            this.txtNomeItem.TabIndex = 7;
            // 
            // txtQuant
            // 
            this.txtQuant.Location = new System.Drawing.Point(547, 31);
            this.txtQuant.Name = "txtQuant";
            this.txtQuant.Size = new System.Drawing.Size(62, 20);
            this.txtQuant.TabIndex = 10;
            this.txtQuant.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuant_KeyDown);
            this.txtQuant.Validating += new System.ComponentModel.CancelEventHandler(this.txtQuant_Validating);
            // 
            // btNovo
            // 
            this.btNovo.Enabled = false;
            this.btNovo.Image = global::GUI.Properties.Resources.plus_2x;
            this.btNovo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btNovo.Location = new System.Drawing.Point(561, 19);
            this.btNovo.Name = "btNovo";
            this.btNovo.Size = new System.Drawing.Size(24, 24);
            this.btNovo.TabIndex = 14;
            this.btNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btNovo.UseVisualStyleBackColor = true;
            this.btNovo.Click += new System.EventHandler(this.btNovo_Click);
            // 
            // btExcluir
            // 
            this.btExcluir.Enabled = false;
            this.btExcluir.Image = global::GUI.Properties.Resources.trash_2x;
            this.btExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExcluir.Location = new System.Drawing.Point(561, 79);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(24, 24);
            this.btExcluir.TabIndex = 18;
            this.btExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Image = global::GUI.Properties.Resources.x_2x;
            this.btCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancelar.Location = new System.Drawing.Point(591, 79);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(96, 24);
            this.btCancelar.TabIndex = 19;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.button2_Click);
            // 
            // gbFicha
            // 
            this.gbFicha.Controls.Add(this.lbNome);
            this.gbFicha.Controls.Add(this.label9);
            this.gbFicha.Controls.Add(this.txtCodigoPrato);
            this.gbFicha.Controls.Add(this.label16);
            this.gbFicha.Controls.Add(this.label10);
            this.gbFicha.Controls.Add(this.label11);
            this.gbFicha.Controls.Add(this.label1);
            this.gbFicha.Controls.Add(this.cbSetor);
            this.gbFicha.Controls.Add(this.label2);
            this.gbFicha.Controls.Add(this.cbCategoria);
            this.gbFicha.Controls.Add(this.txtNome);
            this.gbFicha.Controls.Add(this.cbSubCategoria);
            this.gbFicha.Controls.Add(this.txtPeso);
            this.gbFicha.Controls.Add(this.txtRendimento);
            this.gbFicha.Location = new System.Drawing.Point(18, 12);
            this.gbFicha.Name = "gbFicha";
            this.gbFicha.Size = new System.Drawing.Size(529, 112);
            this.gbFicha.TabIndex = 10;
            this.gbFicha.TabStop = false;
            this.gbFicha.Text = "Definições Ficha técnica";
            // 
            // lbNome
            // 
            this.lbNome.AutoSize = true;
            this.lbNome.Location = new System.Drawing.Point(6, 29);
            this.lbNome.Name = "lbNome";
            this.lbNome.Size = new System.Drawing.Size(67, 13);
            this.lbNome.TabIndex = 2;
            this.lbNome.Text = "Nome Prato*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(351, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Setor*";
            // 
            // txtCodigoPrato
            // 
            this.txtCodigoPrato.Enabled = false;
            this.txtCodigoPrato.Location = new System.Drawing.Point(219, 78);
            this.txtCodigoPrato.Mask = "00\\.00\\.0000";
            this.txtCodigoPrato.Name = "txtCodigoPrato";
            this.txtCodigoPrato.PromptChar = ' ';
            this.txtCodigoPrato.Size = new System.Drawing.Size(68, 20);
            this.txtCodigoPrato.TabIndex = 8;
            this.txtCodigoPrato.TabStop = false;
            this.txtCodigoPrato.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodItem_KeyDown);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(156, 81);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(57, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "Cód. Prato";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(332, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Categoria ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(312, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Subcategoria";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Peso (Kg)";
            // 
            // cbSetor
            // 
            this.cbSetor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSetor.FormattingEnabled = true;
            this.cbSetor.Location = new System.Drawing.Point(393, 28);
            this.cbSetor.Name = "cbSetor";
            this.cbSetor.Size = new System.Drawing.Size(124, 21);
            this.cbSetor.TabIndex = 3;
            this.cbSetor.SelectedIndexChanged += new System.EventHandler(this.cbSetor_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Rendimento (porções)*";
            // 
            // cbCategoria
            // 
            this.cbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Location = new System.Drawing.Point(393, 55);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(124, 21);
            this.cbCategoria.TabIndex = 4;
            this.cbCategoria.SelectedIndexChanged += new System.EventHandler(this.cbCategoria_SelectedIndexChanged);
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(79, 26);
            this.txtNome.MaxLength = 65;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(208, 20);
            this.txtNome.TabIndex = 0;
            this.txtNome.Leave += new System.EventHandler(this.txtNome_Leave);
            // 
            // cbSubCategoria
            // 
            this.cbSubCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubCategoria.FormattingEnabled = true;
            this.cbSubCategoria.Location = new System.Drawing.Point(393, 82);
            this.cbSubCategoria.Name = "cbSubCategoria";
            this.cbSubCategoria.Size = new System.Drawing.Size(124, 21);
            this.cbSubCategoria.TabIndex = 5;
            this.cbSubCategoria.SelectedIndexChanged += new System.EventHandler(this.cbSubCategoria_SelectedIndexChanged);
            // 
            // txtPeso
            // 
            this.txtPeso.Location = new System.Drawing.Point(79, 52);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(69, 20);
            this.txtPeso.TabIndex = 1;
            this.txtPeso.Validating += new System.ComponentModel.CancelEventHandler(this.txtPeso_Validating);
            // 
            // txtRendimento
            // 
            this.txtRendimento.Location = new System.Drawing.Point(79, 78);
            this.txtRendimento.Name = "txtRendimento";
            this.txtRendimento.Size = new System.Drawing.Size(69, 20);
            this.txtRendimento.TabIndex = 2;
            this.txtRendimento.Validating += new System.ComponentModel.CancelEventHandler(this.txtRendimento_Validating);
            // 
            // btEditar
            // 
            this.btEditar.Enabled = false;
            this.btEditar.Image = global::GUI.Properties.Resources.pencil_2x;
            this.btEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEditar.Location = new System.Drawing.Point(663, 49);
            this.btEditar.Name = "btEditar";
            this.btEditar.Size = new System.Drawing.Size(24, 24);
            this.btEditar.TabIndex = 17;
            this.btEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btEditar.UseVisualStyleBackColor = true;
            this.btEditar.Click += new System.EventHandler(this.btEditar_Click);
            // 
            // btLocalizar
            // 
            this.btLocalizar.Enabled = false;
            this.btLocalizar.Image = global::GUI.Properties.Resources.magnifying_glass_2x;
            this.btLocalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btLocalizar.Location = new System.Drawing.Point(591, 19);
            this.btLocalizar.Name = "btLocalizar";
            this.btLocalizar.Size = new System.Drawing.Size(96, 24);
            this.btLocalizar.TabIndex = 15;
            this.btLocalizar.Text = "Buscar";
            this.btLocalizar.UseVisualStyleBackColor = true;
            this.btLocalizar.Click += new System.EventHandler(this.btLocalizar_Click);
            // 
            // btSalvar
            // 
            this.btSalvar.Enabled = false;
            this.btSalvar.Image = global::GUI.Properties.Resources.circle_check_2x;
            this.btSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btSalvar.Location = new System.Drawing.Point(561, 49);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(96, 24);
            this.btSalvar.TabIndex = 16;
            this.btSalvar.Text = "Salvar";
            this.btSalvar.UseVisualStyleBackColor = true;
            this.btSalvar.Click += new System.EventHandler(this.btSalvar_Click);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(168, 13);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(13, 20);
            this.txtId.TabIndex = 8;
            this.txtId.TabStop = false;
            this.txtId.Visible = false;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "del";
            this.dataGridViewImageColumn1.Image = global::GUI.Properties.Resources.trash_2x;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 26;
            // 
            // CadastroFichas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 707);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.gb1);
            this.Controls.Add(this.cbUnidade);
            this.Controls.Add(this.lbUnidade);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CadastroFichas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de fichas técnicas";
            this.Load += new System.EventHandler(this.CadastroFichas_Load);
            this.gb1.ResumeLayout(false);
            this.gbImagem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).EndInit();
            this.gbIngredientes.ResumeLayout(false);
            this.gbIngredientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFicha)).EndInit();
            this.gbFicha.ResumeLayout(false);
            this.gbFicha.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbUnidade;
        private System.Windows.Forms.Label lbUnidade;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lbNome;
        private System.Windows.Forms.MaskedTextBox txtCodItem;
        private System.Windows.Forms.DataGridView dgvFicha;
        private System.Windows.Forms.TextBox txtRendimento;
        private System.Windows.Forms.TextBox txtQuant;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.TextBox txtNomeItem;
        private System.Windows.Forms.TextBox txtPreparo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btAddIngrediente;
        private System.Windows.Forms.ComboBox cbSetor;
        private System.Windows.Forms.ComboBox cbCategoria;
        private System.Windows.Forms.ComboBox cbSubCategoria;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pbFoto;
        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.Button btSalvar;
        private System.Windows.Forms.Button btEditar;
        private System.Windows.Forms.GroupBox gbFicha;
        private System.Windows.Forms.Button btLocalizar;
        private System.Windows.Forms.TextBox txtFc;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtUm;
        private System.Windows.Forms.Label lbUm;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox gbIngredientes;
        private System.Windows.Forms.Button btNovo;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.MaskedTextBox txtCodigoPrato;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODIGO;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn quant;
        private System.Windows.Forms.DataGridViewTextBoxColumn um;
        private System.Windows.Forms.DataGridViewTextBoxColumn fc;
        private System.Windows.Forms.DataGridViewTextBoxColumn custo_unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn custo_total;
        private System.Windows.Forms.DataGridViewImageColumn del;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lbCustoTotal2;
        private System.Windows.Forms.Label lbCustoKg2;
        private System.Windows.Forms.Label lbCustoPorcao2;
        private System.Windows.Forms.Button btDeletaFoto;
        private System.Windows.Forms.Button btCarregaFoto;
        private System.Windows.Forms.GroupBox gbImagem;
    }
}