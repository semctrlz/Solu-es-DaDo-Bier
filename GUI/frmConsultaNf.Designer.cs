namespace GUI
{
    partial class frmConsultaNf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaNf));
            this.dgvConsultaNf = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultaNf)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvConsultaNf
            // 
            this.dgvConsultaNf.AllowUserToAddRows = false;
            this.dgvConsultaNf.AllowUserToDeleteRows = false;
            this.dgvConsultaNf.AllowUserToResizeColumns = false;
            this.dgvConsultaNf.AllowUserToResizeRows = false;
            this.dgvConsultaNf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsultaNf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConsultaNf.Location = new System.Drawing.Point(0, 0);
            this.dgvConsultaNf.Name = "dgvConsultaNf";
            this.dgvConsultaNf.ReadOnly = true;
            this.dgvConsultaNf.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvConsultaNf.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConsultaNf.Size = new System.Drawing.Size(584, 761);
            this.dgvConsultaNf.TabIndex = 0;
            this.dgvConsultaNf.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConsultaNf_CellContentClick);
            this.dgvConsultaNf.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConsultaNf_CellContentDoubleClick);
            // 
            // frmConsultaNf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 761);
            this.Controls.Add(this.dgvConsultaNf);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConsultaNf";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta Nota fiscal";
            this.Load += new System.EventHandler(this.frmConsultaNf_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultaNf)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConsultaNf;
    }
}