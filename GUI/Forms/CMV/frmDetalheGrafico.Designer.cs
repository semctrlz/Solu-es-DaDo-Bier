namespace GUI.Forms.CMV
{
    partial class frmDetalheGrafico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetalheGrafico));
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDetalhe = new System.Windows.Forms.DataGridView();
            this.lbReceitaePax = new System.Windows.Forms.Label();
            this.tit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.custo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detalhes = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalhe)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(586, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Titulo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvDetalhe
            // 
            this.dgvDetalhe.AllowUserToAddRows = false;
            this.dgvDetalhe.AllowUserToDeleteRows = false;
            this.dgvDetalhe.AllowUserToResizeColumns = false;
            this.dgvDetalhe.AllowUserToResizeRows = false;
            this.dgvDetalhe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalhe.ColumnHeadersVisible = false;
            this.dgvDetalhe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tit,
            this.conta,
            this.custo,
            this.valor,
            this.percent,
            this.detalhes});
            this.dgvDetalhe.Location = new System.Drawing.Point(13, 53);
            this.dgvDetalhe.Name = "dgvDetalhe";
            this.dgvDetalhe.ReadOnly = true;
            this.dgvDetalhe.RowHeadersVisible = false;
            this.dgvDetalhe.Size = new System.Drawing.Size(585, 534);
            this.dgvDetalhe.TabIndex = 1;
            this.dgvDetalhe.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalhe_CellContentClick);
            this.dgvDetalhe.SelectionChanged += new System.EventHandler(this.dgvDetalhe_SelectionChanged);
            // 
            // lbReceitaePax
            // 
            this.lbReceitaePax.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReceitaePax.Location = new System.Drawing.Point(8, 590);
            this.lbReceitaePax.Name = "lbReceitaePax";
            this.lbReceitaePax.Size = new System.Drawing.Size(586, 40);
            this.lbReceitaePax.TabIndex = 0;
            this.lbReceitaePax.Text = "Receita e Pax";
            this.lbReceitaePax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tit
            // 
            this.tit.HeaderText = "Column1";
            this.tit.Name = "tit";
            this.tit.ReadOnly = true;
            this.tit.Visible = false;
            // 
            // conta
            // 
            this.conta.HeaderText = "Conta gerencial";
            this.conta.Name = "conta";
            this.conta.ReadOnly = true;
            this.conta.Width = 300;
            // 
            // custo
            // 
            this.custo.HeaderText = "Custo";
            this.custo.Name = "custo";
            this.custo.ReadOnly = true;
            this.custo.Width = 85;
            // 
            // valor
            // 
            this.valor.HeaderText = "Valor";
            this.valor.Name = "valor";
            this.valor.ReadOnly = true;
            this.valor.Width = 85;
            // 
            // percent
            // 
            this.percent.HeaderText = "Percent";
            this.percent.Name = "percent";
            this.percent.ReadOnly = true;
            this.percent.Width = 85;
            // 
            // detalhes
            // 
            this.detalhes.HeaderText = "";
            this.detalhes.Image = global::GUI.Properties.Resources.magnifying_glass_2x;
            this.detalhes.Name = "detalhes";
            this.detalhes.ReadOnly = true;
            this.detalhes.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.detalhes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.detalhes.Width = 26;
            // 
            // frmDetalheGrafico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 639);
            this.Controls.Add(this.dgvDetalhe);
            this.Controls.Add(this.lbReceitaePax);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmDetalheGrafico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalhes";
            this.Load += new System.EventHandler(this.frmDetalheGrafico_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDetalheGrafico_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalhe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDetalhe;
        private System.Windows.Forms.Label lbReceitaePax;
        private System.Windows.Forms.DataGridViewTextBoxColumn tit;
        private System.Windows.Forms.DataGridViewTextBoxColumn conta;
        private System.Windows.Forms.DataGridViewTextBoxColumn custo;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn percent;
        private System.Windows.Forms.DataGridViewImageColumn detalhes;
    }
}