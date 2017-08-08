namespace GUI
{
    partial class frmConfigDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigDatabase));
            this.lbBancoDeDados = new System.Windows.Forms.Label();
            this.txtBancoDeDados = new System.Windows.Forms.TextBox();
            this.btTestar = new System.Windows.Forms.Button();
            this.btSalvar = new System.Windows.Forms.Button();
            this.lbServidor = new System.Windows.Forms.Label();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.btProcurar = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // lbBancoDeDados
            // 
            this.lbBancoDeDados.AutoSize = true;
            this.lbBancoDeDados.Location = new System.Drawing.Point(12, 81);
            this.lbBancoDeDados.Name = "lbBancoDeDados";
            this.lbBancoDeDados.Size = new System.Drawing.Size(87, 13);
            this.lbBancoDeDados.TabIndex = 1;
            this.lbBancoDeDados.Text = "Banco de Dados";
            // 
            // txtBancoDeDados
            // 
            this.txtBancoDeDados.Location = new System.Drawing.Point(12, 97);
            this.txtBancoDeDados.Name = "txtBancoDeDados";
            this.txtBancoDeDados.Size = new System.Drawing.Size(156, 20);
            this.txtBancoDeDados.TabIndex = 5;
            // 
            // btTestar
            // 
            this.btTestar.Image = global::GUI.Properties.Resources.pulse_6x;
            this.btTestar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btTestar.Location = new System.Drawing.Point(190, 46);
            this.btTestar.Name = "btTestar";
            this.btTestar.Size = new System.Drawing.Size(75, 71);
            this.btTestar.TabIndex = 9;
            this.btTestar.Text = "Testar";
            this.btTestar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btTestar.UseVisualStyleBackColor = true;
            this.btTestar.Click += new System.EventHandler(this.btTestar_Click);
            // 
            // btSalvar
            // 
            this.btSalvar.Image = global::GUI.Properties.Resources.circle_check_6x;
            this.btSalvar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btSalvar.Location = new System.Drawing.Point(271, 46);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(75, 71);
            this.btSalvar.TabIndex = 8;
            this.btSalvar.Text = "Salvar";
            this.btSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btSalvar.UseVisualStyleBackColor = true;
            this.btSalvar.Click += new System.EventHandler(this.btSalvar_Click);
            // 
            // lbServidor
            // 
            this.lbServidor.AutoSize = true;
            this.lbServidor.Location = new System.Drawing.Point(12, 42);
            this.lbServidor.Name = "lbServidor";
            this.lbServidor.Size = new System.Drawing.Size(46, 13);
            this.lbServidor.TabIndex = 1;
            this.lbServidor.Text = "Servidor";
            // 
            // txtServidor
            // 
            this.txtServidor.Location = new System.Drawing.Point(12, 58);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(156, 20);
            this.txtServidor.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pasta/Arquivo";
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(90, 12);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(223, 20);
            this.txtFolder.TabIndex = 5;
            // 
            // btProcurar
            // 
            this.btProcurar.Image = global::GUI.Properties.Resources.magnifying_glass_2x;
            this.btProcurar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btProcurar.Location = new System.Drawing.Point(319, 6);
            this.btProcurar.Name = "btProcurar";
            this.btProcurar.Size = new System.Drawing.Size(26, 26);
            this.btProcurar.TabIndex = 8;
            this.btProcurar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btProcurar.UseVisualStyleBackColor = true;
            this.btProcurar.Click += new System.EventHandler(this.btProcurar_Click);
            // 
            // frmConfigDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 238);
            this.Controls.Add(this.btTestar);
            this.Controls.Add(this.btProcurar);
            this.Controls.Add(this.btSalvar);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.txtServidor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBancoDeDados);
            this.Controls.Add(this.lbServidor);
            this.Controls.Add(this.lbBancoDeDados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmConfigDatabase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuração do banco de dados";
            this.Load += new System.EventHandler(this.frmConfigDatabase_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbBancoDeDados;
        private System.Windows.Forms.TextBox txtBancoDeDados;
        private System.Windows.Forms.Button btSalvar;
        private System.Windows.Forms.Button btTestar;
        private System.Windows.Forms.Label lbServidor;
        private System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Button btProcurar;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}