namespace GUI
{
    partial class frmPosicaoDeEstoqueDados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPosicaoDeEstoqueDados));
            this.pnBotoes = new System.Windows.Forms.Panel();
            this.btCancelar = new System.Windows.Forms.Button();
            this.lbPosicaoDia = new System.Windows.Forms.Label();
            this.btExportar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvPosicao = new System.Windows.Forms.DataGridView();
            this.cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnBotoes.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPosicao)).BeginInit();
            this.SuspendLayout();
            // 
            // pnBotoes
            // 
            this.pnBotoes.Controls.Add(this.btCancelar);
            this.pnBotoes.Controls.Add(this.lbPosicaoDia);
            this.pnBotoes.Controls.Add(this.btExportar);
            this.pnBotoes.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnBotoes.Location = new System.Drawing.Point(0, 0);
            this.pnBotoes.Name = "pnBotoes";
            this.pnBotoes.Size = new System.Drawing.Size(479, 45);
            this.pnBotoes.TabIndex = 0;
            // 
            // btCancelar
            // 
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.Image = global::GUI.Properties.Resources.x_2x;
            this.btCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancelar.Location = new System.Drawing.Point(443, 9);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(24, 24);
            this.btCancelar.TabIndex = 7;
            this.btCancelar.TabStop = false;
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // lbPosicaoDia
            // 
            this.lbPosicaoDia.AutoSize = true;
            this.lbPosicaoDia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPosicaoDia.Location = new System.Drawing.Point(12, 9);
            this.lbPosicaoDia.Name = "lbPosicaoDia";
            this.lbPosicaoDia.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbPosicaoDia.Size = new System.Drawing.Size(113, 21);
            this.lbPosicaoDia.TabIndex = 0;
            this.lbPosicaoDia.Text = "Posição do dia ";
            this.lbPosicaoDia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btExportar
            // 
            this.btExportar.Image = global::GUI.Properties.Resources.document_2x;
            this.btExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExportar.Location = new System.Drawing.Point(413, 9);
            this.btExportar.Name = "btExportar";
            this.btExportar.Size = new System.Drawing.Size(24, 24);
            this.btExportar.TabIndex = 6;
            this.btExportar.TabStop = false;
            this.btExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btExportar.UseVisualStyleBackColor = true;
            this.btExportar.Click += new System.EventHandler(this.btExportar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvPosicao);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(479, 584);
            this.panel1.TabIndex = 1;
            // 
            // dgvPosicao
            // 
            this.dgvPosicao.AllowUserToAddRows = false;
            this.dgvPosicao.AllowUserToDeleteRows = false;
            this.dgvPosicao.AllowUserToResizeColumns = false;
            this.dgvPosicao.AllowUserToResizeRows = false;
            this.dgvPosicao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPosicao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cod,
            this.nome,
            this.quantidade});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPosicao.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPosicao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPosicao.Enabled = false;
            this.dgvPosicao.GridColor = System.Drawing.Color.DimGray;
            this.dgvPosicao.Location = new System.Drawing.Point(0, 0);
            this.dgvPosicao.MultiSelect = false;
            this.dgvPosicao.Name = "dgvPosicao";
            this.dgvPosicao.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPosicao.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPosicao.RowHeadersVisible = false;
            this.dgvPosicao.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvPosicao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPosicao.Size = new System.Drawing.Size(479, 584);
            this.dgvPosicao.TabIndex = 0;
            this.dgvPosicao.TabStop = false;
            // 
            // cod
            // 
            this.cod.HeaderText = "Cód";
            this.cod.Name = "cod";
            this.cod.ReadOnly = true;
            this.cod.Width = 80;
            // 
            // nome
            // 
            this.nome.HeaderText = "Nome";
            this.nome.Name = "nome";
            this.nome.ReadOnly = true;
            this.nome.Width = 330;
            // 
            // quantidade
            // 
            this.quantidade.HeaderText = "Quant";
            this.quantidade.Name = "quantidade";
            this.quantidade.ReadOnly = true;
            this.quantidade.Width = 45;
            // 
            // frmPosicaoDeEstoqueDados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancelar;
            this.ClientSize = new System.Drawing.Size(479, 629);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnBotoes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPosicaoDeEstoqueDados";
            this.Text = "Posição de estoque";
            this.Load += new System.EventHandler(this.frmPosicaoDeEstoqueDados_Load);
            this.pnBotoes.ResumeLayout(false);
            this.pnBotoes.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPosicao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnBotoes;
        private System.Windows.Forms.Label lbPosicaoDia;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvPosicao;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidade;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btExportar;
    }
}