namespace GUI
{
    partial class frmConexoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConexoes));
            this.dgvConexoes = new System.Windows.Forms.DataGridView();
            this.ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.del = new System.Windows.Forms.DataGridViewImageColumn();
            this.lbConexaoAtual = new System.Windows.Forms.Label();
            this.lbTexto = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConexoes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvConexoes
            // 
            this.dgvConexoes.AllowUserToAddRows = false;
            this.dgvConexoes.AllowUserToDeleteRows = false;
            this.dgvConexoes.AllowUserToResizeColumns = false;
            this.dgvConexoes.AllowUserToResizeRows = false;
            this.dgvConexoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConexoes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ip,
            this.del});
            this.dgvConexoes.Location = new System.Drawing.Point(12, 34);
            this.dgvConexoes.Name = "dgvConexoes";
            this.dgvConexoes.ReadOnly = true;
            this.dgvConexoes.RowHeadersVisible = false;
            this.dgvConexoes.Size = new System.Drawing.Size(164, 179);
            this.dgvConexoes.TabIndex = 0;
            this.dgvConexoes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConexoes_CellContentClick);
            this.dgvConexoes.SelectionChanged += new System.EventHandler(this.dgvConexoes_SelectionChanged);
            // 
            // ip
            // 
            this.ip.HeaderText = "Ip da conexão";
            this.ip.Name = "ip";
            this.ip.ReadOnly = true;
            this.ip.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // del
            // 
            this.del.HeaderText = "DEL";
            this.del.Image = global::GUI.Properties.Resources.trash_2x;
            this.del.Name = "del";
            this.del.ReadOnly = true;
            this.del.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.del.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.del.Width = 60;
            // 
            // lbConexaoAtual
            // 
            this.lbConexaoAtual.AutoSize = true;
            this.lbConexaoAtual.Location = new System.Drawing.Point(12, 9);
            this.lbConexaoAtual.Name = "lbConexaoAtual";
            this.lbConexaoAtual.Size = new System.Drawing.Size(39, 13);
            this.lbConexaoAtual.TabIndex = 1;
            this.lbConexaoAtual.Text = "Local: ";
            // 
            // lbTexto
            // 
            this.lbTexto.Location = new System.Drawing.Point(9, 225);
            this.lbTexto.Name = "lbTexto";
            this.lbTexto.Size = new System.Drawing.Size(167, 85);
            this.lbTexto.TabIndex = 1;
            this.lbTexto.Text = "Lista de computadores onde você se conecta automaticamene. Clique nas lixeiras, n" +
    "a lista acima, para cancelar a conexão automatica nos ips listados.";
            // 
            // frmConexoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(189, 319);
            this.Controls.Add(this.lbTexto);
            this.Controls.Add(this.lbConexaoAtual);
            this.Controls.Add(this.dgvConexoes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmConexoes";
            this.Text = "Conexões";
            this.Load += new System.EventHandler(this.frmConexoes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConexoes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConexoes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ip;
        private System.Windows.Forms.DataGridViewImageColumn del;
        private System.Windows.Forms.Label lbConexaoAtual;
        private System.Windows.Forms.Label lbTexto;
    }
}