namespace GUI.Forms.CMV
{
    partial class frmRELSinteticoGeral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRELSinteticoGeral));
            this.pnTopo = new System.Windows.Forms.Panel();
            this.numAno = new System.Windows.Forms.NumericUpDown();
            this.cbMes = new System.Windows.Forms.ComboBox();
            this.lbAno = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbUnidade = new System.Windows.Forms.ComboBox();
            this.lbUnidade = new System.Windows.Forms.Label();
            this.pnDados = new System.Windows.Forms.Panel();
            this.pn01 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.pnTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAno)).BeginInit();
            this.pnDados.SuspendLayout();
            this.pn01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // pnTopo
            // 
            this.pnTopo.Controls.Add(this.numAno);
            this.pnTopo.Controls.Add(this.cbMes);
            this.pnTopo.Controls.Add(this.lbAno);
            this.pnTopo.Controls.Add(this.label1);
            this.pnTopo.Controls.Add(this.cbUnidade);
            this.pnTopo.Controls.Add(this.lbUnidade);
            this.pnTopo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTopo.Location = new System.Drawing.Point(0, 0);
            this.pnTopo.Name = "pnTopo";
            this.pnTopo.Size = new System.Drawing.Size(1350, 33);
            this.pnTopo.TabIndex = 1;
            // 
            // numAno
            // 
            this.numAno.Location = new System.Drawing.Point(325, 5);
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
            this.numAno.TabIndex = 2;
            this.numAno.Value = new decimal(new int[] {
            1995,
            0,
            0,
            0});
            this.numAno.ValueChanged += new System.EventHandler(this.numAno_ValueChanged);
            // 
            // cbMes
            // 
            this.cbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMes.FormattingEnabled = true;
            this.cbMes.Location = new System.Drawing.Point(186, 5);
            this.cbMes.Name = "cbMes";
            this.cbMes.Size = new System.Drawing.Size(101, 21);
            this.cbMes.TabIndex = 1;
            this.cbMes.SelectedIndexChanged += new System.EventHandler(this.cbMes_SelectedIndexChanged);
            // 
            // lbAno
            // 
            this.lbAno.AutoSize = true;
            this.lbAno.Location = new System.Drawing.Point(293, 8);
            this.lbAno.Name = "lbAno";
            this.lbAno.Size = new System.Drawing.Size(26, 13);
            this.lbAno.TabIndex = 0;
            this.lbAno.Text = "Ano";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mês";
            // 
            // cbUnidade
            // 
            this.cbUnidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUnidade.FormattingEnabled = true;
            this.cbUnidade.Location = new System.Drawing.Point(65, 5);
            this.cbUnidade.Name = "cbUnidade";
            this.cbUnidade.Size = new System.Drawing.Size(82, 21);
            this.cbUnidade.TabIndex = 1;
            this.cbUnidade.SelectedIndexChanged += new System.EventHandler(this.cbUnidade_SelectedIndexChanged);
            // 
            // lbUnidade
            // 
            this.lbUnidade.AutoSize = true;
            this.lbUnidade.Location = new System.Drawing.Point(12, 8);
            this.lbUnidade.Name = "lbUnidade";
            this.lbUnidade.Size = new System.Drawing.Size(47, 13);
            this.lbUnidade.TabIndex = 0;
            this.lbUnidade.Text = "Unidade";
            // 
            // pnDados
            // 
            this.pnDados.Controls.Add(this.pn01);
            this.pnDados.Controls.Add(this.label2);
            this.pnDados.Location = new System.Drawing.Point(0, 33);
            this.pnDados.Name = "pnDados";
            this.pnDados.Size = new System.Drawing.Size(1350, 674);
            this.pnDados.TabIndex = 2;
            // 
            // pn01
            // 
            this.pn01.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.pn01.ColumnCount = 1;
            this.pn01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pn01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pn01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pn01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pn01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pn01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pn01.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pn01.Controls.Add(this.dgvData, 0, 0);
            this.pn01.Location = new System.Drawing.Point(1, 1);
            this.pn01.Name = "pn01";
            this.pn01.RowCount = 1;
            this.pn01.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 674F));
            this.pn01.Size = new System.Drawing.Size(1347, 674);
            this.pn01.TabIndex = 0;
            this.pn01.Visible = false;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeColumns = false;
            this.dgvData.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(1, 1);
            this.dgvData.Margin = new System.Windows.Forms.Padding(0);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowHeadersWidth = 38;
            this.dgvData.RowTemplate.Height = 20;
            this.dgvData.RowTemplate.ReadOnly = true;
            this.dgvData.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvData.Size = new System.Drawing.Size(1345, 674);
            this.dgvData.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1347, 674);
            this.label2.TabIndex = 1;
            this.label2.Text = "Aguarde, por favor.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmRELSinteticoGeral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 707);
            this.Controls.Add(this.pnDados);
            this.Controls.Add(this.pnTopo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRELSinteticoGeral";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório por grupos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRELSinteticoGeral_Load);
            this.pnTopo.ResumeLayout(false);
            this.pnTopo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAno)).EndInit();
            this.pnDados.ResumeLayout(false);
            this.pn01.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnTopo;
        private System.Windows.Forms.NumericUpDown numAno;
        private System.Windows.Forms.ComboBox cbMes;
        private System.Windows.Forms.Label lbAno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbUnidade;
        private System.Windows.Forms.Label lbUnidade;
        private System.Windows.Forms.Panel pnDados;
        private System.Windows.Forms.TableLayoutPanel pn01;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label label2;
    }
}