namespace GUI.Forms.CMV
{
    partial class frmCMVResumos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCMVResumos));
            this.pnComandos = new System.Windows.Forms.Panel();
            this.numAno = new System.Windows.Forms.NumericUpDown();
            this.lbAno = new System.Windows.Forms.Label();
            this.cbMes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbUnidade = new System.Windows.Forms.ComboBox();
            this.Resumos = new System.Windows.Forms.TabControl();
            this.tabCusto = new System.Windows.Forms.TabPage();
            this.dgvCusto = new System.Windows.Forms.DataGridView();
            this.tabReceita = new System.Windows.Forms.TabPage();
            this.dgvReceita = new System.Windows.Forms.DataGridView();
            this.pnComandos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAno)).BeginInit();
            this.Resumos.SuspendLayout();
            this.tabCusto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCusto)).BeginInit();
            this.tabReceita.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceita)).BeginInit();
            this.SuspendLayout();
            // 
            // pnComandos
            // 
            this.pnComandos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnComandos.Controls.Add(this.numAno);
            this.pnComandos.Controls.Add(this.lbAno);
            this.pnComandos.Controls.Add(this.cbMes);
            this.pnComandos.Controls.Add(this.label2);
            this.pnComandos.Controls.Add(this.label1);
            this.pnComandos.Controls.Add(this.cbUnidade);
            this.pnComandos.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnComandos.Location = new System.Drawing.Point(0, 0);
            this.pnComandos.Name = "pnComandos";
            this.pnComandos.Size = new System.Drawing.Size(1063, 65);
            this.pnComandos.TabIndex = 3;
            // 
            // numAno
            // 
            this.numAno.Location = new System.Drawing.Point(187, 24);
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
            this.numAno.Size = new System.Drawing.Size(74, 20);
            this.numAno.TabIndex = 5;
            this.numAno.Value = new decimal(new int[] {
            1995,
            0,
            0,
            0});
            // 
            // lbAno
            // 
            this.lbAno.AutoSize = true;
            this.lbAno.Location = new System.Drawing.Point(184, 7);
            this.lbAno.Name = "lbAno";
            this.lbAno.Size = new System.Drawing.Size(26, 13);
            this.lbAno.TabIndex = 4;
            this.lbAno.Text = "Ano";
            // 
            // cbMes
            // 
            this.cbMes.FormattingEnabled = true;
            this.cbMes.Items.AddRange(new object[] {
            "Janeiro",
            "Fevereiro",
            "Março",
            "Abril",
            "Maio",
            "Junho",
            "Julho",
            "Agosto",
            "Setembro",
            "Outubro",
            "Novembo",
            "Dezembro"});
            this.cbMes.Location = new System.Drawing.Point(78, 24);
            this.cbMes.Name = "cbMes";
            this.cbMes.Size = new System.Drawing.Size(103, 21);
            this.cbMes.TabIndex = 3;
            this.cbMes.SelectedIndexChanged += new System.EventHandler(this.cbMes_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mês de competência";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Unidade";
            // 
            // cbUnidade
            // 
            this.cbUnidade.FormattingEnabled = true;
            this.cbUnidade.Location = new System.Drawing.Point(11, 24);
            this.cbUnidade.Name = "cbUnidade";
            this.cbUnidade.Size = new System.Drawing.Size(60, 21);
            this.cbUnidade.TabIndex = 1;
            // 
            // Resumos
            // 
            this.Resumos.Controls.Add(this.tabCusto);
            this.Resumos.Controls.Add(this.tabReceita);
            this.Resumos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Resumos.Location = new System.Drawing.Point(0, 65);
            this.Resumos.Name = "Resumos";
            this.Resumos.SelectedIndex = 0;
            this.Resumos.Size = new System.Drawing.Size(1063, 480);
            this.Resumos.TabIndex = 4;
            // 
            // tabCusto
            // 
            this.tabCusto.Controls.Add(this.dgvCusto);
            this.tabCusto.Location = new System.Drawing.Point(4, 22);
            this.tabCusto.Name = "tabCusto";
            this.tabCusto.Padding = new System.Windows.Forms.Padding(3);
            this.tabCusto.Size = new System.Drawing.Size(1055, 454);
            this.tabCusto.TabIndex = 0;
            this.tabCusto.Text = "Custo";
            this.tabCusto.UseVisualStyleBackColor = true;
            this.tabCusto.Enter += new System.EventHandler(this.tabCusto_Enter);
            // 
            // dgvCusto
            // 
            this.dgvCusto.AllowUserToAddRows = false;
            this.dgvCusto.AllowUserToDeleteRows = false;
            this.dgvCusto.AllowUserToResizeColumns = false;
            this.dgvCusto.AllowUserToResizeRows = false;
            this.dgvCusto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCusto.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCusto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCusto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCusto.Location = new System.Drawing.Point(3, 3);
            this.dgvCusto.Name = "dgvCusto";
            this.dgvCusto.RowHeadersVisible = false;
            this.dgvCusto.Size = new System.Drawing.Size(1049, 448);
            this.dgvCusto.TabIndex = 0;
            this.dgvCusto.SelectionChanged += new System.EventHandler(this.dgvCusto_SelectionChanged);
            this.dgvCusto.Enter += new System.EventHandler(this.dgvCusto_Enter);
            // 
            // tabReceita
            // 
            this.tabReceita.Controls.Add(this.dgvReceita);
            this.tabReceita.Location = new System.Drawing.Point(4, 22);
            this.tabReceita.Name = "tabReceita";
            this.tabReceita.Padding = new System.Windows.Forms.Padding(3);
            this.tabReceita.Size = new System.Drawing.Size(1055, 454);
            this.tabReceita.TabIndex = 1;
            this.tabReceita.Text = "Receita";
            this.tabReceita.UseVisualStyleBackColor = true;
            this.tabReceita.Enter += new System.EventHandler(this.tabReceita_Enter);
            // 
            // dgvReceita
            // 
            this.dgvReceita.AllowUserToAddRows = false;
            this.dgvReceita.AllowUserToDeleteRows = false;
            this.dgvReceita.AllowUserToResizeColumns = false;
            this.dgvReceita.AllowUserToResizeRows = false;
            this.dgvReceita.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReceita.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvReceita.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceita.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReceita.Location = new System.Drawing.Point(3, 3);
            this.dgvReceita.MultiSelect = false;
            this.dgvReceita.Name = "dgvReceita";
            this.dgvReceita.RowHeadersVisible = false;
            this.dgvReceita.Size = new System.Drawing.Size(1049, 448);
            this.dgvReceita.TabIndex = 0;
            // 
            // frmCMVResumos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 545);
            this.Controls.Add(this.Resumos);
            this.Controls.Add(this.pnComandos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCMVResumos";
            this.Text = "Resumos Custo/Receita";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCMVResumos_Load);
            this.pnComandos.ResumeLayout(false);
            this.pnComandos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAno)).EndInit();
            this.Resumos.ResumeLayout(false);
            this.tabCusto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCusto)).EndInit();
            this.tabReceita.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceita)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnComandos;
        private System.Windows.Forms.ComboBox cbMes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbUnidade;
        private System.Windows.Forms.TabControl Resumos;
        private System.Windows.Forms.TabPage tabCusto;
        private System.Windows.Forms.TabPage tabReceita;
        private System.Windows.Forms.DataGridView dgvCusto;
        private System.Windows.Forms.DataGridView dgvReceita;
        private System.Windows.Forms.NumericUpDown numAno;
        private System.Windows.Forms.Label lbAno;
    }
}