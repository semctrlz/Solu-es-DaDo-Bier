namespace GUI.Forms.Fichas
{
    partial class frmConsultaFichas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaFichas));
            this.gbFiltros = new System.Windows.Forms.GroupBox();
            this.cbUnidade = new System.Windows.Forms.ComboBox();
            this.lbUnidade = new System.Windows.Forms.Label();
            this.lbSetor = new System.Windows.Forms.Label();
            this.lbCategoria = new System.Windows.Forms.Label();
            this.lbSubCategoria = new System.Windows.Forms.Label();
            this.cbSetor = new System.Windows.Forms.ComboBox();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.cbSubCategoria = new System.Windows.Forms.ComboBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lbNome = new System.Windows.Forms.Label();
            this.bgDados = new System.Windows.Forms.GroupBox();
            this.dgvFichas = new System.Windows.Forms.DataGridView();
            this.btConsulta = new System.Windows.Forms.Button();
            this.btPdf = new System.Windows.Forms.Button();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.gbFiltros.SuspendLayout();
            this.bgDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFichas)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFiltros
            // 
            this.gbFiltros.Controls.Add(this.btPdf);
            this.gbFiltros.Controls.Add(this.cbUnidade);
            this.gbFiltros.Controls.Add(this.lbUnidade);
            this.gbFiltros.Controls.Add(this.btConsulta);
            this.gbFiltros.Controls.Add(this.lbSetor);
            this.gbFiltros.Controls.Add(this.lbCategoria);
            this.gbFiltros.Controls.Add(this.lbSubCategoria);
            this.gbFiltros.Controls.Add(this.cbSetor);
            this.gbFiltros.Controls.Add(this.cbCategoria);
            this.gbFiltros.Controls.Add(this.cbSubCategoria);
            this.gbFiltros.Controls.Add(this.txtNome);
            this.gbFiltros.Controls.Add(this.lbNome);
            this.gbFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbFiltros.Location = new System.Drawing.Point(0, 0);
            this.gbFiltros.Name = "gbFiltros";
            this.gbFiltros.Size = new System.Drawing.Size(1350, 94);
            this.gbFiltros.TabIndex = 0;
            this.gbFiltros.TabStop = false;
            // 
            // cbUnidade
            // 
            this.cbUnidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUnidade.FormattingEnabled = true;
            this.cbUnidade.Location = new System.Drawing.Point(62, 19);
            this.cbUnidade.Name = "cbUnidade";
            this.cbUnidade.Size = new System.Drawing.Size(82, 21);
            this.cbUnidade.TabIndex = 12;
            this.cbUnidade.TabStop = false;
            // 
            // lbUnidade
            // 
            this.lbUnidade.AutoSize = true;
            this.lbUnidade.Location = new System.Drawing.Point(9, 22);
            this.lbUnidade.Name = "lbUnidade";
            this.lbUnidade.Size = new System.Drawing.Size(47, 13);
            this.lbUnidade.TabIndex = 11;
            this.lbUnidade.Text = "Unidade";
            // 
            // lbSetor
            // 
            this.lbSetor.AutoSize = true;
            this.lbSetor.Location = new System.Drawing.Point(266, 71);
            this.lbSetor.Name = "lbSetor";
            this.lbSetor.Size = new System.Drawing.Size(32, 13);
            this.lbSetor.TabIndex = 4;
            this.lbSetor.Text = "Setor";
            // 
            // lbCategoria
            // 
            this.lbCategoria.AutoSize = true;
            this.lbCategoria.Location = new System.Drawing.Point(434, 71);
            this.lbCategoria.Name = "lbCategoria";
            this.lbCategoria.Size = new System.Drawing.Size(55, 13);
            this.lbCategoria.TabIndex = 5;
            this.lbCategoria.Text = "Categoria ";
            // 
            // lbSubCategoria
            // 
            this.lbSubCategoria.AutoSize = true;
            this.lbSubCategoria.Location = new System.Drawing.Point(625, 71);
            this.lbSubCategoria.Name = "lbSubCategoria";
            this.lbSubCategoria.Size = new System.Drawing.Size(70, 13);
            this.lbSubCategoria.TabIndex = 6;
            this.lbSubCategoria.Text = "Subcategoria";
            // 
            // cbSetor
            // 
            this.cbSetor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSetor.FormattingEnabled = true;
            this.cbSetor.Location = new System.Drawing.Point(304, 68);
            this.cbSetor.Name = "cbSetor";
            this.cbSetor.Size = new System.Drawing.Size(124, 21);
            this.cbSetor.TabIndex = 7;
            // 
            // cbCategoria
            // 
            this.cbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Location = new System.Drawing.Point(495, 68);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(124, 21);
            this.cbCategoria.TabIndex = 8;
            // 
            // cbSubCategoria
            // 
            this.cbSubCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubCategoria.FormattingEnabled = true;
            this.cbSubCategoria.Location = new System.Drawing.Point(701, 68);
            this.cbSubCategoria.Name = "cbSubCategoria";
            this.cbSubCategoria.Size = new System.Drawing.Size(124, 21);
            this.cbSubCategoria.TabIndex = 9;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(12, 68);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(242, 20);
            this.txtNome.TabIndex = 1;
            // 
            // lbNome
            // 
            this.lbNome.AutoSize = true;
            this.lbNome.Location = new System.Drawing.Point(9, 51);
            this.lbNome.Name = "lbNome";
            this.lbNome.Size = new System.Drawing.Size(114, 13);
            this.lbNome.TabIndex = 0;
            this.lbNome.Text = "Nome da ficha técnica";
            // 
            // bgDados
            // 
            this.bgDados.Controls.Add(this.dgvFichas);
            this.bgDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bgDados.Location = new System.Drawing.Point(0, 94);
            this.bgDados.Name = "bgDados";
            this.bgDados.Size = new System.Drawing.Size(1350, 613);
            this.bgDados.TabIndex = 1;
            this.bgDados.TabStop = false;
            // 
            // dgvFichas
            // 
            this.dgvFichas.AllowUserToAddRows = false;
            this.dgvFichas.AllowUserToDeleteRows = false;
            this.dgvFichas.AllowUserToResizeColumns = false;
            this.dgvFichas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.dgvFichas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvFichas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFichas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFichas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFichas.Location = new System.Drawing.Point(3, 16);
            this.dgvFichas.Name = "dgvFichas";
            this.dgvFichas.ReadOnly = true;
            this.dgvFichas.RowHeadersVisible = false;
            this.dgvFichas.Size = new System.Drawing.Size(1344, 594);
            this.dgvFichas.TabIndex = 0;
            this.dgvFichas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFichas_CellContentClick);
            this.dgvFichas.SelectionChanged += new System.EventHandler(this.dgvFichas_SelectionChanged);
            // 
            // btConsulta
            // 
            this.btConsulta.Image = global::GUI.Properties.Resources.magnifying_glass_2x;
            this.btConsulta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btConsulta.Location = new System.Drawing.Point(841, 66);
            this.btConsulta.Name = "btConsulta";
            this.btConsulta.Size = new System.Drawing.Size(76, 24);
            this.btConsulta.TabIndex = 10;
            this.btConsulta.Text = "Consulta";
            this.btConsulta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btConsulta.UseVisualStyleBackColor = true;
            this.btConsulta.Click += new System.EventHandler(this.btConsulta_Click);
            // 
            // btPdf
            // 
            this.btPdf.Image = global::GUI.Properties.Resources.exportPdfx48;
            this.btPdf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPdf.Location = new System.Drawing.Point(976, 36);
            this.btPdf.Name = "btPdf";
            this.btPdf.Size = new System.Drawing.Size(54, 54);
            this.btPdf.TabIndex = 13;
            this.btPdf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btPdf.UseVisualStyleBackColor = true;
            this.btPdf.Click += new System.EventHandler(this.btPdf_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::GUI.Properties.Resources.document_2x1;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 26;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = global::GUI.Properties.Resources.pencil_2x;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Width = 26;
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.HeaderText = "";
            this.dataGridViewImageColumn3.Image = global::GUI.Properties.Resources.trash_2x;
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.Width = 26;
            // 
            // frmConsultaFichas
            // 
            this.AcceptButton = this.btConsulta;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 707);
            this.Controls.Add(this.bgDados);
            this.Controls.Add(this.gbFiltros);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmConsultaFichas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de fichas técnicas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmConsultaFichas_Load);
            this.gbFiltros.ResumeLayout(false);
            this.gbFiltros.PerformLayout();
            this.bgDados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFichas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.GroupBox bgDados;
        private System.Windows.Forms.DataGridView dgvFichas;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lbNome;
        private System.Windows.Forms.Label lbSetor;
        private System.Windows.Forms.Label lbCategoria;
        private System.Windows.Forms.Label lbSubCategoria;
        private System.Windows.Forms.ComboBox cbSetor;
        private System.Windows.Forms.ComboBox cbCategoria;
        private System.Windows.Forms.ComboBox cbSubCategoria;
        private System.Windows.Forms.Button btConsulta;
        private System.Windows.Forms.ComboBox cbUnidade;
        private System.Windows.Forms.Label lbUnidade;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        private System.Windows.Forms.Button btPdf;
    }
}