namespace GUI
{
    partial class frmConsultaInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaInventario));
            this.pnFiltros = new System.Windows.Forms.Panel();
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.lbA = new System.Windows.Forms.Label();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btLocalizar = new System.Windows.Forms.Button();
            this.lbDe = new System.Windows.Forms.Label();
            this.txtDataDe = new System.Windows.Forms.MaskedTextBox();
            this.cbAbertos = new System.Windows.Forms.CheckBox();
            this.txtDataA = new System.Windows.Forms.MaskedTextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.cbUnidade = new System.Windows.Forms.ComboBox();
            this.lbInventario = new System.Windows.Forms.Label();
            this.lbUnidade = new System.Windows.Forms.Label();
            this.pnDados = new System.Windows.Forms.Panel();
            this.dgvInventario = new System.Windows.Forms.DataGridView();
            this.aberto = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.inventario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_inventario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itens_inv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnFiltros.SuspendLayout();
            this.gbFiltros.SuspendLayout();
            this.pnDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
            this.SuspendLayout();
            // 
            // pnFiltros
            // 
            this.pnFiltros.Controls.Add(this.gbFiltros);
            this.pnFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnFiltros.Location = new System.Drawing.Point(0, 0);
            this.pnFiltros.Name = "pnFiltros";
            this.pnFiltros.Size = new System.Drawing.Size(379, 139);
            this.pnFiltros.TabIndex = 2;
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.lbA);
            this.gbFiltros.Controls.Add(this.btCancelar);
            this.gbFiltros.Controls.Add(this.btLocalizar);
            this.gbFiltros.Controls.Add(this.lbDe);
            this.gbFiltros.Controls.Add(this.txtDataDe);
            this.gbFiltros.Controls.Add(this.cbAbertos);
            this.gbFiltros.Controls.Add(this.txtDataA);
            this.gbFiltros.Controls.Add(this.txtNumero);
            this.gbFiltros.Controls.Add(this.cbUnidade);
            this.gbFiltros.Controls.Add(this.lbInventario);
            this.gbFiltros.Controls.Add(this.lbUnidade);
            this.gbFiltros.Location = new System.Drawing.Point(13, 13);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(354, 117);
            this.gbFiltros.TabIndex = 1;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtros";
            // 
            // lbA
            // 
            this.lbA.AutoSize = true;
            this.lbA.Location = new System.Drawing.Point(159, 62);
            this.lbA.Name = "lbA";
            this.lbA.Size = new System.Drawing.Size(14, 13);
            this.lbA.TabIndex = 31;
            this.lbA.Text = "A";
            // 
            // btCancelar
            // 
            this.btCancelar.Image = global::GUI.Properties.Resources.x_2x;
            this.btCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancelar.Location = new System.Drawing.Point(273, 76);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 24);
            this.btCancelar.TabIndex = 6;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btLocalizar
            // 
            this.btLocalizar.Image = global::GUI.Properties.Resources.magnifying_glass_2x;
            this.btLocalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btLocalizar.Location = new System.Drawing.Point(273, 46);
            this.btLocalizar.Name = "btLocalizar";
            this.btLocalizar.Size = new System.Drawing.Size(75, 24);
            this.btLocalizar.TabIndex = 5;
            this.btLocalizar.Text = "Localizar";
            this.btLocalizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btLocalizar.UseVisualStyleBackColor = true;
            this.btLocalizar.Click += new System.EventHandler(this.btLocalizar_Click);
            // 
            // lbDe
            // 
            this.lbDe.AutoSize = true;
            this.lbDe.Location = new System.Drawing.Point(6, 62);
            this.lbDe.Name = "lbDe";
            this.lbDe.Size = new System.Drawing.Size(71, 13);
            this.lbDe.TabIndex = 30;
            this.lbDe.Text = "Inventário De";
            // 
            // txtDataDe
            // 
            this.txtDataDe.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert;
            this.txtDataDe.Location = new System.Drawing.Point(83, 59);
            this.txtDataDe.Mask = "00/00/0000";
            this.txtDataDe.Name = "txtDataDe";
            this.txtDataDe.PromptChar = ' ';
            this.txtDataDe.Size = new System.Drawing.Size(70, 20);
            this.txtDataDe.TabIndex = 2;
            this.txtDataDe.ValidatingType = typeof(System.DateTime);
            this.txtDataDe.Leave += new System.EventHandler(this.txtDataDe_Leave);
            // 
            // cbAbertos
            // 
            this.cbAbertos.AutoSize = true;
            this.cbAbertos.Location = new System.Drawing.Point(9, 94);
            this.cbAbertos.Name = "cbAbertos";
            this.cbAbertos.Size = new System.Drawing.Size(206, 17);
            this.cbAbertos.TabIndex = 4;
            this.cbAbertos.Text = "Considerar apenas inventários abertos";
            this.cbAbertos.UseVisualStyleBackColor = true;
            // 
            // txtDataA
            // 
            this.txtDataA.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert;
            this.txtDataA.Location = new System.Drawing.Point(179, 59);
            this.txtDataA.Mask = "00/00/0000";
            this.txtDataA.Name = "txtDataA";
            this.txtDataA.PromptChar = ' ';
            this.txtDataA.Size = new System.Drawing.Size(70, 20);
            this.txtDataA.TabIndex = 3;
            this.txtDataA.ValidatingType = typeof(System.DateTime);
            this.txtDataA.Leave += new System.EventHandler(this.txtDataA_Leave);
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(192, 19);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(76, 20);
            this.txtNumero.TabIndex = 1;
            // 
            // cbUnidade
            // 
            this.cbUnidade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbUnidade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbUnidade.FormattingEnabled = true;
            this.cbUnidade.Location = new System.Drawing.Point(59, 19);
            this.cbUnidade.Name = "cbUnidade";
            this.cbUnidade.Size = new System.Drawing.Size(67, 21);
            this.cbUnidade.TabIndex = 0;
            // 
            // lbInventario
            // 
            this.lbInventario.AutoSize = true;
            this.lbInventario.Location = new System.Drawing.Point(132, 22);
            this.lbInventario.Name = "lbInventario";
            this.lbInventario.Size = new System.Drawing.Size(54, 13);
            this.lbInventario.TabIndex = 2;
            this.lbInventario.Text = "Inventário";
            // 
            // lbUnidade
            // 
            this.lbUnidade.AutoSize = true;
            this.lbUnidade.Location = new System.Drawing.Point(6, 22);
            this.lbUnidade.Name = "lbUnidade";
            this.lbUnidade.Size = new System.Drawing.Size(47, 13);
            this.lbUnidade.TabIndex = 0;
            this.lbUnidade.Text = "Unidade";
            // 
            // pnDados
            // 
            this.pnDados.Controls.Add(this.dgvInventario);
            this.pnDados.Location = new System.Drawing.Point(0, 136);
            this.pnDados.Name = "pnDados";
            this.pnDados.Size = new System.Drawing.Size(379, 419);
            this.pnDados.TabIndex = 3;
            // 
            // dgvInventario
            // 
            this.dgvInventario.AllowUserToAddRows = false;
            this.dgvInventario.AllowUserToDeleteRows = false;
            this.dgvInventario.AllowUserToResizeColumns = false;
            this.dgvInventario.AllowUserToResizeRows = false;
            this.dgvInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.aberto,
            this.inventario,
            this.data_inventario,
            this.itens_inv,
            this.usuario});
            this.dgvInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInventario.Location = new System.Drawing.Point(0, 0);
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.ReadOnly = true;
            this.dgvInventario.RowHeadersVisible = false;
            this.dgvInventario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventario.Size = new System.Drawing.Size(379, 419);
            this.dgvInventario.TabIndex = 0;
            this.dgvInventario.TabStop = false;
            this.dgvInventario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventario_CellContentClick);
            // 
            // aberto
            // 
            this.aberto.HeaderText = "Aberto";
            this.aberto.Name = "aberto";
            this.aberto.ReadOnly = true;
            this.aberto.Width = 45;
            // 
            // inventario
            // 
            this.inventario.HeaderText = "Nº Inventário";
            this.inventario.Name = "inventario";
            this.inventario.ReadOnly = true;
            this.inventario.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.inventario.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // data_inventario
            // 
            this.data_inventario.HeaderText = "Data";
            this.data_inventario.Name = "data_inventario";
            this.data_inventario.ReadOnly = true;
            this.data_inventario.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.data_inventario.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.data_inventario.Width = 88;
            // 
            // itens_inv
            // 
            this.itens_inv.HeaderText = "Quant. Itens";
            this.itens_inv.Name = "itens_inv";
            this.itens_inv.ReadOnly = true;
            this.itens_inv.Width = 68;
            // 
            // usuario
            // 
            this.usuario.HeaderText = "Usuário";
            this.usuario.Name = "usuario";
            this.usuario.ReadOnly = true;
            this.usuario.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.usuario.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.usuario.Width = 50;
            // 
            // frmConsultaInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 555);
            this.Controls.Add(this.pnFiltros);
            this.Controls.Add(this.pnDados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConsultaInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Inventários";
            this.Load += new System.EventHandler(this.frmConsultaInventario_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmConsultaInventario_KeyDown);
            this.pnFiltros.ResumeLayout(false);
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.pnDados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnFiltros;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btLocalizar;
        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.CheckBox cbAbertos;
        private System.Windows.Forms.ComboBox cbUnidade;
        private System.Windows.Forms.Label lbUnidade;
        private System.Windows.Forms.Panel pnDados;
        private System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.MaskedTextBox txtDataDe;
        private System.Windows.Forms.MaskedTextBox txtDataA;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label lbInventario;
        private System.Windows.Forms.Label lbA;
        private System.Windows.Forms.Label lbDe;
        private System.Windows.Forms.DataGridViewCheckBoxColumn aberto;
        private System.Windows.Forms.DataGridViewTextBoxColumn inventario;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_inventario;
        private System.Windows.Forms.DataGridViewTextBoxColumn itens_inv;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario;
    }
}