namespace GUI
{
    partial class frmConsultaUnidade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaUnidade));
            this.dgvUnidade = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnidade)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUnidade
            // 
            this.dgvUnidade.AllowUserToAddRows = false;
            this.dgvUnidade.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvUnidade.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUnidade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnidade.Location = new System.Drawing.Point(13, 13);
            this.dgvUnidade.Name = "dgvUnidade";
            this.dgvUnidade.ReadOnly = true;
            this.dgvUnidade.RowHeadersWidth = 50;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvUnidade.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUnidade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUnidade.Size = new System.Drawing.Size(259, 336);
            this.dgvUnidade.TabIndex = 0;
            this.dgvUnidade.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUnidade_CellDoubleClick);
            this.dgvUnidade.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUnidade_CellDoubleClick);
            // 
            // frmConsultaUnidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 361);
            this.Controls.Add(this.dgvUnidade);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConsultaUnidade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConsultaUnidade";
            this.Load += new System.EventHandler(this.frmConsultaUnidade_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnidade)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUnidade;
    }
}