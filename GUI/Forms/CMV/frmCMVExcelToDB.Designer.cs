namespace GUI.Forms.CMV
{
    partial class frmExcelToDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExcelToDB));
            this.btColarDados = new System.Windows.Forms.Button();
            this.dgvExcel = new System.Windows.Forms.DataGridView();
            this.pnComandos = new System.Windows.Forms.Panel();
            this.btAddBd = new System.Windows.Forms.Button();
            this.lbTipoDado = new System.Windows.Forms.Label();
            this.cbMes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbUnidade = new System.Windows.Forms.ComboBox();
            this.pnCola = new System.Windows.Forms.Panel();
            this.pnAguarde = new System.Windows.Forms.Panel();
            this.lbLoadingAviso = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcel)).BeginInit();
            this.pnComandos.SuspendLayout();
            this.pnCola.SuspendLayout();
            this.pnAguarde.SuspendLayout();
            this.SuspendLayout();
            // 
            // btColarDados
            // 
            this.btColarDados.Location = new System.Drawing.Point(187, 24);
            this.btColarDados.Name = "btColarDados";
            this.btColarDados.Size = new System.Drawing.Size(75, 23);
            this.btColarDados.TabIndex = 0;
            this.btColarDados.Text = "Colar dados";
            this.btColarDados.UseVisualStyleBackColor = true;
            this.btColarDados.Click += new System.EventHandler(this.BtColarDados_Click);
            // 
            // dgvExcel
            // 
            this.dgvExcel.AllowUserToAddRows = false;
            this.dgvExcel.AllowUserToDeleteRows = false;
            this.dgvExcel.AllowUserToResizeColumns = false;
            this.dgvExcel.AllowUserToResizeRows = false;
            this.dgvExcel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExcel.Location = new System.Drawing.Point(0, 0);
            this.dgvExcel.Name = "dgvExcel";
            this.dgvExcel.ReadOnly = true;
            this.dgvExcel.RowHeadersVisible = false;
            this.dgvExcel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExcel.Size = new System.Drawing.Size(547, 306);
            this.dgvExcel.TabIndex = 1;
            // 
            // pnComandos
            // 
            this.pnComandos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnComandos.Controls.Add(this.btAddBd);
            this.pnComandos.Controls.Add(this.lbTipoDado);
            this.pnComandos.Controls.Add(this.cbMes);
            this.pnComandos.Controls.Add(this.label2);
            this.pnComandos.Controls.Add(this.label1);
            this.pnComandos.Controls.Add(this.cbUnidade);
            this.pnComandos.Controls.Add(this.btColarDados);
            this.pnComandos.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnComandos.Location = new System.Drawing.Point(0, 0);
            this.pnComandos.Name = "pnComandos";
            this.pnComandos.Size = new System.Drawing.Size(549, 119);
            this.pnComandos.TabIndex = 2;
            // 
            // btAddBd
            // 
            this.btAddBd.Location = new System.Drawing.Point(268, 25);
            this.btAddBd.Name = "btAddBd";
            this.btAddBd.Size = new System.Drawing.Size(164, 23);
            this.btAddBd.TabIndex = 5;
            this.btAddBd.Text = "Adicionar ao Banco de dados";
            this.btAddBd.UseVisualStyleBackColor = true;
            this.btAddBd.Click += new System.EventHandler(this.AddBd_Click);
            // 
            // lbTipoDado
            // 
            this.lbTipoDado.AutoSize = true;
            this.lbTipoDado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTipoDado.Location = new System.Drawing.Point(11, 52);
            this.lbTipoDado.Name = "lbTipoDado";
            this.lbTipoDado.Size = new System.Drawing.Size(449, 21);
            this.lbTipoDado.TabIndex = 4;
            this.lbTipoDado.Text = "Copie o conteúdo desejado do Excel e clique em \"Copiar dados\"";
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
            // pnCola
            // 
            this.pnCola.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnCola.Controls.Add(this.dgvExcel);
            this.pnCola.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnCola.Location = new System.Drawing.Point(0, 119);
            this.pnCola.Name = "pnCola";
            this.pnCola.Size = new System.Drawing.Size(549, 308);
            this.pnCola.TabIndex = 3;
            // 
            // pnAguarde
            // 
            this.pnAguarde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnAguarde.Controls.Add(this.lbLoadingAviso);
            this.pnAguarde.Controls.Add(this.label3);
            this.pnAguarde.Location = new System.Drawing.Point(1153, 66);
            this.pnAguarde.Name = "pnAguarde";
            this.pnAguarde.Size = new System.Drawing.Size(284, 167);
            this.pnAguarde.TabIndex = 4;
            this.pnAguarde.Visible = false;
            // 
            // lbLoadingAviso
            // 
            this.lbLoadingAviso.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoadingAviso.Location = new System.Drawing.Point(4, 44);
            this.lbLoadingAviso.Name = "lbLoadingAviso";
            this.lbLoadingAviso.Size = new System.Drawing.Size(275, 70);
            this.lbLoadingAviso.TabIndex = 0;
            this.lbLoadingAviso.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-1, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(284, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "AGUARDE";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmExcelToDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 427);
            this.Controls.Add(this.pnAguarde);
            this.Controls.Add(this.pnCola);
            this.Controls.Add(this.pnComandos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmExcelToDB";
            this.Text = "Dados";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmExcelToDB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcel)).EndInit();
            this.pnComandos.ResumeLayout(false);
            this.pnComandos.PerformLayout();
            this.pnCola.ResumeLayout(false);
            this.pnAguarde.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btColarDados;
        private System.Windows.Forms.DataGridView dgvExcel;
        private System.Windows.Forms.Panel pnComandos;
        private System.Windows.Forms.Panel pnCola;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbUnidade;
        private System.Windows.Forms.ComboBox cbMes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnAguarde;
        private System.Windows.Forms.Label lbLoadingAviso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbTipoDado;
        private System.Windows.Forms.Button btAddBd;
    }
}