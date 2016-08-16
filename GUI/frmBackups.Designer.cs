namespace GUI
{
    partial class frmBackups
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBackups));
            this.pnControles = new System.Windows.Forms.Panel();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btHelp = new System.Windows.Forms.Button();
            this.cbUnidade = new System.Windows.Forms.ComboBox();
            this.cbGrupos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnDados = new System.Windows.Forms.Panel();
            this.pnHelp = new System.Windows.Forms.Panel();
            this.lbTextHelp = new System.Windows.Forms.Label();
            this.lbTituloHelp = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pnControles.SuspendLayout();
            this.pnDados.SuspendLayout();
            this.pnHelp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnControles
            // 
            this.pnControles.Controls.Add(this.comboBox2);
            this.pnControles.Controls.Add(this.comboBox1);
            this.pnControles.Controls.Add(this.btHelp);
            this.pnControles.Controls.Add(this.cbUnidade);
            this.pnControles.Controls.Add(this.cbGrupos);
            this.pnControles.Controls.Add(this.label2);
            this.pnControles.Controls.Add(this.label1);
            this.pnControles.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnControles.Location = new System.Drawing.Point(0, 0);
            this.pnControles.Name = "pnControles";
            this.pnControles.Size = new System.Drawing.Size(414, 100);
            this.pnControles.TabIndex = 0;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(210, 73);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(200, 21);
            this.comboBox2.TabIndex = 9;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 73);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 21);
            this.comboBox1.TabIndex = 8;
            // 
            // btHelp
            // 
            this.btHelp.Image = global::GUI.Properties.Resources.question_mark_2x;
            this.btHelp.Location = new System.Drawing.Point(380, 12);
            this.btHelp.Margin = new System.Windows.Forms.Padding(0);
            this.btHelp.Name = "btHelp";
            this.btHelp.Size = new System.Drawing.Size(24, 24);
            this.btHelp.TabIndex = 7;
            this.btHelp.UseVisualStyleBackColor = true;
            this.btHelp.Click += new System.EventHandler(this.btHelp_Click);
            this.btHelp.MouseHover += new System.EventHandler(this.btHelp_MouseHover);
            // 
            // cbUnidade
            // 
            this.cbUnidade.FormattingEnabled = true;
            this.cbUnidade.Location = new System.Drawing.Point(65, 12);
            this.cbUnidade.Name = "cbUnidade";
            this.cbUnidade.Size = new System.Drawing.Size(68, 21);
            this.cbUnidade.TabIndex = 6;
            // 
            // cbGrupos
            // 
            this.cbGrupos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbGrupos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbGrupos.FormattingEnabled = true;
            this.cbGrupos.Location = new System.Drawing.Point(192, 12);
            this.cbGrupos.Name = "cbGrupos";
            this.cbGrupos.Size = new System.Drawing.Size(121, 21);
            this.cbGrupos.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Grupos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Unidade";
            // 
            // pnDados
            // 
            this.pnDados.Controls.Add(this.pnHelp);
            this.pnDados.Controls.Add(this.dataGridView1);
            this.pnDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnDados.Location = new System.Drawing.Point(0, 100);
            this.pnDados.Name = "pnDados";
            this.pnDados.Size = new System.Drawing.Size(414, 461);
            this.pnDados.TabIndex = 1;
            // 
            // pnHelp
            // 
            this.pnHelp.BackColor = System.Drawing.Color.White;
            this.pnHelp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnHelp.Controls.Add(this.lbTextHelp);
            this.pnHelp.Controls.Add(this.lbTituloHelp);
            this.pnHelp.Location = new System.Drawing.Point(13, 15);
            this.pnHelp.Name = "pnHelp";
            this.pnHelp.Size = new System.Drawing.Size(389, 185);
            this.pnHelp.TabIndex = 7;
            this.pnHelp.Visible = false;
            // 
            // lbTextHelp
            // 
            this.lbTextHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTextHelp.Location = new System.Drawing.Point(24, 49);
            this.lbTextHelp.Name = "lbTextHelp";
            this.lbTextHelp.Size = new System.Drawing.Size(339, 123);
            this.lbTextHelp.TabIndex = 1;
            // 
            // lbTituloHelp
            // 
            this.lbTituloHelp.AutoSize = true;
            this.lbTituloHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTituloHelp.Location = new System.Drawing.Point(20, 16);
            this.lbTituloHelp.Name = "lbTituloHelp";
            this.lbTituloHelp.Size = new System.Drawing.Size(50, 20);
            this.lbTituloHelp.TabIndex = 0;
            this.lbTituloHelp.Text = "Ajuda";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(414, 461);
            this.dataGridView1.TabIndex = 0;
            // 
            // frmBackups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 561);
            this.Controls.Add(this.pnDados);
            this.Controls.Add(this.pnControles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBackups";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backups de produtos";
            this.Load += new System.EventHandler(this.frmBackups_Load);
            this.pnControles.ResumeLayout(false);
            this.pnControles.PerformLayout();
            this.pnDados.ResumeLayout(false);
            this.pnHelp.ResumeLayout(false);
            this.pnHelp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnControles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnDados;
        private System.Windows.Forms.ComboBox cbGrupos;
        private System.Windows.Forms.ComboBox cbUnidade;
        private System.Windows.Forms.Button btHelp;
        private System.Windows.Forms.Panel pnHelp;
        private System.Windows.Forms.Label lbTextHelp;
        private System.Windows.Forms.Label lbTituloHelp;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}