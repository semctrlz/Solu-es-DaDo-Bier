namespace GUI
{
    partial class frmCMVRelatorio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCMVRelatorio));
            this.pnTopo = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.numAno = new System.Windows.Forms.NumericUpDown();
            this.cbUnidade = new System.Windows.Forms.ComboBox();
            this.lbUnidade = new System.Windows.Forms.Label();
            this.cbMes = new System.Windows.Forms.ComboBox();
            this.lbAno = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnEsq = new System.Windows.Forms.Panel();
            this.tabelaExibicao = new System.Windows.Forms.TableLayoutPanel();
            this.dgvResumo = new System.Windows.Forms.DataGridView();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvA = new System.Windows.Forms.DataGridView();
            this.tipo_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.custo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.realizado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvB = new System.Windows.Forms.DataGridView();
            this.tipo_linha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setor_B = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.custoB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.realizadob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnTopo.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAno)).BeginInit();
            this.pnEsq.SuspendLayout();
            this.tabelaExibicao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvB)).BeginInit();
            this.SuspendLayout();
            // 
            // pnTopo
            // 
            this.pnTopo.Controls.Add(this.panel5);
            this.pnTopo.Controls.Add(this.panel4);
            this.pnTopo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTopo.Location = new System.Drawing.Point(0, 0);
            this.pnTopo.Name = "pnTopo";
            this.pnTopo.Size = new System.Drawing.Size(1013, 63);
            this.pnTopo.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lbTitulo);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(277, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(736, 63);
            this.panel5.TabIndex = 4;
            // 
            // lbTitulo
            // 
            this.lbTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTitulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.Location = new System.Drawing.Point(0, 0);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(736, 63);
            this.lbTitulo.TabIndex = 2;
            this.lbTitulo.Text = "CMV - Seival - Maio/2016";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.numAno);
            this.panel4.Controls.Add(this.cbUnidade);
            this.panel4.Controls.Add(this.lbUnidade);
            this.panel4.Controls.Add(this.cbMes);
            this.panel4.Controls.Add(this.lbAno);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(277, 63);
            this.panel4.TabIndex = 3;
            // 
            // numAno
            // 
            this.numAno.Location = new System.Drawing.Point(192, 26);
            this.numAno.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.numAno.Minimum = new decimal(new int[] {
            1995,
            0,
            0,
            0});
            this.numAno.Name = "numAno";
            this.numAno.Size = new System.Drawing.Size(72, 20);
            this.numAno.TabIndex = 2;
            this.numAno.Value = new decimal(new int[] {
            1995,
            0,
            0,
            0});
            this.numAno.ValueChanged += new System.EventHandler(this.numAno_ValueChanged);
            // 
            // cbUnidade
            // 
            this.cbUnidade.FormattingEnabled = true;
            this.cbUnidade.Location = new System.Drawing.Point(6, 25);
            this.cbUnidade.Name = "cbUnidade";
            this.cbUnidade.Size = new System.Drawing.Size(70, 21);
            this.cbUnidade.TabIndex = 1;
            this.cbUnidade.SelectedIndexChanged += new System.EventHandler(this.cbUnidade_SelectedIndexChanged);
            // 
            // lbUnidade
            // 
            this.lbUnidade.AutoSize = true;
            this.lbUnidade.Location = new System.Drawing.Point(3, 9);
            this.lbUnidade.Name = "lbUnidade";
            this.lbUnidade.Size = new System.Drawing.Size(47, 13);
            this.lbUnidade.TabIndex = 0;
            this.lbUnidade.Text = "Unidade";
            // 
            // cbMes
            // 
            this.cbMes.FormattingEnabled = true;
            this.cbMes.Location = new System.Drawing.Point(82, 25);
            this.cbMes.Name = "cbMes";
            this.cbMes.Size = new System.Drawing.Size(103, 21);
            this.cbMes.TabIndex = 1;
            this.cbMes.SelectedIndexChanged += new System.EventHandler(this.cbMes_SelectedIndexChanged);
            // 
            // lbAno
            // 
            this.lbAno.AutoSize = true;
            this.lbAno.Location = new System.Drawing.Point(191, 9);
            this.lbAno.Name = "lbAno";
            this.lbAno.Size = new System.Drawing.Size(26, 13);
            this.lbAno.TabIndex = 0;
            this.lbAno.Text = "Ano";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mês de competência";
            // 
            // pnEsq
            // 
            this.pnEsq.BackColor = System.Drawing.Color.Silver;
            this.pnEsq.Controls.Add(this.tabelaExibicao);
            this.pnEsq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnEsq.Location = new System.Drawing.Point(0, 63);
            this.pnEsq.Name = "pnEsq";
            this.pnEsq.Size = new System.Drawing.Size(1013, 533);
            this.pnEsq.TabIndex = 1;
            // 
            // tabelaExibicao
            // 
            this.tabelaExibicao.ColumnCount = 5;
            this.tabelaExibicao.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39F));
            this.tabelaExibicao.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tabelaExibicao.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39F));
            this.tabelaExibicao.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tabelaExibicao.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tabelaExibicao.Controls.Add(this.dgvResumo, 4, 1);
            this.tabelaExibicao.Controls.Add(this.label2, 4, 0);
            this.tabelaExibicao.Controls.Add(this.label3, 2, 0);
            this.tabelaExibicao.Controls.Add(this.label4, 0, 0);
            this.tabelaExibicao.Controls.Add(this.dgvA, 0, 1);
            this.tabelaExibicao.Controls.Add(this.dgvB, 2, 1);
            this.tabelaExibicao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabelaExibicao.Location = new System.Drawing.Point(0, 0);
            this.tabelaExibicao.Name = "tabelaExibicao";
            this.tabelaExibicao.RowCount = 2;
            this.tabelaExibicao.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tabelaExibicao.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tabelaExibicao.Size = new System.Drawing.Size(1013, 533);
            this.tabelaExibicao.TabIndex = 0;
            // 
            // dgvResumo
            // 
            this.dgvResumo.AllowUserToAddRows = false;
            this.dgvResumo.AllowUserToDeleteRows = false;
            this.dgvResumo.AllowUserToResizeColumns = false;
            this.dgvResumo.AllowUserToResizeRows = false;
            this.dgvResumo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResumo.ColumnHeadersVisible = false;
            this.dgvResumo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tipo,
            this.titulo,
            this.valor});
            this.dgvResumo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResumo.Location = new System.Drawing.Point(813, 33);
            this.dgvResumo.Name = "dgvResumo";
            this.dgvResumo.ReadOnly = true;
            this.dgvResumo.RowHeadersVisible = false;
            this.dgvResumo.Size = new System.Drawing.Size(197, 497);
            this.dgvResumo.TabIndex = 1;
            this.dgvResumo.SelectionChanged += new System.EventHandler(this.dgvResumo_SelectionChanged);
            // 
            // tipo
            // 
            this.tipo.HeaderText = "Tipo";
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            this.tipo.Visible = false;
            this.tipo.Width = 40;
            // 
            // titulo
            // 
            this.titulo.HeaderText = "Titulo";
            this.titulo.Name = "titulo";
            this.titulo.ReadOnly = true;
            this.titulo.Width = 150;
            // 
            // valor
            // 
            this.valor.HeaderText = "Valor";
            this.valor.Name = "valor";
            this.valor.ReadOnly = true;
            this.valor.Width = 120;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Gray;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(813, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "RESUMO";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Gray;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(408, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(389, 30);
            this.label3.TabIndex = 0;
            this.label3.Text = "BEBIDAS / DIVERSOS";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Gray;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(389, 30);
            this.label4.TabIndex = 0;
            this.label4.Text = "ALIMENTOS";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvA
            // 
            this.dgvA.AllowUserToAddRows = false;
            this.dgvA.AllowUserToDeleteRows = false;
            this.dgvA.AllowUserToResizeColumns = false;
            this.dgvA.AllowUserToResizeRows = false;
            this.dgvA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvA.ColumnHeadersVisible = false;
            this.dgvA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tipo_col,
            this.setor,
            this.custo,
            this.meta,
            this.realizado});
            this.dgvA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvA.Location = new System.Drawing.Point(3, 33);
            this.dgvA.Name = "dgvA";
            this.dgvA.ReadOnly = true;
            this.dgvA.RowHeadersVisible = false;
            this.dgvA.Size = new System.Drawing.Size(389, 497);
            this.dgvA.TabIndex = 2;
            this.dgvA.SelectionChanged += new System.EventHandler(this.dgvA_SelectionChanged);
            // 
            // tipo_col
            // 
            this.tipo_col.HeaderText = "Tipo";
            this.tipo_col.Name = "tipo_col";
            this.tipo_col.ReadOnly = true;
            this.tipo_col.Visible = false;
            // 
            // setor
            // 
            this.setor.HeaderText = "Setor";
            this.setor.Name = "setor";
            this.setor.ReadOnly = true;
            // 
            // custo
            // 
            this.custo.HeaderText = "Custo";
            this.custo.Name = "custo";
            this.custo.ReadOnly = true;
            // 
            // meta
            // 
            this.meta.HeaderText = "Meta";
            this.meta.Name = "meta";
            this.meta.ReadOnly = true;
            // 
            // realizado
            // 
            this.realizado.HeaderText = "Realizado";
            this.realizado.Name = "realizado";
            this.realizado.ReadOnly = true;
            // 
            // dgvB
            // 
            this.dgvB.AllowUserToAddRows = false;
            this.dgvB.AllowUserToDeleteRows = false;
            this.dgvB.AllowUserToResizeColumns = false;
            this.dgvB.AllowUserToResizeRows = false;
            this.dgvB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvB.ColumnHeadersVisible = false;
            this.dgvB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tipo_linha,
            this.setor_B,
            this.custoB,
            this.metab,
            this.realizadob});
            this.dgvB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvB.Location = new System.Drawing.Point(408, 33);
            this.dgvB.Name = "dgvB";
            this.dgvB.ReadOnly = true;
            this.dgvB.RowHeadersVisible = false;
            this.dgvB.Size = new System.Drawing.Size(389, 497);
            this.dgvB.TabIndex = 3;
            this.dgvB.SelectionChanged += new System.EventHandler(this.dgvB_SelectionChanged);
            // 
            // tipo_linha
            // 
            this.tipo_linha.HeaderText = "tipo";
            this.tipo_linha.Name = "tipo_linha";
            this.tipo_linha.ReadOnly = true;
            this.tipo_linha.Visible = false;
            // 
            // setor_B
            // 
            this.setor_B.HeaderText = "setor";
            this.setor_B.Name = "setor_B";
            this.setor_B.ReadOnly = true;
            // 
            // custoB
            // 
            this.custoB.HeaderText = "Custo";
            this.custoB.Name = "custoB";
            this.custoB.ReadOnly = true;
            // 
            // metab
            // 
            this.metab.HeaderText = "Meta";
            this.metab.Name = "metab";
            this.metab.ReadOnly = true;
            // 
            // realizadob
            // 
            this.realizadob.HeaderText = "Realizado";
            this.realizadob.Name = "realizadob";
            this.realizadob.ReadOnly = true;
            // 
            // frmCMVRelatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 596);
            this.Controls.Add(this.pnEsq);
            this.Controls.Add(this.pnTopo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1029, 635);
            this.Name = "frmCMVRelatorio";
            this.Text = "Relatório de CMV";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCMVRelatorio_Load);
            this.Resize += new System.EventHandler(this.frmCMVRelatorio_Resize);
            this.pnTopo.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAno)).EndInit();
            this.pnEsq.ResumeLayout(false);
            this.tabelaExibicao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnTopo;
        private System.Windows.Forms.Panel pnEsq;
        private System.Windows.Forms.Label lbUnidade;
        private System.Windows.Forms.ComboBox cbUnidade;
        private System.Windows.Forms.ComboBox cbMes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.NumericUpDown numAno;
        private System.Windows.Forms.Label lbAno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvResumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn titulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor;
        private System.Windows.Forms.TableLayoutPanel tabelaExibicao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvA;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn setor;
        private System.Windows.Forms.DataGridViewTextBoxColumn custo;
        private System.Windows.Forms.DataGridViewTextBoxColumn meta;
        private System.Windows.Forms.DataGridViewTextBoxColumn realizado;
        private System.Windows.Forms.DataGridView dgvB;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo_linha;
        private System.Windows.Forms.DataGridViewTextBoxColumn setor_B;
        private System.Windows.Forms.DataGridViewTextBoxColumn custoB;
        private System.Windows.Forms.DataGridViewTextBoxColumn metab;
        private System.Windows.Forms.DataGridViewTextBoxColumn realizadob;
    }
}