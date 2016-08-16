namespace GUI
{
    partial class frmConsultaBasica_Produto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaBasica_Produto));
            this.pnFiltros = new System.Windows.Forms.Panel();
            this.btDetalhes = new System.Windows.Forms.Button();
            this.btLocalizar = new System.Windows.Forms.Button();
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.cbAtivos = new System.Windows.Forms.CheckBox();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.cbGrupo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnDados = new System.Windows.Forms.Panel();
            this.dgvProduto = new System.Windows.Forms.DataGridView();
            this.pnFiltros.SuspendLayout();
            this.gbFiltros.SuspendLayout();
            this.pnDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduto)).BeginInit();
            this.SuspendLayout();
            // 
            // pnFiltros
            // 
            this.pnFiltros.Controls.Add(this.btDetalhes);
            this.pnFiltros.Controls.Add(this.btLocalizar);
            this.pnFiltros.Controls.Add(this.gbFiltros);
            this.pnFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnFiltros.Location = new System.Drawing.Point(0, 0);
            this.pnFiltros.Name = "pnFiltros";
            this.pnFiltros.Size = new System.Drawing.Size(784, 117);
            this.pnFiltros.TabIndex = 0;
            // 
            // btDetalhes
            // 
            this.btDetalhes.Image = global::GUI.Properties.Resources.clipboard_6x;
            this.btDetalhes.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btDetalhes.Location = new System.Drawing.Point(527, 28);
            this.btDetalhes.Name = "btDetalhes";
            this.btDetalhes.Size = new System.Drawing.Size(75, 71);
            this.btDetalhes.TabIndex = 2;
            this.btDetalhes.Text = "Detalhes";
            this.btDetalhes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btDetalhes.UseVisualStyleBackColor = true;
            this.btDetalhes.Click += new System.EventHandler(this.btDetalhes_Click);
            // 
            // btLocalizar
            // 
            this.btLocalizar.Image = global::GUI.Properties.Resources.magnifying_glass_6x;
            this.btLocalizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btLocalizar.Location = new System.Drawing.Point(446, 28);
            this.btLocalizar.Name = "btLocalizar";
            this.btLocalizar.Size = new System.Drawing.Size(75, 71);
            this.btLocalizar.TabIndex = 1;
            this.btLocalizar.Text = "Localizar";
            this.btLocalizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btLocalizar.UseVisualStyleBackColor = true;
            this.btLocalizar.Click += new System.EventHandler(this.btLocalizar_Click);
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.cbAtivos);
            this.gbFiltros.Controls.Add(this.txtModelo);
            this.gbFiltros.Controls.Add(this.txtNome);
            this.gbFiltros.Controls.Add(this.txtMarca);
            this.gbFiltros.Controls.Add(this.cbGrupo);
            this.gbFiltros.Controls.Add(this.label4);
            this.gbFiltros.Controls.Add(this.label3);
            this.gbFiltros.Controls.Add(this.label2);
            this.gbFiltros.Controls.Add(this.label1);
            this.gbFiltros.Location = new System.Drawing.Point(13, 13);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(408, 100);
            this.gbFiltros.TabIndex = 0;
            this.gbFiltros.TabStop = false;
            this.gbFiltros.Text = "Filtros";
            // 
            // cbAtivos
            // 
            this.cbAtivos.AutoSize = true;
            this.cbAtivos.Location = new System.Drawing.Point(49, 76);
            this.cbAtivos.Name = "cbAtivos";
            this.cbAtivos.Size = new System.Drawing.Size(145, 17);
            this.cbAtivos.TabIndex = 8;
            this.cbAtivos.Text = "Considerar apenas ativos";
            this.cbAtivos.UseVisualStyleBackColor = true;
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(224, 49);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(111, 20);
            this.txtModelo.TabIndex = 7;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(49, 49);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(121, 20);
            this.txtNome.TabIndex = 6;
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(224, 20);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(111, 20);
            this.txtMarca.TabIndex = 5;
            // 
            // cbGrupo
            // 
            this.cbGrupo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbGrupo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbGrupo.FormattingEnabled = true;
            this.cbGrupo.Location = new System.Drawing.Point(49, 20);
            this.cbGrupo.Name = "cbGrupo";
            this.cbGrupo.Size = new System.Drawing.Size(121, 21);
            this.cbGrupo.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(176, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Modelo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Marca";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Grupo";
            // 
            // pnDados
            // 
            this.pnDados.Controls.Add(this.dgvProduto);
            this.pnDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnDados.Location = new System.Drawing.Point(0, 117);
            this.pnDados.Name = "pnDados";
            this.pnDados.Size = new System.Drawing.Size(784, 444);
            this.pnDados.TabIndex = 1;
            // 
            // dgvProduto
            // 
            this.dgvProduto.AllowUserToAddRows = false;
            this.dgvProduto.AllowUserToDeleteRows = false;
            this.dgvProduto.AllowUserToResizeColumns = false;
            this.dgvProduto.AllowUserToResizeRows = false;
            this.dgvProduto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProduto.Location = new System.Drawing.Point(0, 0);
            this.dgvProduto.Name = "dgvProduto";
            this.dgvProduto.ReadOnly = true;
            this.dgvProduto.RowHeadersVisible = false;
            this.dgvProduto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProduto.Size = new System.Drawing.Size(784, 444);
            this.dgvProduto.TabIndex = 0;
            this.dgvProduto.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduto_CellClick);
            this.dgvProduto.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduto_CellDoubleClick);
            // 
            // frmConsultaBasica_Produto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.pnDados);
            this.Controls.Add(this.pnFiltros);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(623, 428);
            this.Name = "frmConsultaBasica_Produto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de produto";
            this.Load += new System.EventHandler(this.frmConsultaBasica_Produto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmConsultaBasica_Produto_KeyDown);
            this.pnFiltros.ResumeLayout(false);
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.pnDados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnFiltros;
        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.Panel pnDados;
        private System.Windows.Forms.DataGridView dgvProduto;
        private System.Windows.Forms.Button btLocalizar;
        private System.Windows.Forms.CheckBox cbAtivos;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.ComboBox cbGrupo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btDetalhes;
    }
}