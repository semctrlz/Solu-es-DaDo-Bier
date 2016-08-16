namespace GUI
{
    partial class frmPosicaoDeEstoqueFiltros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPosicaoDeEstoqueFiltros));
            this.cbUnidade = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbNomeProduto = new System.Windows.Forms.Label();
            this.numQuant = new System.Windows.Forms.NumericUpDown();
            this.lbEstoqueMin = new System.Windows.Forms.Label();
            this.lbData = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.MaskedTextBox();
            this.listGrupo = new System.Windows.Forms.ListBox();
            this.txtCodProdAdd = new System.Windows.Forms.MaskedTextBox();
            this.lbProduto = new System.Windows.Forms.Label();
            this.lbUnidade = new System.Windows.Forms.Label();
            this.cbGrupos = new System.Windows.Forms.CheckBox();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btLocalizar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuant)).BeginInit();
            this.SuspendLayout();
            // 
            // cbUnidade
            // 
            this.cbUnidade.FormattingEnabled = true;
            this.cbUnidade.Location = new System.Drawing.Point(6, 32);
            this.cbUnidade.Name = "cbUnidade";
            this.cbUnidade.Size = new System.Drawing.Size(70, 21);
            this.cbUnidade.TabIndex = 0;
            this.cbUnidade.SelectedIndexChanged += new System.EventHandler(this.cbUnidade_SelectedIndexChanged);
            this.cbUnidade.Enter += new System.EventHandler(this.cbUnidade_Enter);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbGrupos);
            this.groupBox1.Controls.Add(this.lbNomeProduto);
            this.groupBox1.Controls.Add(this.numQuant);
            this.groupBox1.Controls.Add(this.lbEstoqueMin);
            this.groupBox1.Controls.Add(this.lbData);
            this.groupBox1.Controls.Add(this.txtData);
            this.groupBox1.Controls.Add(this.listGrupo);
            this.groupBox1.Controls.Add(this.txtCodProdAdd);
            this.groupBox1.Controls.Add(this.lbProduto);
            this.groupBox1.Controls.Add(this.lbUnidade);
            this.groupBox1.Controls.Add(this.cbUnidade);
            this.groupBox1.Location = new System.Drawing.Point(12, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 157);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // lbNomeProduto
            // 
            this.lbNomeProduto.AutoSize = true;
            this.lbNomeProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNomeProduto.Location = new System.Drawing.Point(64, 135);
            this.lbNomeProduto.Name = "lbNomeProduto";
            this.lbNomeProduto.Size = new System.Drawing.Size(0, 15);
            this.lbNomeProduto.TabIndex = 32;
            // 
            // numQuant
            // 
            this.numQuant.Location = new System.Drawing.Point(6, 82);
            this.numQuant.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numQuant.Name = "numQuant";
            this.numQuant.Size = new System.Drawing.Size(71, 20);
            this.numQuant.TabIndex = 2;
            this.numQuant.ValueChanged += new System.EventHandler(this.numQuant_ValueChanged);
            this.numQuant.Enter += new System.EventHandler(this.numQuant_Enter);
            // 
            // lbEstoqueMin
            // 
            this.lbEstoqueMin.AutoSize = true;
            this.lbEstoqueMin.Location = new System.Drawing.Point(6, 66);
            this.lbEstoqueMin.Name = "lbEstoqueMin";
            this.lbEstoqueMin.Size = new System.Drawing.Size(139, 13);
            this.lbEstoqueMin.TabIndex = 31;
            this.lbEstoqueMin.Text = "Quantidade maior ou igual a";
            // 
            // lbData
            // 
            this.lbData.AutoSize = true;
            this.lbData.Location = new System.Drawing.Point(79, 15);
            this.lbData.Name = "lbData";
            this.lbData.Size = new System.Drawing.Size(30, 13);
            this.lbData.TabIndex = 29;
            this.lbData.Text = "Data";
            // 
            // txtData
            // 
            this.txtData.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert;
            this.txtData.Location = new System.Drawing.Point(82, 32);
            this.txtData.Mask = "00/00/0000";
            this.txtData.Name = "txtData";
            this.txtData.PromptChar = ' ';
            this.txtData.Size = new System.Drawing.Size(70, 20);
            this.txtData.TabIndex = 1;
            this.txtData.ValidatingType = typeof(System.DateTime);
            this.txtData.Enter += new System.EventHandler(this.txtData_Enter);
            this.txtData.Leave += new System.EventHandler(this.txtData_Leave);
            // 
            // listGrupo
            // 
            this.listGrupo.FormattingEnabled = true;
            this.listGrupo.Items.AddRange(new object[] {
            "TODOS"});
            this.listGrupo.Location = new System.Drawing.Point(164, 33);
            this.listGrupo.Name = "listGrupo";
            this.listGrupo.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listGrupo.Size = new System.Drawing.Size(120, 95);
            this.listGrupo.TabIndex = 0;
            this.listGrupo.TabStop = false;
            this.listGrupo.SelectedIndexChanged += new System.EventHandler(this.listGrupo_SelectedIndexChanged);
            // 
            // txtCodProdAdd
            // 
            this.txtCodProdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodProdAdd.Location = new System.Drawing.Point(6, 131);
            this.txtCodProdAdd.Mask = "00,0000";
            this.txtCodProdAdd.Name = "txtCodProdAdd";
            this.txtCodProdAdd.PromptChar = ' ';
            this.txtCodProdAdd.Size = new System.Drawing.Size(54, 20);
            this.txtCodProdAdd.TabIndex = 3;
            this.txtCodProdAdd.Enter += new System.EventHandler(this.txtCodProdAdd_Enter);
            this.txtCodProdAdd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodProdAdd_KeyDown);
            this.txtCodProdAdd.Leave += new System.EventHandler(this.txtCodProdAdd_Leave);
            // 
            // lbProduto
            // 
            this.lbProduto.AutoSize = true;
            this.lbProduto.Location = new System.Drawing.Point(6, 115);
            this.lbProduto.Name = "lbProduto";
            this.lbProduto.Size = new System.Drawing.Size(44, 13);
            this.lbProduto.TabIndex = 1;
            this.lbProduto.Text = "Produto";
            // 
            // lbUnidade
            // 
            this.lbUnidade.AutoSize = true;
            this.lbUnidade.Location = new System.Drawing.Point(6, 15);
            this.lbUnidade.Name = "lbUnidade";
            this.lbUnidade.Size = new System.Drawing.Size(47, 13);
            this.lbUnidade.TabIndex = 1;
            this.lbUnidade.Text = "Unidade";
            // 
            // cbGrupos
            // 
            this.cbGrupos.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbGrupos.AutoSize = true;
            this.cbGrupos.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbGrupos.Location = new System.Drawing.Point(164, 10);
            this.cbGrupos.Name = "cbGrupos";
            this.cbGrupos.Size = new System.Drawing.Size(51, 23);
            this.cbGrupos.TabIndex = 33;
            this.cbGrupos.Text = "Grupos";
            this.cbGrupos.UseVisualStyleBackColor = true;
            this.cbGrupos.CheckedChanged += new System.EventHandler(this.cbGrupos_CheckedChanged);
            // 
            // btCancelar
            // 
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.Image = global::GUI.Properties.Resources.x_2x;
            this.btCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancelar.Location = new System.Drawing.Point(231, 168);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(73, 24);
            this.btCancelar.TabIndex = 5;
            this.btCancelar.TabStop = false;
            this.btCancelar.Text = "&Cancelar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btLocalizar
            // 
            this.btLocalizar.Image = global::GUI.Properties.Resources.magnifying_glass_2x;
            this.btLocalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btLocalizar.Location = new System.Drawing.Point(152, 168);
            this.btLocalizar.Name = "btLocalizar";
            this.btLocalizar.Size = new System.Drawing.Size(73, 24);
            this.btLocalizar.TabIndex = 4;
            this.btLocalizar.TabStop = false;
            this.btLocalizar.Text = "&Localizar";
            this.btLocalizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btLocalizar.UseVisualStyleBackColor = true;
            this.btLocalizar.Click += new System.EventHandler(this.btLocalizar_Click);
            // 
            // frmPosicaoDeEstoqueFiltros
            // 
            this.AcceptButton = this.btLocalizar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancelar;
            this.ClientSize = new System.Drawing.Size(317, 205);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btLocalizar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPosicaoDeEstoqueFiltros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Posição de estoque";
            this.Load += new System.EventHandler(this.frmPosicaoDeEstoqueFiltros_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuant)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbUnidade;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbUnidade;
        private System.Windows.Forms.MaskedTextBox txtCodProdAdd;
        private System.Windows.Forms.Label lbProduto;
        private System.Windows.Forms.ListBox listGrupo;
        private System.Windows.Forms.Label lbData;
        private System.Windows.Forms.MaskedTextBox txtData;
        private System.Windows.Forms.Label lbEstoqueMin;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btLocalizar;
        private System.Windows.Forms.NumericUpDown numQuant;
        private System.Windows.Forms.Label lbNomeProduto;
        private System.Windows.Forms.CheckBox cbGrupos;
    }
}