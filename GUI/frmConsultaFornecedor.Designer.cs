namespace GUI
{
    partial class frmConsultaFornecedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaFornecedor));
            this.gbConsulta = new System.Windows.Forms.GroupBox();
            this.btConsulta = new System.Windows.Forms.Button();
            this.rdFantasia = new System.Windows.Forms.RadioButton();
            this.rdRazao = new System.Windows.Forms.RadioButton();
            this.txtConsulta = new System.Windows.Forms.TextBox();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btCancelar = new System.Windows.Forms.Button();
            this.gbConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbConsulta
            // 
            this.gbConsulta.Controls.Add(this.btCancelar);
            this.gbConsulta.Controls.Add(this.btConsulta);
            this.gbConsulta.Controls.Add(this.rdFantasia);
            this.gbConsulta.Controls.Add(this.rdRazao);
            this.gbConsulta.Controls.Add(this.txtConsulta);
            this.gbConsulta.Location = new System.Drawing.Point(13, 12);
            this.gbConsulta.Name = "gbConsulta";
            this.gbConsulta.Size = new System.Drawing.Size(635, 65);
            this.gbConsulta.TabIndex = 0;
            this.gbConsulta.TabStop = false;
            this.gbConsulta.Text = "Consulta";
            // 
            // btConsulta
            // 
            this.btConsulta.Image = global::GUI.Properties.Resources.magnifying_glass_2x;
            this.btConsulta.Location = new System.Drawing.Point(510, 15);
            this.btConsulta.Name = "btConsulta";
            this.btConsulta.Size = new System.Drawing.Size(24, 24);
            this.btConsulta.TabIndex = 4;
            this.btConsulta.UseVisualStyleBackColor = true;
            this.btConsulta.Click += new System.EventHandler(this.btConsulta_Click);
            // 
            // rdFantasia
            // 
            this.rdFantasia.AutoSize = true;
            this.rdFantasia.Location = new System.Drawing.Point(439, 22);
            this.rdFantasia.Name = "rdFantasia";
            this.rdFantasia.Size = new System.Drawing.Size(65, 17);
            this.rdFantasia.TabIndex = 3;
            this.rdFantasia.Text = "Fantasia";
            this.rdFantasia.UseVisualStyleBackColor = true;
            // 
            // rdRazao
            // 
            this.rdRazao.AutoSize = true;
            this.rdRazao.Checked = true;
            this.rdRazao.Location = new System.Drawing.Point(344, 22);
            this.rdRazao.Name = "rdRazao";
            this.rdRazao.Size = new System.Drawing.Size(88, 17);
            this.rdRazao.TabIndex = 2;
            this.rdRazao.TabStop = true;
            this.rdRazao.Text = "Razão Social";
            this.rdRazao.UseVisualStyleBackColor = true;
            // 
            // txtConsulta
            // 
            this.txtConsulta.Location = new System.Drawing.Point(7, 20);
            this.txtConsulta.Name = "txtConsulta";
            this.txtConsulta.Size = new System.Drawing.Size(330, 20);
            this.txtConsulta.TabIndex = 1;
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.AllowUserToDeleteRows = false;
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDados.Location = new System.Drawing.Point(0, 0);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.ReadOnly = true;
            this.dgvDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDados.Size = new System.Drawing.Size(660, 413);
            this.dgvDados.TabIndex = 1;
            this.dgvDados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDados_CellDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbConsulta);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(660, 94);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvDados);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 94);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(660, 413);
            this.panel2.TabIndex = 3;
            // 
            // btCancelar
            // 
            this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancelar.Image = global::GUI.Properties.Resources.x_2x;
            this.btCancelar.Location = new System.Drawing.Point(540, 15);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(24, 24);
            this.btCancelar.TabIndex = 4;
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // frmConsultaFornecedor
            // 
            this.AcceptButton = this.btConsulta;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancelar;
            this.ClientSize = new System.Drawing.Size(660, 507);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmConsultaFornecedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de fornecedor";
            this.Load += new System.EventHandler(this.frmConsultaFornecedor_Load);
            this.gbConsulta.ResumeLayout(false);
            this.gbConsulta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbConsulta;
        private System.Windows.Forms.Button btConsulta;
        private System.Windows.Forms.RadioButton rdFantasia;
        private System.Windows.Forms.RadioButton rdRazao;
        private System.Windows.Forms.TextBox txtConsulta;
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btCancelar;
    }
}