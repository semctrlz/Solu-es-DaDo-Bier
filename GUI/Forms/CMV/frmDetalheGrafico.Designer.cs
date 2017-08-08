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
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.conta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeSetor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.custo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detalhes = new System.Windows.Forms.DataGridViewImageColumn();
            this.abc = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalhe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(522, 40);
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
            this.conta,
            this.nomeSetor,
            this.custo,
            this.valor,
            this.percent,
            this.detalhes,
            this.abc});
            this.dgvDetalhe.Location = new System.Drawing.Point(13, 53);
            this.dgvDetalhe.Name = "dgvDetalhe";
            this.dgvDetalhe.ReadOnly = true;
            this.dgvDetalhe.RowHeadersVisible = false;
            this.dgvDetalhe.Size = new System.Drawing.Size(630, 534);
            this.dgvDetalhe.TabIndex = 1;
            this.dgvDetalhe.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalhe_CellContentClick);
            this.dgvDetalhe.SelectionChanged += new System.EventHandler(this.dgvDetalhe_SelectionChanged);
            // 
            // lbReceitaePax
            // 
            this.lbReceitaePax.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbReceitaePax.Location = new System.Drawing.Point(8, 590);
            this.lbReceitaePax.Name = "lbReceitaePax";
            this.lbReceitaePax.Size = new System.Drawing.Size(635, 40);
            this.lbReceitaePax.TabIndex = 0;
            this.lbReceitaePax.Text = "Receita e Pax";
            this.lbReceitaePax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::GUI.Properties.Resources.magnifying_glass_2x;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.Width = 26;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "ABC";
            this.dataGridViewImageColumn2.Image = global::GUI.Properties.Resources.list_2x;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::GUI.Properties.Resources.magnifying_glass_2x;
            this.pictureBox1.Location = new System.Drawing.Point(540, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Image = global::GUI.Properties.Resources.list_2x;
            this.pictureBox2.Location = new System.Drawing.Point(540, 29);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(566, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Lista de baixas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(566, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "ABC";
            // 
            // conta
            // 
            this.conta.HeaderText = "Conta gerencial";
            this.conta.Name = "conta";
            this.conta.ReadOnly = true;
            this.conta.Visible = false;
            // 
            // nomeSetor
            // 
            this.nomeSetor.HeaderText = "NomeSetor";
            this.nomeSetor.Name = "nomeSetor";
            this.nomeSetor.ReadOnly = true;
            this.nomeSetor.Width = 300;
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
            this.detalhes.HeaderText = "Det.";
            this.detalhes.Image = global::GUI.Properties.Resources.magnifying_glass_2x;
            this.detalhes.Name = "detalhes";
            this.detalhes.ReadOnly = true;
            this.detalhes.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.detalhes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.detalhes.Width = 35;
            // 
            // abc
            // 
            this.abc.HeaderText = "ABC";
            this.abc.Image = global::GUI.Properties.Resources.list_2x;
            this.abc.Name = "abc";
            this.abc.ReadOnly = true;
            this.abc.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.abc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.abc.Width = 35;
            // 
            // frmDetalheGrafico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 639);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDetalhe;
        private System.Windows.Forms.Label lbReceitaePax;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn conta;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeSetor;
        private System.Windows.Forms.DataGridViewTextBoxColumn custo;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn percent;
        private System.Windows.Forms.DataGridViewImageColumn detalhes;
        private System.Windows.Forms.DataGridViewImageColumn abc;
    }
}